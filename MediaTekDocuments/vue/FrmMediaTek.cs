using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTekDocuments.controller;
using MediaTekDocuments.modele;

namespace MediaTekDocuments.vue
{
    /// <summary>
    /// Formulaire principal de l'application MediaTekDocuments.
    /// Permet de gérer le personnel des médiathèques et leurs absences.
    /// </summary>
    public partial class FrmMediaTek : Form
    {
        /// <summary>
        /// Instance du contrôleur principal.
        /// </summary>
        private readonly FrmMediaTekController controller;

        /// <summary>
        /// Liste de tout le personnel chargé depuis la base de données.
        /// </summary>
        private List<Personnel> lePersonnel;

        /// <summary>
        /// Liste des services disponibles dans la base de données.
        /// </summary>
        private List<Service> lesServices;

        /// <summary>
        /// Liste des motifs d'absence disponibles dans la base de données.
        /// </summary>
        private List<Motif> lesMotifs;

        /// <summary>
        /// Membre du personnel actuellement sélectionné dans la liste.
        /// Null si aucun personnel n'est sélectionné.
        /// </summary>
        private Personnel personnelSelectionne;

        /// <summary>
        /// Absence actuellement sélectionnée dans la liste des absences.
        /// Null si aucune absence n'est sélectionnée.
        /// </summary>
        private Absence absenceSelectionnee;

        /// <summary>
        /// Constructeur du formulaire principal.
        /// Initialise les composants et charge les données depuis la base de données.
        /// </summary>
        public FrmMediaTek()
        {
            InitializeComponent();
            controller = FrmMediaTekController.GetInstance();
            ChargerDonnees();
        }

        // ================================================================
        // CHARGEMENT DES DONNÉES
        // ================================================================

        /// <summary>
        /// Charge toutes les données nécessaires depuis la base de données
        /// et remplit les listes et ComboBox de l'interface.
        /// </summary>
        private void ChargerDonnees()
        {
            // Chargement des services dans la ComboBox
            lesServices              = controller.GetAllServices();
            cbxService.DataSource    = new List<Service>(lesServices);
            cbxService.DisplayMember = "Nom";
            cbxService.ValueMember   = "Id";
            cbxService.SelectedIndex = -1;

            // Chargement des motifs dans la ComboBox
            lesMotifs                = controller.GetAllMotifs();
            cbxMotif.DataSource      = new List<Motif>(lesMotifs);
            cbxMotif.DisplayMember   = "Libelle";
            cbxMotif.ValueMember     = "Id";
            cbxMotif.SelectedIndex   = -1;

            // Chargement du personnel
            ChargerPersonnel();
        }

        /// <summary>
        /// Charge et affiche la liste du personnel dans le DataGridView.
        /// Réinitialise également les zones de saisie et la liste des absences.
        /// </summary>
        private void ChargerPersonnel()
        {
            lePersonnel = controller.GetAllPersonnel();
            dgvPersonnel.Rows.Clear();
            foreach (Personnel p in lePersonnel)
            {
                dgvPersonnel.Rows.Add(
                    p.Id,
                    p.Nom,
                    p.Prenom,
                    p.Tel,
                    p.Mail,
                    p.Service != null ? p.Service.Nom : "");
            }
            personnelSelectionne = null;
            absenceSelectionnee  = null;
            ViderZonePersonnel();
            dgvAbsences.Rows.Clear();
            ViderZoneAbsence();
        }

        /// <summary>
        /// Charge et affiche les absences d'un personnel dans le DataGridView des absences.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel dont on veut les absences.</param>
        private void ChargerAbsences(int idPersonnel)
        {
            List<Absence> lesAbsences = controller.GetAbsencesPersonnel(idPersonnel);
            dgvAbsences.Rows.Clear();
            foreach (Absence a in lesAbsences)
            {
                dgvAbsences.Rows.Add(
                    a.Id,
                    a.DateDebut.ToString("dd/MM/yyyy"),
                    a.DateFin.ToString("dd/MM/yyyy"),
                    a.Motif != null ? a.Motif.Libelle : "");
            }
            absenceSelectionnee = null;
            ViderZoneAbsence();
        }

        // ================================================================
        // VIDAGE DES ZONES DE SAISIE
        // ================================================================

        /// <summary>
        /// Vide les champs de saisie de la zone Personnel.
        /// </summary>
        private void ViderZonePersonnel()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtTel.Clear();
            txtMail.Clear();
            cbxService.SelectedIndex = -1;
        }

        /// <summary>
        /// Vide les champs de saisie de la zone Absence.
        /// </summary>
        private void ViderZoneAbsence()
        {
            dtpDebut.Value         = DateTime.Today;
            dtpFin.Value           = DateTime.Today;
            cbxMotif.SelectedIndex = -1;
            absenceSelectionnee    = null;
        }

