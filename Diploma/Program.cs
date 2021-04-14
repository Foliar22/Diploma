using Diploma.Forms;
using System;
using System.Windows.Forms;

namespace Diploma
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        // Application.Run(new Authorization());
        Start:
            using (var loginForm = new Authorization())
            {
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

            }
            using (var mainFrom = new FormMain())
            {
                if (mainFrom.ShowDialog() == DialogResult.Cancel)
                {
                    goto Start;
                }
            }

        }
    }
}
