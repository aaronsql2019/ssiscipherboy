using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSISCipherBoy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new frmCipherBoy());
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);

            }
        }
    }
}
