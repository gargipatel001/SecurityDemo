using LoginLibrary.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UserConsole.User
{
    public class Part4
    {
        static void Main(string[] args)
        {
            UserStore user = new UserStore();
            UserManager manager = new UserManager();
            string userName = "";
            string password = "";
            bool isUserCreated = false;

            WriteLine("Enter your User Name");
            user.UserName = ReadLine();
            WriteLine("Enter your Password");
            user.Password = ReadLine();
            WriteLine("Re-Enter your Password");
            user.ConfirmPassword = ReadLine();


            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.ConfirmPassword) && !string.IsNullOrWhiteSpace(user.ConfirmPassword))
            {
                
                if (user.Password != user.ConfirmPassword)
                {
                    WriteLine(manager.GetMessage(UserManager.MessageType.PASSWORDSDONOTMATCH));
                }
                else
                {
                    isUserCreated = manager.CreateUser(user, out userName,out password);
                    WriteLine(manager.GetMessage(UserManager.MessageType.CREATEUSERSUCCESS));
                }

            }
            else
            {
                WriteLine(manager.GetMessage(UserManager.MessageType.INVALIDINPUT));
            }
            ReadLine();
        }

      
    }
}
