

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbExtractTest
{
    public class MovieListItem : IFileItem
    {
        private string _uniqueKey;

        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_uniqueKey))
                {
                    _uniqueKey = string.Format("{0}|{1}|{2}|{3}", Title, EpisodeTitle, Season, Episode);
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
            var count = Enum.GetNames(typeof (MovieListItemFieldIndex)).Length;
            if (tokens.Count != count)
                throw new ArgumentOutOfRangeException(
                    "Attempt made to build MovieListItem with incorrect number of tokens.");

            Title = tokens[(int) MovieListItemFieldIndex.Title];
            EpisodeTitle = tokens[(int)MovieListItemFieldIndex.EpisodeTitle];
            Season = tokens[(int)MovieListItemFieldIndex.Season];
            Episode = tokens[(int)MovieListItemFieldIndex.Episode];
            Year = tokens[(int)MovieListItemFieldIndex.Year];
        }
    }
}
