using System;

namespace MediaTekDocuments.modele
{
    /// <summary>
    /// Classe qui représente une absence d'un membre du personnel.
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Identifiant unique de l'absence.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifiant du personnel concerné par l'absence.
        /// </summary>
        public int IdPersonnel { get; set; }

        /// <summary>
        /// Date de début de l'absence.
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'absence.
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Identifiant du motif de l'absence.
        /// </summary>
        public int IdMotif { get; set; }

        /// <summary>
        /// Objet Motif associé à l'absence.
        /// </summary>
        public Motif Motif { get; set; }

        /// <summary>
        /// Constructeur de la classe Absence.
        /// </summary>
        /// <param name="id">Identifiant de l'absence.</param>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début.</param>
        /// <param name="dateFin">Date de fin.</param>
        /// <param name="idMotif">Identifiant du motif.</param>
        /// <param name="motif">Objet Motif associé.</param>
        public Absence(int id, int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif, Motif motif)
        {
            Id          = id;
            IdPersonnel = idPersonnel;
            DateDebut   = dateDebut;
            DateFin     = dateFin;
            IdMotif     = idMotif;
            Motif       = motif;
        }
    }
}
