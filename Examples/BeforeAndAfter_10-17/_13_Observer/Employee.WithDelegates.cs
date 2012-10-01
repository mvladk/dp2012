using System;
using System.Collections.Generic;
using System.Text;

namespace _13_Observer.WithDelegates
{
    /// <summary>
    /// A delegate that holds a reference to [ void (string s) ] methods
    /// </summary>
    public delegate void ReportSickDelegate(string i_EmployeeID);
    ///This is a pseudo code of the delegate:
    ///public class ReportSickDelegate
    ///{
    ///    private int m_FuncAddr;

    ///    public Invoker(int i_FuncAddr of signature [ void (string s) ])
    ///    {
    ///        m_FuncAddr = i_FuncAddr;
    ///    }

    ///    public void Invoke(string i_WorkerID)
    ///    {
    ///        [INVOKE](m_FuncAddr, i_WorkerID);
    ///    }
    ///}

    public class Employee
    {
        private const float k_FeverThreshold = 37;
        private string m_ID;
        private float m_Fever = 36.7f;
        bool m_Sick = false;

        private ReportSickDelegate m_ReportSickDelegates;

        public Employee(string i_ID)
        {
            this.m_ID = i_ID;
        }

        public void AttachObserver(ReportSickDelegate i_ObserverDelegate)
        {
            m_ReportSickDelegates += i_ObserverDelegate;
        }

        public void DetachObserver(ReportSickDelegate i_ObserverDelegate)
        {
            m_ReportSickDelegates -= i_ObserverDelegate;
        }

        public float Fever
        {
            get { return m_Fever; }
            set
            {
                if (m_Fever != value)
                {
                    m_Fever = value;
                    doWhenFeverChanged();
                }
            }
        }

        private void doWhenFeverChanged()
        {
            if (!m_Sick && m_Fever > k_FeverThreshold)
            {
                doWhenSick();
            }
            else if (m_Fever <= k_FeverThreshold)
            {
                m_Sick = false;
            }
        }

        private void doWhenSick()
        {
            m_Sick = true;

            /// 1. Take acamol
            /// 2. Drink tea
            /// 3. Go to bed
            /// 4. report sick to who ever cares:
            notifySickObservers();
        }

        private void notifySickObservers()
        {
            if (m_ReportSickDelegates != null)
            {
                m_ReportSickDelegates.Invoke(m_ID);

                /// which does this:
                ///foreach (ReportSickDelegate observerDelegate in m_ReportSickDelegates.GetInvocationList())
                ///{
                ///    observerDelegate.Invoke(m_ID);
                ///}
            }
        }
    }
}
