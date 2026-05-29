using System;
using System.Windows.Forms;

namespace MediaTekDocuments
{
    /// <summary>
    /// Point d'entrée de l'application MediaTekDocuments.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// Lance le formulaire de connexion au démarrage.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new vue.FrmConnexion());
        }
    }
}
