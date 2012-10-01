using System;
using System.Collections.Generic;
using System.Text;

namespace _12_Decorator
{
    public class Before
    {
        public static void Run()
        {
            DecoratedwithX x = new DecoratedwithX();
            DecoratedwithXYZ xyz = new DecoratedwithXYZ();
            x.Operation(); Console.WriteLine();
            xyz.Operation(); Console.WriteLine();
        }

        class Decorated
        {
            public virtual void Operation()
            { Console.Write("Decorated"); }
        }

        class DecoratedwithX : Decorated
        {
            public override void Operation()
            {
                base.Operation();
                OperationX();
            }

            public void OperationX()
            { Console.Write(" X"); }
        }

        class DecoratedwithY : Decorated
        {
            public override void Operation()
            {
                base.Operation();
                OperationY();
            }

            public void OperationY()
            { Console.Write(" Y"); }
        }

        class DecoratedwithZ : Decorated
        {
            public override void Operation()
            {
                base.Operation();
                OperationZ();
            }

            public void OperationZ()
            { Console.Write(" Z"); }
        }

        class DecoratedwithXYZ : Decorated
        {
            public override void Operation()
            {
                base.Operation();
                OperationXYZ();
            }

            public void OperationXYZ()
            {
                new DecoratedwithX().OperationX();
                new DecoratedwithY().OperationY();
                new DecoratedwithZ().OperationZ();
            }
        }
    }
}
