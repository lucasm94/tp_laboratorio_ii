USE [master]
GO

CREATE DATABASE [hincha-plus]
GO

USE [hincha-plus]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[hincha](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[dni] [int] NOT NULL,
	[nacimiento] [date] NOT NULL,
	[sexo] [nvarchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
	[id_club] [int] NOT NULL,
	[es_socio] [bit] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[hincha] ADD  CONSTRAINT [DF_hincha_activo]  DEFAULT ((1)) FOR [activo]
GO

CREATE TABLE [dbo].[club](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[club] ([nombre]) VALUES ('Boca Juniors') 
GO
INSERT INTO [dbo].[club] ([nombre]) VALUES ('River Plate') 
GO
INSERT INTO [dbo].[club] ([nombre]) VALUES ('Racing Club') 
GO
INSERT INTO [dbo].[club] ([nombre]) VALUES ('Independiente') 
GO
INSERT INTO [dbo].[club] ([nombre]) VALUES ('San Lorenzo') 
GO
INSERT INTO [dbo].[club] ([nombre]) VALUES ('Otros') 
GO
