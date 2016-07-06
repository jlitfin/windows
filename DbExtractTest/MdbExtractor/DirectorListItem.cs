using System;
using System.Collections.Generic;

namespace MdbExtractor
{
    public class DirectorListItem : IFileItem
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<DirectorCredit> Credits { get; set; }

        public DirectorListItem()
        {
        }

        public DirectorListItem(List<string> tokens)
        {
            var count = Enum.GetNames(typeof(DirectorListItemFieldIndex)).Length;
            if (tokens.Count < count)
                throw new ArgumentOutOfRangeException(
                    "Attempt made to build DirectorListItem with incorrect number of tokens.");

            Id = tokens[(int)DirectorListItemFieldIndex.Id].Trim();
            FirstName = tokens[(int)DirectorListItemFieldIndex.FirstName].Trim();
            LastName = tokens[(int)DirectorListItemFieldIndex.LastName].Trim();

            Credits = new List<DirectorCredit>();
        }
    }
}
