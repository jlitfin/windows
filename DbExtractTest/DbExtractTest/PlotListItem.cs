using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class PlotListItem : IFileItem
    {
        public int Id { get; set; }
        public string MovieListItemId { get; set; }
        public int MovieListItemEpisodeId { get; set; }
        public string Plot { get; set; }


    }
}
