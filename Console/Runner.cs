﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Console
{
    static class Runner
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller controller = new Controller();
        }
    }
}
