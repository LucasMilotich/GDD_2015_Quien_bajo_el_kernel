CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_USUARIO 
(
@username varchar(255)
,@password varbinary(max)
,@pregunta_secreta varchar(255)
,@respuesta_secreta varchar(255)
,@activo bit
)
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.USUARIO 
(username
,password
,pregunta_secreta
,respuesta_secreta
,activo)
VALUES
(@username
,@password
,@pregunta_secreta
,@respuesta_secreta
,@activo)

select scope_identity()

END



