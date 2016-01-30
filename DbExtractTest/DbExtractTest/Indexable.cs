
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace DbExtractTest
{
    public class Indexable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Source { get; set; }
        public virtual int IndexableTypeId { get; set; }

        public IndexableType IndexableType { get; set; }
        public List<IndexLeaf> Episodes { get; set; }

        public Indexable()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} ({1}) [{2}] >> {3} ", this.Title, this.Year, this.IndexableType.DisplayName, this.Source));
            if (this.Episodes != null && this.Episodes.Count > 0)
            {

                foreach (var leaf in Episodes.OrderBy(e => e.Period).ThenBy(e => e.Index))
                {
                    sb.AppendLine(leaf.ToString());
                }
            }

            return sb.ToString();

        }

        public static Indexable Parse(string source)
        {
            if (string.IsNullOrEmpty(source)) return null;

            var index = source.IndexOf("(");
            var indexable = new Indexable
            {
                Title = source.Substring(0, index).Trim(),
                Year = source.Substring(index + 1, source.IndexOf(")", index + 1) - (index + 1)),
                Source = source
            };

            using (var context = new MdbContext())
            {
                if (source.Contains("(TV)"))
                {
                    indexable.IndexableType = context.IndexableTypes.Single(c => c.Code == "(TV)");
                }
                else if (source.Contains("(V)"))
                {
                    indexable.IndexableType = context.IndexableTypes.Single(c => c.Code == "(V)");
                }
                else if (source.Contains("(VG)"))
                {
                    indexable.IndexableType = context.IndexableTypes.Single(c => c.Code == "(VG)");
                }
                else if (indexable.Title.StartsWith("\""))
                {
                    indexable.IndexableType = context.IndexableTypes.Single(c => c.Code == "(Series)");
                    var indexOpen = source.IndexOf("{");
                    var indexClose = source.IndexOf("}");
                    if (indexOpen > 0)
                    {
                        indexable.Episodes = new List<IndexLeaf>
                        {
                            IndexLeaf.Parse(source.Substring(indexOpen, indexClose - indexOpen + 1))
                        };
                        
                    }
                    
                }
                else
                {
                    indexable.IndexableType = context.IndexableTypes.Single(c => c.Code == "(Film)");
                }
            }

            return indexable;
        }
    }
}
