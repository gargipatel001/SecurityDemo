using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginLibrary.User
{
    public class UserManager
    {
        public enum MessageType{ INVALIDINPUT,INVALIDUSER,VALIDUSER,CREATEUSERSUCCESS,PASSWORDSDONOTMATCH};

        public bool ValidateUser(UserStore user,string username,string password)
        {
            if (user.UserName.Equals(username) && user.Password.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool CreateUser(UserStore user,out string username,out string password)
        {
            username = user.UserName;
            password = user.Password;
            return true;
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
                default:                    
                    break;
            }
            return message;
        }
    }
}
