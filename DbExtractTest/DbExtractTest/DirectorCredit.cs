
using System.ComponentModel.DataAnnotations;


namespace DbExtractTest
{
    public class DirectorCredit : IFileItem
    {
        [Key]
        public string MovieListItemId { get; set; }
        public string DirectorListItemId { get; set; }
    }
}
