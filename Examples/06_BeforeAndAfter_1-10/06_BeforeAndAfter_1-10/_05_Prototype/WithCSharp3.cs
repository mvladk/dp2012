using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Singletons;

namespace _01_Prototype
{
    public class WithCSharp3
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
                    try
                    {
                        shapes.Add(ShapesRepository.Instance.GetDeepCopy(choice));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }
        }

        [Serializable]
        public abstract class Prototype<T>
        {
            public T Clone()
            {
                return (T)this.MemberwiseClone(); // Shallow copy
            }

            public T DeepCopy()
            {// Deep Copy
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Seek(0, SeekOrigin.Begin);
                    T copy = (T)formatter.Deserialize(stream);
                    stream.Close();
                    return copy;
                }
            }

            public virtual string Key
            {
                get { return this.GetType().Name; }
            }
        }

        [Serializable]
        public abstract class Shape : Prototype<Shape>
        {
            public abstract void Draw();
        }

        public class PrototypeRepository<T> where T : Prototype<T>
        {
            protected readonly Dictionary<string, T> m_Dictionary = new Dictionary<string, T>();

            public void AddPrototype(T i_Prototype, string i_Key)
            {
                m_Dictionary.Add(i_Key, i_Prototype);
            }

            public void AddPrototype(T i_Prototype)
            {
                AddPrototype(i_Prototype, i_Prototype.Key);
            }

            public T GetDeepCopy(string i_Key)
            {
                return m_Dictionary[i_Key].DeepCopy();
            }

            public T GetShalowCopy(string i_Key)
            {
                return m_Dictionary[i_Key].Clone();
            }

            public T GetReference(string i_Key)
            {
                return m_Dictionary[i_Key];
            }
        }

        public class ShapesRepository : PrototypeRepository<Shape>
        {
            private ShapesRepository()
            {
                AddPrototype(new Square());
                AddPrototype(new Circle());
                AddPrototype(new Triangle());
            }

            public static ShapesRepository Instance
            {
                get { return Singleton<ShapesRepository>.Instance; }
            }
        }

        [Serializable]
        public class Square : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Square");
            }
        }

        [Serializable]
        public class Circle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Circle");
            }
        }

        [Serializable]
        public class Triangle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Triangle");
            }
        }
    }    
}
