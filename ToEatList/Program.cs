using System;
using System.Windows.Forms;

namespace Tangor.ToEatList
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainController controller = new MainController();
            Application.Run(controller.Form as Form);
        }
    }
}
