namespace MediaTekDocuments.modele
{
    /// <summary>
    /// Classe qui représente un motif d'absence.
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Identifiant unique du motif.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Libellé du motif d'absence.
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur de la classe Motif.
        /// </summary>
        /// <param name="id">Identifiant du motif.</param>
        /// <param name="libelle">Libellé du motif.</param>
        public Motif(int id, string libelle)
        {
            Id      = id;
            Libelle = libelle;
        }

        /// <summary>
        /// Retourne le libellé du motif (utilisé pour l'affichage dans les ComboBox).
        /// </summary>
        /// <returns>Le libellé du motif.</returns>
        public override string ToString()
        {
            return Libelle;
        }
    }
}
