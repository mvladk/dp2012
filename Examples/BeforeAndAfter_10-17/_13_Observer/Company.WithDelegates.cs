using System;
using System.Collections.Generic;
using System.Text;

namespace _13_Observer.WithDelegates
{
    /// <summary>
    /// This company holds employies, which can callback the company to report sick, via delegate
    /// </summary>
    public class SomeCompany
    {
        public readonly List<Employee> m_Workers = new List<Employee>();

        public SomeCompany()
        {
            /// Creating 2 employies, passing each a reference to a delegate to this company's report sick method
            Employee worker = new Employee("2-7683454");
            worker.AttachObserver(new ReportSickDelegate(this.reportSick));
            m_Workers.Add(worker);

            worker = new Employee("2-5672378");
            worker.AttachObserver(new ReportSickDelegate(this.reportSick));

        }

        private void reportSick(string m_WorkerID)
        {
            Console.WriteLine("worker {0} is sick :(", m_WorkerID);
        }
    }
}
