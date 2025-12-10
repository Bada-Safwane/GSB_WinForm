# GSB2 - Application de Gestion Medicale

Application Windows Forms de gestion medicale permettant la gestion des patients, des medicaments et des prescriptions medicales avec export PDF.

## Apercu

**GSB2** est une application desktop developpee en .NET 8 avec Windows Forms, concue pour faciliter la gestion quotidienne des cabinets medicaux et des etablissements de sante.

### Niveaux d'acces
- **Medecin/Prescripteur** : Gestion patients, medicaments, prescriptions
- **Administrateur** : Toutes fonctionnalites + gestion utilisateurs

## Fonctionnalites

### Authentification & Gestion Utilisateurs
- Connexion securisee SHA-256
- Inscription nouveaux utilisateurs
- Gestion complete utilisateurs (admins)
- Deux roles : Medecin et Administrateur

### Gestion Patients
- Creation fiches patients
- Association medecin createur
- Consultation liste patients
- Suppression patients

### Gestion Medicaments
- Ajout medicaments au catalogue
- Tracabilite (ajoute par)
- Consultation base medicaments
- Suppression medicaments

### Gestion Prescriptions
- Creation prescriptions multi-medicaments
- Selection patient et medicaments avec quantites
- Modification prescriptions
- Date validite personnalisable
- Export PDF ordonnances
- Suppression prescriptions

### Export PDF
- Generation automatique ordonnances PDF
- Mise en page professionnelle iText
- Infos completes : patient, medecin, medicaments, quantites
- Ouverture automatique PDF

## Technologies

| Technologie | Version | Usage |
|-------------|---------|-------|
| .NET | 8.0 | Framework |
| C# | 12.0 | Langage |
| Windows Forms | - | Interface |
| MySQL | - | Base donnees |
| MySql.Data | - | Connecteur MySQL |
| iText | 9.x | Generation PDF |

## Installation

### Prerequis
- .NET 8.0 SDK
- MySQL Server (5.7+)
- Visual Studio 2022

### Etapes

1. **Cloner repository**
```bash
git clone https://github.com/Bada-Safwane/GSB_WinForm.git
cd GSB_WinForm
```

2. **Configurer base de donnees**
```sql
CREATE DATABASE gsb;
USE gsb;
-- Importer script SQL ou creer tables manuellement
```

3. **Configurer connexion**
Modifier GSB2/DAO/Database.cs :
```csharp
private string connectionString = "Server=localhost;Database=gsb;Uid=root;Pwd=VotreMotDePasse;";
```

4. **Restaurer packages**
```bash
dotnet restore
```

5. **Compiler et lancer**
```bash
dotnet run --project GSB2/GSB2.csproj
```

Ou ouvrir GSB2.sln dans Visual Studio et appuyer F5

## Configuration

### Chaine Connexion MySQL

Fichier : GSB2/DAO/Database.cs

```csharp
private string connectionString = "Server=localhost;Database=gsb;Uid=root;Pwd=;";
```

Parametres :
- Server : Adresse serveur MySQL (defaut: localhost)
- Database : Nom base (defaut: gsb)
- Uid : Utilisateur MySQL (defaut: root)
- Pwd : Mot de passe MySQL

### Compte Admin Initial

Creer compte via inscription puis modifier en base :
```sql
UPDATE users SET role = TRUE WHERE email = 'admin@example.com';
```

## Documentation

Deux documentations completes disponibles :

1. **DOCS_UTILISATEUR.md** 
   - Guide complet utilisation
   - Description detaillee boutons
   - Cas usage et workflows

2. **DOCS_TECHNIQUE.md**
   - Architecture projet
   - Schema base donnees
   - Guide developpement
   - API DAO et modeles

## Structure Projet

```
GSB2/
|
??? Forms/   # Interfaces utilisateur
|   ??? ConnexionForm.cs
|   ??? RegisterForm.cs
|   ??? MainForm.cs
|   ??? PatientsForm.cs
|   ??? MedicinesForm.cs
|   ??? PrescriptionsForm.cs
|
??? DAO/            # Acces donnees
|   ??? Database.cs
|   ??? UserDAO.cs
|   ??? PatientDAO.cs
|   ??? MedicineDAO.cs
|   ??? PrescriptionDAO.cs
|   ??? LiaiMPDAO.cs
|
??? Models/         # Modeles donnees
|   ??? Users.cs
|   ??? Patients.cs
|   ??? Medicine.cs
| ??? Prescription.cs
|   ??? LiaiMP.cs
|
??? Utils/    # Utilitaires
|   ??? PdfExporter.cs
|
??? Program.cs      # Point entree
```

## Securite

### Protection Mots Passe
- Hachage SHA-256 avant stockage
- Jamais affiches interface
- Hachage cote SQL

### Prevention Injections SQL
- Requetes avec parametres prepares
- Protection injections SQL

### Controle Acces
- Fonctionnalites selon role
- Interface adaptive permissions

### Validation Donnees
- Validation client avant envoi
- Verification contraintes
- Gestion securisee NULL

## Tests

### Tests Manuels Recommandes
- Connexion valide/invalide
- Creation compte unicite email
- Ajout/Modification/Suppression patients
- Ajout/Suppression medicaments
- Creation prescription multi-medicaments
- Modification prescription
- Export PDF verification contenu
- Gestion utilisateurs (admin)
- Verification restrictions role

## Workflow Typique

1. Medecin se connecte
2. Ajoute patients liste
3. Consulte/ajoute medicaments
4. Cree prescription :
   - Selectionne patient
   - Choisit medicaments avec quantites
   - Definit date validite
   - Enregistre
5. Exporte prescription PDF
6. Deconnecte

## Contribution

Les contributions sont bienvenues !

### Pour contribuer
1. Fork projet
2. Creer branche (git checkout -b feature/AmazingFeature)
3. Commit changements (git commit -m 'Add AmazingFeature')
4. Push branche (git push origin feature/AmazingFeature)
5. Ouvrir Pull Request

### Convention Commentaires
Tous commentaires methodes commencent par **SB:** (Safwane Bada)

```csharp
// SB: Description methode
private void MyMethod() { }
```

## Changelog

### Version 1.0 (2024)
- Authentification gestion utilisateurs
- Gestion complete patients
- Gestion medicaments
- Systeme prescriptions
- Export PDF ordonnances
- Documentation complete

## Problemes Connus

- Suppression medicament dans prescriptions (ameliorer CASCADE)
- Transactions multi-tables pas explicites

## Roadmap

- Recherche/filtres listes
- Statistiques tableaux bord
- Historique modifications
- Gestion rendez-vous
- Notifications rappels
- Mode multi-langue
- Tests unitaires integration
- Migration MVVM
- API REST version web

## Auteur

**Safwane Bada (SB)**

- GitHub: @Bada-Safwane
- Repository: GSB_WinForm

## Licence

Projet developpe dans cadre educatif

## Remerciements

- Microsoft pour .NET
- iText pour generation PDF
- Communaute MySQL

---

Developpe avec passion en C# et .NET 8

**Version** : 1.0  
**Date** : 2024  
**Auteur** : SB (Safwane Bada)
