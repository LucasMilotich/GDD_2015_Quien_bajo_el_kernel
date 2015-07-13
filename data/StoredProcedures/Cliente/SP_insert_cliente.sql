
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_CLIENTE 
(
  @tipoDocCod numeric(18,0)
 ,@dni numeric(10,0)
 ,@paisCod numeric(18,0)
 ,@apellido  varchar(255)
 ,@nombre varchar(255)
 ,@dom_calle varchar(255)
 ,@dom_nro numeric(18,0)
 ,@dom_piso numeric(18,0)
 ,@dom_dpto varchar(255)
 ,@fechaNac datetime
 ,@mail varchar(255)
 ,@localidad varchar(255)
 ,@username varchar(255)
 )

AS 
BEGIN




insert into QUIEN_BAJO_EL_KERNEL.CLIENTE
(tipo_documento
 ,numero_documento
 ,pais_codigo
 ,nombre
 ,apellido
 ,dom_calle
 ,dom_nro
 ,dom_piso
 ,dom_dpto
 ,fecha_nacimiento
 ,mail
 ,localidad
 ,username)
 VALUES
 (@tipoDocCod
 ,@dni
 ,@paisCod
 ,@apellido
 ,@nombre
 ,@dom_calle
 ,@dom_nro
 ,@dom_piso
 ,@dom_dpto
 ,@fechaNac
 ,@mail
 ,@localidad
 ,@username)

select scope_identity()

END


