
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
        [MaxLength(512)]
        public string MovieListItemId { get; set; }

        [Key, Column(Order = 1)]
        public string ActorListItemId { get; set; }

        public ActorAppearance()
        {
        }

        public ActorAppearance(string movieListItemId, string actorListItemId)
        {
            MovieListItemId = movieListItemId;
            ActorListItemId = actorListItemId;
        }

        public override bool Equals(object obj)
        {
            var app = obj as ActorAppearance;
            if (app == null) return false;

            return Equals(app);
        }

        public bool Equals(ActorAppearance other)
        {
            return ActorListItemId.Equals(other.ActorListItemId) &&
                   MovieListItemId.Equals(other.MovieListItemId);
        }
    }
}
