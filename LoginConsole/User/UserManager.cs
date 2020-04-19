using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginConsole.DbAccess;

namespace LoginConsole.User
{
    public class UserManager
    {
        public enum MessageType { INVALIDINPUT, INVALIDUSER, VALIDUSER, CREATEUSERSUCCESS, PASSWORDSDONOTMATCH,USERALREADYEXISTS };

        public User GetUserbyDetails(User user)
        {
            User userDetails = new User();

            try
            {
                userDetails=new UserContext().Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return userDetails;
        }
       

        public string GetMessage(MessageType messageType)
        {
            string message = string.Empty;
            switch (messageType)
            {
                case MessageType.INVALIDINPUT:
                    message = "Ohho! Watch what you are writing!!!";
                    break;
                case MessageType.INVALIDUSER:
                    message = "Duhhh You are not one of us!!!";
                    break;
                case MessageType.VALIDUSER:
                    message = "Hurrah Welcome Bruh/Sista!!!";
                    break;
                case MessageType.CREATEUSERSUCCESS:
                    message = "Hurrah You are now a part of us!!!";
                    break;
                case MessageType.PASSWORDSDONOTMATCH:
                    message = "Yor passwords do not match!!!";
                    break;
                case MessageType.USERALREADYEXISTS:
                    message = "Your are already our comrade!!!Salute";
                    break;
                default:
                    break;
            }
            return message;
        }
    }
}
