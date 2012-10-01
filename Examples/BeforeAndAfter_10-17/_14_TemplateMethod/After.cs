using System;
using System.Collections.Generic;
using System.Text;

namespace _14_TemplateMethod
{
    public class After
    {
        public static void Run()
        {
            const int k_Len = 10;
            int[] array = new int[k_Len];
            Random rand = new Random();
            for (int i = 0; i < k_Len; i++)
            {
                array[i] = rand.Next(10);
                Console.Write(array[i].ToString() + " ");
            }

            Console.WriteLine();

            SorterBase[] sorts = new SorterBase[] { new SorterUp(), new SorterDown() };

            sorts[0].Sort(array);
            for (int u = 0; u < k_Len; u++)
            {
                Console.Write(array[u].ToString() + " ");
            }
            Console.WriteLine();

            sorts[1].Sort(array);
            for (int u = 0; u < k_Len; u++)
            {
                Console.Write(array[u].ToString() + " ");
            }
            Console.WriteLine();
        }

        abstract class SorterBase
        {
            /// Bubble sort template method
            public void Sort(int[] i_Array)
            {
                for (int g = i_Array.Length / 2; g > 0; g /= 2)
                {
                    for (int i = g; i < i_Array.Length; i++)
                    {
                        for (int j = i - g; j >= 0; j -= g)
                        {
                            /// calling the template method
                            if (needSwap(i_Array[j], i_Array[j + g]))
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

            protected abstract bool needSwap(int i_Num1, int i_Num2);
        }

        class SorterUp : SorterBase
        {
            protected override bool needSwap(int i_Num1, int i_Num2)
            {
                return (i_Num1 > i_Num2);
            }
        }

        class SorterDown : SorterBase
        {
            protected override bool needSwap(int i_Num1, int i_Num2)
            {
                return (i_Num1 < i_Num2);
            }
        }
    }
}

