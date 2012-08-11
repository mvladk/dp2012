using System;
using System.Collections.Generic;
using System.Text;

namespace Singletons
{
    public class SingleInstanceClass
    {
        // Private constructor to prevent
        // casual instantiation of this class.
        private SingleInstanceClass()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SingleInstanceClass created.");
            Console.ResetColor();

            _count++;
        }

        // Gets the single instance of SingleInstanceClass.
        public static SingleInstanceClass Instance
        {
            get { return Singleton<SingleInstanceClass>.Instance; }
        }

        public static int Count { get { return _count; } }
        public static void DoStatic()
        { Console.WriteLine("DoStatic() called."); }
        public void DoInstance()
        { Console.WriteLine("DoInstance() called."); }

        // Instance counter.
        private static int _count = 0;
    }

    class Program
    {
        static void Main()
        {
            // Show that initially the count is 0; calls
            // a static property which doesn't create the Singleton.
            Console.WriteLine("---");
            Console.WriteLine("Initial instance count: {0}",
                              SingleInstanceClass.Count);

            // Similar to above; show explicitly that calling
            // a static methods doesn't create the Singleton.
            Console.WriteLine("---");
            Console.WriteLine("Calling DoStatic()");
            SingleInstanceClass.DoStatic();
            Console.WriteLine("Instance count after DoStatic(): {0}",
                              SingleInstanceClass.Count);

            // Show that getting the instance creates the Singleton.
            Console.WriteLine("---");
            Console.WriteLine("Calling DoInstance()");
            SingleInstanceClass.Instance.DoInstance();
            Console.WriteLine("Instance count after first DoInstance(): {0}",
                              SingleInstanceClass.Count);

            // Show that getting the instance
            // again doesn't re-instantiate the class.
            Console.WriteLine("---");
            Console.WriteLine("Calling DoInstance()");
            SingleInstanceClass.Instance.DoInstance();
            Console.WriteLine("Instance count after second DoInstance(): {0}",
                              SingleInstanceClass.Count);
            Console.ReadKey();
        }
    }
}
