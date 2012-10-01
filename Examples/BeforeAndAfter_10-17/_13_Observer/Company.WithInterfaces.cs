using System;
using System.Collections.Generic;
using System.Text;

namespace _13_Observer.WithIinterfaces
{
    /// <summary>
    /// This company holds employies, which can callback the company to report sick,
    /// by referencing it back as IReportSickListener
    /// </summary>
    public class Amdocs : ISicknessObserver
    {
        public readonly List<Employee> m_Workers = new List<Employee>();

        public Amdocs()
        {
            /// Creating 2 employies, passing each a reference to this company, as IReportSickListener
            Employee worker = new Employee("1-2345450");
            worker.AttachObserver(this as ISicknessObserver);
            m_Workers.Add(worker);

            worker = new Employee("1-3454560");
            worker.AttachObserver(this as ISicknessObserver);
            m_Workers.Add(worker);
        }

        public void ReportSick(string m_WorkerID)
        {
            Console.WriteLine("worker {0} is sick :(", m_WorkerID);
        }
    }
}
