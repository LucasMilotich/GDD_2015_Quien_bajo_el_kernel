CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[ModificaCuenta]
@an_nro_cuenta	NUMERIC(18,0),
@an_moneda_tipo NUMERIC(1,0),
@an_cuenta_tipo	NUMERIC(1,0),
@an_cod_pais	NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
       SET moneda_tipo = @an_moneda_tipo,
		   tipo_cuenta = @an_cuenta_tipo,
		   pais_codigo = @an_cod_pais
	 WHERE numero = @an_nro_cuenta
	 
END
GO