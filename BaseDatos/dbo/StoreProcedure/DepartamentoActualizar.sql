CREATE PROCEDURE [dbo].[DepartamentoActualizar]
	@Id_Departamento INT
   ,@Descripcion VARCHAR(250)
   ,@Ubicacion VARCHAR(250)
   ,@Estado BIT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION TRANSA3

	BEGIN TRY

	UPDATE Departamentos
	SET 
	    Descripcion = @Descripcion
       ,Ubicacion = @Ubicacion
       ,Estado = @Estado
	WHERE
		Id_Departamento = @Id_Departamento
		
	COMMIT TRANSACTION TRANSA3

		SELECT 0 AS CodeError, '' AS MsgError

	END TRY

	BEGIN CATCH

		SELECT ERROR_NUMBER() AS CodeError, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRANSA3

	END CATCH

END
