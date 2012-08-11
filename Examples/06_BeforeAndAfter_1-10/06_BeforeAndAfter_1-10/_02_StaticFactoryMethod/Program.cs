using System;
using System.Collections.Generic;
using System.Text;

namespace _02_StaticFactoryMethod
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

#if Outoput
 Type: Circle/Square/Triangle/Draw: 2
 Type: Circle/Square/Triangle/Draw: 1
 Type: Circle/Square/Triangle/Draw: 3
 Type: Circle/Square/Triangle/Draw: Draw
 Circle
 Square
 Triangle
#endif
        }
	}
}
