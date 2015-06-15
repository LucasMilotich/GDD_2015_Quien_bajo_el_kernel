CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_ROL_FUNCIONALIDAD (@id_rol numeric(10,0), @id_funcionalidad numeric(10,0))
AS 
BEGIN
insert into QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD_ROL (id_rol,id_funcionalidad) values (@id_rol,@id_funcionalidad)
END