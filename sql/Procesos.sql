USE [ICBA Cirugia 2003]
GO

/****** Object:  Table [cirugia].[Ciencia_Procesos]    Script Date: 12/04/2019 17:16:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cirugia].[Ciencia_Procesos](
	[ProcId] [int] IDENTITY(1,1) NOT NULL,
	[ModuloId] [int] NULL,
	[Proc_ini_F] [datetime] NULL,
	[Proc_fin_F] [datetime] NULL,
	[Proc_Maq_T] [varchar](100) NULL,
	[User_LogOn] [varchar](100) NULL,
 CONSTRAINT [PK_Ciencia_Procesos] PRIMARY KEY CLUSTERED 
(
	[ProcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


