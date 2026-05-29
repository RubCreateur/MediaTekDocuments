using System;
using MySql.Data.MySqlClient;

namespace MediaTekDocuments.bddmanager
{
    /// <summary>
    /// Classe technique singleton qui gère la connexion à la base de données MySQL.
    /// Une seule instance est créée pendant toute la durée de l'application.
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// Instance unique de la classe (pattern Singleton).
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// Objet de connexion à la base de données MySQL.
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Chaîne de connexion à la base de données mediatek86.
        /// Contient le serveur, le port, le nom de la BDD, l'utilisateur et le mot de passe.
        /// </summary>
        private static readonly string connectionString =
            "server=localhost;port=3306;database=mediatek86;uid=userMediatek;password=mdpMediatek86!;";

        /// <summary>
        /// Constructeur privé : crée et ouvre la connexion à la base de données.
        /// Privé pour empêcher la création directe d'une instance (pattern Singleton).
        /// </summary>
        /// <exception cref="Exception">Lancée si la connexion à la base de données échoue.</exception>
        private BddManager()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// Retourne l'instance unique de BddManager.
        /// Crée l'instance si elle n'existe pas encore (pattern Singleton).
        /// </summary>
        /// <returns>L'instance unique de BddManager.</returns>
        public static BddManager GetInstance()
        {
            if (instance == null)
            {
                instance = new BddManager();
            }
            return instance;
        }

        /// <summary>
        /// Exécute une requête SQL de type SELECT et retourne les résultats.
        /// </summary>
        /// <param name="requete">La requête SQL SELECT à exécuter.</param>
        /// <returns>Un MySqlDataReader contenant les lignes résultantes.</returns>
        public MySqlDataReader ExecuteSelect(string requete)
        {
            MySqlCommand cmd = new MySqlCommand(requete, connection);
            return cmd.ExecuteReader();
        }

        /// <summary>
        /// Exécute une requête SQL de type INSERT, UPDATE ou DELETE.
        /// </summary>
        /// <param name="requete">La requête SQL à exécuter.</param>
        /// <returns>True si au moins une ligne a été affectée, False sinon.</returns>
        public bool ExecuteNonQuery(string requete)
        {
            MySqlCommand cmd    = new MySqlCommand(requete, connection);
            int          lignes = cmd.ExecuteNonQuery();
            return (lignes > 0);
        }

        /// <summary>
        /// Retourne la chaîne de connexion utilisée par l'application.
        /// </summary>
        /// <returns>La chaîne de connexion à la base de données.</returns>
        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
