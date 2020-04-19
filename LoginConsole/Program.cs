
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginConsole.User;
using static System.Console;


namespace LoginConsole
{
    class Program
    {
        static void Main(string[] args)
        {            
            bool loop = true;
            string choice = string.Empty;
            try
            {
                while (loop)
                {
                    WriteLine("");
                    WriteLine("1. Lets get you a new account");
                    WriteLine("2. Lets see if you belong here");
                    WriteLine("3. Naaaah! I wanna be out of here");
                    WriteLine("Enter your Choice: ");
                    choice = ReadLine();
                    WriteLine("");
                    switch (choice.Trim())
                    {
                        case "1":
                            new Part4().CreateUser();
                            break;
                        case "2":
                            new Part1().CheckUser();
                            break;
                        case "3":
                            loop = false;
                            WriteLine("See you later Alligator!!!");
                            Read();
                            break;
                        default:
                            loop = true;
                            WriteLine("Hey how hard it is to select between 1,2 and 3?");
                            break;
                    }
                }
            }
            catch (Exception)
            {
                WriteLine("Some Error Occured! Please try after sometime");                
            }

        }

    }
}
