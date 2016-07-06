namespace MdbExtractor
{
    public class RatingListItem : IFileItem
    {
        private string _uniqueKey;

        public string Distribution { get; set; }
        public string MovieListItemId { get; set; }
        public string Title { get; set; }
        public string Season { get; set; }
        public string Episode { get; set; }
        public long Votes { get; set; }
        public decimal Rank { get; set; }

        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_uniqueKey))
                {
                    _uniqueKey = string.Format("{0}|{1}|{2}|{3}", MovieListItemId, Title, Season, Episode);
                }
                return _uniqueKey;
            }
            set { _uniqueKey = value; }
        }
    }
}
