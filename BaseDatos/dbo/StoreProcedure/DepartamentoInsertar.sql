CREATE PROCEDURE [dbo].[DepartamentoInsertar]
	@Descripcion VARCHAR(250)
   ,@Ubicacion VARCHAR(250)
   ,@Estado BIT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION TRANSA3

	BEGIN TRY

	INSERT INTO Departamentos(Descripcion,Ubicacion, Estado)
	VALUES (@Descripcion, @Ubicacion, @Estado)

	COMMIT TRANSACTION TRANSA3

		SELECT 0 AS CodeError, '' AS MsgError

	END TRY

	BEGIN CATCH

		SELECT ERROR_NUMBER() AS CodeError, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRANSA3

	END CATCH

 END
