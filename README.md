# GSB2 - Application de Gestion Medicale

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)

## Description

**GSB2** est une application de gestion medicale developpee en **C# Windows Forms** (.NET 8.0). Elle permet aux professionnels de sante (medecins et administrateurs) de gerer les patients, les medicaments et les prescriptions medicales.

L'application offre egalement la possibilite d'**exporter les ordonnances au format PDF** pour une utilisation professionnelle.

---

## Fonctionnalites

### Authentification
- Connexion securisee avec email et mot de passe (hashage SHA-256)
- Creation de compte utilisateur
- Gestion des roles (Medecin / Administrateur)

### Gestion des Utilisateurs (Admin)
- Visualiser la liste des utilisateurs
- Creer, modifier et supprimer des utilisateurs
- Attribution des roles (medecin ou administrateur)

### Gestion des Patients
- Ajouter de nouveaux patients
- Modifier les informations des patients
- Supprimer des patients
- Rechercher et visualiser les patients

### Gestion des Medicaments
- Catalogue des medicaments avec dosage, molecule et description
- Ajouter, modifier et supprimer des medicaments
- Association medicament-prescripteur

### Gestion des Prescriptions
- Creer des ordonnances avec plusieurs medicaments et quantites
- Modifier et supprimer des prescriptions
- Date de validite des prescriptions
- **Export PDF** des ordonnances

---

## Technologies Utilisees

| Technologie | Version | Description |
|-------------|---------|-------------|
| **.NET** | 8.0 | Framework de developpement |
| **Windows Forms** | - | Interface graphique |
| **MySQL** | - | Base de donnees relationnelle |
| **MySql.Data** | 9.5.0 | Connecteur MySQL pour .NET |
| **iText** | 9.4.0 | Generation de fichiers PDF |

---

## Structure du Projet

```
GSB2/
+-- GSB2.sln             # Solution Visual Studio
+-- GSB2/
    +-- Program.cs              # Point d'entree de l'application
    +-- GSB2.csproj             # Fichier projet
    |
    +-- DAO/      # Data Access Objects (Acces aux donnees)
    |   +-- Database.cs     # Configuration de la connexion MySQL
    |   +-- UserDAO.cs     # Operations CRUD pour les utilisateurs
    |   +-- PatientDAO.cs   # Operations CRUD pour les patients
    |   +-- MedicineDAO.cs      # Operations CRUD pour les medicaments
    |   +-- PrescriptionDAO.cs  # Operations CRUD pour les prescriptions
    |   +-- LiaiMPDAO.cs# Liaison medicaments-prescriptions
    |
    +-- Models/  # Modeles de donnees
 |   +-- Users.cs      # Modele utilisateur
    |   +-- Patients.cs # Modele patient
    |   +-- Medicine.cs         # Modele medicament
    |   +-- Prescription.cs     # Modele prescription
    |   +-- LiaiMP.cs         # Modele liaison medicament-prescription
    |
    +-- Forms/      # Formulaires Windows Forms
    | +-- ConnexionForm.cs# Ecran de connexion
    |   +-- RegisterForm.cs     # Ecran d'inscription
    |   +-- MainForm.cs   # Ecran principal / Dashboard
    |   +-- PatientsForm.cs     # Gestion des patients
    |   +-- MedicinesForm.cs    # Gestion des medicaments
    |   +-- PrescriptionsForm.cs# Gestion des prescriptions
    |
    +-- Utils/      # Utilitaires
        +-- PdfExporter.cs      # Export des ordonnances en PDF
```

---

## Prerequis

- **Windows 10/11**
- **.NET 8.0 SDK** ou superieur
- **Docker Desktop** (pour la base de donnees)
- **Visual Studio 2022** (recommande)

---

## Installation

### 1. Cloner le depot

```bash
git clone https://github.com/Bada-Safwane/GSB_WinForm.git
cd GSB_WinForm/GSB2
```

### 2. Lancer la base de donnees avec Docker

Le projet inclut un `docker-compose.yml` qui configure automatiquement MySQL et phpMyAdmin, et importe le dump SQL au demarrage.

```bash
docker compose up -d
```

| Service | URL / Port | Description |
|---------|-----------|-------------|
| MySQL | `localhost:3306` | Base de donnees |
| phpMyAdmin | http://localhost:8080 | Interface d'administration |

Identifiants MySQL : `root` / `root` — Base : `bd_gsb`

> La base de donnees est automatiquement initialisee avec le dump `dump-bd_gsb-202512101546.sql` au premier demarrage.

### 3. Configurer la connexion

La connexion dans `DAO/Database.cs` est deja configuree pour Docker :

```csharp
private readonly string myConnectionString = "server=localhost;uid=root;pwd=root;database=bd_gsb";
```

### 4. Restaurer les packages NuGet

```bash
dotnet restore
```

### 5. Compiler et executer

```bash
dotnet build
dotnet run
```

Ou ouvrez `GSB2.sln` dans Visual Studio et appuyez sur **F5**.

### Arreter les conteneurs

```bash
docker compose down
```

---

## Base de Donnees

### Schema de la base de donnees

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
    role BOOLEAN DEFAULT FALSE -- FALSE = Medecin, TRUE = Admin
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

-- Table des medicaments
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

-- Table de liaison medicaments-prescriptions
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

## Utilisation

### Premiere connexion

1. Lancez l'application
2. Creez un compte via le bouton **"Creer un compte"**
3. Connectez-vous avec vos identifiants

### Roles utilisateur

| Role | Permissions |
|------|-------------|
| **Medecin** | Gerer patients, medicaments et prescriptions |
| **Administrateur** | Toutes les permissions + gestion des utilisateurs |

---

## Captures d'ecran

*A venir*

---

## Contribution

Les contributions sont les bienvenues ! Pour contribuer :

1. Forkez le projet
2. Creez une branche pour votre fonctionnalite (`git checkout -b feature/nouvelle-fonctionnalite`)
3. Committez vos changements (`git commit -m 'Ajout d'une nouvelle fonctionnalite'`)
4. Poussez vers la branche (`git push origin feature/nouvelle-fonctionnalite`)
5. Ouvrez une Pull Request

---

## Licence

Ce projet est sous licence MIT - voir le fichier [LICENSE](LICENSE) pour plus de details.

---

## Auteur

**Safwane BADA**

- GitHub: [@Bada-Safwane](https://github.com/Bada-Safwane)

---

## Support

Pour toute question ou probleme, veuillez ouvrir une [issue](https://github.com/Bada-Safwane/GSB_WinForm/issues) sur GitHub.
