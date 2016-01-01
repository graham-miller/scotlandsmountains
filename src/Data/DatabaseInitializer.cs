using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScotlandsMountains.Data
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ScotlandsMountainsContext>
    {
        protected override void Seed(ScotlandsMountainsContext context)
        {
            // create data here
            base.Seed(context);
        }
    }
}
