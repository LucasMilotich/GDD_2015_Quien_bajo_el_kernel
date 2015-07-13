CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetTiposMonedaByCuenta (@numeroDoc numeric (18),@tipoDoc numeric(18))
AS
BEGIN
	SELECT codigo,costo, 'Transferencia' as tipoTransaccion
	FROM QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA t 
	inner join QUIEN_BAJO_EL_KERNEL.CUENTA c on t.origen = c.numero
	left join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_TRANSFERENCIAS i on t.codigo = i.transferencia
	where i.factura_numero is null --and c.cliente_numero_doc=@numeroDoc and c.cliente_tipo_doc=@tipoDoc
	
	select numero as codigo,'unCosto' as costo ,'Apertura cuenta' as tipoTransaccion
	FROM QUIEN_BAJO_EL_KERNEL.CUENTA c
	left join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_ACTIVACION_CUENTA i on c.numero = i.cuenta
	where i.factura_numero is null and estado_codigo=4 --and cliente_numero_doc=@numeroDoc and cliente_tipo_doc=@tipoDoc
		
	SELECT c.id_modificacion as codigo, 'unCosto' as costo, 'Modificacion cuenta ' as tipoTransaccion 
	FROM QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION c
	left join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_MODIFICACION_CUENTA i on c.cuenta = i.cuenta
	inner join QUIEN_BAJO_EL_KERNEL.CUENTA c2 on c2.numero = c.cuenta
	where i.factura_numero is null --and c2.cliente_numero_doc=@numeroDoc and c2.cliente_tipo_doc=@tipoDoc
	
END
GO