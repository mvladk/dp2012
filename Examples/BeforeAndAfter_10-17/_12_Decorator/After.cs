using System;
using System.Collections.Generic;
using System.Text;

namespace _12_Decorator
{
    public class After
    {
        public static void Run()
        {
            IDecorated anX = new DecoratorX(new CoreDecorated());
            IDecorated anXY = new DecoratorY(new DecoratorX(new CoreDecorated()));
            IDecorated anXYZ = new DecoratorZ(new DecoratorY(new DecoratorX(new CoreDecorated())));
            anX.Operation(); Console.WriteLine();
            anXY.Operation(); Console.WriteLine();
            anXYZ.Operation(); Console.WriteLine();
        }

        interface IDecorated
        {
            void Operation();
        }

        class CoreDecorated : IDecorated
        {
            public void Operation()
            { Console.Write("CoreDecorated"); }
        }

        class Decorator : IDecorated
        {
            protected IDecorated m_Decorated;
            public Decorator(IDecorated i_Decorated)
            { m_Decorated = i_Decorated; }

            public virtual void Operation()
            { m_Decorated.Operation(); }
        }

        class DecoratorX : Decorator
        {
            public DecoratorX(IDecorated i_Decorated) :
                base(i_Decorated) { }

            public override void Operation()
            {
                m_Decorated.Operation();
                Console.Write("X");
            }
        }

        class DecoratorY : Decorator
        {
            public DecoratorY(IDecorated i_Decorated) :
                base(i_Decorated) { }

            public override void Operation()
            {
                m_Decorated.Operation();
                Console.Write("Y");
            }
        }

        class DecoratorZ : Decorator
        {
            public DecoratorZ(IDecorated i_Decorated) :
                base(i_Decorated) { }

            public override void Operation()
            {
                m_Decorated.Operation();
                Console.Write("Z");
            }
        }
    }    
}
