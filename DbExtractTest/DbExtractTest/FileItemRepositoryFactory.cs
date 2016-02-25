using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class FileItemRepositoryFactory
    {
        public static IFileItemRepository GetInstance(string itemTypeName)
        {
            switch (itemTypeName)
            {
                case Constants.ImportableTypes.MovieListItem:
                    return new MovieListItemRepository();

                case Constants.ImportableTypes.ActorListItem:
                    return new ActorListItemRepository();

                case Constants.ImportableTypes.PlotListItem:
                    return new PlotListItemRepository();
            }

            return null;
        }
    }
}
