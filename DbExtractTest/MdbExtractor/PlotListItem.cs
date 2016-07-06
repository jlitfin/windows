using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MdbExtractor
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
