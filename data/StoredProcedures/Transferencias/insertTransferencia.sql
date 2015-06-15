CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.insertTransferencia (@origen numeric(18,0), @destino numeric(18,0), @importe numeric(18,2), @costo numeric(18,2), @moneda_tipo numeric(1,0), @id_transaccion numeric(18,0))
AS 
BEGIN
insert into [QUIEN_BAJO_EL_KERNEL].TRANSFERENCIA (origen, destino,fecha ,importe, costo, moneda_tipo, id_transaccion) values 
(@origen, @destino, GETDATE(), @importe, @costo, @moneda_tipo, @id_transaccion)
END

