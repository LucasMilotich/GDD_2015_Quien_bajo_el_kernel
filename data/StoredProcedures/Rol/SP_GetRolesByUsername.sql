USE [GD1C2015]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[QUIEN_BAJO_EL_KERNEL].[GetRolesByUsername]') AND type in (N'P', N'PC'))
DROP PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetRolesByUsername]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetRolesByUsername]
@username nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
		r.*
	FROM [QUIEN_BAJO_EL_KERNEL].Rol r
	INNER JOIN [QUIEN_BAJO_EL_KERNEL].USUARIO_ROL ur ON ur.id_rol = r.id
	WHERE
		ur.username = @username AND
		r.activo = 1
END
GO