# ?? Documentation Utilisateur - Application GSB2

## ?? Table des matières
1. [Vue d'ensemble](#vue-densemble)
2. [Connexion et Inscription](#connexion-et-inscription)
3. [Interface Principale](#interface-principale)
4. [Gestion des Utilisateurs](#gestion-des-utilisateurs)
5. [Gestion des Patients](#gestion-des-patients)
6. [Gestion des Médicaments](#gestion-des-médicaments)
7. [Gestion des Prescriptions](#gestion-des-prescriptions)
8. [Fonctionnalités par Rôle](#fonctionnalités-par-rôle)

---

## ?? Vue d'ensemble

**GSB2** est une application de gestion médicale permettant de gérer les patients, les médicaments et les prescriptions. L'application dispose de deux niveaux d'accès :
- **Médecin / Prescripteur** : Accès aux patients, médicaments et prescriptions
- **Administrateur** : Accès complet incluant la gestion des utilisateurs

### Technologies utilisées
- **.NET 8** (C# 12.0)
- **Windows Forms** pour l'interface graphique
- **MySQL** pour la base de données
- **iText** pour l'export PDF des prescriptions

---

## ?? Connexion et Inscription

### 1. Formulaire de Connexion (`ConnexionForm`)

![Connexion](docs/images/connexion.png)

#### Champs disponibles :
- **Email** : Adresse e-mail de l'utilisateur
- **Mot de passe** : Mot de passe sécurisé (hashé en SHA-256 dans la base)

#### Boutons :

##### ?? Bouton "Connexion"
**Fonction** : Authentifie l'utilisateur et ouvre le menu principal

**Étapes** :
1. Saisir votre email et mot de passe
2. Cliquer sur "Connexion"
3. Si les identifiants sont corrects ? redirection vers le menu principal
4. Si les identifiants sont incorrects ? message d'erreur "Email ou mot de passe incorrect"

**Note** : La vérification de la connexion à la base de données est effectuée automatiquement au démarrage

##### ?? Bouton "Créer un compte"
**Fonction** : Ouvre le formulaire d'inscription pour les nouveaux utilisateurs

**Étapes** :
1. Cliquer sur "Créer un compte"
2. Vous êtes redirigé vers le formulaire d'inscription

---

### 2. Formulaire d'Inscription (`RegisterForm`)

#### Champs obligatoires :
- **Nom** : Nom de famille de l'utilisateur
- **Prénom** : Prénom de l'utilisateur
- **Email** : Adresse e-mail (doit être unique dans le système)
- **Mot de passe** : Mot de passe pour la connexion

#### Boutons :

##### ?? Bouton "Créer le compte"
**Fonction** : Enregistre un nouveau compte utilisateur dans la base de données

**Étapes** :
1. Remplir tous les champs obligatoires
2. Cliquer sur "Créer le compte"
3. Le système vérifie :
   - Que tous les champs sont remplis
   - Que l'email n'existe pas déjà
4. Si tout est valide ? message de confirmation et redirection vers la page de connexion
5. Si un champ manque ? message "Veuillez remplir tous les champs"
6. Si l'email existe déjà ? message "Cet email est déjà utilisé"

**Note** : Les nouveaux comptes sont créés par défaut avec le rôle "Médecin / Prescripteur" (non-administrateur)

---

## ?? Interface Principale

### 3. Menu Principal (`MainForm`)

L'interface principale s'adapte selon le rôle de l'utilisateur connecté.

#### Informations affichées :
- **Message de bienvenue** : "Bienvenue [Prénom] [Nom] ??"
- **Rôle** : "Médecin / Prescripteur" ou "Administrateur"
- **Email** : Adresse e-mail de l'utilisateur connecté

#### Boutons de navigation :

##### ?? Bouton "Patients"
**Fonction** : Ouvre le formulaire de gestion des patients
- Accessible à tous les utilisateurs (médecins et administrateurs)
- Permet de créer, consulter et supprimer des patients

##### ?? Bouton "Médicaments"
**Fonction** : Ouvre le formulaire de gestion des médicaments
- Accessible à tous les utilisateurs
- Permet d'ajouter, consulter et supprimer des médicaments

##### ?? Bouton "Prescriptions"
**Fonction** : Ouvre le formulaire de gestion des prescriptions
- Accessible à tous les utilisateurs
- Permet de créer, modifier, consulter et supprimer des prescriptions
- Permet d'exporter les prescriptions en PDF

##### ?? Bouton "Se déconnecter"
**Fonction** : Déconnecte l'utilisateur et retourne à l'écran de connexion
- Demande une confirmation avant la déconnexion
- Ferme la session en cours

---

## ?? Gestion des Utilisateurs

### 4. Section Utilisateurs (visible uniquement pour les Administrateurs)

Cette section est affichée directement dans le `MainForm` mais **uniquement pour les utilisateurs avec le rôle Administrateur**.

#### Vue DataGridView :
Affiche la liste de tous les utilisateurs du système avec :
- **Nom** : Nom de famille
- **Prénom** : Prénom
- **E-mail** : Adresse e-mail
- **Administrateur ?** : True/False (indique si l'utilisateur est admin)

**Colonnes masquées** : ID utilisateur, Mot de passe (pour la sécurité)

#### Champs d'édition :
- **Nom** : Nom de famille de l'utilisateur
- **Prénom** : Prénom de l'utilisateur
- **Email** : Adresse e-mail
- **Mot de passe** : Champ pour définir/modifier le mot de passe
- **Rôle** : Case à cocher "Administrateur"

#### Boutons disponibles :

##### ?? Bouton "Nouveau"
**Fonction** : Prépare la création d'un nouvel utilisateur

**Étapes** :
1. Cliquer sur "Nouveau"
2. Tous les champs sont vidés
3. La sélection dans la grille est supprimée
4. Remplir les informations du nouvel utilisateur
5. Le mot de passe est **obligatoire** pour la création

##### ?? Bouton "Enregistrer"
**Fonction** : Enregistre un nouvel utilisateur ou met à jour un utilisateur existant

**Mode Création** (si aucun utilisateur n'est sélectionné) :
1. Cliquer sur "Nouveau" d'abord
2. Remplir **tous les champs** : Nom, Prénom, Email, **Mot de passe**
3. Cocher "Administrateur" si nécessaire
4. Cliquer sur "Enregistrer"
5. Message de confirmation ? l'utilisateur apparaît dans la liste

**Mode Modification** (si un utilisateur est sélectionné) :
1. Sélectionner une ligne dans la grille
2. Les champs sont pré-remplis automatiquement
3. Modifier les informations souhaitées
4. Le mot de passe peut être laissé vide (conserve l'ancien)
5. Cliquer sur "Enregistrer"
6. Message de confirmation ? les modifications sont appliquées

**Validations** :
- Nom, Prénom et Email sont **obligatoires**
- Le mot de passe est **obligatoire uniquement lors de la création**
- Message d'erreur si un champ requis est manquant

##### ??? Bouton "Supprimer" (visible uniquement pour les Administrateurs)
**Fonction** : Supprime l'utilisateur sélectionné

**Étapes** :
1. Sélectionner un utilisateur dans la grille
2. Cliquer sur "Supprimer"
3. Confirmer la suppression dans la boîte de dialogue
4. L'utilisateur est supprimé de la base de données
5. La liste est mise à jour automatiquement

**Sécurité** :
- Ce bouton n'est visible que pour les administrateurs
- Demande de confirmation avant suppression

#### Interaction avec la grille :
- **Clic sur une ligne** : Les champs d'édition sont automatiquement remplis avec les données de l'utilisateur sélectionné
- Le champ mot de passe est vidé pour des raisons de sécurité

---

## ?? Gestion des Patients

### 5. Formulaire Patients (`PatientsForm`)

Accessible via le bouton "Patients" du menu principal.

#### Vue DataGridView :
Affiche tous les patients du système avec :
- **Médecin référent** : Nom complet du médecin qui a créé le patient
- **Prénom** : Prénom du patient
- **Nom** : Nom du patient
- **Âge** : Âge du patient
- **Genre** : Homme/Femme

**Colonne masquée** : ID du patient

#### Panel d'ajout (affiché/masqué par le bouton "Ajouter") :

**Champs disponibles** :
- **Prénom** : Prénom du patient
- **Nom** : Nom du patient
- **Âge** : Âge en années (nombre entier)
- **Genre** : Liste déroulante (Homme/Femme)

#### Boutons disponibles :

##### ?? Bouton "Actualiser"
**Fonction** : Recharge la liste des patients depuis la base de données
- Utile pour voir les modifications faites par d'autres utilisateurs
- Met à jour le DataGridView

##### ? Bouton "Ajouter"
**Fonction** : Affiche ou masque le panneau d'ajout de patient
- Premier clic ? affiche le formulaire d'ajout
- Deuxième clic ? masque le formulaire
- Permet d'économiser de l'espace à l'écran

##### ?? Bouton "Enregistrer"
**Fonction** : Crée un nouveau patient dans la base de données

**Étapes** :
1. Cliquer sur "Ajouter" pour afficher le formulaire
2. Remplir tous les champs :
   - Prénom
   - Nom
   - Âge (nombre)
   - Genre (sélectionner dans la liste)
3. Cliquer sur "Enregistrer"
4. Le patient est automatiquement associé à l'utilisateur connecté (médecin référent)
5. Message "? Patient ajouté avec succès !"
6. Le formulaire se masque et la liste est actualisée
7. Les champs sont réinitialisés

**Validations** :
- Tous les champs sont obligatoires
- L'âge doit être un nombre valide
- Le genre doit être sélectionné dans la liste

##### ??? Bouton "Supprimer"
**Fonction** : Supprime le patient sélectionné

**Étapes** :
1. Sélectionner une ligne dans la grille
2. Cliquer sur "Supprimer"
3. Confirmer la suppression ? message "Voulez-vous vraiment supprimer ce patient ?"
4. Si confirmation ? message "??? Patient supprimé avec succès !"
5. La liste est actualisée automatiquement

**Sécurité** :
- Demande de confirmation avant suppression
- Si aucune ligne n'est sélectionnée ? message d'avertissement

##### ?? Bouton "Retour"
**Fonction** : Ferme le formulaire et retourne au menu principal
- Ferme la fenêtre actuelle
- Ouvre le `MainForm` avec les informations de l'utilisateur connecté

---

## ?? Gestion des Médicaments

### 6. Formulaire Médicaments (`MedicinesForm`)

Accessible via le bouton "Médicaments" du menu principal.

#### Vue DataGridView :
Affiche tous les médicaments du système avec :
- **Ajouté par** : Nom complet de l'utilisateur qui a créé le médicament
- **Dosage** : Dosage du médicament (ex: 500mg)
- **Nom** : Nom commercial du médicament
- **Description** : Description détaillée
- **Molécule** : Principe actif

**Colonnes masquées** : ID médicament, ID utilisateur

#### Panel d'ajout (affiché/masqué par le bouton "Ajouter") :

**Champs disponibles** :
- **Nom** : Nom commercial du médicament
- **Dosage** : Dosage (ex: 500, 1000)
- **Molécule** : Principe actif (ex: Paracétamol, Ibuprofène)
- **Description** : Informations complémentaires sur le médicament

#### Boutons disponibles :

##### ?? Bouton "Actualiser"
**Fonction** : Recharge la liste des médicaments depuis la base de données
- Met à jour le DataGridView avec les dernières données

##### ? Bouton "Ajouter"
**Fonction** : Affiche ou masque le panneau d'ajout de médicament
- Toggle (bascule) la visibilité du formulaire d'ajout

##### ?? Bouton "Enregistrer"
**Fonction** : Crée un nouveau médicament dans la base de données

**Étapes** :
1. Cliquer sur "Ajouter" pour afficher le formulaire
2. Remplir les champs :
   - Nom (obligatoire)
   - Dosage
   - Molécule
   - Description
3. Cliquer sur "Enregistrer"
4. Le médicament est automatiquement associé à l'utilisateur connecté
5. Message "? Médicament ajouté avec succès !"
6. Le formulaire se masque et la liste est actualisée
7. Les champs sont réinitialisés

**Note** : Le médicament créé sera visible dans le formulaire des prescriptions pour pouvoir être prescrit.

##### ??? Bouton "Supprimer"
**Fonction** : Supprime le médicament sélectionné

**Étapes** :
1. Sélectionner une ligne dans la grille
2. Cliquer sur "Supprimer"
3. Confirmer la suppression ? message "Voulez-vous vraiment supprimer ce médicament ?"
4. Si confirmation ? message "??? Médicament supprimé avec succès !"
5. La liste est actualisée

**Attention** : 
- La suppression d'un médicament peut affecter les prescriptions existantes
- Demande de confirmation obligatoire

##### ?? Bouton "Retour"
**Fonction** : Ferme le formulaire et retourne au menu principal

---

## ?? Gestion des Prescriptions

### 7. Formulaire Prescriptions (`PrescriptionsForm`)

Accessible via le bouton "Prescriptions" du menu principal. **C'est le module le plus complet de l'application.**

#### Vue principale - DataGridView des Prescriptions :
Affiche toutes les prescriptions avec :
- **Patient** : Nom complet du patient
- **Médecin** : Nom complet du médecin prescripteur
- **Date de validité** : Date jusqu'à laquelle la prescription est valide
- **Médicaments** : Liste des médicaments prescrits

**Colonne masquée** : ID de la prescription

#### Panel d'ajout/modification (affiché/masqué par le bouton "Ajouter") :

**Composants du formulaire** :

1. **ComboBox Patient** : Liste déroulante de tous les patients (format : "Nom Prénom")
2. **DateTimePicker Validité** : Sélecteur de date pour la validité de la prescription
3. **DataGridView Médicaments** : Grille avec tous les médicaments disponibles
   - Colonne **Sélectionner** : Case à cocher pour choisir le médicament
   - Colonne **Nom** : Nom du médicament
   - Colonne **Dosage** : Dosage (ex: 500mg)
   - Colonne **Quantité** : Champ de saisie pour la quantité à prescrire

#### Boutons disponibles :

##### ?? Bouton "Actualiser"
**Fonction** : Recharge la liste des prescriptions
- Met à jour la vue principale avec les dernières données

##### ? Bouton "Ajouter"
**Fonction** : Prépare la création d'une nouvelle prescription

**Étapes** :
1. Cliquer sur "Ajouter"
2. Le panneau d'ajout s'affiche
3. Les champs sont réinitialisés :
   - Date = aujourd'hui
   - Tous les médicaments sont décochés
   - Toutes les quantités sont vides
4. Mode "Création" activé (pas d'ID de prescription en cours d'édition)

##### ?? Bouton "Enregistrer"
**Fonction** : Crée une nouvelle prescription ou met à jour une prescription existante

**Mode Création** (après avoir cliqué sur "Ajouter") :

**Étapes détaillées** :
1. Cliquer sur "Ajouter"
2. Sélectionner un **patient** dans la liste déroulante
3. Choisir la **date de validité** (par défaut = aujourd'hui)
4. Dans la grille des médicaments :
   - **Cocher** les médicaments à prescrire
   - **Saisir une quantité** pour chaque médicament coché (ex: 1, 2, 3...)
5. Cliquer sur "Enregistrer"

**Validations** :
- Au moins un patient doit être sélectionné
- Au moins un médicament doit être coché
- Chaque médicament coché doit avoir une quantité valide (nombre entier > 0)
- Si une quantité est invalide ? message "Quantité invalide pour [Nom du médicament]"
- Si aucun médicament sélectionné ? message "Veuillez sélectionner au moins un médicament"

**Si succès** :
- Message "? Prescription enregistrée !"
- Le panneau d'ajout se masque
- La liste des prescriptions est actualisée
- Les champs sont réinitialisés

**Mode Modification** (après avoir cliqué sur une ligne de prescription) :

**Étapes** :
1. **Cliquer sur une ligne** dans la grille des prescriptions
2. Le panneau s'affiche automatiquement avec :
   - Le patient sélectionné
   - La date de validité pré-remplie
   - Les médicaments prescrits **cochés** avec leurs quantités
3. Modifier les informations :
   - Changer le patient si nécessaire
   - Modifier la date de validité
   - Ajouter/retirer des médicaments (cocher/décocher)
   - Modifier les quantités
4. Cliquer sur "Enregistrer"
5. La prescription est mise à jour dans la base de données

**Note importante** : Le système détecte automatiquement si vous êtes en mode création ou modification.

##### ??? Bouton "Supprimer"
**Fonction** : Supprime la prescription sélectionnée

**Étapes** :
1. Sélectionner une ligne dans la grille des prescriptions
2. Cliquer sur "Supprimer"
3. Confirmer ? message "Confirmer la suppression ?"
4. Si oui ? message de confirmation et actualisation de la liste

**Sécurité** :
- Demande de confirmation obligatoire
- Supprime également les liens avec les médicaments (table de liaison)

##### ?? Bouton "Exporter PDF"
**Fonction** : Génère un fichier PDF de la prescription sélectionnée

**Étapes** :
1. Sélectionner une prescription dans la grille
2. Cliquer sur "Exporter PDF"
3. Une boîte de dialogue s'ouvre pour choisir l'emplacement et le nom du fichier
   - Nom par défaut : `Ordonnance_[NomPatient]_[PrénomPatient]_[DateHeure].pdf`
4. Cliquer sur "Enregistrer"
5. Le PDF est généré avec :
   - **En-tête** : "Ordonnance médicale"
   - **Informations patient** : Nom et prénom
 - **Informations médecin** : "Dr [Nom Prénom]"
   - **Date de validité** : Format JJ/MM/AAAA
   - **Tableau des médicaments** :
     - Colonne "Médicament" : Nom + Dosage
     - Colonne "Quantité" : Nombre d'unités
   - **Espace signature** : Pour le médecin
6. Le fichier PDF s'ouvre automatiquement après création

**Validations** :
- Une prescription doit être sélectionnée
- Si aucune sélection ? message "Veuillez sélectionner une prescription"

**Gestion des erreurs** :
- Si un champ est null (patient/médecin) ? valeurs par défaut affichées
- Les erreurs de génération sont affichées dans un MessageBox

##### ?? Bouton "Retour"
**Fonction** : Ferme le formulaire et retourne au menu principal

---

## ?? Fonctionnalités par Rôle

### Médecin / Prescripteur (Role = False)

**Accès autorisés** :
- ? Connexion et inscription
- ? Gestion des patients (créer, consulter, supprimer)
- ? Gestion des médicaments (ajouter, consulter, supprimer)
- ? Gestion des prescriptions (créer, modifier, consulter, supprimer, exporter PDF)
- ? Voir uniquement ses propres patients/médicaments créés (dans les colonnes "Médecin référent" et "Ajouté par")

**Restrictions** :
- ? Pas d'accès à la gestion des utilisateurs
- ? Ne peut pas voir/modifier/supprimer les autres utilisateurs
- ? Pas de bouton "Supprimer" pour les utilisateurs

### Administrateur (Role = True)

**Accès complets** :
- ? Toutes les fonctionnalités du Médecin/Prescripteur
- ? **Gestion complète des utilisateurs** :
  - Créer de nouveaux utilisateurs (médecins ou admins)
  - Modifier les informations des utilisateurs existants
  - Supprimer des utilisateurs
  - Changer le rôle (médecin ? administrateur)
- ? Vue DataGridView des utilisateurs dans le MainForm
- ? Bouton "Supprimer" visible pour la gestion des utilisateurs

---

## ?? Résumé des Actions Disponibles

| Action | Médecin | Administrateur |
|--------|---------|----------------|
| Se connecter | ? | ? |
| S'inscrire | ? | ? |
| Gérer ses patients | ? | ? |
| Gérer les médicaments | ? | ? |
| Créer des prescriptions | ? | ? |
| Exporter PDF | ? | ? |
| Voir tous les utilisateurs | ? | ? |
| Créer des utilisateurs | ? | ? |
| Modifier des utilisateurs | ? | ? |
| Supprimer des utilisateurs | ? | ? |
| Changer les rôles | ? | ? |

---

## ??? Sécurité

### Mots de passe
- Tous les mots de passe sont **hashés** avec SHA-256 avant stockage
- Les mots de passe ne sont **jamais affichés** dans l'interface
- Le champ mot de passe est **vidé** lors de la sélection d'un utilisateur

### Validation des données
- Tous les champs obligatoires sont vérifiés avant enregistrement
- Messages d'erreur clairs pour guider l'utilisateur
- Confirmations obligatoires pour les suppressions

### Associations utilisateur
- Chaque patient est lié à son médecin créateur
- Chaque médicament est lié à l'utilisateur qui l'a ajouté
- Chaque prescription est liée au médecin qui l'a créée

---

## ?? Conseils d'utilisation

### Pour une utilisation optimale :

1. **Créer d'abord des patients** avant de faire des prescriptions
2. **Ajouter des médicaments** dans la base avant de prescrire
3. **Vérifier les quantités** avant d'enregistrer une prescription
4. **Exporter régulièrement les prescriptions en PDF** pour archivage
5. **Utiliser le bouton Actualiser** si plusieurs utilisateurs travaillent en même temps

### Raccourcis et astuces :

- **Double-clic sur une ligne** = sélection rapide pour modification
- **Bouton Nouveau** (Utilisateurs) = réinitialise le formulaire rapidement
- **Bouton Ajouter** = toggle pour gagner de l'espace à l'écran
- **Date par défaut** = aujourd'hui (peut être modifiée)

---

## ?? Support

Pour toute question ou problème technique, contactez l'administrateur système.

**Version de l'application** : 1.0  
**Date de documentation** : 2024  
**Auteur** : SB (Safwane Bada)

---

*Cette documentation couvre toutes les fonctionnalités disponibles dans l'application GSB2. Elle est destinée aux utilisateurs finaux (médecins et administrateurs).*
