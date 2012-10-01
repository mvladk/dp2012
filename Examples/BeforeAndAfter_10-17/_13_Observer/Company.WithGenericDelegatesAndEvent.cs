using System;
using System.Collections.Generic;
using System.Text;

namespace _13_Observer.WithGenericDelegatesAndEvent
{
    /// <summary>
    /// This company holds employies, which can callback the company to report sick,
    /// via a pre-defined delegate, accessed with 'public event' keyword
    /// </summary>
    public class SomeCompany
    {
        public readonly List<Employee> m_Workers = new List<Employee>();

        public SomeCompany()
        {
            Employee worker = new Employee("3-4565776");
            worker.m_ReportSickDelegates += new Action<string>(this.reportSick);
            m_Workers.Add(worker);

            worker = new Employee("3-2345685");
            /// you can also avoid the explicit creation of the delegate object:
            worker.m_ReportSickDelegates += this.reportSick;
            m_Workers.Add(worker);

            worker = new Employee("3-1231245");
            /// you can also attach an anonymous "inline" method to the delegate:
            worker.m_ReportSickDelegates += 
                (string i_WorkerID) => Console.WriteLine("worker {0} is sick :(", i_WorkerID);

            m_Workers.Add(worker);
        }

        private void reportSick(string i_WorkerID)
        {
            Console.WriteLine("worker {0} is sick :(", i_WorkerID);
        }
    }
}
