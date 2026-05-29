using System;
using System.Windows.Forms;
using MediaTekDocuments.controller;

namespace MediaTekDocuments.vue
{
    /// <summary>
    /// Formulaire de connexion à l'application MediaTekDocuments.
    /// Permet au responsable de s'authentifier avec son login et son mot de passe.
    /// </summary>
    public partial class FrmConnexion : Form
    {
        /// <summary>
        /// Instance du contrôleur principal.
        /// </summary>
        private readonly FrmMediaTekController controller;

        /// <summary>
        /// Constructeur du formulaire de connexion.
        /// Initialise les composants graphiques et récupère le contrôleur.
        /// </summary>
        public FrmConnexion()
        {
            InitializeComponent();
            controller = FrmMediaTekController.GetInstance();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Se connecter".
        /// Vérifie les identifiants et ouvre le formulaire principal si corrects.
        /// </summary>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string pwd   = txtPwd.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show(
                    "Veuillez saisir votre login et votre mot de passe.",
                    "Champs obligatoires",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (controller.VerifierResponsable(login, pwd))
            {
                // Connexion réussie : ouverture du formulaire principal
                FrmMediaTek frmPrincipal = new FrmMediaTek();
                this.Hide();
                frmPrincipal.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Login ou mot de passe incorrect. Veuillez réessayer.",
                    "Erreur de connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPwd.Clear();
                txtLogin.Focus();
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Annuler".
        /// Ferme l'application.
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
