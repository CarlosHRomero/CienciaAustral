
/****** Object:  Table [cirugia].[CienciaEquiv]    Script Date: 12/04/2019 17:14:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cirugia].[CienciaEquiv](
	[EquivId] [int] IDENTITY(1,1) NOT NULL,
	[TablaId] [int] NULL,
	[CampoOriginal] [nvarchar](50) NULL,
	[CampoEquivalente] [nvarchar](50) NULL,
	[TipoDeDato] [nvarchar](50) NULL,
	[ValorPorDefecto] [nvarchar](50) NULL,
	[Solapa] [nvarchar](50) NULL,
	[Filtro] [nvarchar](50) NULL,
	[Orden] [int] NULL,
	[Seleccion] [bit] NULL,
	[Filtro_var] [nvarchar](50) NULL,
	[ValoresACeroStr] [nvarchar](255) NULL,
	[TipoDatoSqlServer] [nvarchar](50) NULL,
	[TipoDatoAccess] [nvarchar](50) NULL,
	[FechaEvento] [bit] NULL,
	[VerValor] [bit] NULL,
	[ValoresACero] [nvarchar](50) NULL,
 CONSTRAINT [PK_CienciaEquiv] PRIMARY KEY CLUSTERED 
(
	[EquivId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


