CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getUltimasDiezTransferenciasByCuenta(@cuenta varchar(255))
AS 
BEGIN
select top 10 *  from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].TRANSFERENCIA  where origen= @cuenta or destino= @cuenta  order by fecha desc
END
GO
