USE [Media]
GO
/****** Object:  ForeignKey [FK_t_key_word_index_t_key_word]    Script Date: 12/21/2013 01:02:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_key_word_index_t_key_word]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_key_word_index]'))
ALTER TABLE [dbo].[t_key_word_index] DROP CONSTRAINT [FK_t_key_word_index_t_key_word]
GO
/****** Object:  ForeignKey [FK_t_key_word_index_t_post]    Script Date: 12/21/2013 01:02:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_key_word_index_t_post]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_key_word_index]'))
ALTER TABLE [dbo].[t_key_word_index] DROP CONSTRAINT [FK_t_key_word_index_t_post]
GO
/****** Object:  ForeignKey [FK_t_post_t_thread]    Script Date: 12/21/2013 01:02:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_post_t_thread]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_post]'))
ALTER TABLE [dbo].[t_post] DROP CONSTRAINT [FK_t_post_t_thread]
GO
/****** Object:  Table [dbo].[t_key_word_index]    Script Date: 12/21/2013 01:02:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_key_word_index_t_key_word]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_key_word_index]'))
ALTER TABLE [dbo].[t_key_word_index] DROP CONSTRAINT [FK_t_key_word_index_t_key_word]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_key_word_index_t_post]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_key_word_index]'))
ALTER TABLE [dbo].[t_key_word_index] DROP CONSTRAINT [FK_t_key_word_index_t_post]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_key_word_index_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_key_word_index] DROP CONSTRAINT [DF_t_key_word_index_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_key_word_index_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_key_word_index] DROP CONSTRAINT [DF_t_key_word_index_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_key_word_index]') AND type in (N'U'))
DROP TABLE [dbo].[t_key_word_index]
GO
/****** Object:  Table [dbo].[t_post]    Script Date: 12/21/2013 01:02:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_post_t_thread]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_post]'))
ALTER TABLE [dbo].[t_post] DROP CONSTRAINT [FK_t_post_t_thread]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_post_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_post] DROP CONSTRAINT [DF_t_post_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_post_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_post] DROP CONSTRAINT [DF_t_post_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_post]') AND type in (N'U'))
DROP TABLE [dbo].[t_post]
GO
/****** Object:  Table [dbo].[t_skip_word]    Script Date: 12/21/2013 01:02:25 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_skip_word_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_skip_word] DROP CONSTRAINT [DF_t_skip_word_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_skip_word_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_skip_word] DROP CONSTRAINT [DF_t_skip_word_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_skip_word]') AND type in (N'U'))
DROP TABLE [dbo].[t_skip_word]
GO
/****** Object:  Table [dbo].[t_thread]    Script Date: 12/21/2013 01:02:25 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_thread_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_thread] DROP CONSTRAINT [DF_t_thread_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_thread_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_thread] DROP CONSTRAINT [DF_t_thread_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_thread]') AND type in (N'U'))
DROP TABLE [dbo].[t_thread]
GO
/****** Object:  Table [dbo].[t_key_word]    Script Date: 12/21/2013 01:02:24 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_key_word_updated_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_key_word] DROP CONSTRAINT [DF_t_key_word_updated_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_t_key_word_updated_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[t_key_word] DROP CONSTRAINT [DF_t_key_word_updated_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_key_word]') AND type in (N'U'))
DROP TABLE [dbo].[t_key_word]
GO
/****** Object:  Table [dbo].[t_key_word]    Script Date: 12/21/2013 01:02:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_key_word]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_key_word](
	[word] [varchar](256) NOT NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_key_word_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NOT NULL CONSTRAINT [DF_t_key_word_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_key_word_1] PRIMARY KEY CLUSTERED 
(
	[word] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_thread]    Script Date: 12/21/2013 01:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_thread]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_thread](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](256) NOT NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_thread_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NOT NULL CONSTRAINT [DF_t_thread_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_thread] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_skip_word]    Script Date: 12/21/2013 01:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_skip_word]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_skip_word](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[skip_word] [varchar](256) NOT NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_skip_word_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](256) NOT NULL CONSTRAINT [DF_t_skip_word_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_skip_word] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_t_skip_word] UNIQUE NONCLUSTERED 
(
	[skip_word] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_post]    Script Date: 12/21/2013 01:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_post]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[author] [varchar](256) NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[date_string] [varchar](32) NOT NULL,
	[thread_id] [int] NOT NULL,
	[title] [varchar](2560) NOT NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_post_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](256) NOT NULL CONSTRAINT [DF_t_post_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_key_word_index]    Script Date: 12/21/2013 01:02:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_key_word_index]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_key_word_index](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key_word] [varchar](256) NOT NULL,
	[post_id] [int] NOT NULL,
	[count] [int] NOT NULL,
	[updated_date] [datetime] NOT NULL CONSTRAINT [DF_t_key_word_index_updated_date]  DEFAULT (getdate()),
	[updated_by] [varchar](30) NOT NULL CONSTRAINT [DF_t_key_word_index_updated_by]  DEFAULT (suser_sname()),
 CONSTRAINT [PK_t_key_word_index] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_t_key_word_index_t_key_word]    Script Date: 12/21/2013 01:02:24 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_key_word_index_t_key_word]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_key_word_index]'))
ALTER TABLE [dbo].[t_key_word_index]  WITH CHECK ADD  CONSTRAINT [FK_t_key_word_index_t_key_word] FOREIGN KEY([key_word])
REFERENCES [dbo].[t_key_word] ([word])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_key_word_index_t_key_word]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_key_word_index]'))
ALTER TABLE [dbo].[t_key_word_index] CHECK CONSTRAINT [FK_t_key_word_index_t_key_word]
GO
/****** Object:  ForeignKey [FK_t_key_word_index_t_post]    Script Date: 12/21/2013 01:02:24 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_key_word_index_t_post]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_key_word_index]'))
ALTER TABLE [dbo].[t_key_word_index]  WITH CHECK ADD  CONSTRAINT [FK_t_key_word_index_t_post] FOREIGN KEY([post_id])
REFERENCES [dbo].[t_post] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_key_word_index_t_post]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_key_word_index]'))
ALTER TABLE [dbo].[t_key_word_index] CHECK CONSTRAINT [FK_t_key_word_index_t_post]
GO
/****** Object:  ForeignKey [FK_t_post_t_thread]    Script Date: 12/21/2013 01:02:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_post_t_thread]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_post]'))
ALTER TABLE [dbo].[t_post]  WITH CHECK ADD  CONSTRAINT [FK_t_post_t_thread] FOREIGN KEY([thread_id])
REFERENCES [dbo].[t_thread] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_t_post_t_thread]') AND parent_object_id = OBJECT_ID(N'[dbo].[t_post]'))
ALTER TABLE [dbo].[t_post] CHECK CONSTRAINT [FK_t_post_t_thread]
GO





INSERT INTO t_thread VALUES ('Public', GETDATE(), SUSER_SNAME())
INSERT INTO t_thread VALUES ('Dialogica - FL', GETDATE(), SUSER_SNAME())


DECLARE @tmp TABLE ( word varchar(256) )

INSERT INTO @tmp VALUES (' ')
INSERT INTO @tmp VALUES ('A')
INSERT INTO @tmp VALUES ('ALL')
INSERT INTO @tmp VALUES ('AM')
INSERT INTO @tmp VALUES ('AND')
INSERT INTO @tmp VALUES ('ANY')
INSERT INTO @tmp VALUES ('ARE')
INSERT INTO @tmp VALUES ('AS')
INSERT INTO @tmp VALUES ('AT')
INSERT INTO @tmp VALUES ('BE')
INSERT INTO @tmp VALUES ('BECAUSE')
INSERT INTO @tmp VALUES ('BEEN')
INSERT INTO @tmp VALUES ('BOTH')
INSERT INTO @tmp VALUES ('BUT')
INSERT INTO @tmp VALUES ('BY')
INSERT INTO @tmp VALUES ('CANNOT')
INSERT INTO @tmp VALUES ('COULD')
INSERT INTO @tmp VALUES ('DIDNT')
INSERT INTO @tmp VALUES ('DONT')
INSERT INTO @tmp VALUES ('EACH')
INSERT INTO @tmp VALUES ('FOR')
INSERT INTO @tmp VALUES ('GET')
INSERT INTO @tmp VALUES ('HAS')
INSERT INTO @tmp VALUES ('HAVE')
INSERT INTO @tmp VALUES ('HERE')
INSERT INTO @tmp VALUES ('HOW')
INSERT INTO @tmp VALUES ('HOWEVER')
INSERT INTO @tmp VALUES ('I')
INSERT INTO @tmp VALUES ('IF')
INSERT INTO @tmp VALUES ('IM')
INSERT INTO @tmp VALUES ('IN')
INSERT INTO @tmp VALUES ('INTO')
INSERT INTO @tmp VALUES ('IS')
INSERT INTO @tmp VALUES ('IT')
INSERT INTO @tmp VALUES ('ITS')
INSERT INTO @tmp VALUES ('LET')
INSERT INTO @tmp VALUES ('ME')
INSERT INTO @tmp VALUES ('MORE')
INSERT INTO @tmp VALUES ('MOST')
INSERT INTO @tmp VALUES ('MY')
INSERT INTO @tmp VALUES ('MYSELF')
INSERT INTO @tmp VALUES ('NO')
INSERT INTO @tmp VALUES ('NONE')
INSERT INTO @tmp VALUES ('NOT')
INSERT INTO @tmp VALUES ('OF')
INSERT INTO @tmp VALUES ('ON')
INSERT INTO @tmp VALUES ('OR')
INSERT INTO @tmp VALUES ('OTHER')
INSERT INTO @tmp VALUES ('OUR')
INSERT INTO @tmp VALUES ('OUT')
INSERT INTO @tmp VALUES ('PERHAPS')
INSERT INTO @tmp VALUES ('QUITE')
INSERT INTO @tmp VALUES ('SHE')
INSERT INTO @tmp VALUES ('SO')
INSERT INTO @tmp VALUES ('SOME')
INSERT INTO @tmp VALUES ('THAN')
INSERT INTO @tmp VALUES ('THAT')
INSERT INTO @tmp VALUES ('THE')
INSERT INTO @tmp VALUES ('THEM')
INSERT INTO @tmp VALUES ('THERE')
INSERT INTO @tmp VALUES ('THESE')
INSERT INTO @tmp VALUES ('THEY')
INSERT INTO @tmp VALUES ('THIS')
INSERT INTO @tmp VALUES ('TO')
INSERT INTO @tmp VALUES ('VERY')
INSERT INTO @tmp VALUES ('WAS')
INSERT INTO @tmp VALUES ('WE')
INSERT INTO @tmp VALUES ('WHAT')
INSERT INTO @tmp VALUES ('WHEN')
INSERT INTO @tmp VALUES ('WHICH')
INSERT INTO @tmp VALUES ('WHO')
INSERT INTO @tmp VALUES ('WITH')
INSERT INTO @tmp VALUES ('YOU')
INSERT INTO @tmp VALUES ('YOUR')

INSERT INTO t_skip_word 
(
	skip_word
	,updated_date
	,updated_by
)
SELECT
	word
	,GETDATE()
	,SUSER_SNAME()
FROM
	@tmp
