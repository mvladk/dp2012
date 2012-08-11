using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace _02_StaticFactoryMethod
{
    public class Before
    {
        public static void Run()
        {
            List<Shape> shapes =
                new List<Shape>();

            string choice = string.Empty;

            while (choice != "Draw")
            {
                // let user choose shapes:
                Console.Write(
                    "Type: Circle/Square/Triangle/Draw: ");

                choice = Console.ReadLine();

                if (choice == "Square")
                {
                    shapes.Add(new Square());
                }
                else if (choice == "Circle")
                {
                    shapes.Add(new Circle());
                }
                else if (choice == "Triangle")
                {
                    shapes.Add(new Triangle());
                }
            }

            foreach (Shape clown in shapes)
            {
                clown.Draw();
            }
        }

        public abstract class Shape
        {
            public abstract void Draw();
        }

        public class Square : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Square ");
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
                Console.WriteLine("Triangle ");
            }
        }
    }
}
