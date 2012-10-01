﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _17_Command
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
            Console.WriteLine("- WITH C# 3.0 -");
            WithCSharp3.Run();
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
