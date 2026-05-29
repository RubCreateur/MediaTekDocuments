# MediaTekDocuments

## Présentation du contexte et de la mission

MediaTek86 est un réseau qui gère les médiathèques du département de la Vienne. Son rôle est de fédérer les prêts de livres, DVD et CD et de développer la médiathèque numérique pour l'ensemble des médiathèques du département.

Dans le cadre d'une mission confiée par l'ESN InfoTech Services 86, j'ai développé une application de bureau permettant de **gérer le personnel de chaque médiathèque**, leur affectation à un service et leurs absences. Cette application monoposte est destinée au service administratif.

---

## Modèle Conceptuel de Données (MCD)


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
