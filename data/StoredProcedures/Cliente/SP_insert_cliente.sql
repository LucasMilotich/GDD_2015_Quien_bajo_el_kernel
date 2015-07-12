CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_CLIENTE 
(@nombre varchar(255)
,@apellido varchar(255)
,@mail varchar(255)
,@paisDesc varchar(255)
,@calle varchar(255)
,@piso varchar(255)
,@dpto varchar(255)
,@localidad (255)
,@nacionalidad (255)
,@fechaNac datetime
,@tipoDocDesc varchar(255)
,@dni numeric(10,0)
,@username varchar(255)
)
AS 
BEGIN

declare @tipoDocCod numeric(10,0)
declare @paisCod numeric(18,0)


select @tipoDocCod = codigo from QUIEN_BAJO_EL_KERNEL.TIPO_DOCUMENTO 
where descripcion like @tipoDocDesc

select @paisCod = codigo_pais FROM QUIEN_BAJO_EL_KERNEL.PAIS 
where descripcion_pais like @paisDesc


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