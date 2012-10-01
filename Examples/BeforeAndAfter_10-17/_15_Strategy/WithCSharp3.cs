using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Linq;

namespace _15_Strategy
{
    public class WithCSharp3
    {
        public static void Run()
        {
            const int k_Len = 10;
            int[] numbers = new int[10];
            Random rand = new Random();
            for (int i = 0; i < k_Len; i++)
            {
                numbers[i] = rand.Next(10);
                Console.Write(numbers[i].ToString() + " ");
            }

            Console.WriteLine();

            /// use a delegate to a method as the strategy:
            Sorter sorter = new Sorter(new Func<int, int, bool>(biggerFirstMethod));

            /// we can also dump the explicit creation of the delegate object:
            sorter = new Sorter(biggerFirstMethod);

            ///or, use anonymous method:
            sorter = new Sorter(
                delegate(int num1, int num2)
                {
                    return num1 < num2;
                });

            ///or, use LAMBDA expressions (shorter syntax):
            sorter = new Sorter((num1, num2) => num1 > num2);

            sorter.Sort(numbers);
            foreach(int num in numbers)
            {
                Console.Write(num.ToString() + ",");
            }
            Console.WriteLine();

            /// Lets sort down:
            sorter.ComparerMethod = ((num1, num2) => num1 < num2);
            sorter.Sort(numbers);
            foreach (int num in numbers)
            {
                Console.Write(num.ToString() + ",");
            }
            Console.WriteLine();
        }

        private static bool biggerFirstMethod(int i_Num1, int i_Num2)
        {
            return i_Num1 > i_Num2;
        }

        /// using the Func<T1, T2, R> generic delegate instead of defining a new one:
        /// public delegate bool IntComparerDelegate(int x, int y);

        public class Sorter
        {
            /// use a delegate to a method as the strategy:
            public Func<int, int, bool> ComparerMethod { get; set; } 

            public Sorter(Func<int, int, bool> i_ComparerMethod)
            {
                ComparerMethod = i_ComparerMethod;
            }

            public void Sort(int[] i_Array)
            {
                for (int g = i_Array.Length / 2; g > 0; g /= 2)
                {
                    for (int i = g; i < i_Array.Length; i++)
                    {
                        for (int j = i - g; j >= 0; j -= g)
                        {
                            if (ComparerMethod.Invoke(i_Array[j], i_Array[j + g]))
                            {
                                doSwap(ref i_Array[j], ref i_Array[j + g]);
                            }
                        }
                    }
                }
            }

            private void doSwap(ref int io_Num1, ref int io_Num2)
            {
                int temp = io_Num1;
                io_Num1 = io_Num2;
                io_Num2 = temp;
            }
        }


        /// Just a demo for a good use of lambda expression:
        private void lambdaExpressionDemo()
        {
            List<Customer> customers = new List<Customer>(){
                new Customer(){Name="Guy", Age=50, ID="35454554"},
                new Customer(){Name="Avi", Age=36, ID="64684544"},
                new Customer(){Name="Nir", Age=45, ID="54354545"},
                new Customer(){Name="Tom", Age=22, ID="34534564"},
                new Customer(){Name="Tal", Age=56, ID="45646456"}
            };

            int maxAge = int.Parse(Console.ReadLine());

            /// note that we can use the local var maxAge inside the lambda expression!!
            /// imagine the alternative of using a regular predicate delegate
            /// which points to a predicate method..
            List<Customer> young = customers.FindAll(customer => customer.Age < maxAge);
        }

        public class Customer
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }
        }
    }
}
