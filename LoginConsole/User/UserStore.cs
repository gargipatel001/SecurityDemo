using LoginConsole.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginConsole.DbAccess;

namespace LoginConsole.User
{
    public class UserStore
    {
        
        public UserStore()
        {
          
        }
        public int CreateUser(User user)
        {
            using (UserContext context = new UserContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
           
          
            return user.ID;
        }
    }
}
