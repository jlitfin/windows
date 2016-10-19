USE [web_test]
GO

/****** Object:  StoredProcedure [dbo].[prc_skip_word_sel]    Script Date: 12/20/2013 14:00:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_skip_word_sel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[prc_skip_word_sel]
GO

USE [web_test]
GO

/****** Object:  StoredProcedure [dbo].[prc_skip_word_sel]    Script Date: 12/20/2013 14:00:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_skip_word_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[prc_skip_word_sel]

AS
BEGIN


SELECT
	 id
	,skip_word
FROM
	dbo.t_skip_word WITH (NOLOCK)


END
' 
END
GO


