using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Infrastructure.Adapters.Facebook;

namespace C12Ex03Y314440009V319512893
{
    public class Sorter
    {
        private Comparer m_Comparer;

        public Comparer Comparer
        {
            get { return m_Comparer; }
            set { m_Comparer = value; }
        }

        public Sorter(Comparer i_Comparer)
        {
            m_Comparer = i_Comparer;
        }

        public void Sort(object[] i_Array)
        {
            for (int g = i_Array.Length / 2; g > 0; g /= 2)
            {
                for (int i = g; i < i_Array.Length; i++)
                {
                    for (int j = i - g; j >= 0; j -= g)
                    {
                        if (m_Comparer.ShouldSwap(
                            i_Array[j], i_Array[j + g]))
                        {
                            ////doSwap(i_Array[j] , i_Array[j + g] );
                            object temp = i_Array[j];
                            i_Array[j] = i_Array[j + g];
                            i_Array[j + g] = temp;
                        }
                    }
                }
            }
        }

        private void doSwap(object io_Num1, object io_Num2)
        {
            object temp = io_Num1;
            io_Num1 = io_Num2;
            io_Num2 = temp;
        }
    }
}
