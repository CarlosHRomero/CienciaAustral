USE [ICBA Cirugia 2003]  
GO  
alter PROCEDURE [cirugia].[sp_procesoCiencia]
    @idModulo int  
AS   
	--Nombre de las tablas destino donde se guardaron las tablas traducidas en un proceso anterior, exceptuando las que son evolución o seguimiento
    DECLARE @NombreTablaDestino AS nvarchar(100)
    SELECT @NombreTablaDestino = [NombreTablaEquiv] FROM [cirugia].[CienciaTablaEquiv]
	where [ModuloId] = @idModulo and [estronco] = 1 and [EsEvolucion] = 0
	PRINT @NombreTablaDestino
   
    DECLARE @tablaId AS int
    DECLARE @CampoEquivalente AS nvarchar(100) 
    DECLARE @TipoDatoSqlServer AS nvarchar(100)  
	DECLARE tablaId CURSOR FOR SELECT [tablaid] FROM [cirugia].[CienciaTablaEquiv]
	where [ModuloId] = @idModulo and [EsEvolucion] = 0
	OPEN tablaId
    FETCH NEXT FROM tablaId INTO @tablaId
	WHILE @@fetch_status = 0
    BEGIN
		 PRINT @tablaId
		 DECLARE camposTablaDestino CURSOR FOR SELECT  [CampoEquivalente], [TipoDatoSqlServer] FROM [cirugia].[CienciaEquiv]
	     where [tablaid] = @tablaId
	     OPEN camposTablaDestino
		 FETCH NEXT FROM camposTablaDestino  INTO @CampoEquivalente, @TipoDatoSqlServer
		 WHILE @@fetch_status = 0
		 BEGIN
		 END
	END
	CLOSE tablaId
	DEALLOCATE tablaId
GO  