using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class MdbInitializer : DropCreateDatabaseAlways<MdbContext>
    {
        protected override void Seed(MdbContext context)
        {
            if (!context.IndexableTypes.Any())
            {
                context.IndexableTypes.AddOrUpdate(c => c.Id,
                    new IndexableType { Code = "(TV)", DisplayName = "TV Movie / Special", Id = 1 },
                    new IndexableType { Code = "(V)", DisplayName = "Direct To Video", Id = 2 },
                    new IndexableType { Code = "(VG)", DisplayName = "Video Game", Id = 3 },
                    new IndexableType { Code = "(SERIES)", DisplayName = "TV Series", Id = 4 },
                    new IndexableType { Code = "(FILM)", DisplayName = "Theatrical Release", Id = 5 }                
                    );
            }
            base.Seed(context);
        }
    }
}
