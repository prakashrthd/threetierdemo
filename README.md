threetierdemo
=============
Hello Friend,

If you want to run this code successfully, you have to create the database in SQL Server and respective changes 
should be made in web.config file. Here, I have put the SQL Script for creating table and store procedure. You have to 
create Database in SQL Server your seleft and run the below scring into that database. 

/****** Object:  StoredProcedure [dbo].[spContacts_DeleteByField]    Script Date: 09/28/2013 15:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spContacts_DeleteByField]
	@FieldName varchar(100),
	@Value varchar(1000)
AS

	DECLARE @query varchar(2000);

	SET @query = 'DELETE FROM [dbo].[Contacts] WHERE [' + @FieldName  + '] = ''' + @Value + ''''
	EXEC(@query)
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 09/28/2013 15:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[ProfiePhoto] [varchar](50) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spContacts_Search]    Script Date: 09/28/2013 15:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Prakash Rathod
-- Create date: <Create Date,,>
-- Description:	spContacts_Search '2013-07-10'
-- =============================================
CREATE PROCEDURE [dbo].[spContacts_Search]
	@SearchText varchar(max)
AS
BEGIN
	
	SET NOCOUNT ON;
	Declare @query varchar(max)
	SET @query = 'SELECT [Id], [FirstName], [LastName], [City], [Phone], [Mobile], [ProfiePhoto], [Modified] FROM [dbo].[Contacts]'
	
	if(len(@SearchText)>0)
	set @query += ' where [FirstName] like ''%' + @SearchText + '%'' or LastName like ''%' + @SearchText + 
	'%'' or City like ''%' + @SearchText + '%'' or Phone like ''%' + @SearchText + '%'' or Mobile like ''%' + @SearchText +	'%'''
	
	print (@query)
	EXEC(@query)
END
GO
/****** Object:  StoredProcedure [dbo].[spContacts_SelectByField]    Script Date: 09/28/2013 15:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spContacts_SelectByField]
	@FieldName varchar(100),
	@Value varchar(1000)
AS

	DECLARE @query varchar(2000);

	SET @query = 'SELECT [Id], [FirstName], [LastName], [City], [Phone], [Mobile], [ProfiePhoto], [Modified] FROM [dbo].[Contacts] WHERE [' + @FieldName  + '] = ''' + @Value + ''''
	EXEC(@query)
GO
/****** Object:  StoredProcedure [dbo].[spContacts_Update]    Script Date: 09/28/2013 15:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spContacts_Update]
	@Id int,
	@FirstName varchar(50) = null,
	@LastName varchar(50) = null,
	@City varchar(50) = null,
	@Phone varchar(50) = null,
	@Mobile varchar(50) = null,
	@ProfiePhoto varchar(50) = null,
	@Modified datetime = null

AS

UPDATE [dbo].[Contacts]
SET
	[FirstName] = @FirstName,
	[LastName] = @LastName,
	[City] = @City,
	[Phone] = @Phone,
	[Mobile] = @Mobile,
	[ProfiePhoto] = @ProfiePhoto,
	[Modified] = @Modified
 WHERE 
	[Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[spContacts_SelectByPrimaryKey]    Script Date: 09/28/2013 15:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spContacts_SelectByPrimaryKey]
	@Id int
AS

	SELECT 
		[Id], [FirstName], [LastName], [City], [Phone], [Mobile], [ProfiePhoto], [Modified]
	FROM [dbo].[Contacts]
	WHERE 
			[Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[spContacts_SelectAll]    Script Date: 09/28/2013 15:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spContacts_SelectAll]
AS

	SELECT 
		[Id], [FirstName], [LastName], [City], [Phone], [Mobile], [ProfiePhoto], [Modified]
	FROM [dbo].[Contacts]
GO
/****** Object:  StoredProcedure [dbo].[spContacts_Insert]    Script Date: 09/28/2013 15:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spContacts_Insert]
	@Id int output,
	@FirstName varchar(50) = null ,
	@LastName varchar(50) = null ,
	@City varchar(50) = null ,
	@Phone varchar(50) = null ,
	@Mobile varchar(50) = null ,
	@ProfiePhoto varchar(50) = null ,
	@Modified datetime = null 

AS

INSERT [dbo].[Contacts]
(
	[FirstName],
	[LastName],
	[City],
	[Phone],
	[Mobile],
	[ProfiePhoto],
	[Modified]

)
VALUES
(
	@FirstName,
	@LastName,
	@City,
	@Phone,
	@Mobile,
	@ProfiePhoto,
	@Modified

)
	SELECT @Id=SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[spContacts_DeleteByPrimaryKey]    Script Date: 09/28/2013 15:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spContacts_DeleteByPrimaryKey]
	@Id int
AS

DELETE FROM [dbo].[Contacts]
 WHERE 
	[Id] = @Id
GO
