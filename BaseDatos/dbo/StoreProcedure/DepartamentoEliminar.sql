CREATE PROCEDURE [dbo].[DepartamentoEliminar]
	@Id_Departamento INT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION TRANSA3

	BEGIN TRY

		DELETE FROM Departamentos
		WHERE Id_Departamento = @Id_Departamento

	COMMIT TRANSACTION TRANSA3

		SELECT 0 AS CodeError, '' AS MsgError

	END TRY

	BEGIN CATCH

		SELECT ERROR_NUMBER() AS CodeError, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRANSA3

	END CATCH

 END
