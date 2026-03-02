# GSB2 - Application de Gestion Médicale

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)

## ?? Description

**GSB2** est une application de gestion médicale développée en **C# Windows Forms** (.NET 8.0). Elle permet aux professionnels de santé (médecins et administrateurs) de gérer les patients, les médicaments et les prescriptions médicales.

L'application offre également la possibilité d'**exporter les ordonnances au format PDF** pour une utilisation professionnelle.

---

## ? Fonctionnalités

### ?? Authentification
- Connexion sécurisée avec email et mot de passe (hashage SHA-256)
- Création de compte utilisateur
- Gestion des rôles (Médecin / Administrateur)

### ?? Gestion des Utilisateurs (Admin)
- Visualiser la liste des utilisateurs
- Créer, modifier et supprimer des utilisateurs
- Attribution des rôles (médecin ou administrateur)

### ?? Gestion des Patients
- Ajouter de nouveaux patients
- Modifier les informations des patients
- Supprimer des patients
- Rechercher et visualiser les patients

### ?? Gestion des Médicaments
- Catalogue des médicaments avec dosage, molécule et description
- Ajouter, modifier et supprimer des médicaments
- Association médicament-prescripteur

### ?? Gestion des Prescriptions
- Créer des ordonnances avec plusieurs médicaments et quantités
- Modifier et supprimer des prescriptions
- Date de validité des prescriptions
- **Export PDF** des ordonnances

---

## ??? Technologies Utilisées

| Technologie | Version | Description |
|-------------|---------|-------------|
| **.NET** | 8.0 | Framework de développement |
| **Windows Forms** | - | Interface graphique |
| **MySQL** | - | Base de données relationnelle |
| **MySql.Data** | 9.5.0 | Connecteur MySQL pour .NET |
| **iText** | 9.4.0 | Génération de fichiers PDF |

---

## ?? Structure du Projet

```
GSB2/
??? GSB2.sln           # Solution Visual Studio
??? GSB2/
    ??? Program.cs      # Point d'entrée de l'application
    ??? GSB2.csproj             # Fichier projet
    ?
    ??? DAO/         # Data Access Objects (Accès aux données)
    ?   ??? Database.cs         # Configuration de la connexion MySQL
    ?   ??? UserDAO.cs        # Opérations CRUD pour les utilisateurs
    ?   ??? PatientDAO.cs       # Opérations CRUD pour les patients
    ?   ??? MedicineDAO.cs      # Opérations CRUD pour les médicaments
    ?   ??? PrescriptionDAO.cs  # Opérations CRUD pour les prescriptions
    ?   ??? LiaiMPDAO.cs        # Liaison médicaments-prescriptions
    ?
    ??? Models/                 # Modèles de données
    ?   ??? Users.cs    # Modèle utilisateur
    ?   ??? Patients.cs         # Modèle patient
    ?   ??? Medicine.cs      # Modèle médicament
  ?   ??? Prescription.cs     # Modèle prescription
    ?   ??? LiaiMP.cs           # Modèle liaison médicament-prescription
  ?
    ??? Forms/       # Formulaires Windows Forms
    ?   ??? ConnexionForm.cs    # Écran de connexion
    ?   ??? RegisterForm.cs     # Écran d'inscription
    ?   ??? MainForm.cs # Écran principal / Dashboard
    ?   ??? PatientsForm.cs     # Gestion des patients
    ?   ??? MedicinesForm.cs    # Gestion des médicaments
    ?   ??? PrescriptionsForm.cs# Gestion des prescriptions
    ?
    ??? Utils/              # Utilitaires
   ??? PdfExporter.cs      # Export des ordonnances en PDF
```

---

## ?? Prérequis

- **Windows 10/11**
- **.NET 8.0 SDK** ou supérieur
- **MySQL Server** (version 5.7+ ou 8.0)
- **Visual Studio 2022** (recommandé)

---

## ?? Installation

### 1. Cloner le dépôt

```bash
git clone https://github.com/Bada-Safwane/GSB_WinForm.git
cd GSB_WinForm/GSB2
```

