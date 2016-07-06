using System.Data.Entity;

namespace MdbExtractor
{
    public class MdbConfiguration : DbConfiguration
    {
        public MdbConfiguration()
        {
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
            this.SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
            this.SetDatabaseInitializer(new MdbInitializer());
        }
    }
}
