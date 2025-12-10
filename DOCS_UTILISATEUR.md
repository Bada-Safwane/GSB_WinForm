# Documentation Utilisateur - Application GSB2

## Table des matieres
1. Vue d'ensemble
2. Connexion et Inscription
3. Interface Principale
4. Gestion des Utilisateurs
5. Gestion des Patients
6. Gestion des Medicaments
7. Gestion des Prescriptions
8. Fonctionnalites par Role

---

## Vue d'ensemble

**GSB2** est une application de gestion medicale permettant de gerer les patients, les medicaments et les prescriptions.

### Niveaux d'acces
- **Medecin / Prescripteur** : Acces aux patients, medicaments et prescriptions
- **Administrateur** : Acces complet incluant la gestion des utilisateurs

### Technologies
- .NET 8 (C# 12.0)
- Windows Forms
- MySQL
- iText (export PDF)

---

## Connexion et Inscription

### 1. Formulaire de Connexion (ConnexionForm)

#### Champs
- **Email** : Adresse e-mail
- **Mot de passe** : Mot de passe securise (hache SHA-256)

#### Boutons

**Bouton Connexion**
Fonction : Authentifie l'utilisateur
Etapes :
1. Saisir email et mot de passe
2. Cliquer sur Connexion
3. Si correct -> menu principal
4. Si incorrect -> message d'erreur

**Bouton Creer un compte**
Fonction : Ouvre le formulaire d'inscription

### 2. Formulaire d'Inscription (RegisterForm)

#### Champs obligatoires
- Nom
- Prenom
- Email (unique)
- Mot de passe

#### Bouton Creer le compte
1. Remplir tous les champs
2. Verification unicite email
3. Si valide -> confirmation et redirection
4. Role par defaut : Medecin

---

## Interface Principale (MainForm)

### Informations affichees
- Message de bienvenue
- Role
- Email

### Boutons de navigation

**Bouton Patients**
Ouvre la gestion des patients

**Bouton Medicaments**
Ouvre la gestion des medicaments

**Bouton Prescriptions**
Ouvre la gestion des prescriptions
- Creation, modification, suppression
- Export PDF

**Bouton Se deconnecter**
Deconnexion avec confirmation

---

## Gestion des Utilisateurs

Section visible uniquement pour Administrateurs

### DataGridView Utilisateurs
Affiche : Nom, Prenom, E-mail, Administrateur
Colonnes masquees : ID, Mot de passe

### Champs d'edition
- Nom
- Prenom
- Email
- Mot de passe
- Role (case a cocher)

### Boutons

**Bouton Nouveau**
Prepare creation nouvel utilisateur

**Bouton Enregistrer**
Mode Creation :
1. Nouveau
2. Remplir champs + mot de passe
3. Cocher Administrateur si necessaire
4. Enregistrer

Mode Modification :
1. Selectionner ligne
2. Modifier informations
3. Mot de passe optionnel
4. Enregistrer

**Bouton Supprimer**
Supprime utilisateur avec confirmation

---

## Gestion des Patients (PatientsForm)

### DataGridView
Affiche : Medecin referent, Prenom, Nom, Age, Genre

### Panel d'ajout
Champs : Prenom, Nom, Age, Genre

### Boutons

**Bouton Actualiser**
Recharge la liste

**Bouton Ajouter**
Affiche/masque panel d'ajout

**Bouton Enregistrer**
1. Remplir champs
2. Association automatique au medecin
3. Confirmation
4. Liste actualisee

**Bouton Supprimer**
Suppression avec confirmation

**Bouton Retour**
Retour au menu principal

---

## Gestion des Medicaments (MedicinesForm)

### DataGridView
Affiche : Ajoute par, Dosage, Nom, Description, Molecule

### Panel d'ajout
Champs : Nom, Dosage, Molecule, Description

### Boutons

**Bouton Actualiser**
Recharge la liste

**Bouton Ajouter**
Toggle panel d'ajout

**Bouton Enregistrer**
1. Remplir champs
2. Association automatique
3. Confirmation

**Bouton Supprimer**
Suppression avec confirmation

**Bouton Retour**
Retour au menu principal

---

## Gestion des Prescriptions (PrescriptionsForm)

MODULE LE PLUS COMPLET

### DataGridView principal
Affiche : Patient, Medecin, Date validite, Medicaments

### Panel d'ajout/modification
Composants :
- ComboBox Patient
- DateTimePicker Validite
- DataGridView Medicaments
  - Checkbox Selectionner
  - Nom
  - Dosage
  - Quantite

### Boutons

**Bouton Actualiser**
Recharge liste prescriptions

**Bouton Ajouter**
Prepare nouvelle prescription
- Affiche panel
- Reinitialise champs
- Date = aujourd'hui
- Mode CREATION

**Bouton Enregistrer**

Mode Creation :
1. Ajouter
2. Selectionner patient
3. Choisir date
4. Cocher medicaments
5. Saisir quantites (> 0)
6. Enregistrer

Validations :
- Minimum 1 patient
- Minimum 1 medicament
- Quantites valides (entier > 0)

Mode Modification :
1. Cliquer ligne prescription
2. Panel affiche avec donnees
3. Modifier infos
4. Enregistrer

**Bouton Supprimer**
Suppression avec confirmation

**Bouton Exporter PDF**
1. Selectionner prescription
2. Exporter PDF
3. Choisir emplacement
4. PDF genere avec :
   - Titre : Ordonnance medicale
   - Info patient
   - Info medecin
   - Date validite
   - Tableau medicaments
   - Espace signature
5. Ouverture automatique

**Bouton Retour**
Retour au menu principal

---

## Fonctionnalites par Role

### Medecin / Prescripteur (Role = False)

Acces :
- Connexion, inscription
- Gestion patients
- Gestion medicaments
- Gestion prescriptions
- Export PDF
- Voir uniquement ses donnees

Restrictions :
- Pas gestion utilisateurs
- Pas suppression utilisateurs

### Administrateur (Role = True)

Acces complets :
- Toutes fonctionnalites Medecin
- Gestion complete utilisateurs
- Creation/modification/suppression
- Changement roles
- Vue complete utilisateurs

---

## Resume des Actions

| Action | Medecin | Admin |
|--------|---------|-------|
| Connexion | Oui | Oui |
| Inscription | Oui | Oui |
| Gestion patients | Oui | Oui |
| Gestion medicaments | Oui | Oui |
| Prescriptions | Oui | Oui |
| Export PDF | Oui | Oui |
| Gestion utilisateurs | Non | Oui |

---

## Securite

### Mots de passe
- Hachage SHA-256
- Jamais affiches
- Champ vide lors selection

### Validation
- Champs obligatoires
- Messages erreur clairs
- Confirmations suppressions

### Associations
- Patient -> Medecin createur
- Medicament -> Utilisateur createur
- Prescription -> Medecin createur

---

## Conseils

1. Creer patients avant prescriptions
2. Ajouter medicaments avant prescrire
3. Verifier quantites
4. Exporter regulierement PDF
5. Utiliser Actualiser si plusieurs utilisateurs

### Astuces
- Double-clic = selection rapide
- Nouveau = reinitialise
- Ajouter = toggle espace
- Date defaut = aujourd'hui

---

## Support

**Version** : 1.0  
**Date** : 2024  
**Auteur** : SB (Safwane Bada)

Documentation complete pour utilisateurs finaux (medecins et administrateurs)