### 2. Configurer la base de données

Créez la base de données MySQL en exécutant le script SQL (voir section Base de données ci-dessous).

### 3. Configurer la connexion

Modifiez le fichier `DAO/Database.cs` avec vos paramètres de connexion :

```csharp
private readonly string myConnectionString = "server=localhost;uid=root;pwd=votre_mot_de_passe;database=bd_gsb";
```

### 4. Restaurer les packages NuGet

```bash
dotnet restore
```

### 5. Compiler et exécuter

```bash
dotnet build
dotnet run
```

Ou ouvrez `GSB2.sln` dans Visual Studio et appuyez sur **F5**.

---

## ??? Base de Données

### Schéma de la base de données

```sql
CREATE DATABASE IF NOT EXISTS bd_gsb;
USE bd_gsb;

-- Table des utilisateurs
CREATE TABLE users (
    id_users INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL,
    firstname VARCHAR(100) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
  password VARCHAR(64) NOT NULL, -- SHA-256 hash
    role BOOLEAN DEFAULT FALSE     -- FALSE = Médecin, TRUE = Admin
);

-- Table des patients
CREATE TABLE patients (
    id_patients INT PRIMARY KEY AUTO_INCREMENT,
    id_users INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    firstname VARCHAR(100) NOT NULL,
    age INT NOT NULL,
    gender VARCHAR(20) NOT NULL,
    FOREIGN KEY (id_users) REFERENCES users(id_users)
);

-- Table des médicaments
CREATE TABLE medicine (
    id_medicine INT PRIMARY KEY AUTO_INCREMENT,
    id_users INT NOT NULL,
    names VARCHAR(150) NOT NULL,
    dosage VARCHAR(100),
    description TEXT,
    molecule VARCHAR(150),
    FOREIGN KEY (id_users) REFERENCES users(id_users)
);

-- Table des prescriptions
CREATE TABLE prescription (
id_prescription INT PRIMARY KEY AUTO_INCREMENT,
    id_users INT NOT NULL,
    id_patients INT NOT NULL,
    validity DATE NOT NULL,
    FOREIGN KEY (id_users) REFERENCES users(id_users),
    FOREIGN KEY (id_patients) REFERENCES patients(id_patients)
);

-- Table de liaison médicaments-prescriptions
CREATE TABLE liai_medicine_prescription (
    id_prescrition INT NOT NULL,
    id_medicine INT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    PRIMARY KEY (id_prescrition, id_medicine),
FOREIGN KEY (id_prescrition) REFERENCES prescription(id_prescription),
    FOREIGN KEY (id_medicine) REFERENCES medicine(id_medicine)
);
```

---

## ?? Utilisation

### Première connexion

1. Lancez l'application
2. Créez un compte via le bouton **"Créer un compte"**
3. Connectez-vous avec vos identifiants

### Rôles utilisateur

| Rôle | Permissions |
|------|-------------|
| **Médecin** | Gérer patients, médicaments et prescriptions |
| **Administrateur** | Toutes les permissions + gestion des utilisateurs |

---

## ?? Captures d'écran

*À venir*

---

## ?? Contribution

Les contributions sont les bienvenues ! Pour contribuer :

1. Forkez le projet
2. Créez une branche pour votre fonctionnalité (`git checkout -b feature/nouvelle-fonctionnalite`)
3. Committez vos changements (`git commit -m 'Ajout d'une nouvelle fonctionnalité'`)
4. Poussez vers la branche (`git push origin feature/nouvelle-fonctionnalite`)
5. Ouvrez une Pull Request

---

## ?? Licence

Ce projet est sous licence MIT - voir le fichier [LICENSE](LICENSE) pour plus de détails.

---

## ????? Auteur

**Safwane BADA**

- GitHub: [@Bada-Safwane](https://github.com/Bada-Safwane)

---

## ?? Support

Pour toute question ou problème, veuillez ouvrir une [issue](https://github.com/Bada-Safwane/GSB_WinForm/issues) sur GitHub.
