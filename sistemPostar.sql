USE [master]
GO
/****** Object:  Database [sistempostar]    Script Date: 10/1/2024 7:32:46 PM ******/
CREATE DATABASE [sistempostar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sistempostar_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\sistempostar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sistempostar_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\sistempostar.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [sistempostar] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sistempostar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sistempostar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sistempostar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sistempostar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sistempostar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sistempostar] SET ARITHABORT OFF 
GO
ALTER DATABASE [sistempostar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sistempostar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sistempostar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sistempostar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sistempostar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sistempostar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sistempostar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sistempostar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sistempostar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sistempostar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sistempostar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sistempostar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sistempostar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sistempostar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sistempostar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sistempostar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sistempostar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sistempostar] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sistempostar] SET  MULTI_USER 
GO
ALTER DATABASE [sistempostar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sistempostar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sistempostar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sistempostar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sistempostar] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sistempostar] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'sistempostar', N'ON'
GO
ALTER DATABASE [sistempostar] SET QUERY_STORE = ON
GO
ALTER DATABASE [sistempostar] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [sistempostar]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[message] [varchar](255) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[veprimi] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_qytetar] [int] NOT NULL,
	[sportelist_id] [int] NOT NULL,
	[order_status] [int] NOT NULL,
	[pike_postare_id] [int] NOT NULL,
	[zone_mbulimi_id] [int] NOT NULL,
	[barcode] [varchar](50) NULL,
	[pako_id] [int] NULL,
	[order_number] [int] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[is_priority] [int] NULL,
	[cmimi] [int] NULL,
	[pesha] [int] NULL,
	[pike_postare_nisje] [int] NULL,
	[pike_postare_to_drop] [int] NULL,
	[qyteti_aktual] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatuses]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatuses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatuses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PakoStatuses]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PakoStatuses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PakoStatuses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pakot]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pakot](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[barcode] [varchar](50) NOT NULL,
	[pike_postare_id] [int] NOT NULL,
	[created_by] [int] NOT NULL,
	[status_dergesa] [int] NOT NULL,
	[pika_postare_nisje] [int] NOT NULL,
	[pako_number] [varchar](50) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[kohezgjatja] [varchar](50) NULL,
	[is_priority] [int] NULL,
 CONSTRAINT [PK_Pakot] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PikatPostare]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PikatPostare](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[address] [varchar](255) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[numer_postar] [varchar](50) NOT NULL,
	[status] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[cmimPesha] [int] NULL,
	[tarifePrioritet] [int] NULL,
 CONSTRAINT [PK_PikatPostare] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rruget]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rruget](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pike_postare_nisje] [int] NOT NULL,
	[pike_postare_destinacion] [int] NOT NULL,
	[kohezgjatje] [int] NOT NULL,
	[rruga] [varchar](255) NOT NULL,
	[is_priority] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Rruget] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transportet]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[message] [varchar](50) NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_Transportet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[status] [int] NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[phone] [varchar](25) NOT NULL,
	[pike_postare_id] [int] NULL,
	[zone_mbulimi_id] [int] NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZonaMbulimi]    Script Date: 10/1/2024 7:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZonaMbulimi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[pike_postare_id] [int] NOT NULL,
	[status] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
 CONSTRAINT [PK_ZonaMbulimi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_updated_at]  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Pakot] ADD  CONSTRAINT [DF_Pakot_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Pakot] ADD  CONSTRAINT [DF_Pakot_updated_at]  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[PikatPostare] ADD  CONSTRAINT [DF_PikatPostare_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[PikatPostare] ADD  CONSTRAINT [DF_PikatPostare_updated_at]  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Rruget] ADD  CONSTRAINT [DF_Rruget_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Transportet] ADD  CONSTRAINT [DF_Transportet_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_updated_at]  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[ZonaMbulimi] ADD  CONSTRAINT [DF_ZonaMbulimi_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ZonaMbulimi] ADD  CONSTRAINT [DF_ZonaMbulimi_updated_at]  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderStatuses] FOREIGN KEY([order_status])
REFERENCES [dbo].[OrderStatuses] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderStatuses]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Pakot] FOREIGN KEY([pako_id])
REFERENCES [dbo].[Pakot] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Pakot]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PikatPostare] FOREIGN KEY([pike_postare_id])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PikatPostare]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PikatPostare1] FOREIGN KEY([pike_postare_nisje])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PikatPostare1]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PikatPostare2] FOREIGN KEY([pike_postare_to_drop])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PikatPostare2]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PikatPostare3] FOREIGN KEY([qyteti_aktual])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PikatPostare3]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Sportelist] FOREIGN KEY([sportelist_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Sportelist]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([id_qytetar])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_ZonaMbulimi] FOREIGN KEY([zone_mbulimi_id])
REFERENCES [dbo].[ZonaMbulimi] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_ZonaMbulimi]
GO
ALTER TABLE [dbo].[Pakot]  WITH CHECK ADD  CONSTRAINT [FK_Pakot_PakoStatuses] FOREIGN KEY([status_dergesa])
REFERENCES [dbo].[PakoStatuses] ([id])
GO
ALTER TABLE [dbo].[Pakot] CHECK CONSTRAINT [FK_Pakot_PakoStatuses]
GO
ALTER TABLE [dbo].[Pakot]  WITH CHECK ADD  CONSTRAINT [FK_Pakot_PikatPostare] FOREIGN KEY([pike_postare_id])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Pakot] CHECK CONSTRAINT [FK_Pakot_PikatPostare]
GO
ALTER TABLE [dbo].[Pakot]  WITH CHECK ADD  CONSTRAINT [FK_Pakot_PikatPostare1] FOREIGN KEY([pika_postare_nisje])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Pakot] CHECK CONSTRAINT [FK_Pakot_PikatPostare1]
GO
ALTER TABLE [dbo].[Pakot]  WITH CHECK ADD  CONSTRAINT [FK_Pakot_Users] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Pakot] CHECK CONSTRAINT [FK_Pakot_Users]
GO
ALTER TABLE [dbo].[Rruget]  WITH CHECK ADD  CONSTRAINT [FK_Rruget_PikatPostare] FOREIGN KEY([pike_postare_nisje])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Rruget] CHECK CONSTRAINT [FK_Rruget_PikatPostare]
GO
ALTER TABLE [dbo].[Rruget]  WITH CHECK ADD  CONSTRAINT [FK_Rruget_PikatPostare1] FOREIGN KEY([pike_postare_destinacion])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Rruget] CHECK CONSTRAINT [FK_Rruget_PikatPostare1]
GO
ALTER TABLE [dbo].[Transportet]  WITH CHECK ADD  CONSTRAINT [FK_Transportet_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[Transportet] CHECK CONSTRAINT [FK_Transportet_Orders]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PikatPostare] FOREIGN KEY([pike_postare_id])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PikatPostare]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_ZonaMbulimi] FOREIGN KEY([zone_mbulimi_id])
REFERENCES [dbo].[ZonaMbulimi] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_ZonaMbulimi]
GO
ALTER TABLE [dbo].[ZonaMbulimi]  WITH CHECK ADD  CONSTRAINT [FK_ZonaMbulimi_PikatPostare] FOREIGN KEY([pike_postare_id])
REFERENCES [dbo].[PikatPostare] ([id])
GO
ALTER TABLE [dbo].[ZonaMbulimi] CHECK CONSTRAINT [FK_ZonaMbulimi_PikatPostare]
GO
USE [master]
GO
ALTER DATABASE [sistempostar] SET  READ_WRITE 
GO
