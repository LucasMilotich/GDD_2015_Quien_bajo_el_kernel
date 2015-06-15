--  Clientes que alguna de sus cuentas fueron inhabilitadas por no pagar los costos de transacción
DROP PROCEDURE QUIEN_BAJO_EL_KERNEL.ClientesConCuentasInhabilitadas 
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.ClientesConCuentasInhabilitadas (@fechaDesde date, @fechaHasta date)
AS 
BEGIN

select cli.tipo_documento,cli.numero_documento,cta.numero, cta.estado_codigo 
from QUIEN_BAJO_EL_KERNEL.CLIENTE cli
inner join QUIEN_BAJO_EL_KERNEL.CUENTA cta on cta.cliente_tipo_doc=cli.tipo_documento and cta.cliente_numero_doc=cliente_numero_doc
inner join QUIEN_BAJO_EL_KERNEL.FACTURA fac on fac.cliente_tipo_doc =cli.tipo_documento and fac.cliente_numero_doc=cli.numero_documento
inner join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA itm on itm.factura_numero = fac.numero


select * from QUIEN_BAJO_EL_KERNEL.CUENTA
--where numero=1111111111111158
where estado_codigo=3

select c2.tipo_documento,c2.numero_documento,c2.apellido,c2.nombre,c1.numero as cuentaInhabilitada from QUIEN_BAJO_EL_KERNEL.CUENTA c1
inner join QUIEN_BAJO_EL_KERNEL.CLIENTE c2 on c1.cliente_tipo_doc=c2.tipo_documento and c1.cliente_numero_doc=c2.numero_documento 
where estado_codigo=3

select * from QUIEN_BAJO_EL_KERNEL.TRANSACCIONES
select * from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
select * from QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION

select * from QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA


END
GO
--------------------------------------------------------------------------------------------
--Cliente con mayor cantidad de comisiones facturadas en todas sus cuentas
DROP PROCEDURE QUIEN_BAJO_EL_KERNEL.ClientesComisionesFacturadas
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.ClientesComisionesFacturadas (@fechaDesde date, @fechaHasta date)
AS 
BEGIN

select top 5  c1.tipo_documento,c1.numero_documento,c1.apellido,c1.nombre, COUNT(c3.id_transaccion) as cantComisiones from QUIEN_BAJO_EL_KERNEL.CLIENTE c1
inner join QUIEN_BAJO_EL_KERNEL.FACTURA c2 on c2.cliente_tipo_doc=c1.tipo_documento and c2.cliente_numero_doc= c1.numero_documento 
inner join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA c3 on c2.numero = c3.factura_numero
--where c2.fecha >=@fechaDesde and c2.fecha<=@fechaHasta
group by  c1.tipo_documento,c1.numero_documento,c1.apellido,c1.nombre

END
GO


--------------------------------------------------------------------------------------------
-- Clientes con mayor cantidad de transacciones realizadas entre cuentas propias
--
-- transacciones: transferencias realizadas, apertura de cuenta o  modificación del tipo de cuenta.
-- tipos transferencias: 1=transferencia , 2=activacion, 3=modificacion

select * from QUIEN_BAJO_EL_KERNEL.TransaccionesClientes
drop view QUIEN_BAJO_EL_KERNEL.TransaccionesClientes

create view QUIEN_BAJO_EL_KERNEL.TransaccionesClientes as 

--modificacionDeCuenta
select c3.tipo_documento,c3.numero_documento,c3.apellido,c3.nombre,c2.fecha, COUNT(numero) cantTransacciones from QUIEN_BAJO_EL_KERNEL.CUENTA c1
inner join QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION c2 on c1.numero=c2.cuenta
inner join QUIEN_BAJO_EL_KERNEL.CLIENTE c3 on c3.tipo_documento =c1.cliente_tipo_doc and c3.numero_documento=c1.cliente_numero_doc
group by c3.tipo_documento,c3.numero_documento,c3.apellido,c3.nombre,c2.fecha


UNION ALL

-- apertura cuentas
select c3.tipo_documento,c3.numero_documento,c3.apellido,c3.nombre, c1.fecha_creacion,count (numero)as  cantTransacciones from QUIEN_BAJO_EL_KERNEL.CUENTA c1
inner join QUIEN_BAJO_EL_KERNEL.CLIENTE c3 on c3.tipo_documento =c1.cliente_tipo_doc and c3.numero_documento=c1.cliente_numero_doc
group by c3.tipo_documento,c3.numero_documento,c3.apellido,c3.nombre, c1.fecha_creacion

UNION ALL

