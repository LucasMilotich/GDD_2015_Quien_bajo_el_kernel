CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getUltimosCincoDepositosByCuenta(@cuenta varchar(255))
AS 
BEGIN
select top 5 * from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].DEPOSITO  where cuenta_numero=@cuenta  order by fecha desc
END
GO