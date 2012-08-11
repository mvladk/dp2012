using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Proxy
{
    public class Before
    {
        public static void Run()
        {
            Image[] images = new Image[5];
            for (int i = 0; i < images.Length; ++i)
            {
                images[i] = new Image();
            }

            int selection = 1;
            while (selection != 0)
            {
                Console.WriteLine("Exit[0], Image[1-5]: ");
                selection = int.Parse(Console.ReadLine());
                if (selection != 0)
                {
                    images[selection - 1].Draw();
                }
            }
        }
    }

    public class Image
    {
        int m_Id;
        static int s_Next = 1;

        public Image()
        {
            m_Id = s_Next++;
            Console.WriteLine("** ctor:" + m_Id);
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Image " + m_Id);
        }
    }
}
