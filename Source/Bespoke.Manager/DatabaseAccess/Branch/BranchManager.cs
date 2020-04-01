using Bespoke.Data.Model;
using System.Collections.Generic;
using System.Linq;
using Database = Bespoke.Data.Model;


namespace Bespoke.Manager.DatabaseAccess.Branch
{
    public class BranchManager : IBranchManager
    {
        private BespokeDbEntities db;
        public int Delete(int id)
        {
            db = new BespokeDbEntities();

            var data = db.Branches.FirstOrDefault(x => x.Id == id);

            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;

            return db.SaveChanges();
        }

        public List<Data.Model.Branch> Gets()
        {
            db = new BespokeDbEntities();

            var result = default(List<Database.Branch>);

            result = db.Branches.ToList();

            return result;
        }

        public int Insert(Data.Model.Branch branch)
        {
            db = new BespokeDbEntities();

            db.Entry(branch).State = System.Data.Entity.EntityState.Added;

            return db.SaveChanges();
        }

        public int Update(Data.Model.Branch branch)
        {
            db = new BespokeDbEntities();

            db.Entry(branch).State = System.Data.Entity.EntityState.Modified;

            return db.SaveChanges();

        }

        public Data.Model.Branch Get(int id)
        {
            db = new BespokeDbEntities();

            return db.Branches.FirstOrDefault(x => x.Id == id);
        }
    }
}
