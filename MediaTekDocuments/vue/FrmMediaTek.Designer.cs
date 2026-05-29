namespace MediaTekDocuments.vue
{
    partial class FrmMediaTek
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
            // ── Déclaration de tous les contrôles ──────────────────────
            this.grpPersonnel          = new System.Windows.Forms.GroupBox();
            this.dgvPersonnel          = new System.Windows.Forms.DataGridView();
            this.colId                 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom                = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrenom             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTel                = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMail               = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colService            = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.grpSaisiePersonnel    = new System.Windows.Forms.GroupBox();
            this.lblNom                = new System.Windows.Forms.Label();
            this.txtNom                = new System.Windows.Forms.TextBox();
            this.lblPrenom             = new System.Windows.Forms.Label();
            this.txtPrenom             = new System.Windows.Forms.TextBox();
            this.lblTel                = new System.Windows.Forms.Label();
            this.txtTel                = new System.Windows.Forms.TextBox();
            this.lblMail               = new System.Windows.Forms.Label();
            this.txtMail               = new System.Windows.Forms.TextBox();
            this.lblService            = new System.Windows.Forms.Label();
            this.cbxService            = new System.Windows.Forms.ComboBox();
            this.btnAjouterPersonnel   = new System.Windows.Forms.Button();
            this.btnModifierPersonnel  = new System.Windows.Forms.Button();
            this.btnSupprimerPersonnel = new System.Windows.Forms.Button();

            this.grpAbsences           = new System.Windows.Forms.GroupBox();
            this.dgvAbsences           = new System.Windows.Forms.DataGridView();
            this.colAbsId              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbsDebut           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbsFin             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbsMotif           = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.grpSaisieAbsence      = new System.Windows.Forms.GroupBox();
            this.lblDebut              = new System.Windows.Forms.Label();
            this.dtpDebut              = new System.Windows.Forms.DateTimePicker();
            this.lblFin                = new System.Windows.Forms.Label();
            this.dtpFin                = new System.Windows.Forms.DateTimePicker();
            this.lblMotif              = new System.Windows.Forms.Label();
            this.cbxMotif              = new System.Windows.Forms.ComboBox();
            this.btnAjouterAbsence     = new System.Windows.Forms.Button();
            this.btnModifierAbsence    = new System.Windows.Forms.Button();
            this.btnSupprimerAbsence   = new System.Windows.Forms.Button();

            // ── Suspension du layout ───────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).BeginInit();
            this.grpPersonnel.SuspendLayout();
            this.grpSaisiePersonnel.SuspendLayout();
            this.grpAbsences.SuspendLayout();
            this.grpSaisieAbsence.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════
            // GROUPE LISTE PERSONNEL
            // ════════════════════════════════════════════════════════════
            this.grpPersonnel.Controls.Add(this.dgvPersonnel);
            this.grpPersonnel.Location = new System.Drawing.Point(12, 12);
            this.grpPersonnel.Name     = "grpPersonnel";
            this.grpPersonnel.Size     = new System.Drawing.Size(760, 210);
            this.grpPersonnel.TabIndex = 0;
            this.grpPersonnel.TabStop  = false;
            this.grpPersonnel.Text     = "Liste du personnel";

            // dgvPersonnel
            this.dgvPersonnel.AllowUserToAddRows          = false;
            this.dgvPersonnel.AllowUserToDeleteRows       = false;
            this.dgvPersonnel.AllowUserToResizeRows       = false;
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colNom, this.colPrenom,
                this.colTel, this.colMail, this.colService });
            this.dgvPersonnel.Location          = new System.Drawing.Point(6, 19);
            this.dgvPersonnel.MultiSelect        = false;
            this.dgvPersonnel.Name               = "dgvPersonnel";
            this.dgvPersonnel.ReadOnly           = true;
            this.dgvPersonnel.RowHeadersVisible  = false;
            this.dgvPersonnel.SelectionMode      = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonnel.Size               = new System.Drawing.Size(748, 182);
            this.dgvPersonnel.TabIndex           = 0;
            this.dgvPersonnel.SelectionChanged  += new System.EventHandler(this.dgvPersonnel_SelectionChanged);

            // Colonnes personnel
            this.colId.HeaderText  = "ID";         this.colId.Name  = "colId";      this.colId.Width  = 0;   this.colId.Visible  = false;
            this.colNom.HeaderText = "Nom";         this.colNom.Name = "colNom";     this.colNom.Width = 140;
            this.colPrenom.HeaderText = "Prénom";   this.colPrenom.Name = "colPrenom"; this.colPrenom.Width = 140;
            this.colTel.HeaderText = "Téléphone";   this.colTel.Name = "colTel";     this.colTel.Width = 110;
            this.colMail.HeaderText = "Mail";       this.colMail.Name = "colMail";   this.colMail.Width = 210;
            this.colService.HeaderText = "Service"; this.colService.Name = "colService"; this.colService.Width = 140;

            // ════════════════════════════════════════════════════════════
            // GROUPE SAISIE PERSONNEL
            // ════════════════════════════════════════════════════════════
            this.grpSaisiePersonnel.Controls.Add(this.lblNom);
            this.grpSaisiePersonnel.Controls.Add(this.txtNom);
            this.grpSaisiePersonnel.Controls.Add(this.lblPrenom);
            this.grpSaisiePersonnel.Controls.Add(this.txtPrenom);
            this.grpSaisiePersonnel.Controls.Add(this.lblTel);
            this.grpSaisiePersonnel.Controls.Add(this.txtTel);
            this.grpSaisiePersonnel.Controls.Add(this.lblMail);
            this.grpSaisiePersonnel.Controls.Add(this.txtMail);
            this.grpSaisiePersonnel.Controls.Add(this.lblService);
            this.grpSaisiePersonnel.Controls.Add(this.cbxService);
            this.grpSaisiePersonnel.Controls.Add(this.btnAjouterPersonnel);
            this.grpSaisiePersonnel.Controls.Add(this.btnModifierPersonnel);
            this.grpSaisiePersonnel.Controls.Add(this.btnSupprimerPersonnel);
            this.grpSaisiePersonnel.Location = new System.Drawing.Point(12, 230);
            this.grpSaisiePersonnel.Name     = "grpSaisiePersonnel";
            this.grpSaisiePersonnel.Size     = new System.Drawing.Size(760, 165);
            this.grpSaisiePersonnel.TabIndex = 1;
            this.grpSaisiePersonnel.TabStop  = false;
            this.grpSaisiePersonnel.Text     = "Saisie / Modification d'un personnel";

            // Ligne 1 : Nom et Prénom
            this.lblNom.AutoSize = true; this.lblNom.Location = new System.Drawing.Point(10, 30); this.lblNom.Name = "lblNom"; this.lblNom.Text = "Nom :";
            this.txtNom.Location = new System.Drawing.Point(90, 27); this.txtNom.Name = "txtNom"; this.txtNom.Size = new System.Drawing.Size(160, 20); this.txtNom.TabIndex = 0;
            this.lblPrenom.AutoSize = true; this.lblPrenom.Location = new System.Drawing.Point(270, 30); this.lblPrenom.Name = "lblPrenom"; this.lblPrenom.Text = "Prénom :";
            this.txtPrenom.Location = new System.Drawing.Point(340, 27); this.txtPrenom.Name = "txtPrenom"; this.txtPrenom.Size = new System.Drawing.Size(160, 20); this.txtPrenom.TabIndex = 1;
            this.lblService.AutoSize = true; this.lblService.Location = new System.Drawing.Point(525, 30); this.lblService.Name = "lblService"; this.lblService.Text = "Service :";
            this.cbxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxService.Location = new System.Drawing.Point(590, 27); this.cbxService.Name = "cbxService"; this.cbxService.Size = new System.Drawing.Size(155, 21); this.cbxService.TabIndex = 2;

            // Ligne 2 : Tel et Mail
            this.lblTel.AutoSize = true; this.lblTel.Location = new System.Drawing.Point(10, 70); this.lblTel.Name = "lblTel"; this.lblTel.Text = "Téléphone :";
            this.txtTel.Location = new System.Drawing.Point(90, 67); this.txtTel.Name = "txtTel"; this.txtTel.Size = new System.Drawing.Size(160, 20); this.txtTel.TabIndex = 3;
            this.lblMail.AutoSize = true; this.lblMail.Location = new System.Drawing.Point(270, 70); this.lblMail.Name = "lblMail"; this.lblMail.Text = "Mail :";
            this.txtMail.Location = new System.Drawing.Point(340, 67); this.txtMail.Name = "txtMail"; this.txtMail.Size = new System.Drawing.Size(405, 20); this.txtMail.TabIndex = 4;

            // Ligne 3 : Boutons
            this.btnAjouterPersonnel.Location = new System.Drawing.Point(90, 110); this.btnAjouterPersonnel.Name = "btnAjouterPersonnel"; this.btnAjouterPersonnel.Size = new System.Drawing.Size(90, 30); this.btnAjouterPersonnel.TabIndex = 5; this.btnAjouterPersonnel.Text = "Ajouter"; this.btnAjouterPersonnel.UseVisualStyleBackColor = true;
            this.btnAjouterPersonnel.Click += new System.EventHandler(this.btnAjouterPersonnel_Click);
            this.btnModifierPersonnel.Location = new System.Drawing.Point(210, 110); this.btnModifierPersonnel.Name = "btnModifierPersonnel"; this.btnModifierPersonnel.Size = new System.Drawing.Size(90, 30); this.btnModifierPersonnel.TabIndex = 6; this.btnModifierPersonnel.Text = "Modifier"; this.btnModifierPersonnel.UseVisualStyleBackColor = true;
            this.btnModifierPersonnel.Click += new System.EventHandler(this.btnModifierPersonnel_Click);
            this.btnSupprimerPersonnel.Location = new System.Drawing.Point(330, 110); this.btnSupprimerPersonnel.Name = "btnSupprimerPersonnel"; this.btnSupprimerPersonnel.Size = new System.Drawing.Size(90, 30); this.btnSupprimerPersonnel.TabIndex = 7; this.btnSupprimerPersonnel.Text = "Supprimer"; this.btnSupprimerPersonnel.UseVisualStyleBackColor = true;
            this.btnSupprimerPersonnel.Click += new System.EventHandler(this.btnSupprimerPersonnel_Click);

            // ════════════════════════════════════════════════════════════
            // GROUPE LISTE ABSENCES
            // ════════════════════════════════════════════════════════════
            this.grpAbsences.Controls.Add(this.dgvAbsences);
            this.grpAbsences.Location = new System.Drawing.Point(12, 410);
            this.grpAbsences.Name     = "grpAbsences";
            this.grpAbsences.Size     = new System.Drawing.Size(760, 200);
            this.grpAbsences.TabIndex = 2;
            this.grpAbsences.TabStop  = false;
            this.grpAbsences.Text     = "Absences du personnel sélectionné";

            // dgvAbsences
            this.dgvAbsences.AllowUserToAddRows          = false;
            this.dgvAbsences.AllowUserToDeleteRows       = false;
            this.dgvAbsences.AllowUserToResizeRows       = false;
            this.dgvAbsences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAbsId, this.colAbsDebut, this.colAbsFin, this.colAbsMotif });
            this.dgvAbsences.Location         = new System.Drawing.Point(6, 19);
            this.dgvAbsences.MultiSelect       = false;
            this.dgvAbsences.Name              = "dgvAbsences";
            this.dgvAbsences.ReadOnly          = true;
            this.dgvAbsences.RowHeadersVisible = false;
            this.dgvAbsences.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsences.Size              = new System.Drawing.Size(748, 172);
            this.dgvAbsences.TabIndex          = 0;
            this.dgvAbsences.SelectionChanged += new System.EventHandler(this.dgvAbsences_SelectionChanged);

            // Colonnes absences
            this.colAbsId.HeaderText = "ID";          this.colAbsId.Name = "colAbsId";       this.colAbsId.Width = 0;   this.colAbsId.Visible = false;
            this.colAbsDebut.HeaderText = "Date début"; this.colAbsDebut.Name = "colAbsDebut"; this.colAbsDebut.Width = 130;
            this.colAbsFin.HeaderText = "Date fin";    this.colAbsFin.Name = "colAbsFin";     this.colAbsFin.Width = 130;
            this.colAbsMotif.HeaderText = "Motif";     this.colAbsMotif.Name = "colAbsMotif"; this.colAbsMotif.Width = 460;

            // ════════════════════════════════════════════════════════════
            // GROUPE SAISIE ABSENCE
            // ════════════════════════════════════════════════════════════
            this.grpSaisieAbsence.Controls.Add(this.lblDebut);
            this.grpSaisieAbsence.Controls.Add(this.dtpDebut);
            this.grpSaisieAbsence.Controls.Add(this.lblFin);
            this.grpSaisieAbsence.Controls.Add(this.dtpFin);
            this.grpSaisieAbsence.Controls.Add(this.lblMotif);
            this.grpSaisieAbsence.Controls.Add(this.cbxMotif);
            this.grpSaisieAbsence.Controls.Add(this.btnAjouterAbsence);
            this.grpSaisieAbsence.Controls.Add(this.btnModifierAbsence);
            this.grpSaisieAbsence.Controls.Add(this.btnSupprimerAbsence);
            this.grpSaisieAbsence.Location = new System.Drawing.Point(12, 620);
            this.grpSaisieAbsence.Name     = "grpSaisieAbsence";
            this.grpSaisieAbsence.Size     = new System.Drawing.Size(760, 110);
            this.grpSaisieAbsence.TabIndex = 3;
            this.grpSaisieAbsence.TabStop  = false;
            this.grpSaisieAbsence.Text     = "Saisie / Modification d'une absence";

            // Ligne 1 : Dates et Motif
            this.lblDebut.AutoSize = true; this.lblDebut.Location = new System.Drawing.Point(10, 30); this.lblDebut.Name = "lblDebut"; this.lblDebut.Text = "Date début :";
            this.dtpDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpDebut.Location = new System.Drawing.Point(100, 27); this.dtpDebut.Name = "dtpDebut"; this.dtpDebut.Size = new System.Drawing.Size(110, 20); this.dtpDebut.TabIndex = 0;
            this.lblFin.AutoSize = true; this.lblFin.Location = new System.Drawing.Point(230, 30); this.lblFin.Name = "lblFin"; this.lblFin.Text = "Date fin :";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpFin.Location = new System.Drawing.Point(300, 27); this.dtpFin.Name = "dtpFin"; this.dtpFin.Size = new System.Drawing.Size(110, 20); this.dtpFin.TabIndex = 1;
            this.lblMotif.AutoSize = true; this.lblMotif.Location = new System.Drawing.Point(430, 30); this.lblMotif.Name = "lblMotif"; this.lblMotif.Text = "Motif :";
            this.cbxMotif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMotif.Location = new System.Drawing.Point(485, 27); this.cbxMotif.Name = "cbxMotif"; this.cbxMotif.Size = new System.Drawing.Size(260, 21); this.cbxMotif.TabIndex = 2;

            // Ligne 2 : Boutons
            this.btnAjouterAbsence.Location = new System.Drawing.Point(100, 68); this.btnAjouterAbsence.Name = "btnAjouterAbsence"; this.btnAjouterAbsence.Size = new System.Drawing.Size(90, 30); this.btnAjouterAbsence.TabIndex = 3; this.btnAjouterAbsence.Text = "Ajouter"; this.btnAjouterAbsence.UseVisualStyleBackColor = true;
            this.btnAjouterAbsence.Click += new System.EventHandler(this.btnAjouterAbsence_Click);
            this.btnModifierAbsence.Location = new System.Drawing.Point(215, 68); this.btnModifierAbsence.Name = "btnModifierAbsence"; this.btnModifierAbsence.Size = new System.Drawing.Size(90, 30); this.btnModifierAbsence.TabIndex = 4; this.btnModifierAbsence.Text = "Modifier"; this.btnModifierAbsence.UseVisualStyleBackColor = true;
            this.btnModifierAbsence.Click += new System.EventHandler(this.btnModifierAbsence_Click);
            this.btnSupprimerAbsence.Location = new System.Drawing.Point(330, 68); this.btnSupprimerAbsence.Name = "btnSupprimerAbsence"; this.btnSupprimerAbsence.Size = new System.Drawing.Size(90, 30); this.btnSupprimerAbsence.TabIndex = 5; this.btnSupprimerAbsence.Text = "Supprimer"; this.btnSupprimerAbsence.UseVisualStyleBackColor = true;
            this.btnSupprimerAbsence.Click += new System.EventHandler(this.btnSupprimerAbsence_Click);

            // ════════════════════════════════════════════════════════════
            // FORMULAIRE PRINCIPAL
            // ════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(784, 750);
            this.Controls.Add(this.grpPersonnel);
            this.Controls.Add(this.grpSaisiePersonnel);
            this.Controls.Add(this.grpAbsences);
            this.Controls.Add(this.grpSaisieAbsence);
            this.MinimumSize     = new System.Drawing.Size(800, 800);
            this.Name            = "FrmMediaTek";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "MediaTek86 – Gestion du personnel et des absences";

            // ── Reprise du layout ──────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).EndInit();
            this.grpPersonnel.ResumeLayout(false);
            this.grpSaisiePersonnel.ResumeLayout(false);
            this.grpSaisiePersonnel.PerformLayout();
            this.grpAbsences.ResumeLayout(false);
            this.grpSaisieAbsence.ResumeLayout(false);
            this.grpSaisieAbsence.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // ── Déclaration des contrôles ──────────────────────────────────
        private System.Windows.Forms.GroupBox                  grpPersonnel;
        private System.Windows.Forms.DataGridView              dgvPersonnel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colService;
        private System.Windows.Forms.GroupBox                  grpSaisiePersonnel;
        private System.Windows.Forms.Label                     lblNom;
        private System.Windows.Forms.TextBox                   txtNom;
        private System.Windows.Forms.Label                     lblPrenom;
        private System.Windows.Forms.TextBox                   txtPrenom;
        private System.Windows.Forms.Label                     lblTel;
        private System.Windows.Forms.TextBox                   txtTel;
        private System.Windows.Forms.Label                     lblMail;
        private System.Windows.Forms.TextBox                   txtMail;
        private System.Windows.Forms.Label                     lblService;
        private System.Windows.Forms.ComboBox                  cbxService;
        private System.Windows.Forms.Button                    btnAjouterPersonnel;
        private System.Windows.Forms.Button                    btnModifierPersonnel;
        private System.Windows.Forms.Button                    btnSupprimerPersonnel;
        private System.Windows.Forms.GroupBox                  grpAbsences;
        private System.Windows.Forms.DataGridView              dgvAbsences;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbsDebut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbsFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbsMotif;
        private System.Windows.Forms.GroupBox                  grpSaisieAbsence;
        private System.Windows.Forms.Label                     lblDebut;
        private System.Windows.Forms.DateTimePicker            dtpDebut;
        private System.Windows.Forms.Label                     lblFin;
        private System.Windows.Forms.DateTimePicker            dtpFin;
        private System.Windows.Forms.Label                     lblMotif;
        private System.Windows.Forms.ComboBox                  cbxMotif;
        private System.Windows.Forms.Button                    btnAjouterAbsence;
        private System.Windows.Forms.Button                    btnModifierAbsence;
        private System.Windows.Forms.Button                    btnSupprimerAbsence;
    }
}
