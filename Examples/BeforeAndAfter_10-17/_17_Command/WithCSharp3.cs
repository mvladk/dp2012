using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace _17_Command
{
    public class WithCSharp3
    {
        public static void Run()
        {
            WithCSharp3 after = new WithCSharp3();
            after.InitMenu();
            after.Execute();
        }

        Menu m_Menu;
        public void InitMenu()
        {
            m_Menu = new Menu();
            var menuItem1 = new MenuItemWithDelegate("Print Hello", new Action(printHello));
            var menuItem2 = new MenuItemWithDelegate("Print Date", new Action(printTheDate));
            var menuItem3 = new MenuItemWithDelegate("Print Time", new Action(printTheTime));
            m_Menu.AddRange(new MenuItem[] { menuItem1, menuItem2, menuItem3 });
        }

        public void Execute()
        {
            m_Menu.Run();
        }

        private void printHello()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void printTheDate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(DateTime.Now.ToLongDateString());
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void printTheTime()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class MenuItemWithDelegate : MenuItem
    {
        protected Action m_CommandDelegate;

        public override void Selected()
        {
            if (m_CommandDelegate != null)
            {
                m_CommandDelegate.Invoke();
            }
        }

        public MenuItemWithDelegate(string i_Text, Action i_Comamnd)
        {
            m_Text = i_Text;
            m_CommandDelegate = i_Comamnd;
        }
    }
}
