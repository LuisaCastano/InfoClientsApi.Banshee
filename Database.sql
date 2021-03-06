USE [master]
GO
/****** Object:  Database [InfoClients]    Script Date: 10/22/2019 9:16:53 AM ******/
CREATE DATABASE [InfoClients]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InfoClients', FILENAME = N'C:\Users\Luisa.castano\InfoClients.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InfoClients_log', FILENAME = N'C:\Users\Luisa.castano\InfoClients_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [InfoClients] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InfoClients].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InfoClients] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InfoClients] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InfoClients] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InfoClients] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InfoClients] SET ARITHABORT OFF 
GO
ALTER DATABASE [InfoClients] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [InfoClients] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InfoClients] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InfoClients] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InfoClients] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InfoClients] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InfoClients] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InfoClients] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InfoClients] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InfoClients] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InfoClients] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InfoClients] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InfoClients] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InfoClients] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InfoClients] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InfoClients] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [InfoClients] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InfoClients] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InfoClients] SET  MULTI_USER 
GO
ALTER DATABASE [InfoClients] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InfoClients] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InfoClients] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InfoClients] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InfoClients] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InfoClients] SET QUERY_STORE = OFF
GO
USE [InfoClients]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [InfoClients]
GO
/****** Object:  Schema [infoclients]    Script Date: 10/22/2019 9:16:53 AM ******/
CREATE SCHEMA [infoclients]
GO
/****** Object:  Table [infoclients].[__MicroMigrationHistory]    Script Date: 10/22/2019 9:16:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infoclients].[__MicroMigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___MicroMigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [infoclients].[City]    Script Date: 10/22/2019 9:16:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infoclients].[City](
	[Id] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[StateId] [uniqueidentifier] NOT NULL,
	[NameCity] [nvarchar](max) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [infoclients].[Client]    Script Date: 10/22/2019 9:16:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infoclients].[Client](
	[Id] [uniqueidentifier] NOT NULL,
	[Nit] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[CityId] [uniqueidentifier] NOT NULL,
	[StateId] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[CreditLimit] [int] NOT NULL,
	[VisitsPercentage] [float] NOT NULL,
	[AvailableCredit] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [infoclients].[ClientVisit]    Script Date: 10/22/2019 9:16:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infoclients].[ClientVisit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[VisitDate] [datetime2](7) NOT NULL,
	[SaleRepresentativeId] [int] NOT NULL,
	[Net] [int] NOT NULL,
	[VisitTotal] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClientVisit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [infoclients].[Country]    Script Date: 10/22/2019 9:16:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infoclients].[Country](
	[Id] [uniqueidentifier] NOT NULL,
	[NameCountry] [nvarchar](max) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [infoclients].[SalesRepresentative]    Script Date: 10/22/2019 9:16:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infoclients].[SalesRepresentative](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_SalesRepresentative] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [infoclients].[State]    Script Date: 10/22/2019 9:16:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infoclients].[State](
	[Id] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[NameState] [nvarchar](max) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_CityId]    Script Date: 10/22/2019 9:16:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_Client_CityId] ON [infoclients].[Client]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_CountryId]    Script Date: 10/22/2019 9:16:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_Client_CountryId] ON [infoclients].[Client]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_StateId]    Script Date: 10/22/2019 9:16:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_Client_StateId] ON [infoclients].[Client]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientVisit_ClientId]    Script Date: 10/22/2019 9:16:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClientVisit_ClientId] ON [infoclients].[ClientVisit]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientVisit_SaleRepresentativeId]    Script Date: 10/22/2019 9:16:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClientVisit_SaleRepresentativeId] ON [infoclients].[ClientVisit]
(
	[SaleRepresentativeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [infoclients].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_City_CityId] FOREIGN KEY([CityId])
REFERENCES [infoclients].[City] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [infoclients].[Client] CHECK CONSTRAINT [FK_Client_City_CityId]
GO
ALTER TABLE [infoclients].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [infoclients].[Country] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [infoclients].[Client] CHECK CONSTRAINT [FK_Client_Country_CountryId]
GO
ALTER TABLE [infoclients].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_State_StateId] FOREIGN KEY([StateId])
REFERENCES [infoclients].[State] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [infoclients].[Client] CHECK CONSTRAINT [FK_Client_State_StateId]
GO
ALTER TABLE [infoclients].[ClientVisit]  WITH CHECK ADD  CONSTRAINT [FK_ClientVisit_Client_ClientId] FOREIGN KEY([ClientId])
REFERENCES [infoclients].[Client] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [infoclients].[ClientVisit] CHECK CONSTRAINT [FK_ClientVisit_Client_ClientId]
GO
ALTER TABLE [infoclients].[ClientVisit]  WITH CHECK ADD  CONSTRAINT [FK_ClientVisit_SalesRepresentative_SaleRepresentativeId] FOREIGN KEY([SaleRepresentativeId])
REFERENCES [infoclients].[SalesRepresentative] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [infoclients].[ClientVisit] CHECK CONSTRAINT [FK_ClientVisit_SalesRepresentative_SaleRepresentativeId]
GO
USE [master]
GO
ALTER DATABASE [InfoClients] SET  READ_WRITE 
GO
