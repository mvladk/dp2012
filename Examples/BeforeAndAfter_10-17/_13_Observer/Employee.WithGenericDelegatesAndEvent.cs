using System;
using System.Collections.Generic;
using System.Text;

namespace _13_Observer.WithGenericDelegatesAndEvent
{
    public class Employee
    {
        private const float k_FeverThreshold = 37;
        private string m_ID;
        private float m_Fever = 36.7f;
        bool m_Sick = false;

        /// holding a reference to the pre-defined Action<T> delegate, definining it to be an Action<string>
        /// which makes it a delegate void Action(string s)
        public event Action<string> m_ReportSickDelegates;

        public Employee(string i_ID)
        {
            this.m_ID = i_ID;
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
            /// 4. report sick to who ever listens:
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
