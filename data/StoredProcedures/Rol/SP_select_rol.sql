CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.SELECT_ROL 
(@nombre varchar(255) = null ,
@activo BIT  = null)
AS 
BEGIN
SELECT * FROM QUIEN_BAJO_EL_KERNEL.ROL f 
WHERE (@nombre is null or f.nombre like '%' + @nombre + '%') AND
	  (@activo is null or f.activo = @activo)
END