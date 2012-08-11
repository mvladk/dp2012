using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace _03_StaticFactoryClass
{
    public class Before
    {
        internal static void Run()
        {
            bool stillRuning = true;
            do
            {
                Console.Write("Please enter your full name: ");
                string fullName = Console.ReadLine();

                Namer namer;
                int i = fullName.IndexOf(",");
                if (i > 0)
                {
                    namer = new LastFirstNamer(fullName);
                }
                else
                {
                    namer = new FirstFirstNamer(fullName);
                }

                // polymorphically using the concrete namer:
                Console.WriteLine("First Name: {0}, Last Name: {1}",
                    namer.FirstName, namer.LastName);

                Console.WriteLine("Would you like to try again? (Y/N)");
                stillRuning = Console.ReadLine().ToLower() == "y";

            } while (stillRuning);
        }

        public abstract class Namer
        {
            protected string m_FirstName;
            public string FirstName
            {
                get { return m_FirstName; }
                set { m_FirstName = value; }
            }

            protected string m_LastName;
            public string LastName
            {
                get { return m_LastName; }
                set { m_LastName = value; }
            }
        }

        public class LastFirstNamer : Namer
        {
            public LastFirstNamer(string i_FullName)
            {
                int i = i_FullName.IndexOf(",");
                if (i > 0)
                {
                    m_LastName = i_FullName.Substring(0, i);
                    m_FirstName = i_FullName.Substring(i + 1).Trim();
                }
                else
                {
                    m_LastName = i_FullName;
                    m_FirstName = string.Empty;
                }
            }
        }

        public class FirstFirstNamer : Namer
        {
            public FirstFirstNamer(string i_FullName)
            {
                int i = i_FullName.IndexOf(" ");
                if (i > 0)
                {
                    m_FirstName = i_FullName.Substring(0, i).Trim();
                    m_LastName = i_FullName.Substring(i + 1).Trim();
                }
                else
                {
                    m_LastName = i_FullName;
                    m_FirstName = "";
                }
            }
        }
    }
}
