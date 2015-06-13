CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.SELECT_FUNCIONALIDAD (@id numeric(10,0) = null , @descripcion varchar(255) = null)
AS 
BEGIN


SELECT * FROM QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD f 
WHERE (@descripcion is null or f.descripcion like '%' + @descripcion + '%') AND
	  (@id is null or f.id_funcionalidad = @id)


END