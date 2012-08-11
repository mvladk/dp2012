using System;
using System.Collections.Generic;
using System.Text;

namespace _03_StaticFactoryClass
{
    public class Program
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
            Console.WriteLine("- NO C# 3.0 EXAMPLE-");
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to exit");
            Console.ReadLine();
        }

#if Outoput
- BEFORE -
Please enter your full name: Guy Ronen
First Name: Guy, Last Name: Ronen
Would you like to try again? (Y/N)
y
Please enter your full name: Ronen, Guy
First Name: Guy, Last Name: Ronen
Would you like to try again? (Y/N)
n
=== Press 'Enter' to continue ===

- AFTER -
Please enter your full name: Guy Ronen
First Name: Guy, Last Name: Ronen
Would you like to try again? (Y/N)
y
Please enter your full name: Ronen, Guy
First Name: Guy, Last Name: Ronen
Would you like to try again? (Y/N)
n
=== Press 'Enter' to continue ===
#endif
    }
}
