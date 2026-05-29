# MediaTekDocuments

## Présentation du contexte et de la mission

MediaTek86 est un réseau qui gère les médiathèques du département de la Vienne. Son rôle est de fédérer les prêts de livres, DVD et CD et de développer la médiathèque numérique pour l'ensemble des médiathèques du département.

Dans le cadre d'une mission confiée par l'ESN InfoTech Services 86, j'ai développé une application de bureau permettant de **gérer le personnel de chaque médiathèque**, leur affectation à un service et leurs absences. Cette application monoposte est destinée au service administratif.

---

## Modèle Conceptuel de Données (MCD)

> *(Remplacer cette ligne par une capture d'écran du MCD créé avec Looping)*

![MCD](images/MCD.png)

---

## Diagramme de paquetages

L'application respecte l'architecture **MVC** organisée en packages :

```
MediaTekDocuments/
├── bddmanager/    → BddManager.cs      (singleton de connexion MySQL)
├── dal/           → Access.cs          (couche d'accès aux données)
├── modele/        → Service.cs         (classe métier Service)
│                  → Motif.cs           (classe métier Motif)
│                  → Responsable.cs     (classe métier Responsable)
│                  → Personnel.cs       (classe métier Personnel)
│                  → Absence.cs         (classe métier Absence)
├── controller/    → FrmMediaTekController.cs  (contrôleur MVC)
├── vue/           → FrmConnexion.cs    (formulaire de connexion)
│                  → FrmMediaTek.cs     (formulaire principal)
└── Program.cs     → Point d'entrée
```

> *(Remplacer cette ligne par une capture du diagramme de paquetages sous Visual Studio)*

![Diagramme de paquetages](images/diagramme_paquetages.png)

---

## Interfaces de l'application

### Formulaire de connexion
![Connexion](images/FrmConnexion.png)

Permet au responsable de s'authentifier avec son login et son mot de passe (vérifié via SHA256).

### Formulaire principal
![Principal](images/FrmMediaTek.png)

Permet de :
- Consulter la liste du personnel
- Ajouter, modifier et supprimer un membre du personnel
- Consulter les absences d'un personnel sélectionné
- Ajouter, modifier et supprimer une absence (avec détection de chevauchement automatique)

---

## Fonctionnalités couvertes

| Cas d'utilisation | Description | Statut |
|---|---|---|
| Se connecter | Authentification SHA256 du responsable | ✅ |
| Ajouter un personnel | Saisie nom, prénom, tel, mail, service | ✅ |
| Modifier un personnel | Modification de tous les champs | ✅ |
| Supprimer un personnel | Suppression avec ses absences (cascade) | ✅ |
| Afficher les absences | Liste des absences par personnel | ✅ |
| Ajouter une absence | Avec vérification anti-chevauchement | ✅ |
| Modifier une absence | Avec vérification anti-chevauchement | ✅ |
| Supprimer une absence | Suppression avec confirmation | ✅ |

---

## Étapes de construction et commits

### Étape 1 – Préparation de l'environnement et création de la BDD
- Installation de WampServer, Visual Studio 2022 Enterprise, Looping
- Création de la base de données `mediatek86` sous MySQL
- Création de l'utilisateur MySQL `userMediatek`
- Création de la table `responsable` avec login/pwd hashé
- Alimentation des tables service, motif, personnel (10), absence (50)

**Commit :** `Étape 1 : création BDD mediatek86 et alimentation des données de test`

---

### Étape 2 – Structure MVC, dépôt GitHub, visuel des interfaces
- Création du projet Windows Forms .NET Framework 4.7.2
- Création des packages bddmanager, dal, modele, controller, vue
- Création du dépôt distant sur GitHub
- Création du Kanban (GitHub Projects) avec toutes les issues
- Codage du visuel des formulaires FrmConnexion et FrmMediaTek

**Commit :** `Étape 2 : structure MVC + visuel des formulaires codé`

---

### Étape 3 – Modèle, BddManager, DAL, documentation technique
- Création de BddManager (singleton de connexion MySQL)
- Création des classes métiers (Service, Motif, Responsable, Personnel, Absence)
- Création d'Access (DAL) avec toutes les méthodes CRUD
- Génération de la documentation technique XML
- Ajout du zip de la documentation dans le projet

**Commit :** `Étape 3 : classes modèle + BddManager + DAL + doc technique`

---

### Étape 4 – Codage des fonctionnalités
- Codage du contrôleur FrmMediaTekController
- Codage de FrmConnexion (authentification SHA256)
- Codage de FrmMediaTek (CRUD personnel + CRUD absences)
- Gestion du chevauchement des absences
- Tests de toutes les fonctionnalités

**Commit :** `Étape 4 : toutes les fonctionnalités codées et testées`

---

### Étape 5 – Documentation utilisateur en vidéo
- Enregistrement d'une vidéo de 5 minutes
- Démonstration de toutes les fonctionnalités avec explications orales

**Commit :** `Étape 5 : documentation utilisateur vidéo`

---

### Étape 6 – Déploiement, Readme, Portfolio
- Création de l'installeur avec Visual Studio Installer Projects
- Génération du script SQL complet (CREATE + INSERT)
- Rédaction du Readme complet
- Création de la page portfolio

**Commit :** `Étape 6 : installeur + script SQL + readme final + portfolio`

---

## Installation

### Prérequis
- Windows 10 ou supérieur
- WampServer installé et démarré (icône verte dans la barre des tâches)
- .NET Framework 4.7.2 ou supérieur

### Étapes d'installation
1. Lancer WampServer et vérifier que l'icône est **verte**
2. Ouvrir **phpMyAdmin** (`http://localhost/phpmyadmin`)
3. Aller dans l'onglet **Importer** et importer le fichier `bdd/script_bdd.sql`
4. Lancer le fichier `setup.exe` de l'installeur
5. Suivre les étapes de l'assistant
6. Lancer l'application **MediaTekDocuments**
7. Se connecter avec :
   - Login : `admin`
   - Mot de passe : `admin123`

---

## Liens

- **Dépôt GitHub :** *(à compléter)*
- **Vidéo de démonstration :** *(à compléter)*
- **Page portfolio :** *(à compléter)*
