# Documentation Technique - Application GSB2

## Table des matieres
1. Architecture du Projet
2. Structure des Fichiers
3. Modeles de Donnees
4. Couche DAO
5. Formulaires et Interfaces
6. Utilitaires
7. Base de Donnees
8. Securite
9. Guide de Developpement

---

## Architecture du Projet

### Type de Projet
- Framework : .NET 8
- Langage : C# 12.0
- Application : Windows Forms (WinForms)
- Base de donnees : MySQL
- Bibliotheques : MySql.Data, iText 9

### Pattern Architectural
Architecture en 3 couches :

```
PRESENTATION (Forms)
   |
BUSINESS LOGIC (DAO)
|
DATA (Models + Database)
```

### Flux d'Execution

```
Program.Main 
  -> ConnexionForm
  -> MainForm
      -> PatientsForm / MedicinesForm / PrescriptionsForm
```

---

## Structure des Fichiers

```
GSB2/
|
??? Forms/
|   ??? ConnexionForm.cs
|   ??? RegisterForm.cs
|   ??? MainForm.cs
|   ??? PatientsForm.cs
|   ??? MedicinesForm.cs
|   ??? PrescriptionsForm.cs
|
??? DAO/
|   ??? Database.cs
|   ??? UserDAO.cs
|   ??? PatientDAO.cs
|   ??? MedicineDAO.cs
|??? PrescriptionDAO.cs
|   ??? LiaiMPDAO.cs
|
??? Models/
|   ??? Users.cs
|   ??? Patients.cs
|   ??? Medicine.cs
|   ??? Prescription.cs
|   ??? LiaiMP.cs
|
??? Utils/
|   ??? PdfExporter.cs
|
??? Program.cs
```

---

## Modeles de Donnees

### 1. Users.cs

```csharp
public class Users
{
    public int Id_Users { get; set; }
 public string Firstname { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Role { get; set; }  // True = Admin, False = Medecin
    
    public Users(int id_Users, string firstname, string name, 
        string email, bool role)
}
```

### 2. Patients.cs

```csharp
public class Patients
{
    public int Id_Patients { get; set; }
    public int Id_Users { get; set; }  // FK vers Users
    public string Name { get; set; }
    public string Firstname { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
}
```

### 3. Medicine.cs

```csharp
public class Medicine
{
    public int Id_Medicine { get; set; }
    public int Id_Users { get; set; }  // FK vers Users
    public string Dosage { get; set; }
    public string Names { get; set; }
  public string Description { get; set; }
 public string Molecule { get; set; }
}
```

### 4. Prescription.cs

```csharp
public class Prescription
{
    public int Id_prescription { get; set; }
    public int Id_users { get; set; }      // FK vers Users
    public int Id_patients { get; set; }   // FK vers Patients
    public string Validity { get; set; }   // Date format: yyyy-MM-dd
}
```

### 5. LiaiMP.cs

```csharp
public class LiaiMP
{
    public int Id_medicine { get; set; }       // FK vers Medicine
    public int Id_prescription { get; set; }   // FK vers Prescription
    public int Quantity { get; set; }
}
```

---

## Couche DAO

### 1. Database.cs

```csharp
public class Database
{
    private string connectionString = 
        "Server=localhost;Database=gsb;Uid=root;Pwd=;";
    
    public MySqlConnection GetConnection()
}
```

### 2. UserDAO.cs

#### Methodes principales

**GetUsers(email, password)** - Authentification
```csharp
// SB: Authentifie avec hachage SHA-256 cote SQL
SELECT id_users, firstname, name, email, role 
FROM users 
WHERE email = @email AND password = SHA2(@password, 256);
```

**Register(email, password, name, firstname)** - Inscription
```csharp
// SB: Cree compte avec role Medecin par defaut
// Verifie unicite email
// Hash SHA-256 du mot de passe
```

**CreateUser(...)** - Creation Admin
```csharp
// SB: Admin peut creer utilisateur avec role specifique
```

**UpdateUser(Users user)** - Mise a jour
```csharp
// SB: Met a jour infos (sauf mot de passe)
UPDATE users SET name=@Name, firstname=@Firstname, 
email=@Email, role=@Role WHERE id_users=@Id;
```

**DeleteUser(int userId)** - Suppression
```csharp
// SB: Supprime utilisateur
DELETE FROM users WHERE id_users = @Id;
```

**GetAllUsers()** - Liste complete
```csharp
// SB: Retourne tous utilisateurs
```

### 3. PatientDAO.cs

#### Methodes principales

