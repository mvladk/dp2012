using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Proxy
{
    public interface IImage
    {
        void Draw();
    }

    public class After
    {
        public static void Run()
        {
            IImage[] images = new ImageProxy[5];
            for (int i = 0; i < images.Length; ++i)
            {
                images[i] = new ImageProxy();
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

    public class ImageProxy : IImage
    {
        // 1. The proxy holds a pointer to the real class
        RealImage m_RealImage;
        int m_Id;
        static int s_Next = 1;

        public ImageProxy()
        {
            m_Id = s_Next++;
            // 2. Initialized to null
            m_RealImage = null;
        }

        public void Draw()
        {
            // 3. When a request comes in, the real object is
            //    created "on first use"
            if (m_RealImage == null)
            {
                m_RealImage = new RealImage();
            }

            // 4. The request is always delegated
            m_RealImage.Draw();
        }

    }

    public class RealImage : IImage
    {
        int m_id;
        static int s_next = 1;

        public RealImage()
        {
            m_id = s_next++;
            Console.WriteLine("** ctor:" + m_id);
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Image " + m_id);
        }
    }
}
