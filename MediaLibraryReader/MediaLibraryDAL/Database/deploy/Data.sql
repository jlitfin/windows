


SET IDENTITY_INSERT t_genre_type ON
INSERT INTO t_genre_type 
(
	 genre_type_id
	,genre_type_text
	,genre_type_map
	,updated_date
	,updated_by
)
VALUES 
(
	0
	,'Unknown Value'
	,'Unmapped'
	,GETDATE()
	,SUSER_SNAME()
)
SET IDENTITY_INSERT t_genre_type OFF

SET IDENTITY_INSERT t_kind_type ON
INSERT INTO t_kind_type
(
	kind_type_id
	,kind_type_text
	,kind_type_map
	,updated_date
	,updated_by
)
VALUES
(
	0
	,'Unknown Value'
	,'Unmapped'
	,GETDATE()
	,SUSER_SNAME()
)
INSERT INTO t_kind_type 
(
	kind_type_id
	,kind_type_text
	,kind_type_map
	,updated_date
	,updated_by
)
VALUES (1,'bluray', 'video', GETDATE(), SUSER_SNAME())
INSERT INTO t_kind_type 
(
	kind_type_id
	,kind_type_text
	,kind_type_map
	,updated_date
	,updated_by
)
VALUES (2,'dvd', 'video', GETDATE(), SUSER_SNAME())
SET IDENTITY_INSERT t_kind_type OFF

SET IDENTITY_INSERT t_artist ON
INSERT INTO t_artist
(
	artist_id
	,name
	,base_name
	,updated_date
	,updated_by
)
VALUES
(
	0
	,'Unknown Value'
	,'Unknown Value'
	,GETDATE()
	,SUSER_SNAME()
)
SET IDENTITY_INSERT t_artist OFF


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
	,updated_date
)
VALUES
(
	0
	,'Manual Entry'
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,null
	,SUSER_SNAME()
	,GETDATE()
)
