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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Id);
            foreach (var s in AppearanceList)
            {
                sb.Append("\t")
                    .Append(s.MovieListItemId);
                if (s.Title != Constants.NullFieldValue)
                {
                    sb.Append(" ")
                        .Append(s.Title);
                }
                if (s.Season != (Constants.NullFieldValue))
                {
                    sb.Append(" (#")
                        .Append(s.Season)
                        .Append(".")
                        .Append(s.Episode)
                        .Append(")");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
