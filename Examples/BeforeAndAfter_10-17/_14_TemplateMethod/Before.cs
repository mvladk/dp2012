using System;
using System.Collections.Generic;
using System.Text;

namespace _14_TemplateMethod
{
    public class Before
    {
        /// The SortUp and SortDown classes are almost
        /// identical.  There is a massive opportunity
        /// for reuse - if - the embedded comparison
        /// could be refactored.
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

            SorterUp sortUpObj = new SorterUp();
            sortUpObj.sort(array);

            for (int u = 0; u < k_Len; u++)
            {
                Console.Write(array[u].ToString() + " ");
            }
            Console.WriteLine();

            SorterDown sortDownObj = new SorterDown();
            sortDownObj.sort(array);

            for (int u = 0; u < k_Len; u++)
            {
                Console.Write(array[u].ToString() + " ");
            }
            Console.WriteLine();
        }

        class SorterUp
        {
            /// Bubble sort ascending
            public void sort(int[] i_Array)
            {
                for (int g = i_Array.Length / 2; g > 0; g /= 2)
                {
                    for (int i = g; i < i_Array.Length; i++)
                    {
                        for (int j = i - g; j >= 0; j -= g)
                        {
                            if (i_Array[j] > i_Array[j + g])
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

        class SorterDown
        {
            /// Bubble sort descending
            public void sort(int[] i_Array)
            {
                for (int g = i_Array.Length / 2; g > 0; g /= 2)
                {
                    for (int i = g; i < i_Array.Length; i++)
                    {
                        for (int j = i - g; j >= 0; j -= g)
                        {
                            if (i_Array[j] < i_Array[j + g])
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
    }
}
