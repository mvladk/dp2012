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
    class Sorter
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

        public void Sort(Album[] i_Array)
        {

            for (int g = i_Array.Length / 2; g > 0; g /= 2)
            {
                for (int i = g; i < i_Array.Length; i++)
                {
                    for (int j = i - g; j >= 0; j -= g)
                    {
                        if (m_Comparer.ShouldSwap(
                            i_Array[j].Photos.Count, i_Array[j + g].Photos.Count))
                        {
                            doSwap(ref i_Array[j] , ref i_Array[j + g]);
                        }
                    }
                }
            }
        }

        private void doSwap(ref Album io_Num1, ref Album io_Num2)
        {
            Album temp = io_Num1;
            io_Num1 = io_Num2;
            io_Num2 = temp;
        }
    }

}

