namespace MediaTekDocuments.modele
{
    /// <summary>
    /// Classe qui représente le responsable de l'application.
    /// </summary>
    public class Responsable
    {
        /// <summary>
        /// Login du responsable.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Mot de passe hashé en SHA256 du responsable.
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// Constructeur de la classe Responsable.
        /// </summary>
        /// <param name="login">Login du responsable.</param>
        /// <param name="pwd">Mot de passe hashé du responsable.</param>
        public Responsable(string login, string pwd)
        {
            Login = login;
            Pwd   = pwd;
        }
    }
}
