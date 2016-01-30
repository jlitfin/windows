using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class IndexLeaf
    {
        public int Id { get; set; }
        public int? Period { get; set; }
        public int? Index { get; set; }
        public string Title { get; set; }

        public virtual int IndexableId { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : ({1}.{2})", Title, Period, Index);
        }

        public static IndexLeaf Parse(string source)
        {
            var thrw = !source.StartsWith("{") || !source.EndsWith("}");
            if (thrw) throw new Exception(string.Format("Improperly formed Leaf segment: [{0}].", source));

            var indexOpen = source.IndexOf("(#");
            var leaf = ParseIndex(source, indexOpen);
            var title = source.Substring(1, source.Length - 2);

            if (indexOpen > 1)
            {
                title = source.Substring(1, indexOpen > 0 ? indexOpen - 2 : source.Length - 2);
            }
            leaf.Title = title;

            return leaf;
        }

        private static IndexLeaf ParseIndex(string source, int indexOpen)
        {
            var period = 0;
            var index = 0;
            if (indexOpen > 0)
            {
                var indexClose = source.IndexOf(")", indexOpen);
                var indexDot = source.IndexOf(".", indexOpen);
                period = indexDot > 0 ? Int32.Parse(source.Substring(indexOpen + 2, indexDot - (indexOpen +2))) : 0;
                index = indexDot > 0
                    ? Int32.Parse(source.Substring(indexDot + 1, indexClose - (indexDot + 1)))
                    : 0;
            }

            return new IndexLeaf
            {
                Period = period,
                Index = index
            };
        }
    }
}
