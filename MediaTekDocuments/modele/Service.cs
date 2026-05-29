namespace MediaTekDocuments.modele
{
    /// <summary>
    /// Classe qui représente un service de la médiathèque.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant unique du service.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du service.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Constructeur de la classe Service.
        /// </summary>
        /// <param name="id">Identifiant du service.</param>
        /// <param name="nom">Nom du service.</param>
        public Service(int id, string nom)
        {
            Id  = id;
            Nom = nom;
        }

        /// <summary>
        /// Retourne le nom du service (utilisé pour l'affichage dans les ComboBox).
        /// </summary>
        /// <returns>Le nom du service.</returns>
        public override string ToString()
        {
            return Nom;
        }
    }
}
