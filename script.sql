USE [master]
GO
/****** Object:  Database [BCdatabase]    Script Date: 2022/11/14 19:52:44 ******/
CREATE DATABASE [BCdatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BCdatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BCdatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BCdatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BCdatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BCdatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BCdatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BCdatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BCdatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BCdatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BCdatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BCdatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [BCdatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BCdatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BCdatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BCdatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BCdatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BCdatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BCdatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BCdatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BCdatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BCdatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BCdatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BCdatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BCdatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BCdatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BCdatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BCdatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BCdatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BCdatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BCdatabase] SET  MULTI_USER 
GO
ALTER DATABASE [BCdatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BCdatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BCdatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BCdatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BCdatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BCdatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BCdatabase] SET QUERY_STORE = OFF
GO
USE [BCdatabase]
GO
/****** Object:  Table [dbo].[tblAddress]    Script Date: 2022/11/14 19:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAddress](
	[AddressID] [int] NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[Suburb] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblAddress] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblModule]    Script Date: 2022/11/14 19:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblModule](
	[ModuleCode] [varchar](50) NOT NULL,
	[ModuleName] [varchar](50) NOT NULL,
	[ModuleDescription] [varchar](50) NOT NULL,
	[Resources] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblModule] PRIMARY KEY CLUSTERED 
(
	[ModuleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudent_Module]    Script Date: 2022/11/14 19:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudent_Module](
	[StudentNumber] [varchar](50) NOT NULL,
	[ModuleCode] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudents]    Script Date: 2022/11/14 19:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudents](
	[StudentNumber] [varchar](50) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[StudentSurname] [varchar](50) NOT NULL,
	[StudentImage] [varbinary](max) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[AddressID] [int] NOT NULL,
 CONSTRAINT [PK_tblStudents] PRIMARY KEY CLUSTERED 
(
	[StudentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblStudent_Module]  WITH CHECK ADD  CONSTRAINT [FK_Module Relationship_Module_tblStudent_Module] FOREIGN KEY([ModuleCode])
REFERENCES [dbo].[tblModule] ([ModuleCode])
GO
ALTER TABLE [dbo].[tblStudent_Module] CHECK CONSTRAINT [FK_Module Relationship_Module_tblStudent_Module]
GO
ALTER TABLE [dbo].[tblStudent_Module]  WITH CHECK ADD  CONSTRAINT [FK_Student Relationship_Module_tblStudents] FOREIGN KEY([StudentNumber])
REFERENCES [dbo].[tblStudents] ([StudentNumber])
GO
ALTER TABLE [dbo].[tblStudent_Module] CHECK CONSTRAINT [FK_Student Relationship_Module_tblStudents]
GO
ALTER TABLE [dbo].[tblStudents]  WITH CHECK ADD  CONSTRAINT [FK_tblStudents_tblAddress] FOREIGN KEY([AddressID])
REFERENCES [dbo].[tblAddress] ([AddressID])
GO
ALTER TABLE [dbo].[tblStudents] CHECK CONSTRAINT [FK_tblStudents_tblAddress]
GO
USE [master]
GO
ALTER DATABASE [BCdatabase] SET  READ_WRITE 
GO
