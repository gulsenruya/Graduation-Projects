using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database = Bespoke.Data.Model;


namespace Bespoke.Manager.DatabaseAccess.User
{
    interface IUserManager
    {
        List<Database.User> Gets();

        int Insert(Database.User user);

        int Update(Database.User user);

        int Delete(int id);

        Database.User GetLogin(string username, string password);
    }
}
