
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using LoginConsole.User;

namespace LoginConsole.User
{
    public class Part4
    {
        public void CreateUser()
        {
            UserStore userStore = new UserStore();
            User user = new User();
            UserManager manager = new UserManager();

            string confirmPassword = String.Empty;

            try
            {
                WriteLine("Enter your User Name");
                user.UserName = ReadLine();
                WriteLine("Enter your Password");
                user.Password = ReadLine();
                WriteLine("Re-Enter your Password");
                confirmPassword = ReadLine();
                WriteLine("");

                if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(confirmPassword) && !string.IsNullOrWhiteSpace(confirmPassword))
                {
                    if (user.Password != confirmPassword)
                    {
                        WriteLine(manager.GetMessage(UserManager.MessageType.PASSWORDSDONOTMATCH));
                    }
                    else
                    {
                        var userDetails = manager.GetUserbyDetails(user);
                        if (userDetails == null)
                        {
                            int id = userStore.CreateUser(user);
                            WriteLine(manager.GetMessage(UserManager.MessageType.CREATEUSERSUCCESS) + $"and your id is: {id}");
                        }
                        else
                        {
                            WriteLine(manager.GetMessage(UserManager.MessageType.USERALREADYEXISTS));
                        }                          
                    }
                }
                else
                {
                    WriteLine(manager.GetMessage(UserManager.MessageType.INVALIDINPUT));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
