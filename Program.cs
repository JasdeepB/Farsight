using Farsight.UI_s_and_Controllers;
using System;
using System.Windows.Forms;

namespace Farsight
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
            JSONParser.Runes();
            mainScreen Parent = new mainScreen();
            LCUInterface.IsLCUActive(Parent);
            LCUInterface lCUInterface = new LCUInterface(Parent);
            Application.Run(Parent);
        }
    }
}
