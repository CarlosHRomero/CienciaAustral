USE [ICBA Cirugia 2003]
GO

/****** Object:  Table [cirugia].[CienciaTablaEquiv]    Script Date: 12/04/2019 17:15:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cirugia].[CienciaTablaEquiv](
	[TablaId] [int] NOT NULL,
	[NombreTabla] [nvarchar](40) NULL,
	[Descripcion] [nvarchar](40) NULL,
	[EsEvolucion] [bit] NULL,
	[ModuloId] [int] NULL,
	[NombreTablaEquiv] [nvarchar](40) NULL,
	[EsTronco] [bit] NULL,
	[ClavePrimaria] [nvarchar](40) NULL,
	[ClavePrimariaEquiv] [nvarchar](40) NULL,
	[ClaveForanea] [nvarchar](40) NULL,
	[ClaveForaneaEvol] [nvarchar](40) NULL,
	[EsPaciente] [bit] NULL,
	[Orden] [int] NULL,
	[EsMultiple] [bit] NULL,
	[Procesar] [bit] NULL,
	[CampoFecha] [nvarchar](40) NULL,
 CONSTRAINT [PK_CienciaTablaEquiv] PRIMARY KEY CLUSTERED 
(
	[TablaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


