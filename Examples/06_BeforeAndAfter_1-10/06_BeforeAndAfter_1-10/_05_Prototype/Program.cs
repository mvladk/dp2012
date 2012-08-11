using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Prototype
{
    class Program
    {
        public static void Main()
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

#if OUTPUT
- BEFORE -
Type: 1/2/3/Draw: 2
Type: 1/2/3/Draw: 1
Type: 1/2/3/Draw: 2
Type: 1/2/3/Draw: 3
Type: 1/2/3/Draw: Draw
Circle
Square
Circle
Triangle
=== Press 'Enter' to continue ===

- AFTER -
Type: 1/2/3/Draw: 2
Type: 1/2/3/Draw: 1
Type: 1/2/3/Draw: 2
Type: 1/2/3/Draw: 3
Type: 1/2/3/Draw: Draw
Circle
Square
Circle
Triangle
=== Press 'Enter' to continue ===

- WITH C# 3.0 -
Type: 1/2/3/Draw: 3
Type: 1/2/3/Draw: 2
Type: 1/2/3/Draw: 3
Type: 1/2/3/Draw: 1
Type: 1/2/3/Draw: Draw
Triangle
Circle
Triangle
Square

Press 'Enter' to exit
#endif
