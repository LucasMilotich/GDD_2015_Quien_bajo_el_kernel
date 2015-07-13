CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.Insert_retiro(@fecha datetime , @importe numeric(18,2),
													 @cuenta numeric(18,0), @cheque numeric(18,0))
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.Retiro (fecha,importe,cuenta,cheque)
values
(@fecha,@importe,@cuenta,@cheque)
END
GO
