using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bespoke.Data.Model;
using Database = Bespoke.Data.Model;

namespace Bespoke.Manager.DatabaseAccess.User
{
    public class UserManager : IUserManager
    {
        private BespokeDbEntities db;

        public int Delete(int id)
        {
            db = new BespokeDbEntities();

            var data = db.Users.FirstOrDefault(x => x.Id == id);

            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;

            return db.SaveChanges();
        }

        public Data.Model.User GetLogin(string username, string password)
        {
            var user = new Data.Model.User();

            db = new BespokeDbEntities();

            user = db.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();

            return user;
        }

        public List<Data.Model.User> Gets()
        {
            db = new BespokeDbEntities();

            var result = default(List<Database.User>);

            result = db.Users.ToList();

            return result;
        }

        public int Insert(Data.Model.User user)
        {
            db = new BespokeDbEntities();

            db.Entry(user).State = System.Data.Entity.EntityState.Added;

            return db.SaveChanges();
        }

        public int Update(Data.Model.User user)
        {
            db = new BespokeDbEntities();

            db.Entry(user).State = System.Data.Entity.EntityState.Modified;

            return db.SaveChanges();
        }
        public Data.Model.User Get(int id)
        {
            db = new BespokeDbEntities();

            return db.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
