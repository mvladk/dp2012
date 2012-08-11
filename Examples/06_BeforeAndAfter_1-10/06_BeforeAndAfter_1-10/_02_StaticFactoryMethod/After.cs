using System;
using System.Collections.Generic;
using System.Text;

namespace _02_StaticFactoryMethod
{
    public class After
    {
        internal static void Run()
        {
            List<Shape> shapes =
                new List<Shape>();

            string choice = string.Empty;

            while (choice != "Draw")
            {
                // let user choose shapes
                Console.Write(
                    "Type: Circle/Square/Triangle/Draw: ");

                choice = Console.ReadLine();

                if (choice != "Draw")
                {
                    shapes.Add(Shape.CreateShape(choice));
                }
            }

            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }
        }


        public abstract class Shape
        {
            /// <summary>
            ///  The base class of the concrete polymorphic classes
            ///  exposes a static public factory method
            /// </summary>
            /// <param name="i_Choice">A parameter for choosing the concrete instance to be cerated</param>
            /// <returns>a reference to the newly created concrete instance</returns>
            public static Shape CreateShape(string i_Choice)
            {
                /// NOTE:
                /// This code could be easily replaced with
                /// a code that reads a configuration file
                /// which holds inforamtion (that can be updated/modified)
                /// regarding which instance to create in respect to i_Choice

                if (i_Choice == "Square")
                {
                    return new Square();
                }
                else if (i_Choice == "Circle")
                {
                    return new Circle();
                }
                else if (i_Choice == "Triangle")
                {
                    return new Triangle();
                }
                else
                {
                    return null;
                }
            }

            public abstract void Draw();
        }

        public class Square : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Square");
            }
        }

        public class Circle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Circle");
            }
        }

        public class Triangle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Triangle");
            }
        }
    }
}
