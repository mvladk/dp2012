using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Prototype
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
					shapes.Add(ShapesRepository.GetShape(choice));
				}
			}

			foreach (Shape shape in shapes)
			{
				shape.Draw();
			}
		}

		public abstract class Shape // The prototype base class
		{
			public Shape Clone()
			{
				return this.MemberwiseClone() as Shape;
			}

			public abstract void Draw();
		}


		public static class ShapesRepository { // The prototype repository / mananger

			private static Dictionary<string, Shape> Shapes =
				new Dictionary<string, Shape>(){
				{"Square", new Square()},
				{"Circle", new Circle()},
				{"Triangle", new Triangle()}};
		
			public static void AddPrototype(Shape i_Shape, string i_Choice)
			{
			   Shapes.Add(i_Choice, i_Shape);
			}
		
			public static Shape GetShape(string i_Choice)
			{
				return Shapes[i_Choice].Clone();
			}
		}

		public class Square : Shape // concrete prototype class
		{
			public override void Draw()
			{
				Console.WriteLine("Square");
			}
		}

		public class Circle : Shape // concrete prototype class
		{
			public override void Draw()
			{
				Console.WriteLine("Circle");
			}
		}

		public class Triangle : Shape // concrete prototype class
		{
			public override void Draw()
			{
				Console.WriteLine("Triangle");
			}
		}
	}
}
