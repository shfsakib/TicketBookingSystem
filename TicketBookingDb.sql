USE [master]
GO
/****** Object:  Database [TicketBookingDb]    Script Date: 1/22/2021 5:38:03 PM ******/
CREATE DATABASE [TicketBookingDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TicketBookingDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.LOCAL\MSSQL\DATA\TicketBookingDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TicketBookingDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.LOCAL\MSSQL\DATA\TicketBookingDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TicketBookingDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TicketBookingDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TicketBookingDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TicketBookingDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TicketBookingDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TicketBookingDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TicketBookingDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TicketBookingDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TicketBookingDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TicketBookingDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TicketBookingDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TicketBookingDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TicketBookingDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TicketBookingDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TicketBookingDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TicketBookingDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TicketBookingDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TicketBookingDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TicketBookingDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TicketBookingDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TicketBookingDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TicketBookingDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TicketBookingDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TicketBookingDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TicketBookingDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TicketBookingDb] SET  MULTI_USER 
GO
ALTER DATABASE [TicketBookingDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TicketBookingDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TicketBookingDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TicketBookingDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TicketBookingDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TicketBookingDb]
GO
/****** Object:  Table [dbo].[BookTicket]    Script Date: 1/22/2021 5:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookTicket](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[CoachId] [int] NOT NULL,
	[FromLocation] [int] NOT NULL,
	[ToLocation] [int] NOT NULL,
	[JourneyDate] [nvarchar](50) NOT NULL,
	[Fare] [decimal](18, 2) NOT NULL,
	[SeatName] [nvarchar](50) NOT NULL,
	[CoachType] [nvarchar](50) NOT NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[ServiceCharge] [decimal](18, 2) NOT NULL,
	[Advance] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TokenId] [nvarchar](50) NOT NULL,
	[BkashNo] [nvarchar](50) NOT NULL,
	[TransactionNo] [nvarchar](50) NOT NULL,
	[Amount] [nvarchar](50) NOT NULL,
	[BookTime] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_BookBusTicket] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoachInfo]    Script Date: 1/22/2021 5:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoachInfo](
	[CoachId] [int] IDENTITY(1,1) NOT NULL,
	[CoachName] [nvarchar](max) NULL,
	[CoachType] [nvarchar](50) NULL,
	[CoachNo] [nvarchar](50) NULL,
	[DistrictFrom] [int] NULL,
	[DistrictTo] [int] NULL,
	[StartingPoint] [nvarchar](max) NULL,
	[EndPoint] [nvarchar](max) NULL,
	[DepartureTime] [nvarchar](50) NULL,
	[ArrivalTime] [nvarchar](50) NULL,
	[TicketPrice] [decimal](18, 2) NULL,
	[Status] [nvarchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[InTime] [nvarchar](50) NULL,
	[SeatType] [nvarchar](50) NULL,
	[CoachStatus] [nvarchar](50) NULL,
	[SeatCapacity] [nvarchar](50) NULL,
 CONSTRAINT [PK_BusInfo] PRIMARY KEY CLUSTERED 
(
	[CoachId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 1/22/2021 5:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Id] [int] NOT NULL,
	[Division_Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[bn_name] [nvarchar](50) NULL,
	[lat] [decimal](18, 9) NULL,
	[lon] [decimal](18, 9) NULL,
	[website] [nvarchar](50) NULL,
	[created_at] [nvarchar](50) NULL,
	[updated_at] [nvarchar](50) NULL,
 CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventInfo]    Script Date: 1/22/2021 5:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventInfo](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](max) NOT NULL,
	[EventAddress] [nvarchar](max) NULL,
	[EventLocation] [int] NULL,
	[StartTime] [nvarchar](50) NOT NULL,
	[EndTime] [nvarchar](50) NOT NULL,
	[EventDate] [nvarchar](50) NOT NULL,
	[SeatType] [nvarchar](50) NULL,
	[SeatCapacity] [int] NOT NULL,
	[Fare] [decimal](18, 2) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[CompanyId] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[InTime] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventInfo] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Registration]    Script Date: 1/22/2021 5:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[RegId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ContactNo] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[DateofBirth] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[InTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BookTicket] ON 

INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (13, 1002, 4, 43, 45, N'2021-01-22', CAST(250.00 AS Decimal(18, 2)), N'A1', N'Non Ac', CAST(1000.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), CAST(1100.00 AS Decimal(18, 2)), N'JNJSUNND', N'685506', N'8CbvsKJLx', N'220', N'06/01/2021_11:33:04', N'A', 1001)
INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (14, 1002, 4, 43, 45, N'2021-01-22', CAST(250.00 AS Decimal(18, 2)), N'A2', N'Non Ac', CAST(1000.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), CAST(1100.00 AS Decimal(18, 2)), N'JNJSUNND', N'685506', N'8CbvsKJLx', N'220', N'06/01/2021_11:33:04', N'A', 1001)
INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (15, 1002, 4, 43, 45, N'2021-01-22', CAST(250.00 AS Decimal(18, 2)), N'A3', N'Non Ac', CAST(1000.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), CAST(1100.00 AS Decimal(18, 2)), N'JNJSUNND', N'685506', N'8CbvsKJLx', N'220', N'06/01/2021_11:33:04', N'A', 1001)
INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (16, 1002, 4, 43, 45, N'2021-01-22', CAST(250.00 AS Decimal(18, 2)), N'A4', N'Non Ac', CAST(1000.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), CAST(1100.00 AS Decimal(18, 2)), N'JNJSUNND', N'685506', N'8CbvsKJLx', N'220', N'06/01/2021_11:33:04', N'A', 1001)
INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (19, 1002, 6, 43, 35, N'2021-01-15', CAST(850.00 AS Decimal(18, 2)), N'1', N'Non Ac', CAST(1700.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), CAST(1750.00 AS Decimal(18, 2)), N'YDPFAXJV', N'685506', N'7CdCVB2Xc', N'350', N'07/01/2021_11:44:55', N'A', 1001)
INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (22, 1002, 11, 43, 45, N'2021-01-15', CAST(3500.00 AS Decimal(18, 2)), N'3', N'N/A', CAST(10500.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(2110.00 AS Decimal(18, 2)), CAST(10550.00 AS Decimal(18, 2)), N'XQSIDWIR', N'685506', N'7Dk5Lvc3Xn', N'2110', N'13/01/2021_09:12:31', N'A', 1001)
INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (26, 1002, 4, 43, 0, N'2021-01-27', CAST(650.00 AS Decimal(18, 2)), N'4', N'Movie', CAST(2600.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(540.00 AS Decimal(18, 2)), CAST(2700.00 AS Decimal(18, 2)), N'BMJHZFJZ', N'685506', N'7DkfXjsao1c', N'540', N'15/01/2021_11:59:37', N'A', 1001)
INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (28, 1002, 5, 43, 0, N'2021-01-31', CAST(350.00 AS Decimal(18, 2)), N'2', N'Event', CAST(700.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(750.00 AS Decimal(18, 2)), N'TJJAVBCI', N'685506', N'8nb25XdcG', N'150', N'20/01/2021_11:03:21', N'A', 1001)
INSERT [dbo].[BookTicket] ([BookId], [CompanyId], [CoachId], [FromLocation], [ToLocation], [JourneyDate], [Fare], [SeatName], [CoachType], [SubTotal], [ServiceCharge], [Advance], [GrandTotal], [TokenId], [BkashNo], [TransactionNo], [Amount], [BookTime], [Status], [UserId]) VALUES (29, 1002, 5, 43, 0, N'2021-01-31', CAST(350.00 AS Decimal(18, 2)), N'4', N'Event', CAST(1400.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), N'FZFIKNEE', N'685506', N'7Daskadskd5', N'300', N'21/01/2021_10:59:15', N'A', 1001)
SET IDENTITY_INSERT [dbo].[BookTicket] OFF
SET IDENTITY_INSERT [dbo].[CoachInfo] ON 

INSERT [dbo].[CoachInfo] ([CoachId], [CoachName], [CoachType], [CoachNo], [DistrictFrom], [DistrictTo], [StartingPoint], [EndPoint], [DepartureTime], [ArrivalTime], [TicketPrice], [Status], [CompanyId], [InTime], [SeatType], [CoachStatus], [SeatCapacity]) VALUES (4, N'Soudia-Cox', N'Non Ac', N'01-Cox', 43, 45, N'Owasha', N'Dolphin chottor', N'08:00', N'12:00', CAST(250.00 AS Decimal(18, 2)), N'A', N'1002', N'06/01/2021_11:01:01', N'', N'Bus', N'')
INSERT [dbo].[CoachInfo] ([CoachId], [CoachName], [CoachType], [CoachNo], [DistrictFrom], [DistrictTo], [StartingPoint], [EndPoint], [DepartureTime], [ArrivalTime], [TicketPrice], [Status], [CompanyId], [InTime], [SeatType], [CoachStatus], [SeatCapacity]) VALUES (5, N'Soudia-Deck', N'Ac', N'02-Cox', 43, 45, N'Owasha', N'Dolphin chottor', N'23:00', N'03:00', CAST(500.00 AS Decimal(18, 2)), N'A', N'1002', N'06/01/2021_11:01:50', N'', N'Bus', N'')
INSERT [dbo].[CoachInfo] ([CoachId], [CoachName], [CoachType], [CoachNo], [DistrictFrom], [DistrictTo], [StartingPoint], [EndPoint], [DepartureTime], [ArrivalTime], [TicketPrice], [Status], [CompanyId], [InTime], [SeatType], [CoachStatus], [SeatCapacity]) VALUES (6, N'Soudia-Shamphan', N'Non Ac', N'01-Bar', 43, 35, N'Chittagong Sodorghat', N'Barishal Main Sodor', N'23:00', N'06:00', CAST(850.00 AS Decimal(18, 2)), N'A', N'1002', N'06/01/2021_11:11:31', N'E Class', N'Launch', N'180')
INSERT [dbo].[CoachInfo] ([CoachId], [CoachName], [CoachType], [CoachNo], [DistrictFrom], [DistrictTo], [StartingPoint], [EndPoint], [DepartureTime], [ArrivalTime], [TicketPrice], [Status], [CompanyId], [InTime], [SeatType], [CoachStatus], [SeatCapacity]) VALUES (7, N'Soudia-Kaptan', N'Non Ac', N'01-kap', 1, 34, N'Dhaka Sodorghat', N'Bargona Sodorghat', N'14:00', N'20:00', CAST(1000.00 AS Decimal(18, 2)), N'A', N'1002', N'06/01/2021_11:13:52', N'E Class', N'Launch', N'100')
INSERT [dbo].[CoachInfo] ([CoachId], [CoachName], [CoachType], [CoachNo], [DistrictFrom], [DistrictTo], [StartingPoint], [EndPoint], [DepartureTime], [ArrivalTime], [TicketPrice], [Status], [CompanyId], [InTime], [SeatType], [CoachStatus], [SeatCapacity]) VALUES (9, N'Soudia-Dhk', N'Non Ac', N'01-DHk', 43, 1, N'Owasha', N'Shapla Chottor', N'23:00', N'04:00', CAST(650.00 AS Decimal(18, 2)), N'A', N'1002', N'07/01/2021_12:05:36', N'', N'Bus', N'')
INSERT [dbo].[CoachInfo] ([CoachId], [CoachName], [CoachType], [CoachNo], [DistrictFrom], [DistrictTo], [StartingPoint], [EndPoint], [DepartureTime], [ArrivalTime], [TicketPrice], [Status], [CompanyId], [InTime], [SeatType], [CoachStatus], [SeatCapacity]) VALUES (10, N'Soudia-Express', N'Non Ac', N'01-KHK', 43, 1, N'Chittagong Sodorghat', N'Dhaka Sodorghat', N'08:00', N'16:00', CAST(800.00 AS Decimal(18, 2)), N'A', N'1002', N'07/01/2021_12:07:37', N'E Class', N'Launch', N'120')
INSERT [dbo].[CoachInfo] ([CoachId], [CoachName], [CoachType], [CoachNo], [DistrictFrom], [DistrictTo], [StartingPoint], [EndPoint], [DepartureTime], [ArrivalTime], [TicketPrice], [Status], [CompanyId], [InTime], [SeatType], [CoachStatus], [SeatCapacity]) VALUES (11, N'Flight-01', N'N/A', N'Flight-01', 43, 45, N'N/A', N'N/A', N'08:00', N'12:00', CAST(3500.00 AS Decimal(18, 2)), N'A', N'1002', N'12/01/2021_09:17:06', N'', N'Air', N'130')
SET IDENTITY_INSERT [dbo].[CoachInfo] OFF
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (1, 3, N'Dhaka', N'????', CAST(23.711525300 AS Decimal(18, 9)), CAST(90.411145100 AS Decimal(18, 9)), N'www.dhaka.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (2, 3, N'Faridpur', N'???????', CAST(23.607082200 AS Decimal(18, 9)), CAST(89.842940600 AS Decimal(18, 9)), N'www.faridpur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (3, 3, N'Gazipur', N'???????', CAST(24.002285800 AS Decimal(18, 9)), CAST(90.426428300 AS Decimal(18, 9)), N'www.gazipur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (4, 3, N'Gopalganj', N'?????????', CAST(23.005085700 AS Decimal(18, 9)), CAST(89.826605900 AS Decimal(18, 9)), N'www.gopalganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (5, 8, N'Jamalpur', N'????????', CAST(24.937533000 AS Decimal(18, 9)), CAST(89.937775000 AS Decimal(18, 9)), N'www.jamalpur.gov.bd', N'2015-09-13 04:33:27', N'2016-04-06 10:48:38')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (6, 3, N'Kishoreganj', N'?????????', CAST(24.444937000 AS Decimal(18, 9)), CAST(90.776575000 AS Decimal(18, 9)), N'www.kishoreganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (7, 3, N'Madaripur', N'?????????', CAST(23.164102000 AS Decimal(18, 9)), CAST(90.189680500 AS Decimal(18, 9)), N'www.madaripur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (8, 3, N'Manikganj', N'?????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.manikganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (9, 3, N'Munshiganj', N'??????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.munshiganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (10, 8, N'Mymensingh', N'???????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.mymensingh.gov.bd', N'2015-09-13 04:33:27', N'2016-04-06 10:49:01')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (11, 3, N'Narayanganj', N'???????????', CAST(23.633660000 AS Decimal(18, 9)), CAST(90.496482000 AS Decimal(18, 9)), N'www.narayanganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (12, 3, N'Narsingdi', N'???????', CAST(23.932233000 AS Decimal(18, 9)), CAST(90.715410000 AS Decimal(18, 9)), N'www.narsingdi.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (13, 8, N'Netrokona', N'?????????', CAST(24.870955000 AS Decimal(18, 9)), CAST(90.727887000 AS Decimal(18, 9)), N'www.netrokona.gov.bd', N'2015-09-13 04:33:27', N'2016-04-06 10:46:31')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (14, 3, N'Rajbari', N'???????', CAST(23.757430500 AS Decimal(18, 9)), CAST(89.644466500 AS Decimal(18, 9)), N'www.rajbari.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (15, 3, N'Shariatpur', N'????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.shariatpur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (16, 8, N'Sherpur', N'??????', CAST(25.020493300 AS Decimal(18, 9)), CAST(90.015296600 AS Decimal(18, 9)), N'www.sherpur.gov.bd', N'2015-09-13 04:33:27', N'2016-04-06 10:48:21')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (17, 3, N'Tangail', N'????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.tangail.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (18, 5, N'Bogra', N'?????', CAST(24.846522800 AS Decimal(18, 9)), CAST(89.377755000 AS Decimal(18, 9)), N'www.bogra.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (19, 5, N'Joypurhat', N'????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.joypurhat.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (20, 5, N'Naogaon', N'?????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.naogaon.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (21, 5, N'Natore', N'?????', CAST(24.420556000 AS Decimal(18, 9)), CAST(89.000282000 AS Decimal(18, 9)), N'www.natore.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (22, 5, N'Nawabganj', N'????????', CAST(24.596503400 AS Decimal(18, 9)), CAST(88.277512200 AS Decimal(18, 9)), N'www.chapainawabganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (23, 5, N'Pabna', N'?????', CAST(23.998524000 AS Decimal(18, 9)), CAST(89.233645000 AS Decimal(18, 9)), N'www.pabna.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (24, 5, N'Rajshahi', N'???????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.rajshahi.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (25, 5, N'Sirajgonj', N'?????????', CAST(24.453397800 AS Decimal(18, 9)), CAST(89.700681500 AS Decimal(18, 9)), N'www.sirajganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (26, 6, N'Dinajpur', N'????????', CAST(25.621706100 AS Decimal(18, 9)), CAST(88.635450400 AS Decimal(18, 9)), N'www.dinajpur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (27, 6, N'Gaibandha', N'?????????', CAST(25.328751000 AS Decimal(18, 9)), CAST(89.528088000 AS Decimal(18, 9)), N'www.gaibandha.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (28, 6, N'Kurigram', N'?????????', CAST(25.805445000 AS Decimal(18, 9)), CAST(89.636174000 AS Decimal(18, 9)), N'www.kurigram.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (29, 6, N'Lalmonirhat', N'??????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.lalmonirhat.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (30, 6, N'Nilphamari', N'?????????', CAST(25.931794000 AS Decimal(18, 9)), CAST(88.856006000 AS Decimal(18, 9)), N'www.nilphamari.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (31, 6, N'Panchagarh', N'??????', CAST(26.341100000 AS Decimal(18, 9)), CAST(88.554160600 AS Decimal(18, 9)), N'www.panchagarh.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (32, 6, N'Rangpur', N'?????', CAST(25.755809600 AS Decimal(18, 9)), CAST(89.244462000 AS Decimal(18, 9)), N'www.rangpur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (33, 6, N'Thakurgaon', N'?????????', CAST(26.033694500 AS Decimal(18, 9)), CAST(88.461683400 AS Decimal(18, 9)), N'www.thakurgaon.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (34, 1, N'Barguna', N'??????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.barguna.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (35, 1, N'Barisal', N'??????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.barisal.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (36, 1, N'Bhola', N'????', CAST(22.685923000 AS Decimal(18, 9)), CAST(90.648179000 AS Decimal(18, 9)), N'www.bhola.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (37, 1, N'Jhalokati', N'???????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.jhalakathi.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (38, 1, N'Patuakhali', N'?????????', CAST(22.359631600 AS Decimal(18, 9)), CAST(90.329871200 AS Decimal(18, 9)), N'www.patuakhali.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (39, 1, N'Pirojpur', N'????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.pirojpur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (40, 2, N'Bandarban', N'?????????', CAST(22.195327500 AS Decimal(18, 9)), CAST(92.218377300 AS Decimal(18, 9)), N'www.bandarban.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (41, 2, N'Brahmanbaria', N'??????????????', CAST(23.957090400 AS Decimal(18, 9)), CAST(91.111928600 AS Decimal(18, 9)), N'www.brahmanbaria.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (42, 2, N'Chandpur', N'???????', CAST(23.233258500 AS Decimal(18, 9)), CAST(90.671291200 AS Decimal(18, 9)), N'www.chandpur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (43, 2, N'Chittagong', N'?????????', CAST(22.335109000 AS Decimal(18, 9)), CAST(91.834073000 AS Decimal(18, 9)), N'www.chittagong.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (44, 2, N'Comilla', N'????????', CAST(23.468274700 AS Decimal(18, 9)), CAST(91.178813500 AS Decimal(18, 9)), N'www.comilla.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (45, 2, N'Cox''s Bazar', N'???? ?????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.coxsbazar.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (46, 2, N'Feni', N'????', CAST(23.023231000 AS Decimal(18, 9)), CAST(91.384084400 AS Decimal(18, 9)), N'www.feni.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (47, 2, N'Khagrachari', N'????????', CAST(23.119285000 AS Decimal(18, 9)), CAST(91.984663000 AS Decimal(18, 9)), N'www.khagrachhari.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (48, 2, N'Lakshmipur', N'??????????', CAST(22.942477000 AS Decimal(18, 9)), CAST(90.841184000 AS Decimal(18, 9)), N'www.lakshmipur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (49, 2, N'Noakhali', N'????????', CAST(22.869563000 AS Decimal(18, 9)), CAST(91.099398000 AS Decimal(18, 9)), N'www.noakhali.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (50, 2, N'Rangamati', N'??????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.rangamati.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (51, 7, N'Habiganj', N'???????', CAST(24.374945000 AS Decimal(18, 9)), CAST(91.415530000 AS Decimal(18, 9)), N'www.habiganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (52, 7, N'Maulvibazar', N'??????????', CAST(24.482934000 AS Decimal(18, 9)), CAST(91.777417000 AS Decimal(18, 9)), N'www.moulvibazar.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (53, 7, N'Sunamganj', N'?????????', CAST(25.065804200 AS Decimal(18, 9)), CAST(91.395011500 AS Decimal(18, 9)), N'www.sunamganj.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (54, 7, N'Sylhet', N'?????', CAST(24.889795600 AS Decimal(18, 9)), CAST(91.869789400 AS Decimal(18, 9)), N'www.sylhet.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (55, 4, N'Bagerhat', N'????????', CAST(22.651568000 AS Decimal(18, 9)), CAST(89.785938000 AS Decimal(18, 9)), N'www.bagerhat.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (56, 4, N'Chuadanga', N'??????????', CAST(23.640196100 AS Decimal(18, 9)), CAST(88.841841000 AS Decimal(18, 9)), N'www.chuadanga.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (57, 4, N'Jessore', N'????', CAST(23.166430000 AS Decimal(18, 9)), CAST(89.208112600 AS Decimal(18, 9)), N'www.jessore.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (58, 4, N'Jhenaidah', N'???????', CAST(23.544817600 AS Decimal(18, 9)), CAST(89.153921300 AS Decimal(18, 9)), N'www.jhenaidah.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (59, 4, N'Khulna', N'?????', CAST(22.815774000 AS Decimal(18, 9)), CAST(89.568679000 AS Decimal(18, 9)), N'www.khulna.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (60, 4, N'Kushtia', N'????????', CAST(23.901258000 AS Decimal(18, 9)), CAST(89.120482000 AS Decimal(18, 9)), N'www.kushtia.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (61, 4, N'Magura', N'??????', CAST(23.487337000 AS Decimal(18, 9)), CAST(89.419956000 AS Decimal(18, 9)), N'www.magura.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (62, 4, N'Meherpur', N'????????', CAST(23.762213000 AS Decimal(18, 9)), CAST(88.631821000 AS Decimal(18, 9)), N'www.meherpur.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (63, 4, N'Narail', N'?????', CAST(23.172534000 AS Decimal(18, 9)), CAST(89.512672000 AS Decimal(18, 9)), N'www.narail.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
INSERT [dbo].[District] ([Id], [Division_Id], [Name], [bn_name], [lat], [lon], [website], [created_at], [updated_at]) VALUES (64, 4, N'Satkhira', N'?????????', CAST(0.000000000 AS Decimal(18, 9)), CAST(0.000000000 AS Decimal(18, 9)), N'www.satkhira.gov.bd', N'2015-09-13 04:33:27', N'2015-09-13 04:36:20')
SET IDENTITY_INSERT [dbo].[EventInfo] ON 

INSERT [dbo].[EventInfo] ([EventId], [EventName], [EventAddress], [EventLocation], [StartTime], [EndTime], [EventDate], [SeatType], [SeatCapacity], [Fare], [Picture], [CompanyId], [Status], [InTime], [Type]) VALUES (4, N'Master', N'2no gate,Bayezid', 43, N'14:00', N'17:30', N'2021-01-27', N'A Class', 80, CAST(650.00 AS Decimal(18, 2)), N'/Files/Master.jpg', 1002, N'A', N'15/01/2021_11:58:19', N'Movie')
INSERT [dbo].[EventInfo] ([EventId], [EventName], [EventAddress], [EventLocation], [StartTime], [EndTime], [EventDate], [SeatType], [SeatCapacity], [Fare], [Picture], [CompanyId], [Status], [InTime], [Type]) VALUES (5, N'Artcell Concert', N'Pologround field, CRB', 43, N'17:00', N'22:00', N'2021-01-31', N'N/A', 1200, CAST(350.00 AS Decimal(18, 2)), N'/Files/artcell.jpg', 1002, N'A', N'15/01/2021_03:09:51', N'Event')
SET IDENTITY_INSERT [dbo].[EventInfo] OFF
INSERT [dbo].[Registration] ([RegId], [Name], [CompanyName], [Email], [ContactNo], [Gender], [DateofBirth], [Address], [Password], [Picture], [Status], [Type], [InTime]) VALUES (N'1001', N'Niloy Hasan', N'', N'nil@gmail.com', N'01954236520', N'Male', N'2020-12-02', N'ctg', N'1', N'/Files/1001.png', N'A', N'P', N'27/12/2020_11:58:01')
INSERT [dbo].[Registration] ([RegId], [Name], [CompanyName], [Email], [ContactNo], [Gender], [DateofBirth], [Address], [Password], [Picture], [Status], [Type], [InTime]) VALUES (N'1002', N'Niloy Hasan', N'Soudia', N'moderatetech17@gmail.com', N'01954236520', N'Male', N'', N'ctg', N'1', N'/Files/1002.png', N'A', N'A', N'28/12/2020_12:05:56')
INSERT [dbo].[Registration] ([RegId], [Name], [CompanyName], [Email], [ContactNo], [Gender], [DateofBirth], [Address], [Password], [Picture], [Status], [Type], [InTime]) VALUES (N'1003', N'Niloy Uddin', N'', N'niloycse05995@gmail.com', N'01685400001', N'Male', N'2020-12-01', N'ctg', N'1', N'/Files/1003.png', N'A', N'P', N'31/12/2020_03:52:48')
INSERT [dbo].[Registration] ([RegId], [Name], [CompanyName], [Email], [ContactNo], [Gender], [DateofBirth], [Address], [Password], [Picture], [Status], [Type], [InTime]) VALUES (N'1004', N'Admin', N' ', N'admin@gmail.com', N'01500112233', N'Male', N'1996-08-02', N'ctg', N'1', N'/Files/1001.png', N'A', N'Ad', N'22/01/2021_05:30:00')
INSERT [dbo].[Registration] ([RegId], [Name], [CompanyName], [Email], [ContactNo], [Gender], [DateofBirth], [Address], [Password], [Picture], [Status], [Type], [InTime]) VALUES (N'1005', N'Minhaz', NULL, N'minhaz@gmail.com', N'01622115277', N'Male', N'2021-01-14', N'Ctg', N'1234', N'/Files/1005.png', N'A', N'P', N'22/01/2021_05:23:47')
USE [master]
GO
ALTER DATABASE [TicketBookingDb] SET  READ_WRITE 
GO
