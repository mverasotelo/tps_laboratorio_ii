USE [master]
GO
/****** Object:  Database [ESTABLECIMIENTO]    Script Date: 21/11/2021 19:14:28 ******/
CREATE DATABASE [ESTABLECIMIENTO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ESTABLECIMIENTO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ESTABLECIMIENTO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ESTABLECIMIENTO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ESTABLECIMIENTO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ESTABLECIMIENTO] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ESTABLECIMIENTO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ESTABLECIMIENTO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET ARITHABORT OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET RECOVERY FULL 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET  MULTI_USER 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ESTABLECIMIENTO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ESTABLECIMIENTO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ESTABLECIMIENTO', N'ON'
GO
ALTER DATABASE [ESTABLECIMIENTO] SET QUERY_STORE = OFF
GO
USE [ESTABLECIMIENTO]
GO
/****** Object:  Table [dbo].[BOVINOS]    Script Date: 21/11/2021 19:14:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOVINOS](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[FECHA_INGRESO] [date] NOT NULL,
	[SEXO] [varchar](6) NOT NULL,
	[RAZA] [varchar](10) NOT NULL,
	[USO] [varchar](7) NOT NULL,
 CONSTRAINT [PK_BOVINOS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTADISTICAS]    Script Date: 21/11/2021 19:14:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADISTICAS](
	[FECHA] [date] NOT NULL,
	[TOTAL_ANIMALES] [int] NOT NULL,
	[TOTAL_TAMBO] [int] NOT NULL,
	[LECHE_PRODUCIDA] [float] NULL,
	[BOVINO_MAS_PRODUCTIVO_TAMBO] [int] NOT NULL,
	[TOTAL_ENGORDE] [int] NOT NULL,
	[CARNE_PRODUCIDA] [float] NULL,
 CONSTRAINT [PK_ESTADISTICAS] PRIMARY KEY CLUSTERED 
(
	[FECHA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BOVINOS] ON 

INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1000, CAST(N'2021-11-14' AS Date), N'Macho', N'Angus', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1001, CAST(N'2021-11-20' AS Date), N'Macho', N'Angus', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1003, CAST(N'2021-10-25' AS Date), N'Hembra', N'Holstein', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1004, CAST(N'2021-10-30' AS Date), N'Hembra', N'Hereford', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1006, CAST(N'2021-11-14' AS Date), N'Macho', N'Holstein', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1007, CAST(N'2021-11-14' AS Date), N'Hembra', N'Angus', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1008, CAST(N'2021-11-14' AS Date), N'Hembra', N'Angus', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1009, CAST(N'2021-11-14' AS Date), N'Macho', N'Hereford', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1010, CAST(N'2021-11-14' AS Date), N'Hembra', N'Hereford', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1011, CAST(N'2021-11-14' AS Date), N'Hembra', N'Hereford', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1012, CAST(N'2021-11-14' AS Date), N'Hembra', N'Hereford', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1013, CAST(N'2021-11-17' AS Date), N'Hembra', N'Angus', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1014, CAST(N'2021-11-17' AS Date), N'Hembra', N'Angus', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1015, CAST(N'2021-11-18' AS Date), N'Hembra', N'Angus', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1016, CAST(N'2021-11-18' AS Date), N'Macho', N'Angus', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1017, CAST(N'2021-11-20' AS Date), N'Hembra', N'Hereford', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1018, CAST(N'2021-11-20' AS Date), N'Macho', N'Angus', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1019, CAST(N'2021-11-20' AS Date), N'Hembra', N'Holstein', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1020, CAST(N'2021-11-20' AS Date), N'Hembra', N'Angus', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1022, CAST(N'2021-11-20' AS Date), N'Macho', N'Hereford', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1023, CAST(N'2021-11-20' AS Date), N'Macho', N'Hereford', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1024, CAST(N'2021-11-20' AS Date), N'Hembra', N'Hereford', N'Tambo')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1025, CAST(N'2021-11-20' AS Date), N'Macho', N'Holstein', N'Engorde')
INSERT [dbo].[BOVINOS] ([ID], [FECHA_INGRESO], [SEXO], [RAZA], [USO]) VALUES (1026, CAST(N'2021-11-20' AS Date), N'Hembra', N'Angus', N'Tambo')
SET IDENTITY_INSERT [dbo].[BOVINOS] OFF
GO
INSERT [dbo].[ESTADISTICAS] ([FECHA], [TOTAL_ANIMALES], [TOTAL_TAMBO], [LECHE_PRODUCIDA], [BOVINO_MAS_PRODUCTIVO_TAMBO], [TOTAL_ENGORDE], [CARNE_PRODUCIDA]) VALUES (CAST(N'2021-11-16' AS Date), 11, 5, 1081.830078125, 1000, 6, 61.319999694824219)
INSERT [dbo].[ESTADISTICAS] ([FECHA], [TOTAL_ANIMALES], [TOTAL_TAMBO], [LECHE_PRODUCIDA], [BOVINO_MAS_PRODUCTIVO_TAMBO], [TOTAL_ENGORDE], [CARNE_PRODUCIDA]) VALUES (CAST(N'2021-11-17' AS Date), 11, 5, 1154.52001953125, 1000, 6, 57.599998474121094)
INSERT [dbo].[ESTADISTICAS] ([FECHA], [TOTAL_ANIMALES], [TOTAL_TAMBO], [LECHE_PRODUCIDA], [BOVINO_MAS_PRODUCTIVO_TAMBO], [TOTAL_ENGORDE], [CARNE_PRODUCIDA]) VALUES (CAST(N'2021-11-18' AS Date), 15, 8, 1770.050048828125, 1004, 7, 73.7699966430664)
INSERT [dbo].[ESTADISTICAS] ([FECHA], [TOTAL_ANIMALES], [TOTAL_TAMBO], [LECHE_PRODUCIDA], [BOVINO_MAS_PRODUCTIVO_TAMBO], [TOTAL_ENGORDE], [CARNE_PRODUCIDA]) VALUES (CAST(N'2021-11-20' AS Date), 24, 14, 2628.559814453125, 1004, 10, 86.360000610351562)
INSERT [dbo].[ESTADISTICAS] ([FECHA], [TOTAL_ANIMALES], [TOTAL_TAMBO], [LECHE_PRODUCIDA], [BOVINO_MAS_PRODUCTIVO_TAMBO], [TOTAL_ENGORDE], [CARNE_PRODUCIDA]) VALUES (CAST(N'2021-11-21' AS Date), 24, 14, 2668.97021484375, 1012, 10, 85.9000015258789)
GO
ALTER TABLE [dbo].[BOVINOS]  WITH CHECK ADD  CONSTRAINT [FK_BOVINOS_BOVINOS] FOREIGN KEY([ID])
REFERENCES [dbo].[BOVINOS] ([ID])
GO
ALTER TABLE [dbo].[BOVINOS] CHECK CONSTRAINT [FK_BOVINOS_BOVINOS]
GO
ALTER TABLE [dbo].[ESTADISTICAS]  WITH CHECK ADD  CONSTRAINT [FK_ESTADISTICAS_ESTADISTICAS] FOREIGN KEY([BOVINO_MAS_PRODUCTIVO_TAMBO])
REFERENCES [dbo].[BOVINOS] ([ID])
GO
ALTER TABLE [dbo].[ESTADISTICAS] CHECK CONSTRAINT [FK_ESTADISTICAS_ESTADISTICAS]
GO
USE [master]
GO
ALTER DATABASE [ESTABLECIMIENTO] SET  READ_WRITE 
GO
