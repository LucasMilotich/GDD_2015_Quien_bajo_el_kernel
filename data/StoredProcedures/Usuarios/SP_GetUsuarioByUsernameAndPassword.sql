USE [GD1C2015]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[QUIEN_BAJO_EL_KERNEL].[GetUsuarioByUsernameAndPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetUsuarioByUsernameAndPassword]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetUsuarioByUsernameAndPassword]
@username nvarchar(255),
@password varbinary(max)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
		u.*
	FROM [QUIEN_BAJO_EL_KERNEL].Usuario u
	WHERE 
		u.username = @username AND
		u.password = @password AND
		u.activo = 1
END
GO