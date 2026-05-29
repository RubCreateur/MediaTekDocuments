using System;
using System.Collections.Generic;
using MediaTekDocuments.dal;
using MediaTekDocuments.modele;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur principal de l'application MediaTekDocuments.
    /// Fait le lien entre les vues (interfaces graphiques) et la couche DAL.
    /// Utilise le pattern Singleton pour n'avoir qu'une seule instance.
    /// </summary>
    public class FrmMediaTekController
    {
        /// <summary>
        /// Instance unique du contrôleur (pattern Singleton).
        /// </summary>
        private static FrmMediaTekController instance = null;

        /// <summary>
        /// Instance de la couche d'accès aux données.
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Constructeur privé : récupère l'instance d'Access.
        /// </summary>
        private FrmMediaTekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Retourne l'instance unique du contrôleur.
        /// Crée l'instance si elle n'existe pas encore.
        /// </summary>
        /// <returns>L'instance unique de FrmMediaTekController.</returns>
        public static FrmMediaTekController GetInstance()
        {
            if (instance == null)
            {
                instance = new FrmMediaTekController();
            }
            return instance;
        }

        // ================================================================
        // CONNEXION
        // ================================================================

        /// <summary>
        /// Vérifie les identifiants de connexion du responsable.
        /// </summary>
        /// <param name="login">Login saisi.</param>
        /// <param name="pwd">Mot de passe saisi.</param>
        /// <returns>True si les identifiants sont valides, False sinon.</returns>
        public bool VerifierResponsable(string login, string pwd)
        {
            return access.VerifierResponsable(login, pwd);
        }

        // ================================================================
        // SERVICES ET MOTIFS
        // ================================================================

        /// <summary>
        /// Récupère la liste de tous les services disponibles.
        /// </summary>
        /// <returns>Liste d'objets Service.</returns>
        public List<Service> GetAllServices()
        {
            return access.GetAllServices();
        }

        /// <summary>
        /// Récupère la liste de tous les motifs d'absence.
        /// </summary>
        /// <returns>Liste d'objets Motif.</returns>
        public List<Motif> GetAllMotifs()
        {
            return access.GetAllMotifs();
        }

        // ================================================================
        // PERSONNEL
        // ================================================================

        /// <summary>
        /// Récupère la liste de tout le personnel de la médiathèque.
        /// </summary>
        /// <returns>Liste d'objets Personnel.</returns>
        public List<Personnel> GetAllPersonnel()
        {
            return access.GetAllPersonnel();
        }

        /// <summary>
        /// Ajoute un nouveau membre du personnel.
        /// </summary>
        /// <param name="nom">Nom du personnel.</param>
        /// <param name="prenom">Prénom du personnel.</param>
        /// <param name="tel">Téléphone.</param>
        /// <param name="mail">Adresse mail.</param>
        /// <param name="idService">Identifiant du service.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool AjouterPersonnel(string nom, string prenom, string tel, string mail, int idService)
        {
            return access.AjouterPersonnel(nom, prenom, tel, mail, idService);
        }

        /// <summary>
        /// Modifie les informations d'un membre du personnel.
        /// </summary>
        /// <param name="id">Identifiant du personnel.</param>
        /// <param name="nom">Nouveau nom.</param>
        /// <param name="prenom">Nouveau prénom.</param>
        /// <param name="tel">Nouveau téléphone.</param>
        /// <param name="mail">Nouvelle adresse mail.</param>
        /// <param name="idService">Nouvel identifiant de service.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool ModifierPersonnel(int id, string nom, string prenom, string tel, string mail, int idService)
        {
            return access.ModifierPersonnel(id, nom, prenom, tel, mail, idService);
        }

        /// <summary>
        /// Supprime un membre du personnel ainsi que toutes ses absences.
        /// </summary>
        /// <param name="id">Identifiant du personnel à supprimer.</param>
        /// <returns>True si la suppression a réussi, False sinon.</returns>
        public bool SupprimerPersonnel(int id)
        {
            return access.SupprimerPersonnel(id);
        }

        // ================================================================
        // ABSENCES
        // ================================================================

        /// <summary>
        /// Récupère la liste des absences d'un membre du personnel.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <returns>Liste d'objets Absence.</returns>
        public List<Absence> GetAbsencesPersonnel(int idPersonnel)
        {
            return access.GetAbsencesPersonnel(idPersonnel);
        }

        /// <summary>
        /// Ajoute une absence après vérification qu'il n'y a pas de chevauchement.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début.</param>
        /// <param name="dateFin">Date de fin.</param>
        /// <param name="idMotif">Identifiant du motif.</param>
        /// <returns>True si l'ajout a réussi, False si chevauchement ou erreur.</returns>
        public bool AjouterAbsence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif)
        {
            if (access.VerifierChevauchement(idPersonnel, dateDebut, dateFin))
            {
                return false;
            }
            return access.AjouterAbsence(idPersonnel, dateDebut, dateFin, idMotif);
        }

        /// <summary>
        /// Modifie une absence après vérification qu'il n'y a pas de chevauchement.
        /// L'absence en cours de modification est exclue de la vérification.
        /// </summary>
        /// <param name="id">Identifiant de l'absence à modifier.</param>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Nouvelle date de début.</param>
        /// <param name="dateFin">Nouvelle date de fin.</param>
        /// <param name="idMotif">Nouvel identifiant du motif.</param>
        /// <returns>True si la modification a réussi, False si chevauchement ou erreur.</returns>
        public bool ModifierAbsence(int id, int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif)
        {
            if (access.VerifierChevauchement(idPersonnel, dateDebut, dateFin, id))
            {
                return false;
            }
            return access.ModifierAbsence(id, dateDebut, dateFin, idMotif);
        }

        /// <summary>
        /// Supprime une absence de la base de données.
        /// </summary>
        /// <param name="id">Identifiant de l'absence à supprimer.</param>
        /// <returns>True si la suppression a réussi, False sinon.</returns>
        public bool SupprimerAbsence(int id)
        {
            return access.SupprimerAbsence(id);
        }
    }
}
