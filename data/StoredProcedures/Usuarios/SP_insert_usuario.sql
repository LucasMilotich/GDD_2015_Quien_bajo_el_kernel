
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_USUARIO 
(
@username varchar(255) = null
,@password varbinary(max) =  null
,@pregunta_secreta varchar(255) = null 
,@respuesta_secreta varchar(255) = null 
,@activo bit = null
,@habilitado bit = null
)
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.USUARIO 
(username
,password
,pregunta_secreta
,respuesta_secreta
,activo
,habilitado)
VALUES
(@username
,@password
,@pregunta_secreta
,@respuesta_secreta
,@activo
,@habilitado)



END


