CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getUltimosCincoRetirosByCuenta(@cuenta varchar(255))
AS 
BEGIN
select top 5 * from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].RETIRO  where cuenta= @cuenta order by fecha desc
END
GO
