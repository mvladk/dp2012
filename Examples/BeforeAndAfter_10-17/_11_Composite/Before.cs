using System;
using System.Collections.Generic;
using System.Text;

namespace _11_Composite
{
    public class Before
    {
        public static void Run()
        {
            Folder dir1 = new Folder("dir1"),
                      dir2 = new Folder("dir2"),
                      dir3 = new Folder("dir3");

            File file1 = new File("file1"),
                file2 = new File("file2"),
                file3 = new File("file3"),
                file4 = new File("file4"),
                file5 = new File("file5");

            dir1.Add(file1);
            dir1.Add(dir2);
            dir2.Add(file3);
            dir2.Add(file4);
            dir2.Add(dir3);
            dir3.Add(file5);
            dir1.Add(file2);

            dir1.ls();
        }

        class File
        {
            private String m_Name;

            public File(String i_FileName)
            {
                m_Name = i_FileName;
            }

            public void ls()
            {
                Console.WriteLine(Folder.s_Indent + m_Name);
            }
        }

        class Folder
        {
            public static string s_Indent = string.Empty;

            private String m_Name;
            private List<object> m_Files = new List<object>();

            public Folder(String i_Name)
            {
                m_Name = i_Name;
            }

            public void Add(Object obj)
            {
                m_Files.Add(obj);
            }

            public void ls()
            {
                Console.WriteLine(s_Indent + m_Name);
                Folder.s_Indent += "   ";

                for (int i = 0; i < m_Files.Count; ++i)
                {
                    Object obj = m_Files[i];

                    /// ***** Recover the type of this object ******
                    if (obj is Folder)
                    {
                        ((Folder)obj).ls();
                    }
                    else
                    {
                        ((File)obj).ls();
                    }
                }

                Folder.s_Indent =
                    Folder.s_Indent.Substring(
                        0,
                        Folder.s_Indent.Length - 3);
            }
        }

        /// dir1
        ///    file1
        ///    dir2
        ///       file3
        ///       file4
        ///       dir3
        ///          file5
        ///    file2
    }
}
