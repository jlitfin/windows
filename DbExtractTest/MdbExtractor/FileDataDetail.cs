namespace MdbExtractor
{
    public class FileDataDetail
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ItemClassName { get; set; }
        public int LinesAfterFlag { get; set; }
        public string OpenFlag { get; set; }
        public int TokensPerDatum { get; set; }
        public string ReadAheadFor { get; set; }
        public bool Active { get; set; }
    }
}
