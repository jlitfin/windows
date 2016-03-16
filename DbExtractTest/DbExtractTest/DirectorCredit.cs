using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class DirectorCredit : IFileItem
    {
        public int Id { get; set; }
        public string MovieListItemId { get; set; }
        public string Title { get; set; }
        public string Season { get; set; }
        public string Episode { get; set; }

        public string DirectorListItemId { get; set; }
    }
}