        /// <summary>
        /// Remplit les champs de saisie avec les données du personnel donné.
        /// </summary>
        /// <param name="p">Le personnel dont on veut afficher les données.</param>
        private void RemplirZonePersonnel(Personnel p)
        {
            txtNom.Text    = p.Nom;
            txtPrenom.Text = p.Prenom;
            txtTel.Text    = p.Tel;
            txtMail.Text   = p.Mail;
            // Sélection du bon service dans la ComboBox
            for (int i = 0; i < cbxService.Items.Count; i++)
            {
                if (((Service)cbxService.Items[i]).Id == p.IdService)
                {
                    cbxService.SelectedIndex = i;
                    break;
                }
            }
        }

        // ================================================================
        // ÉVÉNEMENTS – DATAGRIDVIEW PERSONNEL
        // ================================================================

        /// <summary>
        /// Événement déclenché lors de la sélection d'une ligne dans le DataGridView personnel.
        /// Affiche les informations du personnel sélectionné et charge ses absences.
        /// </summary>
        private void dgvPersonnel_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count == 0) return;

            DataGridViewRow ligne       = dgvPersonnel.SelectedRows[0];
            int             idPersonnel = Convert.ToInt32(ligne.Cells["colId"].Value);

            personnelSelectionne = lePersonnel.Find(p => p.Id == idPersonnel);
            if (personnelSelectionne != null)
            {
                RemplirZonePersonnel(personnelSelectionne);
                ChargerAbsences(personnelSelectionne.Id);
            }
        }

        // ================================================================
        // ÉVÉNEMENTS – BOUTONS PERSONNEL
        // ================================================================

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Ajouter" un personnel.
        /// Valide la saisie puis ajoute le nouveau personnel dans la base de données.
        /// </summary>
        private void btnAjouterPersonnel_Click(object sender, EventArgs e)
        {
            if (!SaisiePersonnelValide()) return;

            string nom      = txtNom.Text.Trim();
            string prenom   = txtPrenom.Text.Trim();
            string tel      = txtTel.Text.Trim();
            string mail     = txtMail.Text.Trim();
            int    idService = ((Service)cbxService.SelectedItem).Id;

            if (controller.AjouterPersonnel(nom, prenom, tel, mail, idService))
            {
                MessageBox.Show(
                    "Le personnel a été ajouté avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ChargerPersonnel();
            }
            else
            {
                MessageBox.Show(
                    "Une erreur est survenue lors de l'ajout du personnel.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Modifier" un personnel.
        /// Valide la saisie puis modifie le personnel sélectionné dans la base de données.
        /// </summary>
        private void btnModifierPersonnel_Click(object sender, EventArgs e)
        {
            if (personnelSelectionne == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un membre du personnel à modifier.",
                    "Aucune sélection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (!SaisiePersonnelValide()) return;

            string nom      = txtNom.Text.Trim();
            string prenom   = txtPrenom.Text.Trim();
            string tel      = txtTel.Text.Trim();
            string mail     = txtMail.Text.Trim();
            int    idService = ((Service)cbxService.SelectedItem).Id;

            if (controller.ModifierPersonnel(personnelSelectionne.Id, nom, prenom, tel, mail, idService))
            {
                MessageBox.Show(
                    "Le personnel a été modifié avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ChargerPersonnel();
            }
            else
            {
                MessageBox.Show(
                    "Une erreur est survenue lors de la modification.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer" un personnel.
        /// Demande confirmation puis supprime le personnel et toutes ses absences.
        /// </summary>
        private void btnSupprimerPersonnel_Click(object sender, EventArgs e)
        {
            if (personnelSelectionne == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un membre du personnel à supprimer.",
                    "Aucune sélection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult reponse = MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer " + personnelSelectionne.ToString()
                + " ainsi que toutes ses absences ?",
                "Confirmer la suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (reponse == DialogResult.Yes)
            {
                if (controller.SupprimerPersonnel(personnelSelectionne.Id))
                {
                    MessageBox.Show(
                        "Le personnel a été supprimé avec succès.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ChargerPersonnel();
                }
                else
                {
                    MessageBox.Show(
                        "Une erreur est survenue lors de la suppression.",
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // ================================================================
        // ÉVÉNEMENTS – DATAGRIDVIEW ABSENCES
        // ================================================================

        /// <summary>
        /// Événement déclenché lors de la sélection d'une ligne dans le DataGridView des absences.
        /// Affiche les informations de l'absence sélectionnée dans les champs de saisie.
        /// </summary>
        private void dgvAbsences_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count == 0 || personnelSelectionne == null) return;

            DataGridViewRow ligne     = dgvAbsences.SelectedRows[0];
            int             idAbsence = Convert.ToInt32(ligne.Cells["colAbsId"].Value);

            List<Absence> lesAbsences = controller.GetAbsencesPersonnel(personnelSelectionne.Id);
            absenceSelectionnee = lesAbsences.Find(a => a.Id == idAbsence);

            if (absenceSelectionnee != null)
            {
                dtpDebut.Value = absenceSelectionnee.DateDebut;
                dtpFin.Value   = absenceSelectionnee.DateFin;
                for (int i = 0; i < cbxMotif.Items.Count; i++)
                {
                    if (((Motif)cbxMotif.Items[i]).Id == absenceSelectionnee.IdMotif)
                    {
                        cbxMotif.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        // ================================================================
        // ÉVÉNEMENTS – BOUTONS ABSENCES
        // ================================================================

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Ajouter" une absence.
        /// Valide la saisie, vérifie le chevauchement puis ajoute l'absence.
        /// </summary>
        private void btnAjouterAbsence_Click(object sender, EventArgs e)
        {
            if (personnelSelectionne == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un membre du personnel dans la liste.",
                    "Aucun personnel sélectionné",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (!SaisieAbsenceValide()) return;

            DateTime dateDebut = dtpDebut.Value.Date;
            DateTime dateFin   = dtpFin.Value.Date;
            int      idMotif   = ((Motif)cbxMotif.SelectedItem).Id;

            if (controller.AjouterAbsence(personnelSelectionne.Id, dateDebut, dateFin, idMotif))
            {
                MessageBox.Show(
                    "L'absence a été ajoutée avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ChargerAbsences(personnelSelectionne.Id);
            }
            else
            {
                MessageBox.Show(
                    "Impossible d'ajouter cette absence :\n" +
                    "les dates saisies chevauchent une absence déjà existante pour ce personnel.",
                    "Chevauchement détecté",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Modifier" une absence.
        /// Valide la saisie, vérifie le chevauchement puis modifie l'absence sélectionnée.
        /// </summary>
        private void btnModifierAbsence_Click(object sender, EventArgs e)
        {
            if (absenceSelectionnee == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une absence à modifier.",
                    "Aucune sélection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (!SaisieAbsenceValide()) return;

            DateTime dateDebut = dtpDebut.Value.Date;
            DateTime dateFin   = dtpFin.Value.Date;
            int      idMotif   = ((Motif)cbxMotif.SelectedItem).Id;

            if (controller.ModifierAbsence(
                    absenceSelectionnee.Id,
                    personnelSelectionne.Id,
                    dateDebut, dateFin, idMotif))
            {
                MessageBox.Show(
                    "L'absence a été modifiée avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ChargerAbsences(personnelSelectionne.Id);
            }
            else
            {
                MessageBox.Show(
                    "Impossible de modifier cette absence :\n" +
                    "les dates saisies chevauchent une autre absence déjà existante pour ce personnel.",
                    "Chevauchement détecté",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer" une absence.
        /// Demande confirmation puis supprime l'absence sélectionnée.
        /// </summary>
        private void btnSupprimerAbsence_Click(object sender, EventArgs e)
        {
            if (absenceSelectionnee == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une absence à supprimer.",
                    "Aucune sélection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult reponse = MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer cette absence ?",
                "Confirmer la suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (reponse == DialogResult.Yes)
            {
                if (controller.SupprimerAbsence(absenceSelectionnee.Id))
                {
                    MessageBox.Show(
                        "L'absence a été supprimée avec succès.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ChargerAbsences(personnelSelectionne.Id);
                }
                else
                {
                    MessageBox.Show(
                        "Une erreur est survenue lors de la suppression.",
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // ================================================================
        // VALIDATIONS
        // ================================================================

        /// <summary>
        /// Vérifie que les champs de saisie du personnel sont correctement remplis.
        /// </summary>
        /// <returns>True si la saisie est valide, False sinon.</returns>
        private bool SaisiePersonnelValide()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire.", "Champ manquant",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Le prénom est obligatoire.", "Champ manquant",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrenom.Focus();
                return false;
            }
            if (cbxService.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un service.", "Champ manquant",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxService.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Vérifie que les champs de saisie de l'absence sont correctement remplis.
        /// </summary>
        /// <returns>True si la saisie est valide, False sinon.</returns>
        private bool SaisieAbsenceValide()
        {
            if (dtpFin.Value.Date < dtpDebut.Value.Date)
            {
                MessageBox.Show(
                    "La date de fin ne peut pas être antérieure à la date de début.",
                    "Dates invalides",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            if (cbxMotif.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un motif d'absence.", "Champ manquant",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxMotif.Focus();
                return false;
            }
            return true;
        }
    }
}