**GetAllPatients()** - Liste avec jointure
```csharp
// SB: Recupere patients avec nom medecin referent
SELECT p.*, u.firstname, u.name 
FROM Patients p
INNER JOIN users u ON p.id_users = u.id_users;
```

**Insert(Patients patient)** - Creation
```csharp
// SB: Insere patient lie a utilisateur connecte
```

**DeletePatient(int id)** - Suppression
```csharp
// SB: Supprime patient
```

**GetPatientsForComboBox()** - Pour listes deroulantes
```csharp
// SB: Retourne Id, Name, Firstname pour ComboBox
```

**GetPatientById(int id)** - Recuperation unitaire
```csharp
// SB: Retourne patient specifique
```

### 4. MedicineDAO.cs

#### Methodes principales

**GetAll()** - Liste avec jointure
```csharp
// SB: Recupere medicaments avec nom utilisateur createur
SELECT m.*, u.firstname, u.name
FROM Medicine m
INNER JOIN users u ON m.id_users = u.id_users;
```

**GetById(int id)** - Recuperation unitaire
```csharp
// SB: Retourne medicament avec null-safety
```

**Insert(Medicine med)** - Creation
```csharp
// SB: Insere medicament lie a utilisateur
```

**Delete(int id)** - Suppression
```csharp
// SB: Supprime medicament
```

**GetAllMedicines()** - Pour ComboBox
```csharp
// SB: Retourne Id, Names pour selections
```

### 5. PrescriptionDAO.cs

#### Methodes principales

**GetAllPrescriptions()** - Liste complete
```csharp
// SB: Recupere prescriptions avec noms patients et medecins
SELECT pr.*, 
CONCAT(p.name, ' ', p.firstname) AS patient_name,
CONCAT(u.name, ' ', u.firstname) AS doctor_name
FROM Prescription pr
INNER JOIN Patients p ON pr.id_patients = p.id_patients
INNER JOIN users u ON pr.id_users = u.id_users;
```

**CreatePrescriptionWithMedicines(...)** - Creation complete
```csharp
// SB: Cree prescription + medicaments/quantites
// 1. Insert prescription
// 2. Recupere LAST_INSERT_ID
// 3. Insert liens LiaiMP
```

**UpdatePrescription(...)** - Mise a jour
```csharp
// SB: Met a jour prescription et medicaments
// 1. Delete anciens liens LiaiMP
// 2. Update date validite
// 3. Insert nouveaux liens
```

**GetMedicinesWithQuantities(int idPrescription)** - Medicaments prescription
```csharp
// SB: Retourne liste (Id_medicine, Quantity)
SELECT id_medicine, quantity 
FROM LiaiMP 
WHERE id_prescription = @id;
```

**DeletePrescription(int id)** - Suppression
```csharp
// SB: Supprime prescription et liens
```

**GetPrescriptionById(int id)** - Recuperation unitaire
```csharp
// SB: Retourne prescription specifique
```

---

## Formulaires et Interfaces

### 1. ConnexionForm.cs

**Responsabilites**
- Authentification utilisateur
- Redirection vers MainForm
- Acces inscription

**Composants UI**
- textBoxEmail
- textBoxMdp (PasswordChar = '*')
- buttonConnexion
- buttonRedirCreat

**Methodes cles**

```csharp
// SB: Constructeur - teste connexion BD au demarrage
public ConnexionForm()

// SB: Gere authentification utilisateur
private void buttonConnexion_Click(sender, e)

// SB: Redirige vers inscription
private void buttonRedirCreat_Click(sender, e)
```

### 2. RegisterForm.cs

**Responsabilites**
- Creation compte utilisateur
- Validation champs
- Verification unicite email

**Composants UI**
- txtName, txtFirstname, txtEmail, txtPassword
- buttonCreateAccount

**Methodes cles**

```csharp
// SB: Constructeur
public RegisterForm()

// SB: Valide et cree compte
private void buttonCreateAccount_Click(sender, e)
```

### 3. MainForm.cs

**Responsabilites**
- Affichage infos utilisateur
- Navigation modules
- Gestion utilisateurs (admins)

**Composants UI**
- Firstname_label, Role_label, Email_label
- dgvUsers (visible si admin)
- txtNom, txtPrenom, txtEmail, txtPassword, chkRole
- BtnNewUser, BtnSaveUser, BtnDeleteUser
- BtnPatients, BtnMedicines, BtnPrescriptions
- Logout_button

**Methodes cles**

