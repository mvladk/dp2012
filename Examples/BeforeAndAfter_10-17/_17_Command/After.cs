using System;
using System.Collections.Generic;
using System.Text;

namespace _17_Command
{
    /// <summary>
    ///  The 'after' demonstrates the classic implementation of the command pattern
    ///  and makes the menu mechanism:
    ///  a. Reusable (one can use the menu mechanism in a differnt program)
    ///  b. Efficient (no need to go through a switch-case for each selection. just executing the selected command)
    ///  c. Easy to maintain (in case of adding/removing menu items, we will only need to add/remove menu items)
    ///  d. Not coupled with the client of the menu mechanism (the menu mechanism does not "know" the client and has no direct access to it's methods)
    /// </summary>
    public class After
    {
        public static void Run()
        {
            After after = new After();
            after.InitMenu();
            after.Execute();
        }

        Menu m_Menu;
        public void InitMenu()
        {
            m_Menu = new Menu();
            MenuItem item1 = new MenuItem("Print Hello", new PrintHelloCommand(this));
            MenuItem item2 = new MenuItem("Print Date", new PrintDateCommand(this));
            MenuItem item3 = new MenuItem("Print Time", new PrintTimeCommand(this));
            m_Menu.AddRange(new MenuItem[] { item1, item2, item3 });
        }

        public void Execute()
        {
            m_Menu.Run();
        }

        private void PrintHello()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintTheDate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(DateTime.Now.ToLongDateString());
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintTheTime()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public class PrintHelloCommand : ICommand
        {
            After m_Client;
            public PrintHelloCommand(After i_Client)
            {
                m_Client = i_Client;
            }

            public void Execute()
            {
                m_Client.PrintHello();
            }
        }

        public class PrintDateCommand : ICommand
        {
            After m_Client;
            public PrintDateCommand(After i_Client)
            {
                m_Client = i_Client;
            }

            public void Execute()
            {
                m_Client.PrintTheDate();
            }
        }

        public class PrintTimeCommand : ICommand
        {
            After m_Client;
            public PrintTimeCommand(After i_Client)
            {
                m_Client = i_Client;
            }

            public void Execute()
            {
                m_Client.PrintTheTime();
            }
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class Menu : List<MenuItem>
    {
        public void Run()
        {
            bool userQuit = false;
            int userSelection;
            while (!userQuit)
            {
                ShowMenu();
                try
                {
                    userQuit = !GetUserSelection(out userSelection);
                    if (!userQuit)
                    {
                        Console.Clear();
                        this[userSelection - 1].Selected();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private bool GetUserSelection(out int o_UserSelection)
        {
            bool userQuit = false;
            string userSelection = Console.ReadLine();
            if (userSelection.ToLower() != "q")
            {
                o_UserSelection = int.Parse(userSelection);
                if (!(o_UserSelection > 0 && o_UserSelection <= this.Count))
                {
                    throw new ArgumentException("You must select a number between 1-3");
                }
            }
            else
            {
                o_UserSelection = 0;
                userQuit = true;
            }

            return !userQuit;
        }

        private void ShowMenu()
        {
            Console.WriteLine("Please choose:");

            int itemNum = 1;
            foreach (MenuItem item in this)
            {
                Console.Write(itemNum.ToString() + ": ");
                Console.WriteLine(item.Text);
                itemNum++;
            }

            Console.WriteLine(@"
Type the your selection number and press 'enter'.
To quit type 'Q' and then 'enter'
");
        }
    }

    public class MenuItem
    {
        protected ICommand m_Command;

        public ICommand Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }

        protected string m_Text;

        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        public virtual void Selected()
        {
            if (m_Command != null)
            {
                m_Command.Execute();
            }
        }

        public MenuItem()
        { }

        public MenuItem(string i_Text, ICommand i_Comamnd)
        {
            m_Text = i_Text;
            m_Command = i_Comamnd;
        }
    }
}
