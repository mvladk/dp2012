// <copyright file="Program.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>

// $G$ THE-001 (-13) your grade on diagrams document - 87. please see comments inside the document. (75% of your grade).
// $G$ RUL-006 (-720) Late submission (-2 * 10 days + -1 * 16 days)

namespace C12Ex02Y314440009V319512893
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
