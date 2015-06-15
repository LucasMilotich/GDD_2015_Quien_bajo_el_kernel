CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getUltimasDiezTransferenciasByCuenta(@cuenta varchar(255))
AS 
BEGIN
select top 10 *  from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].TRANSFERENCIA  where origen= 1111111111111111 or destino= 1111111111111111  order by fecha desc
END
GO
