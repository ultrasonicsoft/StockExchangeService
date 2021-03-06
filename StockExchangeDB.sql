USE [master]
GO
/****** Object:  Database [StockExchangeDb]    Script Date: 6/26/2016 8:26:25 PM ******/
CREATE DATABASE [StockExchangeDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockExchangeDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StockExchangeDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockExchangeDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StockExchangeDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockExchangeDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockExchangeDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockExchangeDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockExchangeDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockExchangeDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockExchangeDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockExchangeDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockExchangeDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockExchangeDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockExchangeDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockExchangeDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockExchangeDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockExchangeDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockExchangeDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockExchangeDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockExchangeDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockExchangeDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockExchangeDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockExchangeDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockExchangeDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockExchangeDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockExchangeDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockExchangeDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockExchangeDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockExchangeDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockExchangeDb] SET  MULTI_USER 
GO
ALTER DATABASE [StockExchangeDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockExchangeDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockExchangeDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockExchangeDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StockExchangeDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StockExchangeDb]
GO
/****** Object:  User [IIS APPPOOL\.NET v2.0]    Script Date: 6/26/2016 8:26:25 PM ******/
CREATE USER [IIS APPPOOL\.NET v2.0] FOR LOGIN [IIS APPPOOL\.NET v2.0] WITH DEFAULT_SCHEMA=[db_owner]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\.NET v2.0]
GO
/****** Object:  Table [dbo].[PortfolioStocks]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortfolioStocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [int] NOT NULL,
	[StockId] [int] NOT NULL,
 CONSTRAINT [PK_PortfolioStocks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Price] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NULL,
	[email] [nvarchar](150) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserPortfolio]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPortfolio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserPortfolio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[PortfolioStocks] ON 

INSERT [dbo].[PortfolioStocks] ([Id], [PortfolioId], [StockId]) VALUES (1, 1, 1)
INSERT [dbo].[PortfolioStocks] ([Id], [PortfolioId], [StockId]) VALUES (2, 1, 3)
INSERT [dbo].[PortfolioStocks] ([Id], [PortfolioId], [StockId]) VALUES (3, 1, 4)
INSERT [dbo].[PortfolioStocks] ([Id], [PortfolioId], [StockId]) VALUES (4, 1, 5)
SET IDENTITY_INSERT [dbo].[PortfolioStocks] OFF
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (1, N'INFY', N'Infosys', CAST(3200.55 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (2, N'REL', N'Reliance', CAST(2233.13 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (3, N'WIPRO', N'Wipro Pvt. Ltd.', CAST(223.23 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (4, N'BHEL', N'Bharat Petrolium', CAST(230.23 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (5, N'TATASTEEL', N'Tata Steel Limited', CAST(311.95 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (6, N'JUBLFOOD', N'Jubilant FoodWorks Ltd', CAST(1045.95 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (7, N'SIEMENS', N'	Siemens Ltd', CAST(1258.50 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (8, N'LUPIN', N'Lupin Limited', CAST(1464.00 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (9, N'NESTLEIND', N'Nestle India Limited', CAST(6500.00 AS Numeric(18, 2)))
INSERT [dbo].[Stock] ([Id], [Code], [Name], [Price]) VALUES (10, N'COLPAL', N'Colgate-Palmolive.', CAST(883.50 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Stock] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [email]) VALUES (1, N'admin', N'admin', N'admin', N'admin@gmail.com')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [email]) VALUES (2, N'balram', N'balram', N'user', N'balram@gmail.com')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [email]) VALUES (3, N'user1', N'password1!', N'User', N'user@gmail.com')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [email]) VALUES (4, N'user2', N'password1!', N'User', N'user2@gmail.com')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [email]) VALUES (5, N'user3', N'password1!', N'User', N'user3@gmail.com')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserPortfolio] ON 

INSERT [dbo].[UserPortfolio] ([Id], [UserId], [Name]) VALUES (1, 2, N'p2')
SET IDENTITY_INSERT [dbo].[UserPortfolio] OFF
/****** Object:  StoredProcedure [dbo].[AddStocksInPortfolio]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddStocksInPortfolio]
	-- Add the parameters for the stored procedure here
	(@PortfolioId int,
		@StockId int	
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO PortfolioStocks(PortfolioId,StockId)
	VALUES(@PortfolioId, @StockId)

END

GO
/****** Object:  StoredProcedure [dbo].[CreateNewUser]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateNewUser]
	-- Add the parameters for the stored procedure here
	(@Username nvarchar(50),
	@Password nvarchar(50),
	@Role nvarchar(50),
	@Email nvarchar(150)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[User]
           ([Username]
           ,[Password]
           ,[Role]
           ,[email])
     VALUES
           (@Username
           ,@Password
           ,@Role
           ,@Email)

END

GO
/****** Object:  StoredProcedure [dbo].[CreatePortfolio]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreatePortfolio]
	-- Add the parameters for the stored procedure here
	(@UserName nvarchar(50),
		@Name nvarchar(50)	
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @UserId INT = 0;
	
	SELECT @UserId = Id FROM [User]
	WHERE Username = @UserName

	INSERT INTO UserPortfolio(UserId, Name)
	VALUES(@UserId, @Name)

	SELECT MAX(Id) As Id FROM UserPortfolio

END

GO
/****** Object:  StoredProcedure [dbo].[GetAllPortfolios]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllPortfolios]
	-- Add the parameters for the stored procedure here
	(@UserName nvarchar(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @UserId INT;

	SELECT @UserId = Id FROM [User]
	WHERE Username = @UserName

	SELECT Id, Name FROM UserPortfolio
	WHERE userid = @UserId
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllStocks]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllStocks]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id]
		  ,[Code]
		  ,[Name]
		  ,[Price]
  FROM [dbo].[Stock]
	
END

GO
/****** Object:  StoredProcedure [dbo].[GetPortfolioDetails]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPortfolioDetails]
	-- Add the parameters for the stored procedure here
	(@PortfolioId int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Stock s
	LEFT OUTER JOIN PortfolioStocks p
	ON s.Id = p.StockId
	WHERE p.PortfolioId = @PortfolioId
	
END

GO
/****** Object:  StoredProcedure [dbo].[GetStockPrice]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStockPrice]
	-- Add the parameters for the stored procedure here
	@StockCode nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Price FROM Stock
	WHERE Code = @StockCode
END

GO
/****** Object:  StoredProcedure [dbo].[IsAuthenticatedUser]    Script Date: 6/26/2016 8:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IsAuthenticatedUser]
	-- Add the parameters for the stored procedure here
	(@Username nvarchar(50),
	@Password nvarchar(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT CASE WHEN Id IS NULL THEN 'False' ELSE 'True' END As Result FROM [User]
	WHERE Username = @Username AND [Password] = @Password
END

GO
USE [master]
GO
ALTER DATABASE [StockExchangeDb] SET  READ_WRITE 
GO
