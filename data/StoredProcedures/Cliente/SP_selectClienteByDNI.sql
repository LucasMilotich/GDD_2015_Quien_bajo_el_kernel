
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.SELECT_CLIENTE_BY_DNI 
(
@documento numeric(10,0) = null
,@tipoDocumento numeric(18,0) = null
)
AS 
BEGIN

SELECT *
FROM QUIEN_BAJO_EL_KERNEL.CLIENTE c
WHERE 
c.tipo_documento = @tipoDocumento
and c.numero_documeto = @documento




END


