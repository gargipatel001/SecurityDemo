
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LoginConsole.User
{
    public class Part1
    {
        public void CheckUser()
        {
            UserManager manager = new UserManager();
            User user = new User();

            try
            {
                WriteLine("Enter your User Name");
                user.UserName = ReadLine();
                WriteLine("Enter your Password");
                user.Password = ReadLine();
                WriteLine("");
                if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password))
                {
                    var userDetails = manager.GetUserbyDetails(user);
                    if (userDetails != null && userDetails.ID > 0)
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
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