-- transferencias entre cuentas propias
select t4.tipo_documento, t4.numero_documento, t4.apellido, t4.nombre, t1.fecha, COUNT(*) as cantTransacciones from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA t1
inner join QUIEN_BAJO_EL_KERNEL.CUENTA t2 on t2.numero = t1.origen
inner join QUIEN_BAJO_EL_KERNEL.CUENTA t3 on t3.numero = t1.destino
inner join QUIEN_BAJO_EL_KERNEL.CLIENTE t4 on t3.cliente_tipo_doc =t4.tipo_documento and t3.cliente_numero_doc=t4.numero_documento
where t3.cliente_tipo_doc = t2.cliente_tipo_doc and t3.cliente_numero_doc=t2.cliente_numero_doc
group by t4.tipo_documento, t4.numero_documento, t4.apellido, t4.nombre, t1.fecha

order by numero_documento



DROP PROCEDURE QUIEN_BAJO_EL_KERNEL.ClientesConMayorTransacciones 
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.ClientesConMayorTransacciones (@fechaDesde date, @fechaHasta date)
AS 
BEGIN
select tipo_documento,numero_documento,apellido,nombre, SUM(cantTransacciones) as cantTrancciones from  QUIEN_BAJO_EL_KERNEL.TransaccionesClientes
where fecha>=@fechaDesde and fecha <= @fechaHasta
group by tipo_documento,numero_documento,apellido,nombre
order by cantTrancciones

END


select cliente_numero_doc from QUIEN_BAJO_EL_KERNEL.CUENTA where numero=1111111111111346 or numero =1111111111111345

select cuenta,transaccion,fecha from QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION

insert into  QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION (cuenta,fecha,transaccion)values(1111111111111113,getdate(),442093)
insert into QUIEN_BAJO_EL_KERNEL.TRANSACCIONES (fecha,operacion_tipo) values (getdate(),3)

select top 5* from QUIEN_BAJO_EL_KERNEL.TRANSACCIONES order by fecha desc


--------------------------------------------------------------------------------------------
-- Paises con mayor cantidad movimientos ingresos egresos

select * from QUIEN_BAJO_EL_KERNEL.MovimientosPaises

drop view QUIEN_BAJO_EL_KERNEL.MovimientosPaises
GO

create view QUIEN_BAJO_EL_KERNEL.MovimientosPaises as 
select c2.pais_codigo,c1.fecha,COUNT(c2.numero) as cantMovimientos  from QUIEN_BAJO_EL_KERNEL.DEPOSITO  c1
inner join QUIEN_BAJO_EL_KERNEL.CUENTA c2 on c1.cuenta_numero=c2.numero
group by pais_codigo,c1.fecha
UNION ALL
select c2.pais_codigo,c1.fecha,COUNT(c2.numero) as cantMovimientos from QUIEN_BAJO_EL_KERNEL.RETIRO c1
inner join QUIEN_BAJO_EL_KERNEL.CUENTA c2 on c1.cuenta=c2.numero
group by pais_codigo,c1.fecha
UNION ALL
select c2.pais_codigo,c1.fecha,count(c2.numero) as cantMovimientos from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA c1
inner join QUIEN_BAJO_EL_KERNEL.CUENTA c2 on c1.origen=c2.numero
where c1.origen<>c1.destino
group by pais_codigo,c1.fecha
UNION ALL
select c2.pais_codigo,c1.fecha,count(c2.numero) as cantMovimientos from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA c1
inner join QUIEN_BAJO_EL_KERNEL.CUENTA c2 on c1.destino=c2.numero
where c1.origen<>c1.destino
group by pais_codigo,c1.fecha
UNION ALL
select c2.pais_codigo,c1.fecha,count(c2.numero) as cantMovimientos from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA c1
inner join QUIEN_BAJO_EL_KERNEL.CUENTA c2 on c1.destino=c2.numero
where c1.origen=c1.destino
group by pais_codigo,c1.fecha
GO

DROP PROCEDURE QUIEN_BAJO_EL_KERNEL.PaisesConMayorIngresosEgresos 
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.PaisesConMayorIngresosEgresos (@fechaDesde date, @fechaHasta date)
AS 
BEGIN
select top 5 pais_codigo, SUM(cantMovimientos) as cantMovimientos from QUIEN_BAJO_EL_KERNEL.MovimientosPaises
where fecha>=@fechaDesde and fecha <= @fechaHasta
group by pais_codigo
order by cantMovimientos desc

END

--------------------------------------------------------------------------------------------
-- Total facturado para los distintos tipos de cuentas.
DROP PROCEDURE QUIEN_BAJO_EL_KERNEL.TotalFacturadoPorCuentas
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.TotalFacturadoPorCuentas(@fechaDesde date, @fechaHasta date)
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA (codigo,descripcion,duracion,costo)
select * from QUIEN_BAJO_EL_KERNEL.CUENTA
select * from QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA
select * from QUIEN_BAJO_EL_KERNEL.FACTURA
select * from QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA
select * from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA


END
GO

