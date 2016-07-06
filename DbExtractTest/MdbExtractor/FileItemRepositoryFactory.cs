namespace MdbExtractor
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

                case Constants.ImportableTypes.DirectorListItem:
                    return new DirectorListItemRepository();

                case Constants.ImportableTypes.RatingListItem:
                    return new RatingListItemRepository();
            }

            return null;
        }
    }
}
