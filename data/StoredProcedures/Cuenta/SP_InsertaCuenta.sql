USE [GD1C2015]
GO
/****** Object:  StoredProcedure [QUIEN_BAJO_EL_KERNEL].[InsertaCuenta]    Script Date: 06/19/2015 01:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [QUIEN_BAJO_EL_KERNEL].[InsertaCuenta]
@an_num_cuenta			NUMERIC(18,0),
@an_cod_pais			NUMERIC(18,0),
@an_moneda_tipo			NUMERIC(1,0),
@an_cuenta_tipo			NUMERIC(1,0),
@an_cliente_doc			NUMERIC(10,0),
@an_cliente_tipo_doc	NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO QUIEN_BAJO_EL_KERNEL.CUENTA([numero],[pais_codigo],[moneda_tipo],[tipo_cuenta],[cliente_numero_doc],[cliente_tipo_doc],[fecha_creacion])
		 VALUES (@an_num_cuenta, @an_cod_pais, @an_moneda_tipo, @an_cuenta_tipo, @an_cliente_doc, @an_cliente_tipo_doc, GETDATE())

END
