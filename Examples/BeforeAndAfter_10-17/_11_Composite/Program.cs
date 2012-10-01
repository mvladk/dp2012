using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11_Composite
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("- BEFORE -");
            Before.Run();
            Console.WriteLine("=== Press 'Enter' to continue ===");
            Console.ReadLine();
            Console.WriteLine("- AFTER -");
            After.Run();
            Console.WriteLine("=== Press 'Enter' to continue ===");
            Console.ReadLine();
        }
    }
}
