using System;
using System.Collections.Generic;
using System.Text;

namespace _17_Command
{
    /// <summary>
    ///  The 'before' demonstrates how the naive implementation of the menu
    ///  makes it:
    ///  a. Non-reusable (in order to use the menu mechanism in a differnt program you will need to copy its code..)
    ///  b. Non-Efficient (always needs to go through the switch-case for each selection)
    ///  c. Hard to maintain (in case of adding/removing menu items, we will need to update more than on spot in the menu mechanism)
    ///  d. Tighly-coupled with the client of the menu mechanism (the menu mechanism "knows" the client and has direct access to it's methods)
    ///  and many other problems..
    /// </summary>
    public class Before
    {
        public static void Run()
        {
            new Before().loopWithMenu();
        }

        private void loopWithMenu()
        {
            bool userQuit = false;
            string userSelection = string.Empty;
            while (!userQuit)
            {
                showMenu();
                try
                {
                    userQuit = !getUserSelection(out userSelection);
                    if (!userQuit)
                    {
                        Console.Clear();
                        switch (userSelection)
                        {
                            case "1":
                                printHello();
                                break;
                            case "2":
                                printTheDate();
                                break;
                            case "3":
                                printTheTime();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private bool getUserSelection(out string o_UserSelection)
        {
            bool userQuit = false;
            o_UserSelection = Console.ReadLine();
            if (o_UserSelection.ToLower() != "q")
            {
                int selection = int.Parse(o_UserSelection);
                if (!(selection > 0 && selection < 4))
                {
                    throw new ArgumentException("You must select a number between 1-3");
                }
            }
            else
            {
                userQuit = true;
            }

            return !userQuit;
        }

        private void showMenu()
        {
            Console.WriteLine(@"
Please choose:
1. Print Hello
2. Print the date
3. Print the time
Type the your selection number and press 'enter'.
To quit type 'Q' and then 'enter'
");
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
}
