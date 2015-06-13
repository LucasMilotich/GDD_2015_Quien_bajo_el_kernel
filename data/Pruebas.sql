-- Control de saldo

select SUM(importe) from QUIEN_BAJO_EL_KERNEL.DEPOSITO
where cuenta_numero=1111111111111111

select SUM(importe) from QUIEN_BAJO_EL_KERNEL.retiro
where cuenta=1111111111111111

select SUM(importe) from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
where ORIGEN=1111111111111111

select SUM(importe) from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
where destino=1111111111111111


--	+63645.55
--	-55.93
--	-650.08
--	+637.18

select saldo from QUIEN_BAJO_EL_KERNEL.CUENTA where numero=1111111111111111
--	total: 63576.72



-- Simulacion de una transferencia
select numero,saldo from QUIEN_BAJO_EL_KERNEL.CUENTA where numero=1111111111111111
select numero,saldo from QUIEN_BAJO_EL_KERNEL.CUENTA where numero=1111111111111112

insert into QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA (origen,destino,importe,fecha) values (1111111111111111,1111111111111112,100,GETDATE())

select numero,saldo from QUIEN_BAJO_EL_KERNEL.CUENTA where numero=1111111111111111
select numero,saldo from QUIEN_BAJO_EL_KERNEL.CUENTA where numero=1111111111111112


select * from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA order by codigo desc
select top 1* from QUIEN_BAJO_EL_KERNEL.TRANSACCIONES order by id_transaccion desc

--
