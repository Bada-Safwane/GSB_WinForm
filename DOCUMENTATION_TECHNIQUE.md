# Documentation Technique - GSB2

## Table des Matieres

1. [Vue d'ensemble](#1-vue-densemble)
2. [Architecture du projet](#2-architecture-du-projet)
3. [Modele de donnees](#3-modele-de-donnees)
4. [Couche DAO (Data Access Objects)](#4-couche-dao-data-access-objects)
5. [Couche Modeles](#5-couche-modeles)
6. [Couche Interface Utilisateur](#6-couche-interface-utilisateur)
7. [Utilitaires](#7-utilitaires)
8. [Securite](#8-securite)
9. [Diagrammes](#9-diagrammes)
10. [Guide de developpement](#10-guide-de-developpement)

---

## 1. Vue d'ensemble

### 1.1 Description du projet

GSB2 est une application de bureau Windows Forms developpee en C# avec .NET 8.0. Elle est concue pour la gestion medicale dans un contexte professionnel, permettant la gestion des :

- **Utilisateurs** (medecins et administrateurs)
- **Patients** 
- **Medicaments**
- **Prescriptions/Ordonnances**

### 1.2 Stack technique

| Composant | Technologie | Version |
|-----------|-------------|---------|
| Framework | .NET | 8.0 |
| Interface | Windows Forms | - |
| Base de donnees | MySQL | 8.0+ |
| ORM/Acces donnees | MySql.Data (ADO.NET) | 9.5.0 |
| Export PDF | iText | 9.4.0 |
| Cryptographie PDF | itext.bouncy-castle-adapter | 9.4.0 |

### 1.3 Configuration du projet

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="itext" Version="9.4.0" />
    <PackageReference Include="itext.bouncy-castle-adapter" Version="9.4.0" />
    <PackageReference Include="MySql.Data" Version="9.5.0" />
  </ItemGroup>
</Project>
```

---

## 2. Architecture du projet

### 2.1 Pattern architectural

Le projet suit une architecture **3-tiers** simplifiee :

```
+-----------------------------------------------+
|          COUCHE PRESENTATION            |
|  (Windows Forms)  |
| +-------------------------------------------+ |
| | ConnexionForm | MainForm    | PatientsForm| |
| | RegisterForm  |             | MedicinesForm| |
| |        |  | PrescriptionsForm| |
| +-------------------------------------------+ |
+-----------------------------------------------+
          |
    v
+-----------------------------------------------+
|         COUCHE METIER       |
|   (Models)       |
| +-------------------------------------------+ |
| | Users | Patients | Medicine | Prescription | LiaiMP | |
| +-------------------------------------------+ |
+-----------------------------------------------+
       |
          v
+-----------------------------------------------+
|         COUCHE ACCES DONNEES         |
|   (DAO)             |
| +-------------------------------------------+ |
| | UserDAO | PatientDAO | MedicineDAO |  | |
| | PrescriptionDAO | LiaiMPDAO |             | |
| +-------------------------------------------+ |
|         | |
|        +----------+           |
|              | Database |         |
|      +----------+          |
+-----------------------------------------------+
          |
 v
       +----------+
       |  MySQL   |
        | Database |
      +----------+
```

### 2.2 Structure des dossiers

```
GSB2/
+-- DAO/    # Data Access Objects
|   +-- Database.cs         # Singleton de connexion
|   +-- UserDAO.cs          # CRUD Utilisateurs
|   +-- PatientDAO.cs    # CRUD Patients
|   +-- MedicineDAO.cs      # CRUD Medicaments
|   +-- PrescriptionDAO.cs  # CRUD Prescriptions
|   +-- LiaiMPDAO.cs     # CRUD Liaison Med-Presc
|
+-- Models/      # Entites metier
|   +-- Users.cs
|   +-- Patients.cs
|   +-- Medicine.cs
|   +-- Prescription.cs
|   +-- LiaiMP.cs
|
+-- Forms/     # Interface utilisateur
|   +-- ConnexionForm.cs    # Login
|+-- RegisterForm.cs     # Inscription
|   +-- MainForm.cs  # Dashboard
|   +-- PatientsForm.cs     # Gestion patients
|   +-- MedicinesForm.cs    # Gestion medicaments
|   +-- PrescriptionsForm.cs# Gestion ordonnances
|
+-- Utils/        # Utilitaires
|   +-- PdfExporter.cs      # Export PDF
|
+-- Program.cs   # Point d'entree
```

---

## 3. Modele de donnees

### 3.1 Diagramme Entite-Relation (MCD)

```
+---------------+         +---------------+         +---------------+
|    USERS      |       |   PATIENTS    |   |   MEDICINE    |
+---------------+         +---------------+         +---------------+
| id_users PK   |----+    | id_patients   |    +----| id_medicine   |
| name   |    |    | PK   |    |    |   PK          |
| firstname|    +----| id_users FK |    |    | id_users FK   |----+
| email    |         | name  |    |    | names         |    |
| password      | | firstname     |    |    | dosage |    |
| role          |         | age        |  |    | description   |    |
+---------------+         | gender        |    |    | molecule      |    |
        |          +---------------+    |    +---------------+    |
   |           |      |           |       |
      |              |          | |      |
        |    +-------------------+-------------+           |  |
        |    |         PRESCRIPTION|           |        |
        |    +-----------------------------+   |         |        |
    |    | id_prescription PK          |   |           |        |
        +----| id_users FK                 |   |           |        |
             | id_patients FK  |---+    | |
             | validity      |       |      |
             +-----------------------------+   |       |
             |     | |
         |       |      |
   +-----------------------------+|             |
             | LIAI_MEDICINE_PRESCRIPTION  |     |       |
         +-----------------------------+               |       |
     | id_prescrition FK PK        |   |             |
     | id_medicine FK PK           |---------------+   |
  | quantity        |    |
        +-----------------------------+    |
          |
           +-----------------------------+
```

### 3.2 Description des tables

#### Table `users`
| Colonne | Type | Contraintes | Description |
|---------|------|-------------|-------------|
| id_users | INT | PK, AUTO_INCREMENT | Identifiant unique |
| name | VARCHAR(100) | NOT NULL | Nom de famille |
| firstname | VARCHAR(100) | NOT NULL | Prenom |
| email | VARCHAR(150) | UNIQUE, NOT NULL | Adresse email |
| password | VARCHAR(64) | NOT NULL | Mot de passe hashe SHA-256 |
| role | BOOLEAN | DEFAULT FALSE | FALSE=Medecin, TRUE=Admin |

#### Table `patients`
| Colonne | Type | Contraintes | Description |
|---------|------|-------------|-------------|
| id_patients | INT | PK, AUTO_INCREMENT | Identifiant unique |
| id_users | INT | FK -> users | Medecin referent |
| name | VARCHAR(100) | NOT NULL | Nom du patient |
| firstname | VARCHAR(100) | NOT NULL | Prenom du patient |
| age | INT | NOT NULL | Age du patient |
| gender | VARCHAR(20) | NOT NULL | Genre du patient |

#### Table `medicine`
| Colonne | Type | Contraintes | Description |
|---------|------|-------------|-------------|
| id_medicine | INT | PK, AUTO_INCREMENT | Identifiant unique |
| id_users | INT | FK -> users | Utilisateur createur |
| names | VARCHAR(150) | NOT NULL | Nom du medicament |
| dosage | VARCHAR(100) | - | Dosage (ex: 500mg) |
| description | TEXT | - | Description detaillee |
| molecule | VARCHAR(150) | - | Molecule active |

#### Table `prescription`
| Colonne | Type | Contraintes | Description |
|---------|------|-------------|-------------|
| id_prescription | INT | PK, AUTO_INCREMENT | Identifiant unique |
| id_users | INT | FK -> users | Medecin prescripteur |
| id_patients | INT | FK -> patients | Patient concerne |
| validity | DATE | NOT NULL | Date de validite |

#### Table `liai_medicine_prescription`
| Colonne | Type | Contraintes | Description |
|---------|------|-------------|-------------|
| id_prescrition | INT | PK, FK -> prescription | ID prescription |
| id_medicine | INT | PK, FK -> medicine | ID medicament |
| quantity | INT | DEFAULT 1 | Quantite prescrite |

---

## 4. Couche DAO (Data Access Objects)

### 4.1 Classe Database

Gere la connexion a la base de donnees MySQL.

```csharp
public class Database
{
    private readonly string myConnectionString = 
        "server=localhost;uid=root;pwd=root;database=bd_gsb";

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(myConnectionString);
}
}
```

**Configuration** : Modifier la chaine de connexion selon l'environnement.

### 4.2 UserDAO

Gestion des operations CRUD pour les utilisateurs.

| Methode | Parametres | Retour | Description |
|---------|------------|--------|-------------|
| `GetUsers` | email, password | `Users?` | Authentification utilisateur |
| `Register` | email, password, name, firstname | `bool` | Inscription utilisateur |
| `CreateUser` | email, password, name, firstname, role | `bool` | Creation par admin |
| `GetAllUsers` | - | `List<Users>` | Liste tous les utilisateurs |
| `UpdateUser` | Users | `bool` | Mise a jour utilisateur |
| `DeleteUser` | userId | `bool` | Suppression utilisateur |

**Exemple d'utilisation :**
```csharp
var userDao = new UserDAO();
Users user = userDao.GetUsers("email@example.com", "password123");
if (user != null)
{
  // Utilisateur authentifie
}
```

### 4.3 PatientDAO

| Methode | Parametres | Retour | Description |
|---------|------------|--------|-------------|
| `GetPatientById` | id_patient | `Patients?` | Recupere un patient |
| `CreatePatient` | id_users, name, age, firstname, gender | `bool` | Cree un patient |
| `Insert` | Patients | `bool` | Insere un patient |
| `GetAllPatients` | - | `List<dynamic>` | Liste avec infos medecin |
| `GetPatientsForComboBox` | - | `List<Patients>` | Pour ComboBox |
| `UpdatePatient` | Patients | `bool` | Mise a jour |
| `DeletePatient` | id_patient | `bool` | Suppression |

### 4.4 MedicineDAO

| Methode | Parametres | Retour | Description |
|---------|------------|--------|-------------|
| `GetAll` | - | `List<dynamic>` | Liste avec utilisateur |
| `GetAllMedicines` | - | `List<Medicine>` | Liste simple |
| `GetById` | id | `Medicine?` | Recupere par ID |
| `Insert` | Medicine | `bool` | Ajoute medicament |
| `Update` | Medicine | `bool` | Mise a jour |
| `Delete` | id | `bool` | Suppression |

### 4.5 PrescriptionDAO

| Methode | Parametres | Retour | Description |
|---------|------------|--------|-------------|
| `GetPrescriptionById` | id_prescription | `Prescription?` | Recupere prescription |
| `CreatePrescription` | Prescription | `bool` | Creation simple |
| `CreatePrescriptionWithMedicines` | Prescription, List<(int, int)> | `bool` | Creation avec medicaments |
| `GetAllPrescriptions` | - | `List<dynamic>` | Liste complete |
| `GetMedicinesWithQuantities` | id_prescription | `List<(int, int)>` | Medicaments d'une prescription |
| `UpdatePrescription` | id, validity, medicines | `bool` | Mise a jour complete |
| `DeletePrescription` | id_prescription | `bool` | Suppression avec cascade |

**Note** : Les operations de creation/mise a jour/suppression utilisent des **transactions** pour garantir l'integrite des donnees.

### 4.6 LiaiMPDAO

Gere la table de liaison medicaments-prescriptions.

| Methode | Parametres | Retour | Description |
|---------|------------|--------|-------------|
| `GetAll` | - | `List<LiaiMP>` | Toutes les liaisons |
| `GetByPrescriptionId` | id_prescription | `List<LiaiMP>` | Medicaments d'une prescription |
| `GetByMedicineId` | id_medicine | `List<LiaiMP>` | Prescriptions d'un medicament |
| `Insert` | LiaiMP | `bool` | Ajoute une liaison |
| `Delete` | id_prescription, id_medicine | `bool` | Supprime une liaison |
| `DeleteByPrescriptionId` | id_prescription | `bool` | Supprime toutes les liaisons |

---

## 5. Couche Modeles

### 5.1 Classe Users

```csharp
public class Users
{
    public int Id_Users { get; set; }
    public string Firstname { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Role { get; set; }  // false = Medecin, true = Admin
}
```

### 5.2 Classe Patients

```csharp
public class Patients
{
    public int Id_Patients { get; set; }
    public int Id_Users { get; set; }      // FK vers medecin referent
    public string Name { get; set; }
    public int Age { get; set; }
    public string Firstname { get; set; }
    public string Gender { get; set; }
}
```

### 5.3 Classe Medicine

```csharp
public class Medicine
{
    public int Id_Medicine { get; set; }
    public int Id_Users { get; set; }      // FK vers createur
    public string Dosage { get; set; }
    public string Names { get; set; }
    public string Description { get; set; }
 public string Molecule { get; set; }
}
```

### 5.4 Classe Prescription

```csharp
public class Prescription
{
    public int Id_prescription { get; set; }
 public int Id_users { get; set; }       // FK vers medecin
    public int Id_patients { get; set; }    // FK vers patient
    public string Validity { get; set; }    // Date de validite
}
```

### 5.5 Classe LiaiMP

```csharp
public class LiaiMP
{
    public int Id_medicine { get; set; }
    public int Id_prescription { get; set; }
  public int Quantity { get; set; }
}
```

---

## 6. Couche Interface Utilisateur

### 6.1 Flux de navigation

```
+------------------+
|  ConnexionForm   |---------------------------+
|  (Login)         |          |
+------------------+  |
        | |
    +---+---+    |
    |       |    |
 v       v   |
+--------+ +-----------+      |
|Register| | MainForm  |---------------------->|
|  Form  | | (Dashboard)| |
+--------+ +-----------+        |
              |    |
    +-----------+-----------+  |
    |     | |         |
    v         v           v |
+----------+ +----------+ +---------------+    |
| Patients | | Medicines| | Prescriptions |    |
|   Form   | |   Form   | |     Form      ||
+----------+ +----------+ +---------------+    |
        |
       [Deconnexion] ---------+
```

### 6.2 ConnexionForm

**Responsabilites :**
- Authentification des utilisateurs
- Redirection vers MainForm si succes
- Lien vers RegisterForm pour inscription

**Evenements principaux :**
- `buttonConnexion_Click` : Verifie les identifiants
- `buttonRedirCreat_Click` : Ouvre le formulaire d'inscription

### 6.3 MainForm

**Responsabilites :**
- Dashboard principal apres connexion
- Affichage des informations utilisateur
- Navigation vers les autres modules
- Gestion des utilisateurs (admin uniquement)

**Composants :**
- `dgvUsers` : DataGridView liste des utilisateurs (admin)
- Champs d'edition : nom, prenom, email, role
- Boutons de navigation : Patients, Medicaments, Prescriptions

**Fonctionnalites conditionnelles :**
```csharp
// Bouton suppression visible uniquement pour les admins
btnDeleteUser.Visible = connectedUser.Role;

// DataGridView visible uniquement pour les admins
if (connectedUser.Role)
{
    dgvUsers.Visible = true;
    dgvUsers.DataSource = Users.GetAllUsers();
}
```

### 6.4 PatientsForm, MedicinesForm, PrescriptionsForm

Structure commune :
- DataGridView pour afficher les donnees
- Formulaire de saisie/modification
- Boutons CRUD (Nouveau, Enregistrer, Supprimer)
- Bouton Retour vers MainForm

---

## 7. Utilitaires

### 7.1 PdfExporter

Classe statique pour l'export des ordonnances au format PDF.

**Signature :**
```csharp
public static void ExportPrescription(
    Prescription presc,
    Patients patient,
    Users doctor,
    List<(Medicine med, int quantity)> meds)
```

**Fonctionnalites :**
- Dialogue de sauvegarde avec nom par defaut
- Generation PDF avec iText 9
- Informations patient/medecin/date
- Tableau des medicaments avec quantites
- Zone de signature
- Ouverture automatique du PDF genere

**Dependances NuGet :**
- `iText` (9.4.0)
- `itext.bouncy-castle-adapter` (9.4.0)

---

## 8. Securite

### 8.1 Hashage des mots de passe

Les mots de passe sont hashes en **SHA-256** cote base de donnees :

```sql
-- Insertion
INSERT INTO users (password) VALUES (SHA2(@password, 256));

-- Verification
SELECT * FROM users WHERE password = SHA2(@password, 256);
```

### 8.2 Protection contre les injections SQL

Utilisation systematique de **requetes parametrees** :

```csharp
MySqlCommand cmd = new MySqlCommand(
    "SELECT * FROM users WHERE email = @email", connection);
cmd.Parameters.AddWithValue("@email", email);
```

### 8.3 Gestion des roles

| Role | Valeur | Permissions |
|------|--------|-------------|
| Medecin | `false` | Patients, Medicaments, Prescriptions |
| Administrateur | `true` | Tout + Gestion utilisateurs |

---

## 9. Diagrammes

### 9.1 Diagramme de classes simplifie

```
+-----------------------------------------------------+
|       <<DAO>>                 |
+-----------------------------------------------------+
| +----------+ +------------+ +-------------+ +------+|
| | UserDAO  | | PatientDAO | | MedicineDAO | |Presc-||
| |          | |        | |        | |DAO   ||
| +----------+ +------------+ +-------------+ +------+|
|      ||       | |     |
|      +------------+--------------+------------+ |
|  |   |
|               +----------+        |
|        | Database |        |
|       +----------+        |
+-----------------------------------------------------+
      |
           v
+-----------------------------------------------------+
|                   <<Models>>         |
+-----------------------------------------------------+
| +---------+ +----------+ +-----------+ +-----------+|
| |  Users  | | Patients | | Medicine  | |Prescription||
| +---------+ +----------+ +-----------+ +-----------+|
|      |        |
|    +---------+   |
|             | LiaiMP  |  |
|      +---------+  |
+-----------------------------------------------------+
```

### 9.2 Diagramme de sequence - Authentification

```
+---------+       +---------------+       +---------+       +--------+
|  User   |       | ConnexionForm |       | UserDAO |       | MySQL  |
+---------+       +---------------+       +---------+ +--------+
     |       |     |            |
     | Saisie email/mdp   |               |   |
     |------------------->|                 |     |
     |      |       |   |
     |          | GetUsers(email,pw) |         |
     |            |------------------->|        |
     |         |         |        |
     ||            | SELECT avec     |
     |         |   | SHA2(password)  |
     |  |           |---------------->|
     ||       |      |
     |           |       |<----------------|
     |        |  |   ResultSet     |
     |     |<-------------------|   |
   |     |    Users object    |      |
     |           |          |         |
     |    Redirection     |        |      |
     |  vers MainForm     |    |     |
     |<-------------------|      |    |
     |      |         |        |
```


---

## 10. Guide de developpement

### 10.1 Ajouter une nouvelle entite

1. **Creer le modele** dans `Models/`
2. **Creer le DAO** dans `DAO/`
3. **Creer le formulaire** dans `Forms/`
4. **Ajouter la navigation** depuis `MainForm`

### 10.2 Conventions de nommage

| Element | Convention | Exemple |
|---------|------------|---------|
| Classes | PascalCase | `UserDAO`, `PatientDAO` |
| Methodes | PascalCase | `GetAllUsers()` |
| Variables | camelCase | `connectedUser` |
| Proprietes | PascalCase | `Id_Users` |
| Controles Forms | prefixe + nom | `btnSave`, `txtEmail`, `dgvUsers` |

### 10.3 Gestion des erreurs

Pattern utilise dans les DAO :

```csharp
try
{
    connection.Open();
    // ... operations
}
catch (Exception ex)
{
    MessageBox.Show($"Erreur : {ex.Message}");
 return false; // ou null
}
```

### 10.4 Tests

Pour tester l'application :

1. Creer un utilisateur admin via script SQL :
```sql
INSERT INTO users (name, firstname, email, password, role) 
VALUES ('Admin', 'Test', 'admin@test.com', SHA2('admin123', 256), TRUE);
```

2. Se connecter avec ces identifiants
3. Creer des donnees de test via l'interface

---

## Changelog

| Version | Date | Description |
|---------|------|-------------|
| 1.0.0 | 2024 | Version initiale |

---

## References

- [Documentation .NET 8.0](https://learn.microsoft.com/dotnet/)
- [MySQL Connector/NET](https://dev.mysql.com/doc/connector-net/en/)
- [iText 9 Documentation](https://kb.itextpdf.com/)
- [Windows Forms Documentation](https://learn.microsoft.com/dotnet/desktop/winforms/)
