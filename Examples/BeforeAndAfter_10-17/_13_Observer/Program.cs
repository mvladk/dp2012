using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13_Observer
{
    class Program
    {
        static void Main()
        {
            WithIinterfaces.Amdocs someCompany1 = new WithIinterfaces.Amdocs();
            someCompany1.m_Workers[1].Fever = 38;

            WithDelegates.SomeCompany someCompany2 = new WithDelegates.SomeCompany();
            someCompany2.m_Workers[1].Fever = 38;

            WithGenericDelegatesAndEvent.SomeCompany someCompany3 = new WithGenericDelegatesAndEvent.SomeCompany();
            someCompany3.m_Workers[1].Fever = 38;
        }
    }
}
