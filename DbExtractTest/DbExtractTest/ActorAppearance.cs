using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DbExtractTest
{
    public class ActorAppearance : IFileItem
    {
        
        public int Id { get; set; }
        public string MovieListItemId { get; set; }
        public string Title { get; set; }
        public string Season { get; set; }
        public string Episode { get; set; }

        public string ActorListItemId { get; set; }


    }
}
