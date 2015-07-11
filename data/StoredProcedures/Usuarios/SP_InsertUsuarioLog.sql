SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[InsertUsuarioLog]
@username nvarchar(255),
@login_correcto bit
AS
BEGIN
	SET NOCOUNT ON;
	
	IF (EXISTS (SELECT * FROM [QUIEN_BAJO_EL_KERNEL].USUARIO WHERE username = @username))
	BEGIN
		INSERT INTO [QUIEN_BAJO_EL_KERNEL].USUARIO_LOG
		(
			username,
			fecha,
			login_correcto
		)
		VALUES
		(
			@username,
			GETDATE(),
			@login_correcto
		)
		
		IF ((SELECT COUNT(*) FROM [QUIEN_BAJO_EL_KERNEL].USUARIO_LOG WHERE username = @username AND login_correcto = 0) >= 3 AND @login_correcto = 0)
		BEGIN
			UPDATE [QUIEN_BAJO_EL_KERNEL].USUARIO SET habilitado = 0 WHERE username = @username
		END
	END
END
GO