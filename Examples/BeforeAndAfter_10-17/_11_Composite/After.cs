using System;
using System.Collections.Generic;
using System.Text;

namespace _11_Composite
{
    public class After
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

        /// Define a "lowest common denominator"
        interface ISomethingThatCanResideInAFolder
        {
            void ls();
        }

        /// File implements the "lowest common denominator"
        class File : ISomethingThatCanResideInAFolder
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

        /// Directory implements the "lowest common denominator"
        class Folder : ISomethingThatCanResideInAFolder
        {
            public static string s_Indent = string.Empty;

            private String m_Name;
            private List<ISomethingThatCanResideInAFolder> m_Files = new List<ISomethingThatCanResideInAFolder>();

            public Folder(String i_Name)
            {
                m_Name = i_Name;
            }

            public void Add(ISomethingThatCanResideInAFolder i_FileOrFolder)
            {
                m_Files.Add(i_FileOrFolder);
            }

            public void ls()
            {
                Console.WriteLine(s_Indent + m_Name);
                Folder.s_Indent += "   ";

                /// ** Leverage the "lowest common denominator"
                foreach (ISomethingThatCanResideInAFolder abstractFile in m_Files)
                {
                    abstractFile.ls();
                }

                Folder.s_Indent =
                  Folder.s_Indent.Substring(0, Folder.s_Indent.Length - 3);
            }
        }
    }
}