```csharp
// SB: Constructeur - charge donnees utilisateur
public MainForm(Users user)

// SB: Affiche infos et adapte interface selon role
private void LoadUserData()

// SB: Charge liste utilisateurs (si admin)
private void dvgUsersLoadContent()

// SB: Remplit champs lors selection ligne
private void DgvUsers_SelectionChanged(sender, e)

// SB: Reinitialise pour nouveau
private void BtnNewUser_Click(sender, e)

// SB: Cree ou met a jour utilisateur
private void BtnSaveUser_Click(sender, e)

// SB: Supprime utilisateur
private void BtnDeleteUser_Click(sender, e)

// SB: Deconnexion
private void Logout_button_Click(sender, e)

// SB: Navigation vers modules
private void BtnPatients_Click(sender, e)
private void BtnPrescriptions_Click(sender, e)
private void BtnMedicines_Click(sender, e)
```

### 4. PatientsForm.cs

**Responsabilites**
- Affichage patients
- Ajout patients
- Suppression patients

**Pattern** : Toggle groupBoxAdd

**Methodes cles**

```csharp
// SB: Constructeur - charge patients
public PatientsForm(Users user)

// SB: Charge liste avec medecin referent
private void LoadPatients()

// SB: Recharge liste
private void BtnRefresh_Click(sender, e)

// SB: Toggle panel ajout
private void BtnAdd_Click(sender, e)

// SB: Cree patient lie a utilisateur connecte
private void BtnSave_Click(sender, e)

// SB: Supprime patient
private void BtnDelete_Click(sender, e)

// SB: Reinitialise champs
private void ClearFields()

// SB: Retour menu
private void btnBackToMain_Click(sender, e)
```

### 5. MedicinesForm.cs

Structure identique a PatientsForm

**Methodes cles**

```csharp
// SB: Constructeur
public MedicinesForm(Users user)

// SB: Charge medicaments avec utilisateur createur
private void LoadMedicines()

// SB: Autres methodes similaires a PatientsForm
```

### 6. PrescriptionsForm.cs

**FORMULAIRE LE PLUS COMPLEXE**

**Responsabilites**
- Creation/modification prescriptions
- Selection patient
- Selection medicaments avec quantites
- Export PDF

**Composants UI**
- dgvPrescriptions (liste principale)
- cmbPatients (ComboBox)
- dtpValidity (DateTimePicker)
- dgvMedicines (grille avec checkboxes et quantites)
- BtnRefresh, BtnAdd, BtnSave, BtnDelete, BtnExportPdf

**Methodes cles**

```csharp
// SB: Constructeur - charge patients, medicaments, prescriptions
public PrescriptionsForm(Users user)

// SB: Remplit ComboBox patients
private void LoadPatients()

// SB: Remplit grille medicaments avec checkboxes
private void LoadMedicinesGrid()

// SB: Charge liste prescriptions
private void LoadPrescriptions()

// SB: Recharge liste
private void BtnRefresh_Click(sender, e)

// SB: Prepare nouvelle prescription
private void BtnAdd_Click(sender, e)

// SB: Charge prescription pour modification
private void DgvPrescriptions_CellClick(sender, e)

// SB: Enregistre (creation ou modification)
private void BtnSave_Click(sender, e)
// - Valide patient selectionne
// - Parcourt grille medicaments
// - Valide quantites (entier > 0)
// - Cree ou met a jour

// SB: Supprime prescription
private void BtnDelete_Click(sender, e)

// SB: Genere PDF ordonnance
private void BtnExportPdf_Click(sender, e)

// SB: Reinitialise champs
private void ClearFields()

// SB: Retour menu
private void btnBackToMain_Click(sender, e)
```

---

## Utilitaires

### PdfExporter.cs

**Bibliotheque** : iText 9

**Methode principale**

```csharp
// SB: Genere PDF ordonnance avec gestion NULL
public static void ExportPrescription(
    Prescription presc,
    Patients patient,
    Users doctor,
    List<(Medicine med, int quantity)> meds)
{
    // 1. SaveFileDialog
    // 2. Parser date (TryParse)
    // 3. Creer document PDF
    //    - Titre
    //    - Info patient (null-safe)
    //    - Info medecin (null-safe)
    //    - Table medicaments
    //    - Espace signature
    // 4. Ouvrir fichier genere
}
```

**Gestion erreurs** :
- Try-catch global
- Null-safety tous champs
- Validation date avec TryParse

---

## Base de Donnees

### Structure des Tables

**Table users**
```sql
CREATE TABLE users (
    id_users INT AUTO_INCREMENT PRIMARY KEY,
    firstname VARCHAR(100) NOT NULL,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(64) NOT NULL,  -- SHA-256
    role BOOLEAN NOT NULL DEFAULT FALSE
);
```

