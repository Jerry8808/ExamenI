CREATE PROCEDURE [dbo].[TituloEliminar]
	@Id_Titulo INT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION TRANSA1

	BEGIN TRY

		DELETE FROM Titulos
		WHERE Id_Titulo = @Id_Titulo

	COMMIT TRANSACTION TRANSA1

		SELECT 0 AS CodeError, '' AS MsgError

	END TRY

	BEGIN CATCH

		SELECT ERROR_NUMBER() AS CodeError, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRANSA1

	END CATCH

 END
