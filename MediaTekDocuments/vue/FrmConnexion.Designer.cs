namespace MediaTekDocuments.vue
{
    partial class FrmConnexion
    {
        /// <summary>
        /// Variable requise par le concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">True si les ressources managées doivent être supprimées.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            this.lblTitre     = new System.Windows.Forms.Label();
            this.lblLogin     = new System.Windows.Forms.Label();
            this.lblPwd       = new System.Windows.Forms.Label();
            this.txtLogin     = new System.Windows.Forms.TextBox();
            this.txtPwd       = new System.Windows.Forms.TextBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.btnAnnuler   = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ── lblTitre ──────────────────────────────────────────────
            this.lblTitre.AutoSize  = false;
            this.lblTitre.Font      = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location  = new System.Drawing.Point(12, 18);
            this.lblTitre.Name      = "lblTitre";
            this.lblTitre.Size      = new System.Drawing.Size(370, 32);
            this.lblTitre.TabIndex  = 0;
            this.lblTitre.Text      = "MediaTek86 – Connexion";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblLogin ──────────────────────────────────────────────
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(25, 75);
            this.lblLogin.Name     = "lblLogin";
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text     = "Login :";

            // ── txtLogin ──────────────────────────────────────────────
            this.txtLogin.Location  = new System.Drawing.Point(120, 72);
            this.txtLogin.Name      = "txtLogin";
            this.txtLogin.Size      = new System.Drawing.Size(240, 20);
            this.txtLogin.TabIndex  = 2;

            // ── lblPwd ────────────────────────────────────────────────
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(25, 115);
            this.lblPwd.Name     = "lblPwd";
            this.lblPwd.TabIndex = 3;
            this.lblPwd.Text     = "Mot de passe :";

            // ── txtPwd ────────────────────────────────────────────────
            this.txtPwd.Location     = new System.Drawing.Point(120, 112);
            this.txtPwd.Name         = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size         = new System.Drawing.Size(240, 20);
            this.txtPwd.TabIndex     = 4;

            // ── btnConnexion ──────────────────────────────────────────
            this.btnConnexion.Location = new System.Drawing.Point(75, 158);
            this.btnConnexion.Name     = "btnConnexion";
            this.btnConnexion.Size     = new System.Drawing.Size(110, 30);
            this.btnConnexion.TabIndex = 5;
            this.btnConnexion.Text     = "Se connecter";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);

            // ── btnAnnuler ────────────────────────────────────────────
            this.btnAnnuler.Location = new System.Drawing.Point(215, 158);
            this.btnAnnuler.Name     = "btnAnnuler";
            this.btnAnnuler.Size     = new System.Drawing.Size(80, 30);
            this.btnAnnuler.TabIndex = 6;
            this.btnAnnuler.Text     = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);

            // ── FrmConnexion ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(396, 215);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.btnAnnuler);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FrmConnexion";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Connexion – MediaTekDocuments";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label   lblTitre;
        private System.Windows.Forms.Label   lblLogin;
        private System.Windows.Forms.Label   lblPwd;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button  btnConnexion;
        private System.Windows.Forms.Button  btnAnnuler;
    }
}
