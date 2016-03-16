﻿using System.Data.Entity;


namespace DbExtractTest
{
    [DbConfigurationType(typeof(MdbConfiguration))]
    public class MdbContext : DbContext
    {
        public MdbContext() : base("Mdb")
        { 
        }

        public DbSet<ActorAppearance> ActorAppearances { get; set; }
        public DbSet<ActorListItem> ActorListItems { get; set; }
        public DbSet<DirectorCredit> DirectorCredits { get; set; }
        public DbSet<DirectorListItem> DirectorListItems { get; set; }
        public DbSet<FileDataDetail> FileDataDetails { get; set; }
        public DbSet<MovieListItem> MovieListItems { get; set; }
        //public DbSet<MovieListItemType> MovieListItemTypes { get; set; }
        public DbSet<PlotListItem> PlotListItems { get; set; }
        public DbSet<RatingListItem> RatingListItems { get; set; }
    }
}
