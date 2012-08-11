using System;
using System.Collections.Generic;
using System.Text;

namespace _10_Composite
{
    public class Before
    {
        public static void Run()
        {
            // We would like two use two shape objects did we got a legacy code.
            // this two objects are not polymorphic and do not expose the same Draw method
            // in order to hold them in one collection, we use an object array:
            Object[] shapes = new Object[]{ new LegacyLine(), new LegacyRectangle() };
            
            // A begin and end point from a graphical editor
            int x1 = 10, y1 = 20;
            int x2 = 30, y2 = 60;

            for (int i = 0; i < shapes.Length; ++i)
            {
                if (shapes[i] is LegacyLine)
                {
                    // The Line class has a Draw method takes 2 points:
                    ((LegacyLine)shapes[i]).Draw(x1, y1, x2, y2);
                }
                else if (shapes[i] is LegacyRectangle)
                {
                    // The Rectangle class has a Draw method takes a point and width/height:
                    ((LegacyRectangle)shapes[i]).Draw(
                          Math.Min(x1, x2), Math.Min(y1, y2),       // top/left point
                          Math.Abs(x2 - x1), Math.Abs(y2 - y1));    // width, height
                }
            }
        }
    }

    public class LegacyLine
    {
        // The Line class has a Draw method takes 2 points:
        public void Draw(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine("line from (" + x1 + ',' + y1 + ") to (" + x2 + ',' + y2 + ')' );
        }
    }

    public class LegacyRectangle
    {
        // The Rectangle class has a Draw method takes a point and width/height:
        public void Draw(int x, int y, int w, int h)
        {
            Console.WriteLine("rectangle at (" + x + ',' + y + ") with width " + w + " and height " + h );
        }
    }

}
