USE [jooce]
GO

--
-- DROP
--

DROP TABLE [dbo].[evaluation_type]
GO


ALTER TABLE [dbo].[pgn_header] DROP CONSTRAINT [FK_pgn_header_pgn]
GO


DROP TABLE [dbo].[pgn_header]
GO


DROP TABLE [dbo].[pgn]
GO

--
-- CREATE
--

CREATE TABLE [dbo].[evaluation_type](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[evaluation_type] [varchar](64) NOT NULL
) ON [PRIMARY]
GO

USE [jooce]
GO


CREATE TABLE [dbo].[pgn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [bigint] NOT NULL,
	[text] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_pgn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[pgn_header](
	[pgn_id] [int] NOT NULL,
	[header] [varchar](64) NOT NULL,
	[header_value] [varchar](64) NOT NULL,
 CONSTRAINT [PK_pgn_header] PRIMARY KEY CLUSTERED 
(
	[pgn_id] ASC,
	[header] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[pgn_header]  WITH CHECK ADD  CONSTRAINT [FK_pgn_header_pgn] FOREIGN KEY([pgn_id])
REFERENCES [dbo].[pgn] ([id])
GO

ALTER TABLE [dbo].[pgn_header] CHECK CONSTRAINT [FK_pgn_header_pgn]
GO






