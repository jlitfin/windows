using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExifDiscover
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
            
            //Application.Run(new ProcessingViews.ProcessFiles());

            //Application.Run(new ColorPalette());

            Application.Run(new ProcessingViews.ProcessFiles());
        }
    }
}