CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getClienteByUsername(@username varchar(255))
AS 
BEGIN
select * from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].CLIENTE  where username= @username 
END
GO
