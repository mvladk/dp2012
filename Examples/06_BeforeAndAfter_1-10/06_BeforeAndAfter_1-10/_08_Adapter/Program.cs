using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_Composite
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("- BEFORE -");
            Before.Run();
            Console.WriteLine("=== Press 'Enter' to continue ===");
            Console.ReadLine();
            Console.WriteLine("- AFTER -");
            After.Run();
            Console.WriteLine("=== Press 'Enter' to continue ===");
            Console.ReadLine();
            Console.WriteLine("- WITH C# 3.0 -");
            WithCSharp3.Run();
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
