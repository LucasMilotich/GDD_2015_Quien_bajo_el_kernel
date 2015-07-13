CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.Insert_cheque(@numero numeric(18), @fecha datetime , @importe numeric(18,2),
													 @codigo_banco numeric(18,0), @moneda_tipo numeric(1,0), 
													 @nombre_destinatario varchar(255))
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.CHEQUE (numero,fecha,importe,codigo_banco,moneda_tipo,nombre_destinatario)
values
(@numero,@fecha,@importe,@codigo_banco,@moneda_tipo,@nombre_destinatario)
END
GO
