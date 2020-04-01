using Bespoke.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database = Bespoke.Data.Model;


namespace Bespoke.Manager.DatabaseAccess.Branch
{
    public class CategoryManager
    {
        private BespokeDbEntities db;
        public int Delete(int id)
        {
            db = new BespokeDbEntities();

            var data = db.Categories.FirstOrDefault(x => x.Id == id);

            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;

            return db.SaveChanges();
        }

        public List<Data.Model.Category> Gets()
        {
            db = new BespokeDbEntities();

            var result = default(List<Database.Category>);

            result = db.Categories.ToList();

            return result;
        }

        public int Insert(Data.Model.Category category)
        {
            db = new BespokeDbEntities();

            db.Entry(category).State = System.Data.Entity.EntityState.Added;

            return db.SaveChanges();
        }

        public int Update(Data.Model.Category category)
        {
            db = new BespokeDbEntities();

            db.Entry(category).State = System.Data.Entity.EntityState.Modified;

            return db.SaveChanges();

        }

        public Data.Model.Category Get(int id)
        {
            db = new BespokeDbEntities();

            return db.Categories.FirstOrDefault(x => x.Id == id);
        }

    }
}
