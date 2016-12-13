IF OBJECT_ID('dbo.prc_track_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_track_ins
        IF OBJECT_ID('dbo.prc_track_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_track_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_track_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_track_ins
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
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_track_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_track_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_track_ins >>>'
    GO
