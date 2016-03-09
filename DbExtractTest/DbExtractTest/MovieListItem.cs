
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity.Migrations.History;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Schema;

namespace DbExtractTest
{
    public class MovieListItem : IFileItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Source { get; set; }
        public int? MovieListItemTypeId { get; set; }

        [ForeignKey("MovieListItemTypeId")]
        public MovieListItemType MovieListItemType { get; set; }
        public virtual ICollection<MovieListItemEpisode> Episodes { get; set; }

        public MovieListItem()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{")
                .AppendLine(string.Format("{0}\"Id\": \"{1}\",", "\t", Id))
                .AppendLine(string.Format("{0}\"Key\": \"{1}\",", "\t", Id))
                .AppendLine(string.Format("{0}\"Title\": \"{1}\",", "\t", Title))
                .AppendLine(string.Format("{0}\"Year\": \"{1}\",", "\t", Year))
                .AppendLine(string.Format("{0}\"Episodes\": ", "\t"));

            sb.AppendLine("\t{");
            if (this.Episodes != null && this.Episodes.Count > 0)
            {
                foreach (var leaf in Episodes.OrderBy(e => e.Season).ThenBy(e => e.Episode))
                {
                    sb.AppendLine("\t\t{");
                    sb.AppendLine(string.Format("{0}{1}\"Title\": \"{2}\",", "\t", "\t\t", leaf.Title));
                    sb.AppendLine(string.Format("{0}{1}\"Season\": \"{2}\",", "\t", "\t\t", leaf.Season));
                    sb.AppendLine(string.Format("{0}{1}\"Episode\": \"{2}\"", "\t", "\t\t", leaf.Episode));
                    sb.AppendLine("\t\t},");
                }
            }
            sb.AppendLine("\t}");
            sb.AppendLine("}");

            return sb.ToString();

        }




    }
}
