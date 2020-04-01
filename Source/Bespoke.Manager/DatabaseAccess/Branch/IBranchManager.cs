using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database = Bespoke.Data.Model;


namespace Bespoke.Manager.DatabaseAccess.Branch
{
    interface IBranchManager
    {
        List<Database.Branch> Gets();

        int Insert(Database.Branch branch);

        int Update(Database.Branch branch);

        int Delete(int id);
    }
}
