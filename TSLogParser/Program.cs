using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItracksLogParser
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

            //   string input = Microsoft.VisualBasic.Interaction.InputBox("Prompt", "Title", "Default", -1, -1);

                    Application.Run(new Form1());


        }
    }
}
