
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace DbExtractTest
{
    public class ActorAppearance : IFileItem
    {     
        [Key, Column(Order = 0)]
        public string MovieListItemId { get; set; }

        [Key, Column(Order = 1)]
        public string ActorListItemId { get; set; }

        public ActorAppearance()
        {
        }

        public ActorAppearance(List<string> tokens)
        {
            
        }

    }
}
