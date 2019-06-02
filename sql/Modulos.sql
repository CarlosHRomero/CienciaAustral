

/****** Object:  Table [cirugia].[Ciencia_Modulo]    Script Date: 12/04/2019 17:15:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cirugia].[Ciencia_Modulo](
	[ModuloId] [int] NOT NULL,
	[Nombre] [nvarchar](40) NULL,
	[TablaEquiv] [nvarchar](50) NULL,
	[TablasGeneradas] [int] NULL,
	[ClavePrimariaEvol] [nvarchar](50) NULL,
	[ClaveExternaEvol] [nvarchar](50) NULL,
	[TablaExternaEvol_Id] [int] NULL
) ON [PRIMARY]
GO


