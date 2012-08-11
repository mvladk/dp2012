using System;
using System.Collections.Generic;
using System.Text;

namespace _10_Composite
{
    public class WithCSharp3
    {
        public static void Run()
        {
            IShape[] shapes = { new ShapeAdapter(new LegacyLine()), new ShapeAdapter(new LegacyRectangle()) };
            // A begin and end point from a graphical editor
            int x1 = 10, y1 = 20;
            int x2 = 30, y2 = 60;
            for (int i = 0; i < shapes.Length; ++i)
            {
                shapes[i].draw(x1, y1, x2, y2);
            }
        }
    }

    // no need for that:
    public delegate void DrawDelegate(int x1, int y1, int x2, int y2);

    // adapter from Shape to Line
    public class ShapeAdapter : IShape
    {
        private Action<int, int, int, int> m_DrawDelegate;

        public void draw(int x1, int y1, int x2, int y2)
        {
            m_DrawDelegate.Invoke(x1, y1, x2, y2);
        }

        public ShapeAdapter (LegacyLine i_Line)
        {
            // delegating straight to the adoptee's method:
            // (no need to explicitly create a new instance of the delegate)
            m_DrawDelegate = i_Line.Draw;
        }

        public ShapeAdapter (LegacyRectangle i_Rectangle)
        {
            // delegating to an anonymous method:
            m_DrawDelegate = delegate(int x1, int y1, int x2, int y2)
            {
                i_Rectangle.Draw(Math.Min(x1, x2), Math.Min(y1, y2),
                          Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            };
        }
    }
}
