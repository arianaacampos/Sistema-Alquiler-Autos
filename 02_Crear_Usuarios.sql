IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DB_AlquilerAutos')
CREATE DATABASE [DB_AlquilerAutos]
GO

USE [DB_AlquilerAutos]
GO

-- crear usuario
CREATE TABLE [dbo].[Usuarios](
    [ID_Usuario] [int] IDENTITY(1,1) PRIMARY KEY,
    [NombreUsuario] [varchar](50) UNIQUE NOT NULL,
    [Clave] [varchar](255) NOT NULL,
    [IntentosFallidos] [int] DEFAULT 0,
    [Bloqueado] [bit] DEFAULT 0,
    [DNI] [varchar](50) NULL,
    [Apellido] [varchar](100) NULL,
    [Nombre] [varchar](100) NULL,
    [Rol] [varchar](50) NULL,
    [Email] [varchar](100) NULL,
    [Activo] [bit] DEFAULT 1
)
GO

-- crear bitacora
CREATE TABLE [dbo].[Bitacora](
    [ID_Bitacora] [int] IDENTITY(1,1) PRIMARY KEY,
    [FechaHora] [datetime] NULL,
    [Usuario] [varchar](50) NULL,
    [Modulo] [varchar](50) NULL,
    [Evento] [varchar](255) NULL,
    [Criticidad] [varchar](20) NULL
)
GO