using System.Data.Entity;


namespace DbExtractTest
{
    [DbConfigurationType(typeof(MdbConfiguration))]
    public class MdbContext : DbContext
    {
        public MdbContext() : base("Mdb")
        { 
        }

        public DbSet<Indexable> Indexables { get; set; }
        public DbSet<IndexableType> IndexableTypes { get; set; }
    }
}
