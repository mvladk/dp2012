using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("- BEFORE -");
            Before.Run();
            Console.WriteLine("=== Press 'Enter' to continue ===");
            Console.ReadLine();
            Console.WriteLine("- AFTER -");
            AfterWithGenerics.Run();
            Console.WriteLine("Press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
