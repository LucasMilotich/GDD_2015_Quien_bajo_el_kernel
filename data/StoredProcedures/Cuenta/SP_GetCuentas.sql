CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetCuentas]
@an_pais		NUMERIC(18,0) = NULL,
@an_estado		NUMERIC(1,0) = NULL,
@an_moneda		NUMERIC(1,0) = NULL,
@an_tipo_cuenta	NUMERIC(1,0) = NULL,
@an_doc			NUMERIC(10,0) = NULL,
@an_tipo_doc	NUMERIC(18,0) = NULL
AS
BEGIN
	SELECT numero as Numero,
		   c.cliente_numero_doc as NroDocumento,
		   c.cliente_tipo_doc as TipoDocumento,
		   ec.descripcion as Estado,
		   p.descripcion_pais as Pais,
		   m.descripcion as Moneda,
		   tc.descripcion as Tipo,
		   c.saldo as Saldo,
		   c.fecha_creacion as FechaCreacion
	  FROM QUIEN_BAJO_EL_KERNEL.CUENTA c 
		left join QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA tc on c.tipo_cuenta=tc.codigo
		left join QUIEN_BAJO_EL_KERNEL.PAIS p on c.pais_codigo=p.codigo_pais
		left join QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA m on c.moneda_tipo=m.codigo
		left join QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA ec on c.estado_codigo=ec.codigo
	 WHERE (@an_pais is null or c.pais_codigo = @an_pais) 
	   AND (@an_estado is null or c.estado_codigo = @an_estado) 
	   AND (@an_moneda is null or c.moneda_tipo = @an_moneda) 
	   AND (@an_tipo_cuenta is null or c.tipo_cuenta = @an_tipo_cuenta)
	   AND (@an_doc is null or c.cliente_numero_doc = @an_doc)
	   AND (@an_tipo_doc is null or c.cliente_tipo_doc = @an_tipo_doc)
	   AND c.fecha_cierre IS NULL
		   
END
GO