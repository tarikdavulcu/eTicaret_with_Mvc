USE [master]
GO
/****** Object:  Database [eTicaret]    Script Date: 03/10/2021 00:46:03 ******/
CREATE DATABASE [eTicaret] ON  PRIMARY 
( NAME = N'eTicaret', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\eTicaret.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'eTicaret_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\eTicaret_1.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [eTicaret] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eTicaret].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eTicaret] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [eTicaret] SET ANSI_NULLS OFF
GO
ALTER DATABASE [eTicaret] SET ANSI_PADDING OFF
GO
ALTER DATABASE [eTicaret] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [eTicaret] SET ARITHABORT OFF
GO
ALTER DATABASE [eTicaret] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [eTicaret] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [eTicaret] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [eTicaret] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [eTicaret] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [eTicaret] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [eTicaret] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [eTicaret] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [eTicaret] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [eTicaret] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [eTicaret] SET  DISABLE_BROKER
GO
ALTER DATABASE [eTicaret] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [eTicaret] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [eTicaret] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [eTicaret] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [eTicaret] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [eTicaret] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [eTicaret] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [eTicaret] SET  READ_WRITE
GO
ALTER DATABASE [eTicaret] SET RECOVERY SIMPLE
GO
ALTER DATABASE [eTicaret] SET  MULTI_USER
GO
ALTER DATABASE [eTicaret] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [eTicaret] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'eTicaret', N'ON'
GO
USE [eTicaret]
GO
/****** Object:  User [weblogin]    Script Date: 03/10/2021 00:46:03 ******/
CREATE USER [weblogin] FOR LOGIN [weblogin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[UrunFiyatlari]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunFiyatlari](
	[DilID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[KDV] [decimal](18, 0) NULL,
	[NakitIndirim] [decimal](18, 0) NULL,
	[KampanyaIndirim] [decimal](18, 0) NULL,
	[OzelIndirim] [decimal](18, 0) NULL,
	[KargoIndirimi] [decimal](18, 0) NULL,
	[Fiyat] [decimal](18, 0) NULL,
	[TaksitliFiyat] [decimal](18, 0) NULL,
	[ParaBirimi] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tedarikci_Firmalar]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tedarikci_Firmalar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirmaAdi] [nvarchar](150) NULL,
 CONSTRAINT [PK_Tedarikci_Firmalar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](150) NULL,
	[Resim] [nvarchar](150) NULL,
	[BaslikIcerik] [nvarchar](150) NULL,
	[BaslikEk] [nvarchar](150) NULL,
	[ButtonName] [nvarchar](150) NULL,
	[URL] [nvarchar](150) NULL,
	[Aktif] [bit] NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Slider] ON
