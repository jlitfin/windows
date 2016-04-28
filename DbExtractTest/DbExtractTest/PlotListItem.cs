using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class PlotListItem : IFileItem
    {
        [MaxLength(512)]
        public string Id { get; set; }
        public string Plot { get; set; }

        public PlotListItem()
        {
        }

        public PlotListItem(List<string> tokens)
        {
            Id = tokens[(int) PlotListItemFieldIndex.Id];
            Plot = tokens[(int) PlotListItemFieldIndex.Plot];
        }
    }
}
