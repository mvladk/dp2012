using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _09_Proxy
{
    class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            //Console.WriteLine("- BEFORE -");
            //Before.Run();
            //Console.WriteLine("=== Press 'Enter' to continue ===");
            //Console.ReadLine();
            //Console.WriteLine("- AFTER -");
            //After.Run();
            //Console.WriteLine("=== Press 'Enter' to continue ===");
            //Console.ReadLine();
            Console.WriteLine("- WITH C# 3.0 -");
            WithCSharp3.Run();
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
