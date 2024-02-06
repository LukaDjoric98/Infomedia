USE [master]
GO
/****** Object:  Database [Infomedia]    Script Date: 2/6/2024 2:15:00 AM ******/
CREATE DATABASE [Infomedia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Infomedia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Infomedia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Infomedia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Infomedia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Infomedia] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Infomedia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Infomedia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Infomedia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Infomedia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Infomedia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Infomedia] SET ARITHABORT OFF 
GO
ALTER DATABASE [Infomedia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Infomedia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Infomedia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Infomedia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Infomedia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Infomedia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Infomedia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Infomedia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Infomedia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Infomedia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Infomedia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Infomedia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Infomedia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Infomedia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Infomedia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Infomedia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Infomedia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Infomedia] SET RECOVERY FULL 
GO
ALTER DATABASE [Infomedia] SET  MULTI_USER 
GO
ALTER DATABASE [Infomedia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Infomedia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Infomedia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Infomedia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Infomedia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Infomedia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Infomedia', N'ON'
GO
ALTER DATABASE [Infomedia] SET QUERY_STORE = ON
GO
ALTER DATABASE [Infomedia] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Infomedia]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2/6/2024 2:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[ThirdPartyID] [nvarchar](256) NULL,
	[MSISDN] [nvarchar](20) NULL,
	[TransactionDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Infomedia] SET  READ_WRITE 
GO
