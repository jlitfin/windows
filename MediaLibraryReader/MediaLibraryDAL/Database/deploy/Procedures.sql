USE [Media]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_track_ins]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_track_ins]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_album_track_ins]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_track_sel]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_track_sel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_album_track_sel]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_track_upd]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_track_upd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_album_track_upd]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_track_ups]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_track_ups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_album_track_ups]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_upd]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_upd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_album_upd]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_ups]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_ups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_album_ups]
GO
/****** Object:  StoredProcedure [dbo].[prc_artist_ins]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_artist_ins]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_artist_ins]
GO
/****** Object:  StoredProcedure [dbo].[prc_artist_sel]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_artist_sel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_artist_sel]
GO
/****** Object:  StoredProcedure [dbo].[prc_artist_upd]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_artist_upd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_artist_upd]
GO
/****** Object:  StoredProcedure [dbo].[prc_artist_ups]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_artist_ups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_artist_ups]
GO
/****** Object:  StoredProcedure [dbo].[prc_genre_type_ins]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_genre_type_ins]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_genre_type_ins]
GO
/****** Object:  StoredProcedure [dbo].[prc_genre_type_sel]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_genre_type_sel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_genre_type_sel]
GO
/****** Object:  StoredProcedure [dbo].[prc_genre_type_upd]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_genre_type_upd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_genre_type_upd]
GO
/****** Object:  StoredProcedure [dbo].[prc_genre_type_ups]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_genre_type_ups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_genre_type_ups]
GO
/****** Object:  StoredProcedure [dbo].[prc_imdb_search_ins]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_imdb_search_ins]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_imdb_search_ins]
GO
/****** Object:  StoredProcedure [dbo].[prc_imdb_search_sel]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_imdb_search_sel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_imdb_search_sel]
GO
/****** Object:  StoredProcedure [dbo].[prc_imdb_search_upd]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_imdb_search_upd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_imdb_search_upd]
GO
/****** Object:  StoredProcedure [dbo].[prc_kind_type_ins]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_kind_type_ins]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_kind_type_ins]
GO
/****** Object:  StoredProcedure [dbo].[prc_kind_type_sel]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_kind_type_sel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_kind_type_sel]
GO
/****** Object:  StoredProcedure [dbo].[prc_kind_type_upd]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_kind_type_upd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_kind_type_upd]
GO
/****** Object:  StoredProcedure [dbo].[prc_track_ins]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_track_ins]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_track_ins]
GO
/****** Object:  StoredProcedure [dbo].[prc_track_sel]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_track_sel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_track_sel]
GO
/****** Object:  StoredProcedure [dbo].[prc_track_upd]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_track_upd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_track_upd]
GO
/****** Object:  StoredProcedure [dbo].[prc_track_ups]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_track_ups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_track_ups]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_ins]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_ins]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_album_ins]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_sel]    Script Date: 12/07/2013 16:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_sel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_album_sel]
GO
/****** Object:  StoredProcedure [dbo].[prc_album_sel]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[prc_album_sel]

AS
BEGIN


SELECT
	 album_id
	,imdb_id
	,manual_update
	,name
	,year
FROM
	dbo.t_album WITH (NOLOCK)


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_album_ins]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_album_ins]
(
	 @imdb_id		 varchar(64)
	,@manual_update  bit
	,@name           varchar(128)
	,@year           int
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_album
(
	 imdb_id
	,manual_update
	,name
	,year
	,updated_by
)
VALUES
(
	 @imdb_id
	,@manual_update  
	,@name           
	,@year           
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_track_ups]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_track_ups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_track_ups]
(
	 @xml_list   nvarchar(max)
	,@updated_by varchar(30)
)
AS
BEGIN

DECLARE @intDoc int
DECLARE @doc    nvarchar(max)
SET @doc = @xml_list
--
-- Create an internal representation of the XML document
--
EXEC sp_xml_preparedocument @intDoc OUTPUT, @doc


CREATE TABLE #tmp
(
	 track_id              int
	,name                  varchar(128)
	,artist                varchar(128)
	,album_artist          varchar(128)
	,album                 varchar(128)
	,genre                 varchar(32)
	,kind                  varchar(32)
	,size                  int
	,total_time            int
	,total_time_string     varchar(32)
	,disc_number           int
	,disc_count            int
	,track_number          int
	,track_count           int
	,year                  int
	,date_modified         datetime
	,date_added            datetime
	,bit_rate              int
	,sample_rate           int
	,play_count            int
	,play_date             int
	,play_date_utc         datetime
	,release_date          datetime
	,artwork_count         int
	,persistent_id         varchar(32)
	,track_type            varchar(32)
	,purchased             bit
	,location              varchar(512)
	,file_folder_count     int
	,library_folder_count  int
)
INSERT INTO #tmp
(
	 track_id
	,name
	,artist
	,album_artist
	,album
	,genre
	,kind
	,size
	,total_time
	,total_time_string
	,disc_number
	,disc_count
	,track_number
	,track_count
	,year
	,date_modified
	,date_added
	,bit_rate
	,sample_rate
	,play_count
	,play_date
	,play_date_utc
	,release_date
	,artwork_count
	,persistent_id
	,track_type
	,purchased
	,location
	,file_folder_count
	,library_folder_count
)
SELECT
	 track_id
	,name
	,artist
	,album_artist
	,album
	,genre
	,kind
	,size
	,total_time
	,total_time_string
	,disc_number
	,disc_count
	,track_number
	,track_count
	,year
	,date_modified
	,date_added
	,bit_rate
	,sample_rate
	,play_count
	,play_date
	,play_date_utc
	,release_date
	,artwork_count
	,persistent_id
	,track_type
	,purchased
	,location
	,file_folder_count
	,library_folder_count
FROM OPENXML (@intDoc, ''ArrayOfTrack/Track'', 1)
WITH (
	 track_id              int                 ''TrackId''
	,name                  varchar(128)        ''Name''
	,artist                varchar(128)        ''Artist''
	,album_artist          varchar(128)        ''AlbumArtist''
	,album                 varchar(128)        ''Album''
	,genre                 varchar(32)         ''Genre''
	,kind                  varchar(32)         ''Kind''
	,size                  int                 ''Size''
	,total_time            int                 ''TotalTime''
	,total_time_string     varchar(32)         ''TotalTimeString''
	,disc_number           int                 ''DiscNumber''
	,disc_count            int                 ''DiscCount''
	,track_number          int                 ''TrackNumber''
	,track_count           int                 ''TrackCount''
	,year                  int                 ''Year''
	,date_modified         datetime            ''DateModified''
	,date_added            datetime            ''DateAdded''
	,bit_rate              int                 ''BitRate''
	,sample_rate           int                 ''SampleRate''
	,play_count            int                 ''PlayCount''
	,play_date             int                 ''PlayDate''
	,play_date_utc         datetime            ''PlayDateUtc''
	,release_date          datetime            ''ReleaseDate''
	,artwork_count         int                 ''ArtworkCount''
	,persistent_id         varchar(32)         ''PersistentId''
	,track_type            varchar(32)         ''TrackType''
	,purchased             bit                 ''Purchased''
	,location              varchar(512)        ''Location''
	,file_folder_count     int                 ''FileFolderCount''
	,library_folder_count  int                 ''LibraryFolderCount''
)


UPDATE t_track
SET
	 name                  = tmp.name
	,artist                = tmp.artist
	,album_artist          = tmp.album_artist
	,album                 = tmp.album
	,genre                 = tmp.genre
	,kind                  = tmp.kind
	,size                  = tmp.size
	,total_time            = tmp.total_time
	,total_time_string     = tmp.total_time_string
	,disc_number           = tmp.disc_number
	,disc_count            = tmp.disc_count
	,track_number          = tmp.track_number
	,track_count           = tmp.track_count
	,year                  = tmp.year
	,date_modified         = tmp.date_modified
	,date_added            = tmp.date_added
	,bit_rate              = tmp.bit_rate
	,sample_rate           = tmp.sample_rate
	,play_count            = tmp.play_count
	,play_date             = tmp.play_date
	,play_date_utc         = tmp.play_date_utc
	,release_date          = tmp.release_date
	,artwork_count         = tmp.artwork_count
	,persistent_id         = tmp.persistent_id
	,track_type            = tmp.track_type
	,purchased             = tmp.purchased
	,location              = tmp.location
	,file_folder_count     = tmp.file_folder_count
	,library_folder_count  = tmp.library_folder_count
	,updated_by            = @updated_by
	,updated_date          = GETDATE()
FROM
	t_track tbl
	INNER JOIN #tmp tmp
		ON(tbl.track_id = tmp.track_id)


INSERT INTO t_track
(
	 track_id
	,name
	,artist
	,album_artist
	,album
	,genre
	,kind
	,size
	,total_time
	,total_time_string
	,disc_number
	,disc_count
	,track_number
	,track_count
	,year
	,date_modified
	,date_added
	,bit_rate
	,sample_rate
	,play_count
	,play_date
	,play_date_utc
	,release_date
	,artwork_count
	,persistent_id
	,track_type
	,purchased
	,location
	,file_folder_count
	,library_folder_count
	,updated_by
)
SELECT
	 tmp.track_id
	,tmp.name
	,tmp.artist
	,tmp.album_artist
	,tmp.album
	,tmp.genre
	,tmp.kind
	,tmp.size
	,tmp.total_time
	,tmp.total_time_string
	,tmp.disc_number
	,tmp.disc_count
	,tmp.track_number
	,tmp.track_count
	,tmp.year
	,tmp.date_modified
	,tmp.date_added
	,tmp.bit_rate
	,tmp.sample_rate
	,tmp.play_count
	,tmp.play_date
	,tmp.play_date_utc
	,tmp.release_date
	,tmp.artwork_count
	,tmp.persistent_id
	,tmp.track_type
	,tmp.purchased
	,tmp.location
	,tmp.file_folder_count
	,tmp.library_folder_count
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_track tbl
		ON(tmp.track_id = tbl.track_id)
WHERE
	tbl.track_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_track_upd]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_track_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_track_upd]
(
	 @track_id              int
	,@name                  varchar(128)
	,@artist                varchar(128)
	,@album_artist          varchar(128)
	,@album                 varchar(128)
	,@genre                 varchar(32)
	,@kind                  varchar(32)
	,@size                  int
	,@total_time            int
	,@total_time_string     varchar(32)
	,@disc_number           int
	,@disc_count            int
	,@track_number          int
	,@track_count           int
	,@year                  int
	,@date_modified         datetime
	,@date_added            datetime
	,@bit_rate              int
	,@sample_rate           int
	,@play_count            int
	,@play_date             int
	,@play_date_utc         datetime
	,@release_date          datetime
	,@artwork_count         int
	,@persistent_id         varchar(32)
	,@track_type            varchar(32)
	,@purchased             bit
	,@location              varchar(512)
	,@file_folder_count     int
	,@library_folder_count  int
	,@updated_by            varchar(30)
)
AS
UPDATE dbo.t_track
SET
	 name                   = @name
	,artist                 = @artist
	,album_artist           = @album_artist
	,album                  = @album
	,genre                  = @genre
	,kind                   = @kind
	,size                   = @size
	,total_time             = @total_time
	,total_time_string      = @total_time_string
	,disc_number            = @disc_number
	,disc_count             = @disc_count
	,track_number           = @track_number
	,track_count            = @track_count
	,year                   = @year
	,date_modified          = @date_modified
	,date_added             = @date_added
	,bit_rate               = @bit_rate
	,sample_rate            = @sample_rate
	,play_count             = @play_count
	,play_date              = @play_date
	,play_date_utc          = @play_date_utc
	,release_date           = @release_date
	,artwork_count          = @artwork_count
	,persistent_id          = @persistent_id
	,track_type             = @track_type
	,purchased              = @purchased
	,location               = @location
	,file_folder_count      = @file_folder_count
	,library_folder_count   = @library_folder_count
	,updated_by             = @updated_by
	,updated_date           = GETDATE()
WHERE
	track_id = @track_id

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_track_sel]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_track_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[prc_track_sel]

AS
BEGIN


SELECT
	 track_id
	,name
	,artist
	,album_artist
	,album
	,genre
	,kind
	,size
	,total_time
	,total_time_string
	,disc_number
	,disc_count
	,track_number
	,track_count
	,year
	,date_modified
	,date_added
	,bit_rate
	,sample_rate
	,play_count
	,play_date
	,play_date_utc
	,release_date
	,artwork_count
	,persistent_id
	,track_type
	,purchased
	,location
	,file_folder_count
	,library_folder_count
FROM
	dbo.t_track WITH (NOLOCK)


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_track_ins]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_track_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_track_ins]
(
	 @track_id              int
	,@name                  varchar(128)
	,@artist                varchar(128)
	,@album_artist          varchar(128)
	,@album                 varchar(128)
	,@genre                 varchar(32)
	,@kind                  varchar(32)
	,@size                  int
	,@total_time            int
	,@total_time_string     varchar(32)
	,@disc_number           int
	,@disc_count            int
	,@track_number          int
	,@track_count           int
	,@year                  int
	,@date_modified         datetime
	,@date_added            datetime
	,@bit_rate              int
	,@sample_rate           int
	,@play_count            int
	,@play_date             int
	,@play_date_utc         datetime
	,@release_date          datetime
	,@artwork_count         int
	,@persistent_id         varchar(32)
	,@track_type            varchar(32)
	,@purchased             bit
	,@location              varchar(512)
	,@file_folder_count     int
	,@library_folder_count  int
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_track
(
	 track_id
	,name
	,artist
	,album_artist
	,album
	,genre
	,kind
	,size
	,total_time
	,total_time_string
	,disc_number
	,disc_count
	,track_number
	,track_count
	,year
	,date_modified
	,date_added
	,bit_rate
	,sample_rate
	,play_count
	,play_date
	,play_date_utc
	,release_date
	,artwork_count
	,persistent_id
	,track_type
	,purchased
	,location
	,file_folder_count
	,library_folder_count
	,updated_by
)
VALUES
(
	 @track_id              
	,@name                  
	,@artist                
	,@album_artist          
	,@album                 
	,@genre                 
	,@kind                  
	,@size                  
	,@total_time            
	,@total_time_string     
	,@disc_number           
	,@disc_count            
	,@track_number          
	,@track_count           
	,@year                  
	,@date_modified         
	,@date_added            
	,@bit_rate              
	,@sample_rate           
	,@play_count            
	,@play_date             
	,@play_date_utc         
	,@release_date          
	,@artwork_count         
	,@persistent_id         
	,@track_type            
	,@purchased             
	,@location              
	,@file_folder_count     
	,@library_folder_count  
	,@updated_by
)

SELECT @track_id

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_kind_type_upd]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_kind_type_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_kind_type_upd]
(
	 @kind_type_id    int
	,@kind_type_map   varchar(16)
	,@kind_type_text  varchar(64)
	,@updated_by      varchar(30)
)
AS
UPDATE dbo.t_kind_type
SET
	 kind_type_map    = @kind_type_map
	,kind_type_text   = @kind_type_text
	,updated_by       = @updated_by
	,updated_date     = GETDATE()
WHERE
	kind_type_id = @kind_type_id

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_kind_type_sel]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_kind_type_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[prc_kind_type_sel]

AS
BEGIN


SELECT
	 kind_type_id
	,kind_type_map
	,kind_type_text
FROM
	dbo.t_kind_type WITH (NOLOCK)


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_kind_type_ins]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_kind_type_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_kind_type_ins]
(
	 @kind_type_id    int
	,@kind_type_map   varchar(16)
	,@kind_type_text  varchar(64)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_kind_type
(
	 kind_type_map
	,kind_type_text
	,updated_by
)
VALUES
(
	 @kind_type_map   
	,@kind_type_text  
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_imdb_search_upd]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_imdb_search_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_imdb_search_upd]
(
	 @imdb_search_id  int
	,@json_result     varchar(max)
	,@search_string   varchar(128)
	,@updated_by      varchar(30)
)
AS
UPDATE dbo.t_imdb_search
SET
	 json_result      = @json_result
	,search_string    = @search_string
	,updated_by       = @updated_by
	,updated_date     = GETDATE()
WHERE
	imdb_search_id = @imdb_search_id

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_imdb_search_sel]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_imdb_search_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[prc_imdb_search_sel]

AS
BEGIN


SELECT
	 imdb_search_id
	,json_result
	,search_string
FROM
	dbo.t_imdb_search WITH (NOLOCK)


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_imdb_search_ins]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_imdb_search_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_imdb_search_ins]
(
	 @imdb_search_id  int
	,@json_result     varchar(max)
	,@search_string   varchar(128)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_imdb_search
(
	 json_result
	,search_string
	,updated_by
)
VALUES
(
	 @json_result     
	,@search_string   
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_genre_type_ups]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_genre_type_ups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_genre_type_ups]
(
	 @xml_list   nvarchar(max)
	,@updated_by varchar(30)
)
AS
BEGIN

DECLARE @intDoc int
DECLARE @doc    nvarchar(max)
SET @doc = @xml_list
--
-- Create an internal representation of the XML document
--
EXEC sp_xml_preparedocument @intDoc OUTPUT, @doc


CREATE TABLE #tmp
(
	 genre_type_id    int
	,genre_type_map   varchar(32)
	,genre_type_text  varchar(64)
)
INSERT INTO #tmp
(
	 genre_type_id
	,genre_type_map
	,genre_type_text
)
SELECT
	 genre_type_id
	,genre_type_map
	,genre_type_text
FROM OPENXML (@intDoc, ''ArrayOfGenreType/GenreType'', 1)
WITH (
	 genre_type_id    int                 ''GenreTypeId''
	,genre_type_map   varchar(32)         ''GenreTypeMap''
	,genre_type_text  varchar(64)         ''GenreTypeText''
)


UPDATE t_genre_type
SET
	 genre_type_map   = tmp.genre_type_map
	,genre_type_text  = tmp.genre_type_text
	,updated_by       = @updated_by
	,updated_date     = GETDATE()
FROM
	t_genre_type tbl
	INNER JOIN #tmp tmp
		ON(tbl.genre_type_id = tmp.genre_type_id)


INSERT INTO t_genre_type
(
	 genre_type_map
	,genre_type_text
	,updated_by
)
SELECT
	 tmp.genre_type_map
	,tmp.genre_type_text
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_genre_type tbl
		ON(tmp.genre_type_id = tbl.genre_type_id)
WHERE
	tbl.genre_type_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_genre_type_upd]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_genre_type_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_genre_type_upd]
(
	 @genre_type_id    int
	,@genre_type_map   varchar(32)
	,@genre_type_text  varchar(64)
	,@updated_by       varchar(30)
)
AS
UPDATE dbo.t_genre_type
SET
	 genre_type_map    = @genre_type_map
	,genre_type_text   = @genre_type_text
	,updated_by        = @updated_by
	,updated_date      = GETDATE()
WHERE
	genre_type_id = @genre_type_id

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_genre_type_sel]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_genre_type_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[prc_genre_type_sel]

AS
BEGIN


SELECT
	 genre_type_id
	,genre_type_map
	,genre_type_text
FROM
	dbo.t_genre_type WITH (NOLOCK)


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_genre_type_ins]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_genre_type_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_genre_type_ins]
(
	 @genre_type_id    int
	,@genre_type_map   varchar(32)
	,@genre_type_text  varchar(64)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_genre_type
(
	 genre_type_map
	,genre_type_text
	,updated_by
)
VALUES
(
	 @genre_type_map   
	,@genre_type_text  
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_artist_ups]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_artist_ups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_artist_ups]
(
	 @xml_list   nvarchar(max)
	,@updated_by varchar(30)
)
AS
BEGIN

DECLARE @intDoc int
DECLARE @doc    nvarchar(max)
SET @doc = @xml_list
--
-- Create an internal representation of the XML document
--
EXEC sp_xml_preparedocument @intDoc OUTPUT, @doc


CREATE TABLE #tmp
(
	 artist_id  int
	,base_name  varchar(128)
	,name       varchar(128)
)
INSERT INTO #tmp
(
	 artist_id
	,base_name
	,name
)
SELECT
	 artist_id
	,base_name
	,name
FROM OPENXML (@intDoc, ''ArrayOfArtist/Artist'', 1)
WITH (
	 artist_id  int                 ''ArtistId''
	,base_name  varchar(128)        ''BaseName''
	,name       varchar(128)        ''Name''
)


UPDATE t_artist
SET
	 base_name  = tmp.base_name
	,name       = tmp.name
	,updated_by = @updated_by
	,updated_date= GETDATE()
FROM
	t_artist tbl
	INNER JOIN #tmp tmp
		ON(tbl.artist_id = tmp.artist_id)


INSERT INTO t_artist
(
	 base_name
	,name
	,updated_by
)
SELECT
	 tmp.base_name
	,tmp.name
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_artist tbl
		ON(tmp.artist_id = tbl.artist_id)
WHERE
	tbl.artist_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_artist_upd]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_artist_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_artist_upd]
(
	 @artist_id  int
	,@base_name  varchar(128)
	,@name       varchar(128)
	,@updated_by varchar(30)
)
AS
UPDATE dbo.t_artist
SET
	 base_name   = @base_name
	,name        = @name
	,updated_by  = @updated_by
	,updated_date = GETDATE()
WHERE
	artist_id = @artist_id

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_artist_sel]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_artist_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[prc_artist_sel]

AS
BEGIN


SELECT
	 artist_id
	,base_name
	,name
FROM
	dbo.t_artist WITH (NOLOCK)


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_artist_ins]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_artist_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_artist_ins]
(
	 @artist_id  int
	,@base_name  varchar(128)
	,@name       varchar(128)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_artist
(
	 base_name
	,name
	,updated_by
)
VALUES
(
	 @base_name  
	,@name       
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_album_ups]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_ups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_album_ups]
(
	 @xml_list   nvarchar(max)
	,@updated_by varchar(30)
)
AS
BEGIN

DECLARE @intDoc int
DECLARE @doc    nvarchar(max)
SET @doc = @xml_list
--
-- Create an internal representation of the XML document
--
EXEC sp_xml_preparedocument @intDoc OUTPUT, @doc


CREATE TABLE #tmp
(
	 album_id       int
	,imdb_id        varchar(64)
	,manual_update  bit
	,name           varchar(128)
	,year           int
)
INSERT INTO #tmp
(
	 album_id
	,imdb_id
	,manual_update
	,name
	,year
)
SELECT
	 album_id
	,imdb_id
	,manual_update
	,name
	,year
FROM OPENXML (@intDoc, ''ArrayOfAlbum/Album'', 1)
WITH (
	 album_id       int                 ''AlbumId''
	,imdb_id		varchar(64)         ''ImdbId''
	,manual_update  bit                 ''ManualUpdate''
	,name           varchar(128)        ''Name''
	,year           int                 ''Year''
)


UPDATE t_album
SET
	 imdb_id	    = tmp.imdb_id
	,manual_update  = tmp.manual_update
	,name           = tmp.name
	,year           = tmp.year
	,updated_by     = @updated_by
	,updated_date   = GETDATE()
FROM
	t_album tbl
	INNER JOIN #tmp tmp
		ON(tbl.album_id = tmp.album_id)
WHERE
	tbl.manual_update = 0


INSERT INTO t_album
(
	 imdb_id
	,manual_update
	,name
	,year
	,updated_by
)
SELECT
	 tmp.imdb_id
	,tmp.manual_update
	,tmp.name
	,tmp.year
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_album tbl
		ON(tmp.album_id = tbl.album_id)
WHERE
	tbl.album_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_album_upd]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_album_upd]
(
	 @album_id       int
	,@imdb_id		 varchar(64)
	,@manual_update  bit
	,@name           varchar(128)
	,@year           int
	,@updated_by     varchar(30)
)
AS
UPDATE dbo.t_album
SET
	 imdb_id		 = @imdb_id
	,manual_update   = @manual_update
	,name            = @name
	,year            = @year
	,updated_by      = @updated_by
	,updated_date    = GETDATE()
WHERE
	album_id = @album_id

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_album_track_ups]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_track_ups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_album_track_ups]
(
	 @xml_list   nvarchar(max)
	,@updated_by varchar(30)
)
AS
BEGIN

DECLARE @intDoc int
DECLARE @doc    nvarchar(max)
SET @doc = @xml_list
--
-- Create an internal representation of the XML document
--
EXEC sp_xml_preparedocument @intDoc OUTPUT, @doc


CREATE TABLE #tmp
(
	 album_id           int
	,album_track_id     int
	,artist_id          int
	,genre_id           int
	,itunes_track_id    int
	,kind_type_id       int
	,manual_update      bit
	,name               varchar(128)
	,persistent_id      varchar(64)
	,total_time_string  varchar(32)
	,track_number       int
)
INSERT INTO #tmp
(
	 album_id
	,album_track_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,manual_update
	,name
	,persistent_id
	,total_time_string
	,track_number
)
SELECT
	 album_id
	,album_track_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,manual_update
	,name
	,persistent_id
	,total_time_string
	,track_number
FROM OPENXML (@intDoc, ''ArrayOfAlbumTrack/AlbumTrack'', 1)
WITH (
	 album_id           int                 ''AlbumId''
	,album_track_id     int                 ''AlbumTrackId''
	,artist_id          int                 ''ArtistId''
	,genre_id           int                 ''GenreId''
	,itunes_track_id    int                 ''ItunesTrackId''
	,kind_type_id       int                 ''KindTypeId''
	,manual_update      bit                 ''ManualUpdate''
	,name               varchar(128)        ''Name''
	,persistent_id      varchar(64)         ''PersistentId''
	,total_time_string  varchar(32)         ''TotalTimeString''
	,track_number       int                 ''TrackNumber''
)



UPDATE #tmp
SET
	album_track_id = tbl.album_track_id
FROM
	#tmp tmp
	INNER JOIN t_album_track tbl
		ON(tmp.persistent_id = tbl.persistent_id)

UPDATE t_album_track
SET
	 album_id           = tmp.album_id
	,artist_id          = tmp.artist_id
	,genre_id           = tmp.genre_id
	,itunes_track_id    = tmp.itunes_track_id
	,kind_type_id       = tmp.kind_type_id
	,manual_update      = tmp.manual_update
	,name               = tmp.name
	,persistent_id      = tmp.persistent_id
	,total_time_string  = tmp.total_time_string
	,track_number       = tmp.track_number
	,updated_by         = @updated_by
	,updated_date       = GETDATE()
FROM
	t_album_track tbl
	INNER JOIN #tmp tmp
		ON(tbl.album_track_id = tmp.album_track_id)
WHERE
	tbl.manual_update = 0


INSERT INTO t_album_track
(
	 album_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,manual_update
	,name
	,persistent_id
	,total_time_string
	,track_number
	,updated_by
)
SELECT
	 tmp.album_id
	,tmp.artist_id
	,tmp.genre_id
	,tmp.itunes_track_id
	,tmp.kind_type_id
	,tmp.manual_update
	,tmp.name
	,tmp.persistent_id
	,tmp.total_time_string
	,tmp.track_number
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_album_track tbl
		ON(tmp.album_track_id = tbl.album_track_id)
WHERE
	tbl.album_track_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_album_track_upd]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_track_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_album_track_upd]
(
	 @album_id           int
	,@album_track_id     int
	,@artist_id          int
	,@genre_id           int
	,@itunes_track_id    int
	,@kind_type_id       int
	,@manual_update      bit
	,@name               varchar(128)
	,@persistent_id      varchar(64)
	,@total_time_string  varchar(32)
	,@track_number       int
	,@updated_by         varchar(30)
)
AS
UPDATE dbo.t_album_track
SET
	 album_id			 = @album_id
	,artist_id           = @artist_id
	,genre_id            = @genre_id
	,itunes_track_id     = @itunes_track_id
	,kind_type_id        = @kind_type_id
	,manual_update       = @manual_update
	,name                = @name
	,persistent_id       = @persistent_id
	,total_time_string   = @total_time_string
	,track_number        = @track_number
	,updated_by          = @updated_by
	,updated_date        = GETDATE()
WHERE
	album_track_id = @album_track_id

SET ANSI_NULLS OFF
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_album_track_sel]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_track_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[prc_album_track_sel]

AS
BEGIN


SELECT
	 album_id
	,album_track_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,manual_update
	,name
	,persistent_id
	,total_time_string
	,track_number
FROM
	dbo.t_album_track WITH (NOLOCK)


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[prc_album_track_ins]    Script Date: 12/07/2013 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_album_track_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[prc_album_track_ins]
(
	 @album_id           int
	,@album_track_id     int
	,@artist_id          int
	,@genre_id           int
	,@itunes_track_id    int
	,@kind_type_id       int
	,@manual_update      bit
	,@name               varchar(128)
	,@persistent_id      varchar(64)
	,@total_time_string  varchar(32)
	,@track_number       int
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_album_track
(
	 album_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,manual_update
	,name
	,persistent_id
	,total_time_string
	,track_number
	,updated_by
)
VALUES
(
	 @album_id             
	,@artist_id          
	,@genre_id           
	,@itunes_track_id    
	,@kind_type_id       
	,@manual_update      
	,@name               
	,@persistent_id      
	,@total_time_string  
	,@track_number       
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
' 
END
GO
