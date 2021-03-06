USE [master]
GO
/****** Object:  Database [17022_DB]    Script Date: 26/05/2017 19:30:35 ******/
CREATE DATABASE [17022_DB] ON  PRIMARY 
( NAME = N'17022_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\17022_DB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'17022_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\17022_DB_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [17022_DB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [17022_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [17022_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [17022_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [17022_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [17022_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [17022_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [17022_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [17022_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [17022_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [17022_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [17022_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [17022_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [17022_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [17022_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [17022_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [17022_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [17022_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [17022_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [17022_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [17022_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [17022_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [17022_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [17022_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [17022_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [17022_DB] SET  MULTI_USER 
GO
ALTER DATABASE [17022_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [17022_DB] SET DB_CHAINING OFF 
GO
USE [17022_DB]
GO
/****** Object:  User [17022_User]    Script Date: 26/05/2017 19:30:35 ******/
CREATE USER [17022_User] FOR LOGIN [17022_User] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [17022_User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [17022_User]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [17022_User]
GO
/****** Object:  Table [dbo].[AzuriranjeSirovina]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AzuriranjeSirovina](
	[idZapisa] [int] IDENTITY(1,1) NOT NULL,
	[sirovinaId] [int] NOT NULL,
	[korisnikId] [int] NOT NULL,
	[datum] [date] NOT NULL,
	[kolicina] [int] NOT NULL,
 CONSTRAINT [PK_AzuriranjeSirovina] PRIMARY KEY CLUSTERED 
(
	[idZapisa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaterijeKaveza]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaterijeKaveza](
	[idBaterije] [int] IDENTITY(1,1) NOT NULL,
	[brojKokosi] [int] NOT NULL,
	[brojKavezaBaterije] [int] NOT NULL,
 CONSTRAINT [PK_BaterijeKaveza] PRIMARY KEY CLUSTERED 
(
	[idBaterije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaterijeTurnusa]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaterijeTurnusa](
	[idTurnusa] [int] NOT NULL,
	[idBaterije] [int] NOT NULL,
 CONSTRAINT [PK_BaterijeTurnusa] PRIMARY KEY CLUSTERED 
(
	[idTurnusa] ASC,
	[idBaterije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cijepljenje]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cijepljenje](
	[turnusId] [int] NOT NULL,
	[cijepivoId] [int] NOT NULL,
	[datumCijepljenja] [date] NOT NULL,
 CONSTRAINT [PK_Cijepljenje] PRIMARY KEY CLUSTERED 
(
	[turnusId] ASC,
	[cijepivoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cjepivo]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cjepivo](
	[idCjepiva] [int] IDENTITY(1,1) NOT NULL,
	[nazivCjepiva] [nvarchar](50) NOT NULL,
	[vrstaCjepiva] [nvarchar](50) NOT NULL,
	[opis] [nchar](10) NULL,
	[zapisNeaktivan] [bit] NOT NULL,
 CONSTRAINT [PK_Cjepivo] PRIMARY KEY CLUSTERED 
(
	[idCjepiva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funkcionalnost]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funkcionalnost](
	[idFunkcionalnosti] [int] IDENTITY(1,1) NOT NULL,
	[nazivFunkcionalnosti] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Funkcionalnost] PRIMARY KEY CLUSTERED 
(
	[idFunkcionalnosti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jaja]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jaja](
	[idDnevneSerije] [int] IDENTITY(1,1) NOT NULL,
	[klasa] [nvarchar](2) NOT NULL,
	[brojPrikupljenih] [int] NOT NULL,
	[turnusId] [int] NOT NULL,
	[datumPrikupljanja] [date] NOT NULL,
	[zapisNekativan] [bit] NOT NULL,
 CONSTRAINT [PK_Jaja] PRIMARY KEY CLUSTERED 
(
	[idDnevneSerije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KokosiTurnus]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KokosiTurnus](
	[idTurnusa] [int] IDENTITY(1,1) NOT NULL,
	[datumNabavkeTurnusa] [nvarchar](50) NOT NULL,
	[zapisNeaktivan] [bit] NOT NULL,
 CONSTRAINT [PK_KokosiTurnus] PRIMARY KEY CLUSTERED 
(
	[idTurnusa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[ime] [nvarchar](50) NOT NULL,
	[prezime] [nvarchar](50) NOT NULL,
	[idKorisnika] [int] IDENTITY(1,1) NOT NULL,
	[korisnickoIme] [nvarchar](50) NOT NULL,
	[lozinka] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NULL,
	[telefon] [nvarchar](50) NULL,
	[zapisNeaktivan] [bit] NOT NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[idKorisnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Korisnik] UNIQUE NONCLUSTERED 
(
	[korisnickoIme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kupac]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kupac](
	[idKupca] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [nvarchar](50) NOT NULL,
	[opis] [nvarchar](250) NULL,
	[kontakt] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Kupac] PRIMARY KEY CLUSTERED 
(
	[idKupca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogAkcija]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogAkcija](
	[idZapisa] [int] IDENTITY(1,1) NOT NULL,
	[korisnikId] [int] NOT NULL,
	[opisAkcije] [nvarchar](255) NOT NULL,
	[datumVrijeme] [datetime] NOT NULL,
 CONSTRAINT [PK_LogAkcija] PRIMARY KEY CLUSTERED 
(
	[idZapisa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Narudzba]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Narudzba](
	[idNarudzbe] [int] IDENTITY(1,1) NOT NULL,
	[datumNarudzbe] [date] NOT NULL,
	[datumIsporuke] [date] NULL,
	[kupacId] [int] NOT NULL,
	[stanjeNarudzbeId] [int] NOT NULL,
 CONSTRAINT [PK_Narudzba] PRIMARY KEY CLUSTERED 
(
	[idNarudzbe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OvlastiKorisnika]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OvlastiKorisnika](
	[idKorisnika] [int] NOT NULL,
	[idFunkcionalnosti] [int] NOT NULL,
 CONSTRAINT [PK_OvlastiKorisnika] PRIMARY KEY CLUSTERED 
(
	[idKorisnika] ASC,
	[idFunkcionalnosti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recept]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recept](
	[receptGlavniSastojakId] [int] NOT NULL,
	[receptSastojak] [int] NOT NULL,
	[postotak] [int] NOT NULL,
 CONSTRAINT [PK_Recept] PRIMARY KEY CLUSTERED 
(
	[receptGlavniSastojakId] ASC,
	[receptSastojak] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sirovina]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sirovina](
	[idSirovine] [int] IDENTITY(1,1) NOT NULL,
	[nazivSirovine] [nvarchar](255) NOT NULL,
	[kolicina] [int] NOT NULL,
	[opis] [nvarchar](255) NULL,
	[zapisNeaktivan] [bit] NOT NULL,
 CONSTRAINT [PK_sirovina] PRIMARY KEY CLUSTERED 
(
	[idSirovine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StanjeNarudzbe]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StanjeNarudzbe](
	[idStanja] [int] IDENTITY(1,1) NOT NULL,
	[nazivStanja] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_StanjeNarudzbe] PRIMARY KEY CLUSTERED 
(
	[idStanja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkeNarudzbe]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkeNarudzbe](
	[idStavke] [int] IDENTITY(1,1) NOT NULL,
	[narudzbaId] [int] NOT NULL,
	[kolicina] [int] NOT NULL,
	[klasa] [nvarchar](2) NOT NULL,
	[cijena] [float] NOT NULL,
 CONSTRAINT [PK_StavkeNarudzbe] PRIMARY KEY CLUSTERED 
(
	[idStavke] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnositeljJaja]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnositeljJaja](
	[idZapisa] [int] IDENTITY(1,1) NOT NULL,
	[dnevnaSerijaId] [int] NOT NULL,
	[korisnikId] [int] NOT NULL,
	[datum] [date] NOT NULL,
 CONSTRAINT [PK_UnositeljJaja] PRIMARY KEY CLUSTERED 
(
	[idZapisa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnosUginulih]    Script Date: 26/05/2017 19:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnosUginulih](
	[idZapisa] [int] IDENTITY(1,1) NOT NULL,
	[datumUnosa] [date] NOT NULL,
	[baterijaKavezaId] [int] NOT NULL,
	[brojUginulihKokosi] [int] NOT NULL,
	[korisnikId] [int] NOT NULL,
	[uzrok] [nvarchar](250) NULL,
 CONSTRAINT [PK_UnosUginulih] PRIMARY KEY CLUSTERED 
(
	[idZapisa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Korisnik] ADD  CONSTRAINT [DF_Korisnik_zapisNeaktivan]  DEFAULT ((0)) FOR [zapisNeaktivan]
GO
ALTER TABLE [dbo].[Sirovina] ADD  CONSTRAINT [DF_sirovina_zapisNeaktivan]  DEFAULT ((0)) FOR [zapisNeaktivan]
GO
ALTER TABLE [dbo].[AzuriranjeSirovina]  WITH CHECK ADD  CONSTRAINT [FK_AzuriranjeSirovina_Korisnik] FOREIGN KEY([korisnikId])
REFERENCES [dbo].[Korisnik] ([idKorisnika])
GO
ALTER TABLE [dbo].[AzuriranjeSirovina] CHECK CONSTRAINT [FK_AzuriranjeSirovina_Korisnik]
GO
ALTER TABLE [dbo].[AzuriranjeSirovina]  WITH CHECK ADD  CONSTRAINT [FK_AzuriranjeSirovina_Sirovina] FOREIGN KEY([sirovinaId])
REFERENCES [dbo].[Sirovina] ([idSirovine])
GO
ALTER TABLE [dbo].[AzuriranjeSirovina] CHECK CONSTRAINT [FK_AzuriranjeSirovina_Sirovina]
GO
ALTER TABLE [dbo].[BaterijeTurnusa]  WITH CHECK ADD  CONSTRAINT [FK_BaterijeTurnusa_BaterijeKaveza] FOREIGN KEY([idBaterije])
REFERENCES [dbo].[BaterijeKaveza] ([idBaterije])
GO
ALTER TABLE [dbo].[BaterijeTurnusa] CHECK CONSTRAINT [FK_BaterijeTurnusa_BaterijeKaveza]
GO
ALTER TABLE [dbo].[BaterijeTurnusa]  WITH CHECK ADD  CONSTRAINT [FK_BaterijeTurnusa_KokosiTurnus] FOREIGN KEY([idTurnusa])
REFERENCES [dbo].[KokosiTurnus] ([idTurnusa])
GO
ALTER TABLE [dbo].[BaterijeTurnusa] CHECK CONSTRAINT [FK_BaterijeTurnusa_KokosiTurnus]
GO
ALTER TABLE [dbo].[Cijepljenje]  WITH CHECK ADD  CONSTRAINT [FK_Cijepljenje_Cjepivo] FOREIGN KEY([cijepivoId])
REFERENCES [dbo].[Cjepivo] ([idCjepiva])
GO
ALTER TABLE [dbo].[Cijepljenje] CHECK CONSTRAINT [FK_Cijepljenje_Cjepivo]
GO
ALTER TABLE [dbo].[Cijepljenje]  WITH CHECK ADD  CONSTRAINT [FK_Cijepljenje_KokosiTurnus] FOREIGN KEY([turnusId])
REFERENCES [dbo].[KokosiTurnus] ([idTurnusa])
GO
ALTER TABLE [dbo].[Cijepljenje] CHECK CONSTRAINT [FK_Cijepljenje_KokosiTurnus]
GO
ALTER TABLE [dbo].[Jaja]  WITH CHECK ADD  CONSTRAINT [FK_Jaja_KokosiTurnus] FOREIGN KEY([turnusId])
REFERENCES [dbo].[KokosiTurnus] ([idTurnusa])
GO
ALTER TABLE [dbo].[Jaja] CHECK CONSTRAINT [FK_Jaja_KokosiTurnus]
GO
ALTER TABLE [dbo].[LogAkcija]  WITH CHECK ADD  CONSTRAINT [FK_LogAkcija_Korisnik] FOREIGN KEY([korisnikId])
REFERENCES [dbo].[Korisnik] ([idKorisnika])
GO
ALTER TABLE [dbo].[LogAkcija] CHECK CONSTRAINT [FK_LogAkcija_Korisnik]
GO
ALTER TABLE [dbo].[Narudzba]  WITH CHECK ADD  CONSTRAINT [FK_Narudzba_Kupac] FOREIGN KEY([kupacId])
REFERENCES [dbo].[Kupac] ([idKupca])
GO
ALTER TABLE [dbo].[Narudzba] CHECK CONSTRAINT [FK_Narudzba_Kupac]
GO
ALTER TABLE [dbo].[Narudzba]  WITH CHECK ADD  CONSTRAINT [FK_Narudzba_StanjeNarudzbe] FOREIGN KEY([stanjeNarudzbeId])
REFERENCES [dbo].[StanjeNarudzbe] ([idStanja])
GO
ALTER TABLE [dbo].[Narudzba] CHECK CONSTRAINT [FK_Narudzba_StanjeNarudzbe]
GO
ALTER TABLE [dbo].[OvlastiKorisnika]  WITH CHECK ADD  CONSTRAINT [FK_OvlastiKorisnika_Funkcionalnost] FOREIGN KEY([idFunkcionalnosti])
REFERENCES [dbo].[Funkcionalnost] ([idFunkcionalnosti])
GO
ALTER TABLE [dbo].[OvlastiKorisnika] CHECK CONSTRAINT [FK_OvlastiKorisnika_Funkcionalnost]
GO
ALTER TABLE [dbo].[OvlastiKorisnika]  WITH CHECK ADD  CONSTRAINT [FK_OvlastiKorisnika_Korisnik] FOREIGN KEY([idKorisnika])
REFERENCES [dbo].[Korisnik] ([idKorisnika])
GO
ALTER TABLE [dbo].[OvlastiKorisnika] CHECK CONSTRAINT [FK_OvlastiKorisnika_Korisnik]
GO
ALTER TABLE [dbo].[Recept]  WITH CHECK ADD  CONSTRAINT [FK_Sastojak_Smjese] FOREIGN KEY([receptSastojak])
REFERENCES [dbo].[Sirovina] ([idSirovine])
GO
ALTER TABLE [dbo].[Recept] CHECK CONSTRAINT [FK_Sastojak_Smjese]
GO
ALTER TABLE [dbo].[Recept]  WITH CHECK ADD  CONSTRAINT [FK_Sirovina_Smjesa] FOREIGN KEY([receptGlavniSastojakId])
REFERENCES [dbo].[Sirovina] ([idSirovine])
GO
ALTER TABLE [dbo].[Recept] CHECK CONSTRAINT [FK_Sirovina_Smjesa]
GO
ALTER TABLE [dbo].[StavkeNarudzbe]  WITH CHECK ADD  CONSTRAINT [FK_StavkeNarudzbe_Narudzba] FOREIGN KEY([narudzbaId])
REFERENCES [dbo].[Narudzba] ([idNarudzbe])
GO
ALTER TABLE [dbo].[StavkeNarudzbe] CHECK CONSTRAINT [FK_StavkeNarudzbe_Narudzba]
GO
ALTER TABLE [dbo].[UnositeljJaja]  WITH CHECK ADD  CONSTRAINT [FK_UnositeljJaja_Jaja] FOREIGN KEY([dnevnaSerijaId])
REFERENCES [dbo].[Jaja] ([idDnevneSerije])
GO
ALTER TABLE [dbo].[UnositeljJaja] CHECK CONSTRAINT [FK_UnositeljJaja_Jaja]
GO
ALTER TABLE [dbo].[UnositeljJaja]  WITH CHECK ADD  CONSTRAINT [FK_UnositeljJaja_Korisnik] FOREIGN KEY([korisnikId])
REFERENCES [dbo].[Korisnik] ([idKorisnika])
GO
ALTER TABLE [dbo].[UnositeljJaja] CHECK CONSTRAINT [FK_UnositeljJaja_Korisnik]
GO
ALTER TABLE [dbo].[UnosUginulih]  WITH CHECK ADD  CONSTRAINT [FK_UnosUginulih_BaterijeKaveza] FOREIGN KEY([baterijaKavezaId])
REFERENCES [dbo].[BaterijeKaveza] ([idBaterije])
GO
ALTER TABLE [dbo].[UnosUginulih] CHECK CONSTRAINT [FK_UnosUginulih_BaterijeKaveza]
GO
ALTER TABLE [dbo].[UnosUginulih]  WITH CHECK ADD  CONSTRAINT [FK_UnosUginulih_Korisnik] FOREIGN KEY([korisnikId])
REFERENCES [dbo].[Korisnik] ([idKorisnika])
GO
ALTER TABLE [dbo].[UnosUginulih] CHECK CONSTRAINT [FK_UnosUginulih_Korisnik]
GO
USE [master]
GO
ALTER DATABASE [17022_DB] SET  READ_WRITE 
GO
