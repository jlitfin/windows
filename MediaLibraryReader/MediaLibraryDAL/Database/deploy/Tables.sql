USE [Media]
GO
/****** Object:  ForeignKey [FK_t_album_track_t_artist]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_artist]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [FK_t_album_track_t_artist]
GO
/****** Object:  ForeignKey [FK_t_album_track_t_genre_type]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_genre_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [FK_t_album_track_t_genre_type]
GO
/****** Object:  ForeignKey [FK_t_album_track_t_kind_type]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_kind_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [FK_t_album_track_t_kind_type]
GO
/****** Object:  Table [dbo].[t_album_track]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_artist]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [FK_t_album_track_t_artist]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_genre_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [FK_t_album_track_t_genre_type]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_kind_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [FK_t_album_track_t_kind_type]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_album_track_manual_update]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [DF_t_album_track_manual_update]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_album_track_persistent_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [DF_t_album_track_persistent_id]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_album_track_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [DF_t_album_track_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_album_track_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_album_track] DROP CONSTRAINT [DF_t_album_track_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_album_track]') AND type in (N'U'))
DROP TABLE [dbo].[t_album_track]
GO
/****** Object:  Table [dbo].[t_artist]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_artist_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_artist] DROP CONSTRAINT [DF_t_artist_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_artist_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_artist] DROP CONSTRAINT [DF_t_artist_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_artist]') AND type in (N'U'))
DROP TABLE [dbo].[t_artist]
GO
/****** Object:  Table [dbo].[t_genre_type]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_genre_type_genre_type_map]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_genre_type] DROP CONSTRAINT [DF_t_genre_type_genre_type_map]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_genre_type_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_genre_type] DROP CONSTRAINT [DF_t_genre_type_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_genre_type_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_genre_type] DROP CONSTRAINT [DF_t_genre_type_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_genre_type]') AND type in (N'U'))
DROP TABLE [dbo].[t_genre_type]
GO
/****** Object:  Table [dbo].[t_imdb_search]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_imdb_search_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_imdb_search] DROP CONSTRAINT [DF_t_imdb_search_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_imdb_search_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_imdb_search] DROP CONSTRAINT [DF_t_imdb_search_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_imdb_search]') AND type in (N'U'))
DROP TABLE [dbo].[t_imdb_search]
GO
/****** Object:  Table [dbo].[t_kind_type]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_kind_type_kind_type_map]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_kind_type] DROP CONSTRAINT [DF_t_kind_type_kind_type_map]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_kind_type_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_kind_type] DROP CONSTRAINT [DF_t_kind_type_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_kind_type_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_kind_type] DROP CONSTRAINT [DF_t_kind_type_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_kind_type]') AND type in (N'U'))
DROP TABLE [dbo].[t_kind_type]
GO
/****** Object:  Table [dbo].[t_track]    Script Date: 12/07/2013 16:13:12 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_track_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_track] DROP CONSTRAINT [DF_t_track_updated_by]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_track_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_track] DROP CONSTRAINT [DF_t_track_updated_date]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_track]') AND type in (N'U'))
DROP TABLE [dbo].[t_track]
GO
/****** Object:  Table [dbo].[t_album]    Script Date: 12/07/2013 16:13:11 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_album_manual_update]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_album] DROP CONSTRAINT [DF_t_album_manual_update]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_album_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_album] DROP CONSTRAINT [DF_t_album_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_album_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_album] DROP CONSTRAINT [DF_t_album_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_album]') AND type in (N'U'))
DROP TABLE [dbo].[t_album]
GO
/****** Object:  Table [dbo].[t_album]    Script Date: 12/07/2013 16:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_album]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_album](
	[album_id] [int] IDENTITY(1,1) NOT NULL,
	[imdb_id] [varchar](64) NULL,
	[manual_update] [bit] NOT NULL CONSTRAINT [DF_t_album_manual_update]  DEFAULT ((0)),
	[name] [varchar](128) NOT NULL,
	[year] [int] NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_album_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NOT NULL CONSTRAINT [DF_t_album_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_album] PRIMARY KEY CLUSTERED 
(
	[album_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_track]    Script Date: 12/07/2013 16:13:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_track]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_track](
	[track_id] [int] NOT NULL,
	[name] [varchar](128) NULL,
	[artist] [varchar](128) NULL,
	[album_artist] [varchar](128) NULL,
	[album] [varchar](128) NULL,
	[genre] [varchar](32) NULL,
	[kind] [varchar](32) NULL,
	[size] [int] NULL,
	[total_time] [int] NULL,
	[total_time_string] [varchar](32) NULL,
	[disc_number] [int] NULL,
	[disc_count] [int] NULL,
	[track_number] [int] NULL,
	[track_count] [int] NULL,
	[year] [int] NULL,
	[date_modified] [datetime] NULL,
	[date_added] [datetime] NULL,
	[bit_rate] [int] NULL,
	[sample_rate] [int] NULL,
	[play_count] [int] NULL,
	[play_date] [int] NULL,
	[play_date_utc] [datetime] NULL,
	[release_date] [datetime] NULL,
	[artwork_count] [int] NULL,
	[persistent_id] [varchar](32) NULL,
	[track_type] [varchar](32) NULL,
	[purchased] [bit] NULL,
	[location] [varchar](512) NULL,
	[file_folder_count] [int] NULL,
	[library_folder_count] [int] NULL,
	[updated_by] [varchar](30) NULL CONSTRAINT [DF_t_track_updated_by]  DEFAULT (suser_sname()),
	[updated_date] [datetime] NULL CONSTRAINT [DF_t_track_updated_date]  DEFAULT (getdate()),
 CONSTRAINT [PK_t_track] PRIMARY KEY CLUSTERED 
(
	[track_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_kind_type]    Script Date: 12/07/2013 16:13:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_kind_type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_kind_type](
	[kind_type_id] [int] IDENTITY(1,1) NOT NULL,
	[kind_type_text] [varchar](64) NOT NULL,
	[kind_type_map] [varchar](16) NOT NULL CONSTRAINT [DF_t_kind_type_kind_type_map]  DEFAULT ('Unmapped'),
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_kind_type_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NULL CONSTRAINT [DF_t_kind_type_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_kind_type] PRIMARY KEY CLUSTERED 
(
	[kind_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_imdb_search]    Script Date: 12/07/2013 16:13:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_imdb_search]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_imdb_search](
	[imdb_search_id] [int] IDENTITY(1,1) NOT NULL,
	[json_result] [varchar](max) NOT NULL,
	[search_string] [varchar](128) NOT NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_imdb_search_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NOT NULL CONSTRAINT [DF_t_imdb_search_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_imdb_search] PRIMARY KEY CLUSTERED 
(
	[imdb_search_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_t_imdb_search] UNIQUE NONCLUSTERED 
(
	[search_string] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_genre_type]    Script Date: 12/07/2013 16:13:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_genre_type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_genre_type](
	[genre_type_id] [int] IDENTITY(1,1) NOT NULL,
	[genre_type_text] [varchar](64) NOT NULL,
	[genre_type_map] [varchar](32) NOT NULL CONSTRAINT [DF_t_genre_type_genre_type_map]  DEFAULT ('Unmapped'),
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_genre_type_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NOT NULL CONSTRAINT [DF_t_genre_type_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_genre_type] PRIMARY KEY CLUSTERED 
(
	[genre_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_artist]    Script Date: 12/07/2013 16:13:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_artist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_artist](
	[artist_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](128) NOT NULL,
	[base_name] [varchar](128) NOT NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_artist_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NOT NULL CONSTRAINT [DF_t_artist_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_artist] PRIMARY KEY CLUSTERED 
(
	[artist_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_album_track]    Script Date: 12/07/2013 16:13:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_album_track]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_album_track](
	[album_track_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](128) NOT NULL,
	[itunes_track_id] [int] NULL,
	[artist_id] [int] NOT NULL,
	[album_id] [int] NOT NULL,
	[genre_id] [int] NOT NULL,
	[kind_type_id] [int] NOT NULL,
	[manual_update] [bit] NOT NULL CONSTRAINT [DF_t_album_track_manual_update]  DEFAULT ((0)),
	[persistent_id] [varchar](64) NULL CONSTRAINT [DF_t_album_track_persistent_id]  DEFAULT (''),
	[total_time_string] [varchar](32) NULL,
	[track_number] [int] NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_album_track_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NOT NULL CONSTRAINT [DF_t_album_track_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_album_track] PRIMARY KEY CLUSTERED 
(
	[album_track_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_t_album_track_t_artist]    Script Date: 12/07/2013 16:13:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_artist]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track]  WITH CHECK ADD  CONSTRAINT [FK_t_album_track_t_artist] FOREIGN KEY([artist_id])
REFERENCES [dbo].[t_artist] ([artist_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_artist]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] CHECK CONSTRAINT [FK_t_album_track_t_artist]
GO
/****** Object:  ForeignKey [FK_t_album_track_t_genre_type]    Script Date: 12/07/2013 16:13:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_genre_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track]  WITH CHECK ADD  CONSTRAINT [FK_t_album_track_t_genre_type] FOREIGN KEY([genre_id])
REFERENCES [dbo].[t_genre_type] ([genre_type_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_genre_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] CHECK CONSTRAINT [FK_t_album_track_t_genre_type]
GO
/****** Object:  ForeignKey [FK_t_album_track_t_kind_type]    Script Date: 12/07/2013 16:13:12 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_kind_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track]  WITH CHECK ADD  CONSTRAINT [FK_t_album_track_t_kind_type] FOREIGN KEY([kind_type_id])
REFERENCES [dbo].[t_kind_type] ([kind_type_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_album_track_t_kind_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_album_track]'))
ALTER TABLE [dbo].[t_album_track] CHECK CONSTRAINT [FK_t_album_track_t_kind_type]
GO