INSERT [dbo].[Slider] ([ID], [Adi], [Resim], [BaslikIcerik], [BaslikEk], [ButtonName], [URL], [Aktif]) VALUES (5, N'Kravat', N'slide.png', N'', N'', N'', N'', 1)
SET IDENTITY_INSERT [dbo].[Slider] OFF
/****** Object:  Table [dbo].[Promosyon]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promosyon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Resim] [nvarchar](150) NULL,
	[URL] [nvarchar](150) NULL,
	[SiraNo] [int] NULL,
	[Adi] [nvarchar](150) NULL,
	[Aktif] [bit] NULL,
	[OlcuY] [int] NULL,
	[OlcuX] [int] NULL,
 CONSTRAINT [PK_Reklamlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Promosyon] ON
INSERT [dbo].[Promosyon] ([ID], [Resim], [URL], [SiraNo], [Adi], [Aktif], [OlcuY], [OlcuX]) VALUES (1, N'9C7AC23A-BE3D-4FDB-B441-DF912B60CFDA.png', N'asd', 1, N'Sol Üst', 1, 600, 257)
INSERT [dbo].[Promosyon] ([ID], [Resim], [URL], [SiraNo], [Adi], [Aktif], [OlcuY], [OlcuX]) VALUES (2, N'88891A66-71DF-4CA2-BCEF-2AC5DBBECFF0.png', N'#', 2, N'Sol Alt', 1, 600, 484)
INSERT [dbo].[Promosyon] ([ID], [Resim], [URL], [SiraNo], [Adi], [Aktif], [OlcuY], [OlcuX]) VALUES (3, N'CD1133E3-42B5-4EC6-82B4-8ACD71FDE4C6.png', N'#', 3, N'Sağ Alt', 1, 600, 257)
INSERT [dbo].[Promosyon] ([ID], [Resim], [URL], [SiraNo], [Adi], [Aktif], [OlcuY], [OlcuX]) VALUES (4, N'0CB68A1B-0F63-4647-94C6-C091A4B7B315.png', N'#', 4, N'Sağ Üst', 1, 600, 484)
SET IDENTITY_INSERT [dbo].[Promosyon] OFF
/****** Object:  Table [dbo].[Sepet]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sepet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tarih] [nvarchar](50) NULL,
	[Cookie] [nvarchar](150) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Sepet_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sepet] ON
INSERT [dbo].[Sepet] ([ID], [Tarih], [Cookie], [Aktif]) VALUES (7, N'28-07-2018', N'88.250.196.51', 1)
INSERT [dbo].[Sepet] ([ID], [Tarih], [Cookie], [Aktif]) VALUES (8, N'12-09-2018', N'176.33.226.227', 1)
INSERT [dbo].[Sepet] ([ID], [Tarih], [Cookie], [Aktif]) VALUES (9, N'12-02-2019', N'31.223.41.34', 1)
INSERT [dbo].[Sepet] ([ID], [Tarih], [Cookie], [Aktif]) VALUES (10, N'15-05-2019', N'176.88.43.232', 1)
INSERT [dbo].[Sepet] ([ID], [Tarih], [Cookie], [Aktif]) VALUES (11, N'12-09-2019', N'176.220.232.4', 1)
INSERT [dbo].[Sepet] ([ID], [Tarih], [Cookie], [Aktif]) VALUES (12, N'16-10-2019', N'176.88.68.4', 1)
INSERT [dbo].[Sepet] ([ID], [Tarih], [Cookie], [Aktif]) VALUES (13, N'24-02-2021', N'::1', 1)
SET IDENTITY_INSERT [dbo].[Sepet] OFF
/****** Object:  Table [dbo].[OdemeDetay]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeDetay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SepetID] [int] NOT NULL,
	[OdemeTuru] [nvarchar](50) NULL,
	[ToplamTurtar] [decimal](18, 0) NULL,
	[Aciklama] [nvarchar](250) NULL,
	[IpAdresi] [nvarchar](50) NULL,
 CONSTRAINT [PK_OdemeDetay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL,
	[KullaniciAdi] [nvarchar](150) NULL,
	[Sifre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Musteriler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MusteriAdresleri]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusteriAdresleri](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[Adres] [nvarchar](150) NULL,
	[Adres1] [nvarchar](150) NULL,
	[Sehir] [nvarchar](50) NULL,
	[Ulke] [nvarchar](50) NULL,
	[PostaKodu] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL,
	[Sirket] [nvarchar](150) NULL,
	[SirketUnvani] [nvarchar](150) NULL,
	[Adresİsmi] [nvarchar](50) NULL,
 CONSTRAINT [PK_MusteriAdresleri] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogKategori]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogKategori](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](150) NULL,
	[Aktif] [bit] NULL,
 CONSTRAINT [PK_BlogKategori] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BlogKategori] ON
INSERT [dbo].[BlogKategori] ([ID], [Adi], [Aktif]) VALUES (2, N'Deneme', 1)
SET IDENTITY_INSERT [dbo].[BlogKategori] OFF
/****** Object:  Table [dbo].[Mesajlar]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesajlar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Gonderen] [nvarchar](150) NULL,
	[Mail] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	[Mesaj] [nvarchar](350) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Mesajlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Resim] [nvarchar](150) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kategori] ON
INSERT [dbo].[Kategori] ([ID], [Adi], [Resim], [Aktif]) VALUES (53, N'Pantolon', N'pantolon.jpg', 0)
INSERT [dbo].[Kategori] ([ID], [Adi], [Resim], [Aktif]) VALUES (55, N'Gömlek', N'gomlek.jpg', 0)
INSERT [dbo].[Kategori] ([ID], [Adi], [Resim], [Aktif]) VALUES (56, N'Elbise', N'elbise.png', 1)
INSERT [dbo].[Kategori] ([ID], [Adi], [Resim], [Aktif]) VALUES (57, N'24 h Online Shoppen ab Sept. 2018', NULL, 1)
INSERT [dbo].[Kategori] ([ID], [Adi], [Resim], [Aktif]) VALUES (58, N'Zweiteiler', NULL, 1)
SET IDENTITY_INSERT [dbo].[Kategori] OFF
/****** Object:  Table [dbo].[Etiket]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](150) NULL,
 CONSTRAINT [PK_Etiket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Etiket] ON
INSERT [dbo].[Etiket] ([ID], [Adi]) VALUES (9, N'kisakot')
SET IDENTITY_INSERT [dbo].[Etiket] OFF
/****** Object:  Table [dbo].[Dil]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dil](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[KisaAdi] [nvarchar](50) NOT NULL,
	[Resim] [nvarchar](150) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Dil] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dil] ON
INSERT [dbo].[Dil] ([ID], [Adi], [KisaAdi], [Resim], [Aktif]) VALUES (1, N'DEUTSCH', N'DE', NULL, 1)
INSERT [dbo].[Dil] ([ID], [Adi], [KisaAdi], [Resim], [Aktif]) VALUES (2, N'ENGLISH', N'EN', NULL, 1)
INSERT [dbo].[Dil] ([ID], [Adi], [KisaAdi], [Resim], [Aktif]) VALUES (3, N'TÜRKCE', N'TR', NULL, 1)
SET IDENTITY_INSERT [dbo].[Dil] OFF
/****** Object:  Table [dbo].[Menu]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](150) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Menu] ON
INSERT [dbo].[Menu] ([ID], [Adi], [Active]) VALUES (1, N'Ürünler', 1)
SET IDENTITY_INSERT [dbo].[Menu] OFF
/****** Object:  Table [dbo].[Markalar]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Markalar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MarkaAdi] [nvarchar](150) NULL,
	[Resim] [nvarchar](50) NULL,
	[SiraNo] [int] NULL,
	[Aktif] [bit] NULL,
 CONSTRAINT [PK_Markalar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Markalar] ON
INSERT [dbo].[Markalar] ([ID], [MarkaAdi], [Resim], [SiraNo], [Aktif]) VALUES (13, N'NOTABU', N'05 - Kopya.png', 0, 1)
SET IDENTITY_INSERT [dbo].[Markalar] OFF
/****** Object:  Table [dbo].[KullaniciRol]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullaniciRol](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KullaniciRol] ON
INSERT [dbo].[KullaniciRol] ([ID], [RoleName]) VALUES (1, N'Admin')
SET IDENTITY_INSERT [dbo].[KullaniciRol] OFF
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RolID] [int] NOT NULL,
	[KullaniciAdi] [nvarchar](150) NULL,
	[KullaniciSifre] [nvarchar](150) NULL,
	[Aktif] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON
INSERT [dbo].[Kullanicilar] ([ID], [RolID], [KullaniciAdi], [KullaniciSifre], [Aktif]) VALUES (1, 1, N'kutlu', N'c4ca4238a0b923820dcc509a6f75849b', 1)
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
/****** Object:  Table [dbo].[KategoriL]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KategoriL](
	[KID] [int] NOT NULL,
	[DID] [int] NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Aciklama] [nvarchar](max) NOT NULL,
	[Seolink] [nvarchar](250) NOT NULL,
	[Aktif] [bit] NULL,
	[SiraNo] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[KategoriL] ([KID], [DID], [Adi], [Aciklama], [Seolink], [Aktif], [SiraNo]) VALUES (53, 1, N'Pantolon', N'Wide', N'pantolon', 0, 0)
INSERT [dbo].[KategoriL] ([KID], [DID], [Adi], [Aciklama], [Seolink], [Aktif], [SiraNo]) VALUES (55, 1, N'Gömlek', N'Kisa', N'gömlek', 1, 0)
INSERT [dbo].[KategoriL] ([KID], [DID], [Adi], [Aciklama], [Seolink], [Aktif], [SiraNo]) VALUES (57, 1, N'24 h Online Shoppen ab Sept. 2018', N'', N'24-h-online-shoppen-ab-sept.-2018', 0, 0)
INSERT [dbo].[KategoriL] ([KID], [DID], [Adi], [Aciklama], [Seolink], [Aktif], [SiraNo]) VALUES (58, 1, N'Zweiteiler', N'', N'zweiteiler', 0, 0)
/****** Object:  Table [dbo].[BlogKategoriL]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogKategoriL](
	[BlogKategoriID] [int] NOT NULL,
	[DilID] [int] NOT NULL,
	[Aktif] [bit] NULL,
	[Adi] [nvarchar](150) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[BlogKategoriL] ([BlogKategoriID], [DilID], [Aktif], [Adi]) VALUES (2, 1, 1, N'Yok Adı')
/****** Object:  Table [dbo].[MenuL]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuL](
	[MID] [int] NOT NULL,
	[DID] [int] NOT NULL,
	[Adi] [nvarchar](150) NOT NULL,
	[SeoLink] [nvarchar](250) NULL,
	[URL] [nvarchar](150) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[MenuL] ([MID], [DID], [Adi], [SeoLink], [URL]) VALUES (1, 1, N'Ürünler', N'urunler', N'yok')
/****** Object:  Table [dbo].[BlogHaber]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogHaber](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BlogKategoriID] [int] NULL,
	[Aktif] [bit] NULL,
	[Baslik] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_BlogHaber] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BlogHaber] ON
INSERT [dbo].[BlogHaber] ([ID], [BlogKategoriID], [Aktif], [Baslik]) VALUES (2, 2, 1, N'Dneme Baslık')
SET IDENTITY_INSERT [dbo].[BlogHaber] OFF
/****** Object:  Table [dbo].[Metinler]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metinler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Hakkimizda] [nvarchar](max) NULL,
	[SatisSozlesmesi] [nvarchar](max) NULL,
	[GizlilikPolitikasi] [nvarchar](max) NULL,
	[UyelikSozlesmesi] [nvarchar](max) NULL,
	[Iadeİptal] [nvarchar](max) NULL,
	[Bilgilendirme] [nvarchar](max) NULL,
	[GirisYazisiBaslik] [nvarchar](150) NULL,
	[GirisYazisi] [nvarchar](max) NULL,
	[Vizyon] [nvarchar](max) NULL,
	[Misyon] [nvarchar](max) NULL,
	[Strateji] [nvarchar](max) NULL,
	[DilID] [int] NULL,
 CONSTRAINT [PK_Metinler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Metinler] ON
INSERT [dbo].[Metinler] ([ID], [Hakkimizda], [SatisSozlesmesi], [GizlilikPolitikasi], [UyelikSozlesmesi], [Iadeİptal], [Bilgilendirme], [GirisYazisiBaslik], [GirisYazisi], [Vizyon], [Misyon], [Strateji], [DilID]) VALUES (1, N'hakkımızda', N'<p><span style="font-size:24px"><strong>Mesafeli Satış S&ouml;zleşmesi</strong></span></p>', N'<h2>ALIŞ-VERIŞ G&Uuml;VENLIĞI VE SSL SERTIFIKASI</h2>', N'<p><strong>&Ouml;deme ve Teslimat</strong></p>', N'<p><strong>&Ouml;deme ve Teslimat</strong></p>', N'<p><strong>&Ouml;deme ve Teslimat</strong></p>', N'Deneme', N'Deneme', N' <p>Türkiye’de ve bölgede e-ticaret sektörünün lideri olmak.</p>', N' <p>E-ticaret sektöründe hem müşterilere hem mağazalara yenilikçi hizmetler sunarak Türkiye e-ticaret sektörünün yeniden şekillendirilmesine öncülük etmek.</p>', N'<p>Stratejik ortaklıklarla güçlü entegrasyona dayanan eko-sistemimizde, müşterilere Güven ve Kolaylık; mağazalara ise Destek ve Özen üzerine dayalı değer önerileri sunmaktır.</p>', 1)
SET IDENTITY_INSERT [dbo].[Metinler] OFF
/****** Object:  Table [dbo].[Ayarlar]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ayarlar](
	[SatisAktif] [bit] NULL,
	[BlogAktif] [bit] NULL,
	[UyeliksizSatis] [bit] NULL,
	[UyelikZorunlu] [bit] NULL,
	[GoogleClientID] [nvarchar](150) NULL,
	[GoogleClientSecret] [nvarchar](150) NULL,
	[FacebookAppID] [nvarchar](150) NULL,
	[FacebookSecret] [nvarchar](150) NULL,
	[TwitterApiID] [nvarchar](150) NULL,
	[TwitterSecret] [nvarchar](150) NULL,
	[DilID] [int] NOT NULL,
	[AcilisDili] [int] NOT NULL,
	[InstagramID] [nvarchar](150) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Ayarlar] ([SatisAktif], [BlogAktif], [UyeliksizSatis], [UyelikZorunlu], [GoogleClientID], [GoogleClientSecret], [FacebookAppID], [FacebookSecret], [TwitterApiID], [TwitterSecret], [DilID], [AcilisDili], [InstagramID]) VALUES (1, 1, 1, 1, N'1', N'yok', N'1', N'yok', N'1', N'yok', 1, 1, NULL)
/****** Object:  Table [dbo].[Urunler]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](150) NOT NULL,
	[KategoriID] [int] NOT NULL,
	[TedarikciID] [int] NULL,
	[MarkaID] [int] NULL,
	[UrunKodu] [nvarchar](50) NULL,
	[Barkod] [nvarchar](50) NULL,
	[Aktif] [bit] NOT NULL,
	[Resim] [nvarchar](50) NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Urunler] ON
INSERT [dbo].[Urunler] ([ID], [UrunAdi], [KategoriID], [TedarikciID], [MarkaID], [UrunKodu], [Barkod], [Aktif], [Resim]) VALUES (31, N'Kisapantolon', 53, 0, 13, N'Sarikisa', N'0', 1, N'kisapantolon-2.png')
INSERT [dbo].[Urunler] ([ID], [UrunAdi], [KategoriID], [TedarikciID], [MarkaID], [UrunKodu], [Barkod], [Aktif], [Resim]) VALUES (32, N'', 53, 0, 13, N'Uzuncorap', N'', 1, N'Yok')
INSERT [dbo].[Urunler] ([ID], [UrunAdi], [KategoriID], [TedarikciID], [MarkaID], [UrunKodu], [Barkod], [Aktif], [Resim]) VALUES (33, N'Kisa', 55, 0, 13, N'Yazlik', N'0', 1, N'kisa-1.png')
INSERT [dbo].[Urunler] ([ID], [UrunAdi], [KategoriID], [TedarikciID], [MarkaID], [UrunKodu], [Barkod], [Aktif], [Resim]) VALUES (34, N'Yazlik', 56, 0, 13, N'Yzlik', N'', 1, N'Yok')
INSERT [dbo].[Urunler] ([ID], [UrunAdi], [KategoriID], [TedarikciID], [MarkaID], [UrunKodu], [Barkod], [Aktif], [Resim]) VALUES (35, N'Kislik', 56, 0, 13, N'Yazlik uzun', N'0', 1, N'Yok')
INSERT [dbo].[Urunler] ([ID], [UrunAdi], [KategoriID], [TedarikciID], [MarkaID], [UrunKodu], [Barkod], [Aktif], [Resim]) VALUES (36, N'Bluse', 53, 0, 13, N'', N'0', 1, N'bluse-1.png')
INSERT [dbo].[Urunler] ([ID], [UrunAdi], [KategoriID], [TedarikciID], [MarkaID], [UrunKodu], [Barkod], [Aktif], [Resim]) VALUES (37, N'Zweiteiler', 58, 0, 13, N'', N'0', 1, N'zweiteiler-1.png')
SET IDENTITY_INSERT [dbo].[Urunler] OFF
/****** Object:  Table [dbo].[SiteBilgileri]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteBilgileri](
	[FirmaAdi] [nvarchar](250) NOT NULL,
	[Adres] [nvarchar](250) NULL,
	[Ulke] [nvarchar](50) NULL,
	[Sehir] [nvarchar](50) NULL,
	[Ilce] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	[Faks] [nvarchar](50) NULL,
	[MobilTel] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[URL] [nvarchar](50) NULL,
	[KeyWords] [nvarchar](max) NULL,
	[HaritaKodu] [nvarchar](max) NULL,
	[SiteLogo] [nvarchar](150) NULL,
	[DilID] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[SiteBilgileri] ([FirmaAdi], [Adres], [Ulke], [Sehir], [Ilce], [Tel], [Faks], [MobilTel], [Mail], [URL], [KeyWords], [HaritaKodu], [SiteLogo], [DilID]) VALUES (N'türkçe', N'deneme', N'TÜRKİYE', N'İZMİR', N'KONAK', N'+90 541 850 27 81', N'0', N'0', N'deneme', N'deneme', N'deneme', NULL, N'logo_black.png', 1)
INSERT [dbo].[SiteBilgileri] ([FirmaAdi], [Adres], [Ulke], [Sehir], [Ilce], [Tel], [Faks], [MobilTel], [Mail], [URL], [KeyWords], [HaritaKodu], [SiteLogo], [DilID]) VALUES (N'ingilizce', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', NULL, N'logo_black.png', 2)
INSERT [dbo].[SiteBilgileri] ([FirmaAdi], [Adres], [Ulke], [Sehir], [Ilce], [Tel], [Faks], [MobilTel], [Mail], [URL], [KeyWords], [HaritaKodu], [SiteLogo], [DilID]) VALUES (N'almanca', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', NULL, N'logo_black.png', 3)
/****** Object:  Table [dbo].[UrunResimleri]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunResimleri](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Resim] [nvarchar](150) NOT NULL,
	[SiraNo] [int] NULL,
	[UrunID] [int] NOT NULL,
 CONSTRAINT [PK_UrunResimleri] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UrunResimleri] ON
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (86, N'kisapantolon-2.png', 0, 31)
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (87, N'kisapantolon-3.png', 0, 31)
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (88, N'kisa-1.png', 0, 33)
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (89, N'kisa-2.png', 0, 33)
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (90, N'kisa-3.png', 0, 33)
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (91, N'bluse-1.png', 0, 36)
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (92, N'bluse-2.png', 0, 36)
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (93, N'zweiteiler-1.png', 0, 37)
INSERT [dbo].[UrunResimleri] ([ID], [Resim], [SiraNo], [UrunID]) VALUES (94, N'kisapantolon-3.png', 0, 31)
SET IDENTITY_INSERT [dbo].[UrunResimleri] OFF
/****** Object:  Table [dbo].[UrunlerL]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunlerL](
	[UrunAdi] [nvarchar](150) NOT NULL,
	[DilID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Aciklama] [nvarchar](max) NULL,
	[SiraNo] [int] NULL,
	[SeoLink] [nvarchar](250) NULL,
	[Fiyat] [float] NULL,
	[KDV] [float] NULL,
	[MetaTit] [nvarchar](250) NULL,
	[MetaKey] [nvarchar](250) NULL,
	[MetaDes] [nvarchar](250) NULL,
	[Resim] [nvarchar](50) NULL,
	[TeknikAciklama] [nvarchar](max) NULL,
	[TeknikAciklamaDevam] [nvarchar](max) NULL,
	[TeknikDetay] [nvarchar](max) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[UrunlerL] ([UrunAdi], [DilID], [UrunID], [Aciklama], [SiraNo], [SeoLink], [Fiyat], [KDV], [MetaTit], [MetaKey], [MetaDes], [Resim], [TeknikAciklama], [TeknikAciklamaDevam], [TeknikDetay]) VALUES (N'Kleid', 1, 31, N'<p><br></p>', 0, N'kisapantolon', 0, 0, N'', N'', N'', N'kisapantolon-2.png', N'<p><br></p>', N'<p><br></p>', N'<p><br></p>')
INSERT [dbo].[UrunlerL] ([UrunAdi], [DilID], [UrunID], [Aciklama], [SiraNo], [SeoLink], [Fiyat], [KDV], [MetaTit], [MetaKey], [MetaDes], [Resim], [TeknikAciklama], [TeknikAciklamaDevam], [TeknikDetay]) VALUES (N'Kleid', 1, 33, N'<p><br></p>', 0, N'kisa', 20, 0, N'Kisa gömlek', N'', N'', N'kisa-1.png', N'<p><br></p>', N'<p><br></p>', N'<p><br></p>')
INSERT [dbo].[UrunlerL] ([UrunAdi], [DilID], [UrunID], [Aciklama], [SiraNo], [SeoLink], [Fiyat], [KDV], [MetaTit], [MetaKey], [MetaDes], [Resim], [TeknikAciklama], [TeknikAciklamaDevam], [TeknikDetay]) VALUES (N'Bluse', 1, 36, N'<p>Sehr schön</p>', 0, N'bluse', 0, 0, N'Sommerbluse', N'', N'', N'bluse-1.png', N'<p><br></p>', N'<p><br></p>', N'<p><br></p>')
INSERT [dbo].[UrunlerL] ([UrunAdi], [DilID], [UrunID], [Aciklama], [SiraNo], [SeoLink], [Fiyat], [KDV], [MetaTit], [MetaKey], [MetaDes], [Resim], [TeknikAciklama], [TeknikAciklamaDevam], [TeknikDetay]) VALUES (N'Zweiteiler', 1, 37, N'<p><br></p>', 0, N'zweiteiler', 0, 0, N'', N'', N'', N'zweiteiler-1.png', N'<p><br></p>', N'<p><br></p>', N'<p><br></p>')
/****** Object:  Table [dbo].[UrunEtiket]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunEtiket](
	[EtiketID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
 CONSTRAINT [PK_UrunEtiket] PRIMARY KEY CLUSTERED 
(
	[EtiketID] ASC,
	[UrunID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UrunEtiket] ([EtiketID], [UrunID]) VALUES (9, 31)
/****** Object:  Table [dbo].[Urun_Yorumlari]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun_Yorumlari](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NOT NULL,
	[Yorum] [nvarchar](max) NULL,
	[YorumuYazan] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[Tarih] [nvarchar](50) NULL,
 CONSTRAINT [PK_Urun_Yorumlari] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sepet_Detay]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sepet_Detay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SepetID] [int] NOT NULL,
	[MID] [int] NULL,
	[UrunID] [int] NOT NULL,
	[Adet] [int] NULL,
	[Fiyat] [float] NULL,
	[IndirimOrani] [float] NULL,
	[Tarih] [nvarchar](50) NULL,
	[Renk] [nvarchar](50) NULL,
	[Beden] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sepet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sepet_Detay] ON
INSERT [dbo].[Sepet_Detay] ([ID], [SepetID], [MID], [UrunID], [Adet], [Fiyat], [IndirimOrani], [Tarih], [Renk], [Beden]) VALUES (116, 7, NULL, 37, 1, 0, NULL, N'28-07-2018', N'Belirtilmemiş', N'Belirtilmemiş')
INSERT [dbo].[Sepet_Detay] ([ID], [SepetID], [MID], [UrunID], [Adet], [Fiyat], [IndirimOrani], [Tarih], [Renk], [Beden]) VALUES (119, 10, NULL, 33, 2, 20, NULL, N'15-05-2019', N'Belirtilmemiş', N'Belirtilmemiş')
INSERT [dbo].[Sepet_Detay] ([ID], [SepetID], [MID], [UrunID], [Adet], [Fiyat], [IndirimOrani], [Tarih], [Renk], [Beden]) VALUES (120, 11, NULL, 33, 2, 20, NULL, N'12-09-2019', N'Belirtilmemiş', N'Belirtilmemiş')
INSERT [dbo].[Sepet_Detay] ([ID], [SepetID], [MID], [UrunID], [Adet], [Fiyat], [IndirimOrani], [Tarih], [Renk], [Beden]) VALUES (121, 11, NULL, 33, 2, 20, NULL, N'12-09-2019', N'Belirtilmemiş', N'Belirtilmemiş')
INSERT [dbo].[Sepet_Detay] ([ID], [SepetID], [MID], [UrunID], [Adet], [Fiyat], [IndirimOrani], [Tarih], [Renk], [Beden]) VALUES (122, 12, NULL, 33, 1, 20, NULL, N'16-10-2019', N'Belirtilmemiş', N'Belirtilmemiş')
INSERT [dbo].[Sepet_Detay] ([ID], [SepetID], [MID], [UrunID], [Adet], [Fiyat], [IndirimOrani], [Tarih], [Renk], [Beden]) VALUES (124, 13, NULL, 33, 1, 20, NULL, N'24-02-2021', N'Belirtilmemiş', N'Belirtilmemiş')
INSERT [dbo].[Sepet_Detay] ([ID], [SepetID], [MID], [UrunID], [Adet], [Fiyat], [IndirimOrani], [Tarih], [Renk], [Beden]) VALUES (125, 13, NULL, 33, 1, 20, NULL, N'24-02-2021', N'Belirtilmemiş', N'Belirtilmemiş')
SET IDENTITY_INSERT [dbo].[Sepet_Detay] OFF
/****** Object:  Table [dbo].[Renkler]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Renkler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NOT NULL,
	[RenkAdi] [nvarchar](50) NOT NULL,
	[RenkKodu] [nvarchar](50) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Renkler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Renkler] ON
INSERT [dbo].[Renkler] ([ID], [UrunID], [RenkAdi], [RenkKodu], [Aktif]) VALUES (5, 31, N'Kirmizi', N'#000000', 1)
SET IDENTITY_INSERT [dbo].[Renkler] OFF
/****** Object:  Table [dbo].[Olculer]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Olculer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NOT NULL,
	[OlcuAdi] [nvarchar](50) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Olculer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bedenler]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bedenler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NULL,
	[BedenAdi] [nvarchar](50) NULL,
	[Aktif] [bit] NULL,
 CONSTRAINT [PK_Bedenler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bedenler] ON
INSERT [dbo].[Bedenler] ([ID], [UrunID], [BedenAdi], [Aktif]) VALUES (8, 31, N'38', 1)
SET IDENTITY_INSERT [dbo].[Bedenler] OFF
/****** Object:  Table [dbo].[BlogHaberL]    Script Date: 03/10/2021 00:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogHaberL](
	[BlogHaberID] [int] NOT NULL,
	[DilID] [int] NOT NULL,
	[Baslik] [nvarchar](150) NULL,
	[Detay] [nvarchar](max) NULL,
	[Resim] [nvarchar](150) NULL,
	[Tarih] [nvarchar](150) NULL,
	[KullaniciID] [int] NULL,
	[Aktif] [bit] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[BlogHaberL] ([BlogHaberID], [DilID], [Baslik], [Detay], [Resim], [Tarih], [KullaniciID], [Aktif]) VALUES (2, 1, N'Denememe', N'yok detay', N'blog_01.jpg', N'01-01-2020', 1, 1)
/****** Object:  Default [DF_Slider_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Slider] ADD  CONSTRAINT [DF_Slider_Aktif]  DEFAULT ((0)) FOR [Aktif]
GO
/****** Object:  Default [DF_Promosyon_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Promosyon] ADD  CONSTRAINT [DF_Promosyon_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_Sepet_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Sepet] ADD  CONSTRAINT [DF_Sepet_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_BlogKategori_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[BlogKategori] ADD  CONSTRAINT [DF_BlogKategori_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_Kategori_Active]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Kategori] ADD  CONSTRAINT [DF_Kategori_Active]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_Dil_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Dil] ADD  CONSTRAINT [DF_Dil_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_Markalar_SiraNo]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Markalar] ADD  CONSTRAINT [DF_Markalar_SiraNo]  DEFAULT ((0)) FOR [SiraNo]
GO
/****** Object:  Default [DF_Markalar_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Markalar] ADD  CONSTRAINT [DF_Markalar_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_KategoriL_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[KategoriL] ADD  CONSTRAINT [DF_KategoriL_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_KategoriL_SiraNo]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[KategoriL] ADD  CONSTRAINT [DF_KategoriL_SiraNo]  DEFAULT ((0)) FOR [SiraNo]
GO
/****** Object:  Default [DF_BlogKategoriL_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[BlogKategoriL] ADD  CONSTRAINT [DF_BlogKategoriL_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_SiteAyarlari_SatisAktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Ayarlar] ADD  CONSTRAINT [DF_SiteAyarlari_SatisAktif]  DEFAULT ((1)) FOR [SatisAktif]
GO
/****** Object:  Default [DF_SiteAyarlari_BlogAktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Ayarlar] ADD  CONSTRAINT [DF_SiteAyarlari_BlogAktif]  DEFAULT ((1)) FOR [BlogAktif]
GO
/****** Object:  Default [DF_Table_1_UyelikAktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Ayarlar] ADD  CONSTRAINT [DF_Table_1_UyelikAktif]  DEFAULT ((1)) FOR [UyeliksizSatis]
GO
/****** Object:  Default [DF_SiteAyarlari_UyelikZorunlu]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Ayarlar] ADD  CONSTRAINT [DF_SiteAyarlari_UyelikZorunlu]  DEFAULT ((0)) FOR [UyelikZorunlu]
GO
/****** Object:  Default [DF_Urunler_TedarikciID]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_TedarikciID]  DEFAULT ((0)) FOR [TedarikciID]
GO
/****** Object:  Default [DF_Urunler_MarkaID]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_MarkaID]  DEFAULT ((0)) FOR [MarkaID]
GO
/****** Object:  Default [DF_Urunler_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_Urunler_Resim]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_Resim]  DEFAULT (N'Yok') FOR [Resim]
GO
/****** Object:  Default [DF_UrunResimleri_Resim]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunResimleri] ADD  CONSTRAINT [DF_UrunResimleri_Resim]  DEFAULT (N'Yok') FOR [Resim]
GO
/****** Object:  Default [DF_UrunResimleri_SiraNo]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunResimleri] ADD  CONSTRAINT [DF_UrunResimleri_SiraNo]  DEFAULT ((0)) FOR [SiraNo]
GO
/****** Object:  Default [DF_UrunlerL_Fiyat]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunlerL] ADD  CONSTRAINT [DF_UrunlerL_Fiyat]  DEFAULT ((0)) FOR [Fiyat]
GO
/****** Object:  Default [DF_UrunlerL_KDV]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunlerL] ADD  CONSTRAINT [DF_UrunlerL_KDV]  DEFAULT ((0)) FOR [KDV]
GO
/****** Object:  Default [DF_Sepet_Detay_MID]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Sepet_Detay] ADD  CONSTRAINT [DF_Sepet_Detay_MID]  DEFAULT ((0)) FOR [MID]
GO
/****** Object:  Default [DF_Renkler_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Renkler] ADD  CONSTRAINT [DF_Renkler_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_Olculer_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Olculer] ADD  CONSTRAINT [DF_Olculer_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  Default [DF_Bedenler_Aktif]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Bedenler] ADD  CONSTRAINT [DF_Bedenler_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
/****** Object:  ForeignKey [FK_User_UserRole]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Kullanicilar]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([RolID])
REFERENCES [dbo].[KullaniciRol] ([ID])
GO
ALTER TABLE [dbo].[Kullanicilar] CHECK CONSTRAINT [FK_User_UserRole]
GO
/****** Object:  ForeignKey [FK_KategoriL_Dil]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[KategoriL]  WITH CHECK ADD  CONSTRAINT [FK_KategoriL_Dil] FOREIGN KEY([DID])
REFERENCES [dbo].[Dil] ([ID])
GO
ALTER TABLE [dbo].[KategoriL] CHECK CONSTRAINT [FK_KategoriL_Dil]
GO
/****** Object:  ForeignKey [FK_KategoriL_Kategori]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[KategoriL]  WITH CHECK ADD  CONSTRAINT [FK_KategoriL_Kategori] FOREIGN KEY([KID])
REFERENCES [dbo].[Kategori] ([ID])
GO
ALTER TABLE [dbo].[KategoriL] CHECK CONSTRAINT [FK_KategoriL_Kategori]
GO
/****** Object:  ForeignKey [FK_BlogKategoriL_BlogKategori]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[BlogKategoriL]  WITH CHECK ADD  CONSTRAINT [FK_BlogKategoriL_BlogKategori] FOREIGN KEY([BlogKategoriID])
REFERENCES [dbo].[BlogKategori] ([ID])
GO
ALTER TABLE [dbo].[BlogKategoriL] CHECK CONSTRAINT [FK_BlogKategoriL_BlogKategori]
GO
/****** Object:  ForeignKey [FK_BlogKategoriL_Dil]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[BlogKategoriL]  WITH CHECK ADD  CONSTRAINT [FK_BlogKategoriL_Dil] FOREIGN KEY([DilID])
REFERENCES [dbo].[Dil] ([ID])
GO
ALTER TABLE [dbo].[BlogKategoriL] CHECK CONSTRAINT [FK_BlogKategoriL_Dil]
GO
/****** Object:  ForeignKey [FK_MenuL_Dil]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[MenuL]  WITH CHECK ADD  CONSTRAINT [FK_MenuL_Dil] FOREIGN KEY([DID])
REFERENCES [dbo].[Dil] ([ID])
GO
ALTER TABLE [dbo].[MenuL] CHECK CONSTRAINT [FK_MenuL_Dil]
GO
/****** Object:  ForeignKey [FK_MenuL_Menu]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[MenuL]  WITH CHECK ADD  CONSTRAINT [FK_MenuL_Menu] FOREIGN KEY([MID])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[MenuL] CHECK CONSTRAINT [FK_MenuL_Menu]
GO
/****** Object:  ForeignKey [FK_BlogHaber_BlogKategori]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[BlogHaber]  WITH CHECK ADD  CONSTRAINT [FK_BlogHaber_BlogKategori] FOREIGN KEY([BlogKategoriID])
REFERENCES [dbo].[BlogKategori] ([ID])
GO
ALTER TABLE [dbo].[BlogHaber] CHECK CONSTRAINT [FK_BlogHaber_BlogKategori]
GO
/****** Object:  ForeignKey [FK_Metinler_Dil]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Metinler]  WITH CHECK ADD  CONSTRAINT [FK_Metinler_Dil] FOREIGN KEY([DilID])
REFERENCES [dbo].[Dil] ([ID])
GO
ALTER TABLE [dbo].[Metinler] CHECK CONSTRAINT [FK_Metinler_Dil]
GO
/****** Object:  ForeignKey [FK_Ayarlar_Dil]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Ayarlar]  WITH CHECK ADD  CONSTRAINT [FK_Ayarlar_Dil] FOREIGN KEY([DilID])
REFERENCES [dbo].[Dil] ([ID])
GO
ALTER TABLE [dbo].[Ayarlar] CHECK CONSTRAINT [FK_Ayarlar_Dil]
GO
/****** Object:  ForeignKey [FK_Urunler_Kategori]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Kategori] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategori] ([ID])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Kategori]
GO
/****** Object:  ForeignKey [FK_Urunler_Markalar]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Markalar] FOREIGN KEY([MarkaID])
REFERENCES [dbo].[Markalar] ([ID])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Markalar]
GO
/****** Object:  ForeignKey [FK_SiteBilgileri_Dil]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[SiteBilgileri]  WITH CHECK ADD  CONSTRAINT [FK_SiteBilgileri_Dil] FOREIGN KEY([DilID])
REFERENCES [dbo].[Dil] ([ID])
GO
ALTER TABLE [dbo].[SiteBilgileri] CHECK CONSTRAINT [FK_SiteBilgileri_Dil]
GO
/****** Object:  ForeignKey [FK_UrunResimleri_Urunler]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunResimleri]  WITH CHECK ADD  CONSTRAINT [FK_UrunResimleri_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[UrunResimleri] CHECK CONSTRAINT [FK_UrunResimleri_Urunler]
GO
/****** Object:  ForeignKey [FK_UrunlerL_Dil]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunlerL]  WITH CHECK ADD  CONSTRAINT [FK_UrunlerL_Dil] FOREIGN KEY([DilID])
REFERENCES [dbo].[Dil] ([ID])
GO
ALTER TABLE [dbo].[UrunlerL] CHECK CONSTRAINT [FK_UrunlerL_Dil]
GO
/****** Object:  ForeignKey [FK_UrunlerL_Urunler]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunlerL]  WITH CHECK ADD  CONSTRAINT [FK_UrunlerL_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[UrunlerL] CHECK CONSTRAINT [FK_UrunlerL_Urunler]
GO
/****** Object:  ForeignKey [FK_UrunEtiket_Etiket]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunEtiket]  WITH CHECK ADD  CONSTRAINT [FK_UrunEtiket_Etiket] FOREIGN KEY([EtiketID])
REFERENCES [dbo].[Etiket] ([ID])
GO
ALTER TABLE [dbo].[UrunEtiket] CHECK CONSTRAINT [FK_UrunEtiket_Etiket]
GO
/****** Object:  ForeignKey [FK_UrunEtiket_Urunler]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[UrunEtiket]  WITH CHECK ADD  CONSTRAINT [FK_UrunEtiket_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[UrunEtiket] CHECK CONSTRAINT [FK_UrunEtiket_Urunler]
GO
/****** Object:  ForeignKey [FK_Urun_Yorumlari_Urunler]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Urun_Yorumlari]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Yorumlari_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[Urun_Yorumlari] CHECK CONSTRAINT [FK_Urun_Yorumlari_Urunler]
GO
/****** Object:  ForeignKey [FK_Sepet_Detay_Sepet]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Sepet_Detay]  WITH CHECK ADD  CONSTRAINT [FK_Sepet_Detay_Sepet] FOREIGN KEY([SepetID])
REFERENCES [dbo].[Sepet] ([ID])
GO
ALTER TABLE [dbo].[Sepet_Detay] CHECK CONSTRAINT [FK_Sepet_Detay_Sepet]
GO
/****** Object:  ForeignKey [FK_Sepet_Detay_Urunler]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Sepet_Detay]  WITH CHECK ADD  CONSTRAINT [FK_Sepet_Detay_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[Sepet_Detay] CHECK CONSTRAINT [FK_Sepet_Detay_Urunler]
GO
/****** Object:  ForeignKey [FK_Renkler_Urunler]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Renkler]  WITH CHECK ADD  CONSTRAINT [FK_Renkler_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[Renkler] CHECK CONSTRAINT [FK_Renkler_Urunler]
GO
/****** Object:  ForeignKey [FK_Olculer_Urunler]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Olculer]  WITH CHECK ADD  CONSTRAINT [FK_Olculer_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[Olculer] CHECK CONSTRAINT [FK_Olculer_Urunler]
GO
/****** Object:  ForeignKey [FK_Bedenler_Urunler]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[Bedenler]  WITH CHECK ADD  CONSTRAINT [FK_Bedenler_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([ID])
GO
ALTER TABLE [dbo].[Bedenler] CHECK CONSTRAINT [FK_Bedenler_Urunler]
GO
/****** Object:  ForeignKey [FK_BlogHaberL_BlogHaber]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[BlogHaberL]  WITH CHECK ADD  CONSTRAINT [FK_BlogHaberL_BlogHaber] FOREIGN KEY([BlogHaberID])
REFERENCES [dbo].[BlogHaber] ([ID])
GO
ALTER TABLE [dbo].[BlogHaberL] CHECK CONSTRAINT [FK_BlogHaberL_BlogHaber]
GO
/****** Object:  ForeignKey [FK_BlogHaberL_Dil]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[BlogHaberL]  WITH CHECK ADD  CONSTRAINT [FK_BlogHaberL_Dil] FOREIGN KEY([DilID])
REFERENCES [dbo].[Dil] ([ID])
GO
ALTER TABLE [dbo].[BlogHaberL] CHECK CONSTRAINT [FK_BlogHaberL_Dil]
GO
/****** Object:  ForeignKey [FK_BlogHaberL_Kullanicilar]    Script Date: 03/10/2021 00:46:04 ******/
ALTER TABLE [dbo].[BlogHaberL]  WITH CHECK ADD  CONSTRAINT [FK_BlogHaberL_Kullanicilar] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanicilar] ([ID])
GO
ALTER TABLE [dbo].[BlogHaberL] CHECK CONSTRAINT [FK_BlogHaberL_Kullanicilar]
GO
