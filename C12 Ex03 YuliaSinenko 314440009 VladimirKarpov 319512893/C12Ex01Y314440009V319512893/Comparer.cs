using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C12Ex03Y314440009V319512893
{
    /// the strategy declaration
    public abstract class Comparer
    {
        abstract public bool ShouldSwap(int i_Num1, int i_Num2);
    }

    /// a strategy implementation
    public class ComparerDown : Comparer
    {
        public override bool ShouldSwap(int i_Num1, int i_Num2)
        {
            return i_Num1 > i_Num2;
        }
    }

    /// another strategy implementation
    public class ComparerUp : Comparer
    {
        public override bool ShouldSwap(int i_Num1, int i_Num2)
        {
            return i_Num1 < i_Num2;
        }
    }
}
