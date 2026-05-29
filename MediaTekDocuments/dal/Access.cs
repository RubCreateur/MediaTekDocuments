using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MediaTekDocuments.bddmanager;
using MediaTekDocuments.modele;
using MySql.Data.MySqlClient;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données (couche DAL).
    /// Contient toutes les méthodes qui interrogent ou modifient la base de données.
    /// Utilise le pattern Singleton pour n'avoir qu'une seule instance.
    /// </summary>
    public class Access
    {
        /// <summary>
        /// Instance unique de la classe Access (pattern Singleton).
        /// </summary>
        private static Access instance = null;

        /// <summary>
        /// Instance du BddManager pour accéder à la base de données.
        /// </summary>
        private readonly BddManager bddManager;

        /// <summary>
        /// Constructeur privé : récupère l'instance du BddManager.
        /// </summary>
        private Access()
        {
            bddManager = BddManager.GetInstance();
        }

        /// <summary>
        /// Retourne l'instance unique de la classe Access.
        /// Crée l'instance si elle n'existe pas encore.
        /// </summary>
        /// <returns>L'instance unique d'Access.</returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne la chaîne de connexion à la base de données.
        /// </summary>
        /// <returns>La chaîne de connexion.</returns>
        public string GetConnectionString()
        {
            return BddManager.GetConnectionString();
        }

        // ================================================================
        // RESPONSABLE
        // ================================================================

        /// <summary>
        /// Vérifie les identifiants du responsable dans la base de données.
        /// Le mot de passe saisi est hashé en SHA256 avant comparaison.
        /// </summary>
        /// <param name="login">Login saisi par l'utilisateur.</param>
        /// <param name="pwd">Mot de passe saisi en clair (sera hashé).</param>
        /// <returns>True si les identifiants sont corrects, False sinon.</returns>
        public bool VerifierResponsable(string login, string pwd)
        {
            string pwdHash = HashSHA256(pwd);
            string requete = "SELECT COUNT(*) FROM responsable WHERE login='"
                             + login + "' AND pwd='" + pwdHash + "';";
            MySqlDataReader reader  = bddManager.ExecuteSelect(requete);
            bool            valide  = false;
            if (reader.Read())
            {
                valide = (reader.GetInt32(0) == 1);
            }
            reader.Close();
            return valide;
        }

        // ================================================================
        // SERVICES
        // ================================================================

        /// <summary>
        /// Récupère la liste de tous les services depuis la base de données.
        /// </summary>
        /// <returns>Liste d'objets Service triés par nom.</returns>
        public List<Service> GetAllServices()
        {
            List<Service>   lesServices = new List<Service>();
            string          requete     = "SELECT id, nom FROM service ORDER BY nom;";
            MySqlDataReader reader      = bddManager.ExecuteSelect(requete);
            while (reader.Read())
            {
                int    id  = reader.GetInt32("id");
                string nom = reader.GetString("nom");
                lesServices.Add(new Service(id, nom));
            }
            reader.Close();
            return lesServices;
        }

        // ================================================================
        // MOTIFS
        // ================================================================

        /// <summary>
        /// Récupère la liste de tous les motifs d'absence depuis la base de données.
        /// </summary>
        /// <returns>Liste d'objets Motif triés par libellé.</returns>
        public List<Motif> GetAllMotifs()
        {
            List<Motif>     lesMotifs = new List<Motif>();
            string          requete   = "SELECT id, libelle FROM motif ORDER BY libelle;";
            MySqlDataReader reader    = bddManager.ExecuteSelect(requete);
            while (reader.Read())
            {
                int    id      = reader.GetInt32("id");
                string libelle = reader.GetString("libelle");
                lesMotifs.Add(new Motif(id, libelle));
            }
            reader.Close();
            return lesMotifs;
        }

        // ================================================================
        // PERSONNEL
        // ================================================================

        /// <summary>
        /// Récupère la liste de tout le personnel avec leur service associé.
        /// </summary>
        /// <returns>Liste d'objets Personnel triés par nom puis prénom.</returns>
        public List<Personnel> GetAllPersonnel()
        {
            List<Personnel> lePersonnel = new List<Personnel>();
            string requete =
                "SELECT p.id, p.nom, p.prenom, p.tel, p.mail, p.idService, s.nom AS nomService " +
                "FROM personnel p " +
                "JOIN service s ON p.idService = s.id " +
                "ORDER BY p.nom, p.prenom;";
            MySqlDataReader reader = bddManager.ExecuteSelect(requete);
            while (reader.Read())
            {
                int     id         = reader.GetInt32("id");
                string  nom        = reader.GetString("nom");
                string  prenom     = reader.GetString("prenom");
                string  tel        = reader.IsDBNull(reader.GetOrdinal("tel"))  ? "" : reader.GetString("tel");
                string  mail       = reader.IsDBNull(reader.GetOrdinal("mail")) ? "" : reader.GetString("mail");
                int     idService  = reader.GetInt32("idService");
                string  nomService = reader.GetString("nomService");
                Service service    = new Service(idService, nomService);
                lePersonnel.Add(new Personnel(id, nom, prenom, tel, mail, idService, service));
            }
            reader.Close();
            return lePersonnel;
        }

        /// <summary>
        /// Ajoute un nouveau membre du personnel dans la base de données.
        /// </summary>
        /// <param name="nom">Nom du personnel.</param>
        /// <param name="prenom">Prénom du personnel.</param>
        /// <param name="tel">Numéro de téléphone.</param>
        /// <param name="mail">Adresse mail.</param>
        /// <param name="idService">Identifiant du service.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool AjouterPersonnel(string nom, string prenom, string tel, string mail, int idService)
        {
            string requete =
                "INSERT INTO personnel (nom, prenom, tel, mail, idService) VALUES ('" +
                EchapperChaine(nom) + "', '" +
                EchapperChaine(prenom) + "', '" +
                EchapperChaine(tel) + "', '" +
                EchapperChaine(mail) + "', " +
                idService + ");";
            return bddManager.ExecuteNonQuery(requete);
        }

        /// <summary>
        /// Modifie les informations d'un membre du personnel dans la base de données.
        /// </summary>
        /// <param name="id">Identifiant du personnel à modifier.</param>
        /// <param name="nom">Nouveau nom.</param>
        /// <param name="prenom">Nouveau prénom.</param>
        /// <param name="tel">Nouveau téléphone.</param>
        /// <param name="mail">Nouvelle adresse mail.</param>
        /// <param name="idService">Nouvel identifiant de service.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool ModifierPersonnel(int id, string nom, string prenom, string tel, string mail, int idService)
        {
            string requete =
                "UPDATE personnel SET " +
                "nom='"       + EchapperChaine(nom)    + "', " +
                "prenom='"    + EchapperChaine(prenom) + "', " +
                "tel='"       + EchapperChaine(tel)    + "', " +
                "mail='"      + EchapperChaine(mail)   + "', " +
                "idService="  + idService +
                " WHERE id="  + id + ";";
            return bddManager.ExecuteNonQuery(requete);
        }

        /// <summary>
        /// Supprime un membre du personnel et toutes ses absences de la base de données.
        /// Les absences sont supprimées en premier pour respecter les contraintes de clé étrangère.
        /// </summary>
        /// <param name="id">Identifiant du personnel à supprimer.</param>
        /// <returns>True si la suppression a réussi, False sinon.</returns>
        public bool SupprimerPersonnel(int id)
        {
            // Suppression des absences liées d'abord (contrainte de clé étrangère)
            string requeteAbsences = "DELETE FROM absence WHERE idPersonnel=" + id + ";";
            bddManager.ExecuteNonQuery(requeteAbsences);
            // Suppression du personnel
            string requete = "DELETE FROM personnel WHERE id=" + id + ";";
            return bddManager.ExecuteNonQuery(requete);
        }

        // ================================================================
        // ABSENCES
        // ================================================================

        /// <summary>
        /// Récupère la liste des absences d'un membre du personnel donné.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <returns>Liste d'objets Absence triés par date de début.</returns>
        public List<Absence> GetAbsencesPersonnel(int idPersonnel)
        {
            List<Absence> lesAbsences = new List<Absence>();
            string requete =
                "SELECT a.id, a.idPersonnel, a.dateDebut, a.dateFin, a.idMotif, m.libelle " +
                "FROM absence a " +
                "JOIN motif m ON a.idMotif = m.id " +
                "WHERE a.idPersonnel=" + idPersonnel +
                " ORDER BY a.dateDebut;";
            MySqlDataReader reader = bddManager.ExecuteSelect(requete);
            while (reader.Read())
            {
                int      id        = reader.GetInt32("id");
                DateTime dateDebut = reader.GetDateTime("dateDebut");
                DateTime dateFin   = reader.GetDateTime("dateFin");
                int      idMotif   = reader.GetInt32("idMotif");
                string   libelle   = reader.GetString("libelle");
                Motif    motif     = new Motif(idMotif, libelle);
                lesAbsences.Add(new Absence(id, idPersonnel, dateDebut, dateFin, idMotif, motif));
            }
            reader.Close();
            return lesAbsences;
        }

        /// <summary>
        /// Vérifie si une période chevauche une absence existante pour un personnel donné.
        /// Permet d'exclure une absence lors d'une modification (pour ne pas se chevaucher avec elle-même).
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début à vérifier.</param>
        /// <param name="dateFin">Date de fin à vérifier.</param>
        /// <param name="idAbsenceExclure">Id de l'absence à exclure (0 pour un ajout).</param>
        /// <returns>True s'il y a chevauchement, False sinon.</returns>
        public bool VerifierChevauchement(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idAbsenceExclure = 0)
        {
            string exclusion = (idAbsenceExclure > 0) ? " AND id <> " + idAbsenceExclure : "";
            string requete =
                "SELECT COUNT(*) FROM absence " +
                "WHERE idPersonnel=" + idPersonnel +
                " AND NOT (dateFin < '" + dateDebut.ToString("yyyy-MM-dd") +
                "' OR dateDebut > '"    + dateFin.ToString("yyyy-MM-dd")   + "')" +
                exclusion + ";";
            MySqlDataReader reader        = bddManager.ExecuteSelect(requete);
            bool            chevauchement = false;
            if (reader.Read())
            {
                chevauchement = (reader.GetInt32(0) > 0);
            }
            reader.Close();
            return chevauchement;
        }

        /// <summary>
        /// Ajoute une nouvelle absence dans la base de données.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début de l'absence.</param>
        /// <param name="dateFin">Date de fin de l'absence.</param>
        /// <param name="idMotif">Identifiant du motif.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool AjouterAbsence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif)
        {
            string requete =
                "INSERT INTO absence (idPersonnel, dateDebut, dateFin, idMotif) VALUES (" +
                idPersonnel + ", '" +
                dateDebut.ToString("yyyy-MM-dd") + "', '" +
                dateFin.ToString("yyyy-MM-dd")   + "', " +
                idMotif + ");";
            return bddManager.ExecuteNonQuery(requete);
        }

        /// <summary>
        /// Modifie une absence existante dans la base de données.
        /// </summary>
        /// <param name="id">Identifiant de l'absence à modifier.</param>
        /// <param name="dateDebut">Nouvelle date de début.</param>
        /// <param name="dateFin">Nouvelle date de fin.</param>
        /// <param name="idMotif">Nouvel identifiant du motif.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool ModifierAbsence(int id, DateTime dateDebut, DateTime dateFin, int idMotif)
        {
            string requete =
                "UPDATE absence SET " +
                "dateDebut='" + dateDebut.ToString("yyyy-MM-dd") + "', " +
                "dateFin='"   + dateFin.ToString("yyyy-MM-dd")   + "', " +
                "idMotif="    + idMotif +
                " WHERE id="  + id + ";";
            return bddManager.ExecuteNonQuery(requete);
        }

        /// <summary>
        /// Supprime une absence de la base de données.
        /// </summary>
        /// <param name="id">Identifiant de l'absence à supprimer.</param>
        /// <returns>True si la suppression a réussi, False sinon.</returns>
        public bool SupprimerAbsence(int id)
        {
            string requete = "DELETE FROM absence WHERE id=" + id + ";";
            return bddManager.ExecuteNonQuery(requete);
        }

        // ================================================================
        // UTILITAIRES PRIVÉS
        // ================================================================

        /// <summary>
        /// Calcule le hash SHA256 d'une chaîne de caractères.
        /// Utilisé pour vérifier le mot de passe du responsable.
        /// </summary>
        /// <param name="input">La chaîne à hasher.</param>
        /// <returns>La chaîne hashée en hexadécimal minuscule.</returns>
        private string HashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[]        bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb    = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Échappe les apostrophes dans une chaîne pour éviter les erreurs SQL.
        /// </summary>
        /// <param name="chaine">La chaîne à échapper.</param>
        /// <returns>La chaîne avec les apostrophes doublées.</returns>
        private string EchapperChaine(string chaine)
        {
            if (string.IsNullOrEmpty(chaine)) return "";
            return chaine.Replace("'", "''");
        }
    }
}
