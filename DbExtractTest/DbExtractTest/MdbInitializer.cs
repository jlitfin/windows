using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class MdbInitializer : DropCreateDatabaseIfModelChanges<MdbContext> // DropCreateDatabaseIfModelChanges<MdbContext> // DropCreateDatabaseAlways<MdbContext>
    {
        protected override void Seed(MdbContext context)
        {
            if (!context.MovieListItemTypes.Any())
            {
                context.MovieListItemTypes.AddOrUpdate(c => c.Id,
                    new MovieListItemType { Code = "[VOID]", DisplayName = "", Id = 1 },
                    new MovieListItemType { Code = "(TV)", DisplayName = "TV Movie / Special", Id = 2},
                    new MovieListItemType { Code = "(V)", DisplayName = "Direct To Video", Id = 3 },
                    new MovieListItemType { Code = "(VG)", DisplayName = "Video Game", Id = 4 },
                    new MovieListItemType { Code = "(SERIES)", DisplayName = "TV Series", Id = 5 },
                    new MovieListItemType { Code = "(FILM)", DisplayName = "Theatrical Release", Id =6 }                
                    );
            }

            if (!context.FileDataDetails.Any())
            {
                context.FileDataDetails.AddOrUpdate(d => d.FileName,
                    new FileDataDetail { Id = 1, FileName = "movies.list.gz", ItemClassName = "MovieListItem", LinesAfterFlag = 3, OpenFlag = "MOVIES LIST", TokensPerDatum = 7, ReadAheadFor = null, Active = true },
                    new FileDataDetail { Id = 1, FileName = "actresses.list.gz", ItemClassName = "ActorListItem", LinesAfterFlag = 5, OpenFlag = "THE ACTRESSES LIST", TokensPerDatum = 7, ReadAheadFor = null, Active = true },
                    new FileDataDetail { Id = 1, FileName = "actors.list.gz", ItemClassName = "ActorListItem", LinesAfterFlag = 5, OpenFlag = "THE ACTORS LIST", TokensPerDatum = 7, ReadAheadFor = null, Active = true },
                    new FileDataDetail { Id = 1, FileName = "plot.list.gz", ItemClassName = "PlotListItem", LinesAfterFlag = 3, OpenFlag = "PLOT SUMMARIES LIST", TokensPerDatum = 4, ReadAheadFor = "MV: ", Active = true });
            }
           

            base.Seed(context);
        }
    }
}
