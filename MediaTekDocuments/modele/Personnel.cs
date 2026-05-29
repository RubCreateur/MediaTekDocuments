namespace MediaTekDocuments.modele
{
    /// <summary>
    /// Classe qui représente un membre du personnel d'une médiathèque.
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Identifiant unique du personnel.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du personnel.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du personnel.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Numéro de téléphone du personnel.
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Adresse mail du personnel.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Identifiant du service auquel est affecté le personnel.
        /// </summary>
        public int IdService { get; set; }

        /// <summary>
        /// Objet Service auquel est affecté le personnel.
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// Constructeur de la classe Personnel.
        /// </summary>
        /// <param name="id">Identifiant du personnel.</param>
        /// <param name="nom">Nom du personnel.</param>
        /// <param name="prenom">Prénom du personnel.</param>
        /// <param name="tel">Téléphone du personnel.</param>
        /// <param name="mail">Adresse mail du personnel.</param>
        /// <param name="idService">Identifiant du service.</param>
        /// <param name="service">Objet Service associé.</param>
        public Personnel(int id, string nom, string prenom, string tel, string mail, int idService, Service service)
        {
            Id        = id;
            Nom       = nom;
            Prenom    = prenom;
            Tel       = tel;
            Mail      = mail;
            IdService = idService;
            Service   = service;
        }

        /// <summary>
        /// Retourne le nom et le prénom du personnel.
        /// </summary>
        /// <returns>Nom et prénom du personnel.</returns>
        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
