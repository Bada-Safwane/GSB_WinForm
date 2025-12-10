# ?? GSB2 - Application de Gestion Médicale

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp)
![MySQL](https://img.shields.io/badge/MySQL-Database-4479A1?logo=mysql)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-UI-0078D4?logo=windows)

Application Windows Forms de gestion médicale permettant la gestion des patients, des médicaments et des prescriptions médicales avec export PDF.

## ?? Table des Matières

- [Aperçu](#aperçu)
- [Fonctionnalités](#fonctionnalités)
- [Technologies](#technologies)
- [Installation](#installation)
- [Configuration](#configuration)
- [Documentation](#documentation)
- [Captures d'Écran](#captures-décran)
- [Structure du Projet](#structure-du-projet)
- [Sécurité](#sécurité)
- [Auteur](#auteur)

## ?? Aperçu

**GSB2** est une application desktop développée en .NET 8 avec Windows Forms, conçue pour faciliter la gestion quotidienne des cabinets médicaux et des établissements de santé.

L'application propose deux niveaux d'accès :
- **????? Médecin/Prescripteur** : Gestion des patients, médicaments et prescriptions
- **?? Administrateur** : Toutes les fonctionnalités + gestion des utilisateurs

## ? Fonctionnalités

### ?? Authentification & Gestion des Utilisateurs
- ? Connexion sécurisée avec hachage SHA-256 des mots de passe
- ? Inscription de nouveaux utilisateurs
- ? Gestion complète des utilisateurs (admins uniquement)
- ? Deux rôles distincts : Médecin et Administrateur

### ?? Gestion des Patients
- ? Création de fiches patients (nom, prénom, âge, genre)
- ? Association automatique avec le médecin créateur
- ? Consultation de la liste de tous les patients
- ? Suppression de patients

### ?? Gestion des Médicaments
- ? Ajout de médicaments au catalogue (nom, dosage, molécule, description)
- ? Traçabilité des médicaments (ajouté par quel utilisateur)
- ? Consultation de la base de médicaments
- ? Suppression de médicaments

### ?? Gestion des Prescriptions
- ? Création de prescriptions multi-médicaments
- ? Sélection de patient et de médicaments avec quantités
- ? Modification de prescriptions existantes
- ? Date de validité personnalisable
- ? **Export PDF** des ordonnances
- ? Suppression de prescriptions

### ?? Export PDF
- ? Génération automatique d'ordonnances au format PDF
- ? Mise en page professionnelle avec iText
- ? Informations complètes : patient, médecin, médicaments, quantités
- ? Ouverture automatique du PDF après génération

## ??? Technologies

| Technologie | Version | Usage |
|-------------|---------|-------|
| .NET | 8.0 | Framework principal |
| C# | 12.0 | Langage de programmation |
| Windows Forms | - | Interface utilisateur |
| MySQL | - | Base de données |
| MySql.Data | - | Connecteur MySQL pour .NET |
| iText | 9.x | Génération de PDF |

## ?? Installation

### Prérequis

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (version 5.7 ou supérieure)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (recommandé) ou tout IDE compatible .NET

### Étapes d'Installation

1. **Cloner le repository**
```bash
git clone https://github.com/Bada-Safwane/GSB_WinForm.git
cd GSB_WinForm
```

2. **Configurer la base de données**

Créer la base de données MySQL :
```sql
CREATE DATABASE gsb;
USE gsb;
```

Importer le script SQL fourni (si disponible) ou créer les tables manuellement :
```sql
-- Tables users, Patients, Medicine, Prescription, LiaiMP
-- Voir DOCUMENTATION_TECHNIQUE.md pour le schéma complet
```

3. **Configurer la connexion**

Modifier la chaîne de connexion dans `GSB2/DAO/Database.cs` :
```csharp
private string connectionString = "Server=localhost;Database=gsb;Uid=root;Pwd=VotreMotDePasse;";
```

4. **Restaurer les packages NuGet**
```bash
dotnet restore
```

5. **Compiler et lancer l'application**
```bash
dotnet run --project GSB2/GSB2.csproj
```

Ou ouvrir `GSB2.sln` dans Visual Studio et appuyer sur **F5**.

## ?? Configuration

### Chaîne de Connexion MySQL

Fichier : `GSB2/DAO/Database.cs`

```csharp
private string connectionString = "Server=localhost;Database=gsb;Uid=root;Pwd=;";
```

Paramètres configurables :
- **Server** : Adresse du serveur MySQL (par défaut : `localhost`)
- **Database** : Nom de la base de données (par défaut : `gsb`)
- **Uid** : Nom d'utilisateur MySQL (par défaut : `root`)
- **Pwd** : Mot de passe MySQL

### Compte Administrateur Initial

Lors de la première utilisation, créez un compte via le formulaire d'inscription. Pour en faire un administrateur, modifiez directement en base :

```sql
UPDATE users SET role = TRUE WHERE email = 'admin@example.com';
```

## ?? Documentation

Deux documentations complètes sont disponibles :

1. **[Documentation Utilisateur](DOCUMENTATION_UTILISATEUR.md)** 
   - Guide complet d'utilisation de l'application
   - Description détaillée de chaque bouton et fonctionnalité
- Cas d'usage et workflows

2. **[Documentation Technique](DOCUMENTATION_TECHNIQUE.md)**
   - Architecture du projet
   - Schéma de base de données
 - Guide de développement
   - API des DAO et modèles

## ?? Captures d'Écran

### Connexion
![Connexion](docs/images/connexion.png)

### Menu Principal (Administrateur)
![Menu Principal](docs/images/main.png)

### Gestion des Prescriptions
![Prescriptions](docs/images/prescriptions.png)

### Export PDF
![PDF](docs/images/pdf-export.png)

## ?? Structure du Projet

```
GSB2/
?
??? Forms/          # Interfaces utilisateur (WinForms)
?   ??? ConnexionForm.cs
?   ??? RegisterForm.cs
?   ??? MainForm.cs
?   ??? PatientsForm.cs
?   ??? MedicinesForm.cs
?   ??? PrescriptionsForm.cs
?
??? DAO/  # Couche d'accès aux données
?   ??? Database.cs
?   ??? UserDAO.cs
?   ??? PatientDAO.cs
?   ??? MedicineDAO.cs
?   ??? PrescriptionDAO.cs
?   ??? LiaiMPDAO.cs
?
??? Models/      # Modèles de données (POCO)
?   ??? Users.cs
?   ??? Patients.cs
?   ??? Medicine.cs
?   ??? Prescription.cs
?   ??? LiaiMP.cs
?
??? Utils/        # Utilitaires
?   ??? PdfExporter.cs
?
??? Program.cs       # Point d'entrée
??? DOCUMENTATION_UTILISATEUR.md
??? DOCUMENTATION_TECHNIQUE.md
??? README.md
```

## ?? Sécurité

### Protection des Mots de Passe
- ? Hachage **SHA-256** des mots de passe avant stockage
- ? Aucun mot de passe n'est jamais affiché dans l'interface
- ? Hachage effectué côté SQL pour éviter la transmission en clair

### Prévention des Injections SQL
- ? Toutes les requêtes utilisent des **paramètres préparés**
- ? Protection contre les injections SQL

### Contrôle d'Accès
- ? Fonctionnalités restreintes selon le rôle (Médecin/Admin)
- ? Interface adaptative basée sur les permissions

### Validation des Données
- ? Validation côté client avant envoi
- ? Vérification des contraintes (unicité email, champs obligatoires)
- ? Gestion sécurisée des valeurs NULL

## ?? Tests

### Tests Manuels Recommandés

- [ ] Connexion avec identifiants valides/invalides
- [ ] Création de compte et vérification de l'unicité de l'email
- [ ] Ajout/Modification/Suppression de patients
- [ ] Ajout/Suppression de médicaments
- [ ] Création de prescription multi-médicaments
- [ ] Modification d'une prescription existante
- [ ] Export PDF et vérification du contenu
- [ ] Gestion des utilisateurs (en tant qu'admin)
- [ ] Vérification des restrictions de rôle

## ?? Workflow Typique

1. **Médecin** se connecte
2. Ajoute des **patients** à sa liste
3. Consulte/ajoute des **médicaments** au catalogue
4. Crée une **prescription** :
   - Sélectionne un patient
   - Choisit des médicaments avec quantités
   - Définit la date de validité
   - Enregistre
5. **Exporte la prescription en PDF** pour l'imprimer
6. Se déconnecte

## ?? Contribution

Les contributions sont les bienvenues ! 

### Pour contribuire :

1. Forker le projet
2. Créer une branche (`git checkout -b feature/AmazingFeature`)
3. Commiter les changements (`git commit -m 'Add some AmazingFeature'`)
4. Pousser vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request

### Convention de Commentaires

Tous les commentaires de méthodes doivent commencer par **SB:** (Safwane Bada)

```csharp
// SB: Description claire de la méthode
private void MyMethod() { }
```

## ?? Changelog

### Version 1.0 (2024)
- ? Authentification et gestion des utilisateurs
- ? Gestion complète des patients
- ? Gestion des médicaments
- ? Système de prescriptions
- ? Export PDF des ordonnances
- ? Documentation complète

## ?? Problèmes Connus

- La suppression d'un médicament utilisé dans des prescriptions peut causer des erreurs (à améliorer avec des contraintes CASCADE)
- Les transactions multi-tables ne sont pas explicites (à améliorer)

## ??? Roadmap

- [ ] Ajout de recherche/filtres dans les listes
- [ ] Statistiques et tableaux de bord
- [ ] Historique des modifications
- [ ] Gestion des rendez-vous
- [ ] Notifications et rappels
- [ ] Mode multi-langue
- [ ] Tests unitaires et d'intégration
- [ ] Migration vers une architecture MVVM
- [ ] API REST pour une future version web

## ????? Auteur

**Safwane Bada (SB)**

- GitHub: [@Bada-Safwane](https://github.com/Bada-Safwane)
- Repository: [GSB_WinForm](https://github.com/Bada-Safwane/GSB_WinForm)

## ?? Licence

Ce projet est développé dans un cadre éducatif.

## ?? Remerciements

- Microsoft pour .NET et Entity Framework
- iText pour la génération de PDF
- La communauté MySQL

---

? **N'hésitez pas à donner une étoile si ce projet vous a aidé !** ?

---

*Développé avec ?? en C# et .NET 8*
