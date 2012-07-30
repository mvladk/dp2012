using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsAndLocks
{
	public class Program
	{
        public static void Main()
		{
			Thread[] threads = new Thread[4];
			Account account = new Account(1000);

			for(int i = 0 ; i < 4 ; ++i)
			{
                AccountWrapperForThreading wrapper = new AccountWrapperForThreading(account, (i+1)*30);
                wrapper.Finished += new EventHandler(wrapper_Finished);
                /// Creating a thread that holds a reference to the DoTransactions method
                threads[i] = new Thread(new ThreadStart(wrapper.DoTransactions));
                /// naming the thread so we can identify it when it finishes
                threads[i].Name = "Thread 0" + i;
			}

            foreach (Thread thread in threads)
            {
                /// executing the tread
                /// and passing a delegate to the thread_Finished method
                /// as the parameter
                thread.Start();
            }

            Console.ReadKey();
		}

        private static void wrapper_Finished(object sender, EventArgs e)
        {
            // note: this method is being executed from each on of the threads.
            // when it is executed, the Thread.CurrentThread is not the main thread!
            Console.WriteLine(Thread.CurrentThread.Name + " ******* Finished");
        }
	}

    public class AccountWrapperForThreading
    {
        public Account TheAccount { get; set; }
        public int MaxAmount { get; set; }
        public event EventHandler Finished;

        public AccountWrapperForThreading(Account i_Account, int i_MaxAmount)
        {
            MaxAmount = i_MaxAmount;
            TheAccount = i_Account;
        }

        public void DoTransactionsAsync()
        {
            Thread thread = new Thread(new ThreadStart(this.DoTransactions));
            thread.Start();
        }

        public void DoTransactions()
        {
            TheAccount.DoTransactions(MaxAmount);
            if (Finished != null)
            {
                Finished.Invoke(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// The original class
    /// </summary>
	public class Account
	{
        int m_Balance;
        Random m_Random = new Random();

		public Account(int i_InitialBalance)
		{
			m_Balance = i_InitialBalance;
        }

        public void DoTransactions(int i_MaxAmount)
        {
            for (int i = 0; i < 10; i++)
            {
                Withdraw(m_Random.Next(1, i_MaxAmount));
            }
        }

        private readonly object m_LockWithdraw = new object();
        int Withdraw(int amount)
		{
            if (m_Balance < 0)
            {
                Console.WriteLine("!!!! Negative Balance !!!!!  (" + m_Balance + ")");
                amount = 0;
            }
            else
            {
                lock (m_LockWithdraw)
                {
                    if (m_Balance >= amount)
                    {
                        Console.WriteLine("Balance before Withdrawal :  " + m_Balance);
                        Console.WriteLine("Amount to Withdraw        :  " + amount);

                        m_Balance = m_Balance - amount;

                        Console.WriteLine("Balance after Withdrawal  :  " + m_Balance);
                    }
                    else
                    {
                        Console.WriteLine("Can't withdraw {0}. Account has only {1}", amount, m_Balance);
                        amount = 0;
                    }
                }
            }

            return amount;
		}
	}
}