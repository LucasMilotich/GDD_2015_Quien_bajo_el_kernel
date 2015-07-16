CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetCuentaByNumero]
@an_nro_cuenta	NUMERIC(18,0)
AS
BEGIN
	SELECT c.numero,
		   c.moneda_tipo,
		   c.pais_codigo,
		   c.tipo_cuenta,
		   c.cliente_numero_doc,
		   c.cliente_tipo_doc,
		   c.saldo
	  FROM QUIEN_BAJO_EL_KERNEL.CUENTA c
	 WHERE c.numero = @an_nro_cuenta
END
GO