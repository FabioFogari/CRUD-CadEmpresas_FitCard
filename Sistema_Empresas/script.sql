USE [master]
GO
/****** Object:  Database [CrudEmpresa]    Script Date: 08/08/2019 19:29:23 ******/
CREATE DATABASE [CrudEmpresa] ON  PRIMARY 
( NAME = N'CrudEmpresa', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\CrudEmpresa.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CrudEmpresa_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\CrudEmpresa_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CrudEmpresa] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrudEmpresa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CrudEmpresa] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CrudEmpresa] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CrudEmpresa] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CrudEmpresa] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CrudEmpresa] SET ARITHABORT OFF
GO
ALTER DATABASE [CrudEmpresa] SET AUTO_CLOSE ON
GO
ALTER DATABASE [CrudEmpresa] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [CrudEmpresa] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CrudEmpresa] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CrudEmpresa] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CrudEmpresa] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CrudEmpresa] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CrudEmpresa] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CrudEmpresa] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CrudEmpresa] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CrudEmpresa] SET  ENABLE_BROKER
GO
ALTER DATABASE [CrudEmpresa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CrudEmpresa] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CrudEmpresa] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CrudEmpresa] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CrudEmpresa] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CrudEmpresa] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CrudEmpresa] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CrudEmpresa] SET  READ_WRITE
GO
ALTER DATABASE [CrudEmpresa] SET RECOVERY SIMPLE
GO
ALTER DATABASE [CrudEmpresa] SET  MULTI_USER
GO
ALTER DATABASE [CrudEmpresa] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CrudEmpresa] SET DB_CHAINING OFF
GO
USE [CrudEmpresa]
GO
/****** Object:  Table [dbo].[ESTADO]    Script Date: 08/08/2019 19:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ESTADO](
	[ID_ESTADO] [int] IDENTITY(1,1) NOT NULL,
	[UF] [char](2) NULL,
	[NOME] [varchar](100) NULL,
 CONSTRAINT [PK_ID_ESTADO] PRIMARY KEY CLUSTERED 
(
	[ID_ESTADO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CrudEmpresa]    Script Date: 08/08/2019 19:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CrudEmpresa](
	[ID_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NULL,
	[RAZAO_SOCIAL] [varchar](100) NULL,
	[CNPJ] [varchar](20) NULL,
	[ENDERECO] [varchar](100) NULL,
	[CIDADE] [varchar](100) NULL,
	[UF] [char](2) NULL,
	[TELEFONE] [varchar](30) NULL,
	[EMAIL] [varchar](100) NULL,
	[CATEGORIA] [varchar](100) NULL,
	[STATUS] [varchar](100) NULL,
	[AGENCIA] [varchar](20) NULL,
	[CONTA] [varchar](20) NULL,
 CONSTRAINT [PK_ID_EMPRESA] PRIMARY KEY CLUSTERED 
(
	[ID_Empresa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CIDADE]    Script Date: 08/08/2019 19:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CIDADE](
	[ID_CIDADE] [int] IDENTITY(1,1) NOT NULL,
	[UF] [char](2) NULL,
	[NOME] [varchar](100) NULL,
 CONSTRAINT [PK_ID_CIDADE] PRIMARY KEY CLUSTERED 
(
	[ID_CIDADE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