**Table Patients**
```sql
CREATE TABLE Patients (
    id_patients INT AUTO_INCREMENT PRIMARY KEY,
    id_users INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    firstname VARCHAR(100) NOT NULL,
    age INT NOT NULL,
    gender VARCHAR(20) NOT NULL,
    FOREIGN KEY (id_users) REFERENCES users(id_users) ON DELETE CASCADE
);
```

**Table Medicine**
```sql
CREATE TABLE Medicine (
    id_medicine INT AUTO_INCREMENT PRIMARY KEY,
    id_users INT NOT NULL,
    dosage VARCHAR(50),
    names VARCHAR(255) NOT NULL,
    description TEXT,
    molecule VARCHAR(255),
    FOREIGN KEY (id_users) REFERENCES users(id_users) ON DELETE CASCADE
);
```

**Table Prescription**
```sql
CREATE TABLE Prescription (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_users INT NOT NULL,
  id_patients INT NOT NULL,
    validity DATE NOT NULL,
    FOREIGN KEY (id_users) REFERENCES users(id_users) ON DELETE CASCADE,
    FOREIGN KEY (id_patients) REFERENCES Patients(id_patients) ON DELETE CASCADE
);
```

**Table LiaiMP**
```sql
CREATE TABLE LiaiMP (
    id_medicine INT NOT NULL,
    id_prescription INT NOT NULL,
    quantity INT NOT NULL,
    PRIMARY KEY (id_medicine, id_prescription),
    FOREIGN KEY (id_medicine) REFERENCES Medicine(id_medicine) ON DELETE CASCADE,
    FOREIGN KEY (id_prescription) REFERENCES Prescription(id) ON DELETE CASCADE
);
```

### Relations

```
users (1) ---< (N) Patients
users (1) ---< (N) Medicine
users (1) ---< (N) Prescription

Patients (1) ---< (N) Prescription

Prescription (N) ---< (N) Medicine  [via LiaiMP]
```

---

## Securite

### 1. Hachage Mots de Passe

**Cote SQL** :
```sql
-- Insertion
INSERT INTO users (email, password, name, firstname, role)
VALUES (@Email, SHA2(@Password, 256), @Name, @Firstname, @Role);

-- Verification
SELECT ... FROM users 
WHERE email = @email AND password = SHA2(@password, 256);
```

- Jamais stockes en clair
- SHA-256 (64 caracteres hex)
- Hachage cote SQL

### 2. Prevention Injections SQL

**Bonnes pratiques** :
```csharp
MySqlCommand cmd = new MySqlCommand(query, connection);
cmd.Parameters.AddWithValue("@email", email);
cmd.Parameters.AddWithValue("@password", password);
```

Toutes requetes utilisent parametres prepares

### 3. Controle Acces

```csharp
if (connectedUser.Role)
{
    dgvUsers.Visible = true;
    btnDeleteUser.Visible = true;
}
```

### 4. Validation Donnees

- Champs obligatoires
- Quantites validees (> 0, entier)
- Emails uniques
- Dates avec TryParse

---

## Guide de Developpement

### Ajouter un Nouveau Modele

1. Creer classe dans Models/
2. Creer DAO dans DAO/
3. Creer formulaire dans Forms/
4. Ajouter navigation dans MainForm

### Bonnes Pratiques

**1. Utiliser using pour connexions**
```csharp
using (var connection = db.GetConnection())
{
    connection.Open();
    // Operations SQL
}
```

**2. Gestion erreurs**
```csharp
try
{
    // Operation BD
}
catch (Exception ex)
{
    MessageBox.Show($"Erreur : {ex.Message}");
    return false;
}
```

**3. Null-safety**
```csharp
string value = row["column"]?.ToString() ?? "Defaut";
```

**4. Commentaires SB**
```csharp
// SB: Description methode
private void MyMethod() { }
```

### Conventions Nommage

- Classes : PascalCase
- Methodes : PascalCase
- Variables : camelCase
- Controles UI : Prefixe + PascalCase

### Tests Recommandes

1. Tests connexion
2. Tests CRUD
3. Tests validation
4. Tests roles

### Ameliorations Futures

1. Transactions explicites
2. Logging structure
3. Configuration externalisee
4. Hash cote C#
5. Unit Tests
6. Validation FluentValidation

---

## Notes Techniques

### Dependances NuGet
- MySql.Data
- iText 9.x

### Configuration Requise
- .NET SDK 8.0
- MySQL Server
- Visual Studio 2022

### Points Attention

1. Connexion String a adapter
2. Performances jointures
3. Securite mots de passe
4. Transactions multi-tables

---

**Version** : 1.0  
**Date** : 2024
**Auteur** : SB (Safwane Bada)

Documentation technique pour developpeurs
