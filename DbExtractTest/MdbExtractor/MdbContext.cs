using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;

namespace MdbExtractor
{
    [DbConfigurationType(typeof(MdbConfiguration))]
    public class MdbContext : DbContext
    {
        public MdbContext() : base("Mdb")
        { 
        }

        public DbSet<ActorAppearance> ActorAppearances { get; set; }
        public DbSet<ActorListItem> ActorListItems { get; set; }
        public DbSet<DirectorCredit> DirectorCredits { get; set; }
        public DbSet<DirectorListItem> DirectorListItems { get; set; }
        public DbSet<FileDataDetail> FileDataDetails { get; set; }
        public DbSet<MovieListItem> MovieListItems { get; set; }
        public DbSet<PlotListItem> PlotListItems { get; set; }
        public DbSet<RatingListItem> RatingListItems { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    ); // Add the original exception as the innerException
            }  
        }
    }
}
