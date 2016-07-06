using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MdbExtractor
{
    public class MovieListItem : IFileItem
    {
        private string _uniqueKey;

        [MaxLength(512)]
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_uniqueKey))
                {
                    _uniqueKey = string.Format("{0}|{1}|{2}|{3}", Title, EpisodeTitle, Season, Episode).ToUpper();
                }
                return _uniqueKey;
            }
            set { _uniqueKey = value; }
        }

        public string Title { get; set; }
        public string EpisodeTitle { get; set; }
        public string Season { get; set; }
        public string Episode { get; set; }
        public string Year { get; set; }

        public MovieListItem()
        {
        }

        public MovieListItem(List<string> tokens)
        {
            var count = Enum.GetNames(typeof(MovieListItemFieldIndex)).Length;
            while (tokens.Count < count)
            {
                tokens.Add(Constants.NullFieldValue);
            }

            Title = tokens[(int) MovieListItemFieldIndex.Title];
            EpisodeTitle = tokens[(int)MovieListItemFieldIndex.EpisodeTitle];
            Season = tokens[(int)MovieListItemFieldIndex.Season];
            Episode = tokens[(int)MovieListItemFieldIndex.Episode];
            Year = tokens[(int)MovieListItemFieldIndex.Year];
        }
    }
}
