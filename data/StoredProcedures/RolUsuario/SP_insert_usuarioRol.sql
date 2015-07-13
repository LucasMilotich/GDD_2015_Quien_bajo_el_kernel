
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_USUARIO 
(
@username varchar(255) = null
,@id_rol numeric(10,0) = null
)
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.USUARIO_ROL 
(username
,id_rol
)
VALUES
(@username
,@id_rol)



END


