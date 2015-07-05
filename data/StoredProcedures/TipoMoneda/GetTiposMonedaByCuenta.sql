CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetTiposMonedaByCuenta (@cuenta varchar(255))
AS
BEGIN
	SELECT c2.codigo,c2.descripcion FROM QUIEN_BAJO_EL_KERNEL.CUENTA c1
	inner join QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA c2 on c1.moneda_tipo= c2.codigo
	where numero=@cuenta
END
GO