using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class ActorListItem : IFileItem
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ActorAppearance> AppearanceList { get; set; }

        public ActorListItem()
        {
            AppearanceList = new List<ActorAppearance>();
        }

        public ActorListItem(List<string> tokens)
        {
            var count = Enum.GetNames(typeof(ActorListItemFieldIndex)).Length;
            if (tokens.Count < count)
                throw new ArgumentOutOfRangeException(
                    "Attempt made to build ActorListItem with incorrect number of tokens.");

            Id = tokens[(int) ActorListItemFieldIndex.Id].Trim();
            FirstName = tokens[(int)ActorListItemFieldIndex.FirstName].Trim();
            LastName = tokens[(int)ActorListItemFieldIndex.LastName].Trim();

            AppearanceList = new List<ActorAppearance>();
        }
    }
}
