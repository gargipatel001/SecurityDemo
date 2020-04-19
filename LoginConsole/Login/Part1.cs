using LoginLibrary.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LoginConsole.Login
{
    public class Part1
    {
        static void Main(string[] args)
        {
           
            UserStore user = new UserStore();
            UserManager manager = new UserManager();
            string userName = "test";
            string password = "test";
            bool isUserValid = false;
            WriteLine("Enter your User Name");
            user.UserName = ReadLine();
            WriteLine("Enter your Password");
            user.Password = ReadLine();

            if(!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password))
            {
                isUserValid = manager.ValidateUser(user, userName, password);
                if (isUserValid)
                {
                    WriteLine(manager.GetMessage(UserManager.MessageType.VALIDUSER));
                }
                else
                {
                    WriteLine(manager.GetMessage(UserManager.MessageType.INVALIDUSER));
                }
                
            }
            else
            {
                WriteLine(manager.GetMessage(UserManager.MessageType.INVALIDINPUT));  
            }

            
            
            Read();


            


        }
    }
}
