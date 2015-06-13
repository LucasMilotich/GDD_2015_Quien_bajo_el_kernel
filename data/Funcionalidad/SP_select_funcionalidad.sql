CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.SELECT_FUNCIONALIDAD (@id numeric(10,0), @descripcion varchar(255))
AS 
BEGIN

IF(@id is not null)
SELECT * FROM QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD f WHERE f.id_funcionalidad = @id 

IF(@descripcion is not null)
SELECT * FROM QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD f WHERE f.descripcion like '%' + @descripcion + '%'

IF(@id is null AND @descripcion is  null) 
SELECT * FROM QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD

END