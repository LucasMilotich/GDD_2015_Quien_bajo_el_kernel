insert into QUIEN_BAJO_EL_KERNEL.TIPO_DOCUMENTO (codigo,descripcion)
			 (select distinct cli_tipo_doc_cod,cli_tipo_doc_desc
					from gd_esquema.Maestra
					
			 )

insert into QUIEN_BAJO_EL_KERNEL.PAIS (codigo_pais, descripcion_pais)
		   (select distinct Cli_Pais_Codigo,Cli_Pais_Desc from gd_esquema.Maestra
			UNION
			select  distinct cuenta_pais_codigo,cuenta_pais_desc
			from gd_esquema.Maestra
		  		 )
				 

insert into QUIEN_BAJO_EL_KERNEL.CLIENTE (tipo_documento,numero_documento,
					 pais_codigo,nombre,apellido,dom_calle,
					 dom_nro,dom_piso,dom_dpto,fecha_nacimiento,
					 mail)
			       (select distinct  cli_tipo_doc_cod,cli_nro_doc,cli_pais_codigo,
						   cli_nombre,cli_apellido,cli_dom_calle,
						   cli_dom_nro,cli_dom_piso,cli_dom_depto,
						   cli_fecha_nac,cli_mail
					from gd_esquema.Maestra
						   		
				   )
				   

insert into QUIEN_BAJO_EL_KERNEL.CUENTA (numero,fecha_creacion,pais_codigo,fecha_cierre,
				   cliente_tipo_doc,cliente_numero_doc)
			 (select distinct cuenta_numero,cuenta_fecha_creacion,
									cuenta_pais_codigo,cuenta_fecha_cierre,cli_tipo_doc_cod,
									cli_nro_doc
					from gd_esquema.Maestra
					)
insert into QUIEN_BAJO_EL_KERNEL.TARJETA (tarjeta_numero, fecha_emision,fecha_vencimiento,
					 codigo_seguridad, emisor_descripcion)
			  (select distinct tarjeta_numero, tarjeta_fecha_emision,tarjeta_fecha_vencimiento,
					 tarjeta_codigo_seg, tarjeta_emisor_descripcion
					 from gd_esquema.Maestra
					 where Tarjeta_Numero is not null)
					 
insert into QUIEN_BAJO_EL_KERNEL.DEPOSITO (deposito_codigo,fecha, importe, cuenta_numero, tarjeta_numero)
				 (select (deposito_codigo,deposito_fecha, deposito_importe, 
							  cuenta_numero, tarjeta_numero)
					  from gd_esquema.Maestra
					  where deposito_codigo is not null)



insert into QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA (origen,destino,fecha,importe, costo)
				    (select cuenta_numero,cuenta_dest_numero,
						   transf_fecha,trans_importe,trans_costo_trans
						   from gd_esquema.Maestra
						   where transf_fecha is not null)
						   

insert into QUIEN_BAJO_EL_KERNEL.BANCO  (codigo,nombre,direccion)
			 (select distinct(banco_cogido,banco_nombre,banco_direccion)
					from gd_esquema.Maestra
					where banco_cogido is not null
					)
					
					

insert into QUIEN_BAJO_EL_KERNEL.CHEQUE (numero,fecha,importe,codigo_banco)		
			 (select cheque_numero,cheque_fecha,cheque_importe,banco_cogido
					from gd_esquema.Maestra
					where cheque_numero is not null)

insert into QUIEN_BAJO_EL_KERNEL.RETIRO (fecha,codigo,importe,cuenta,cheque)
			 (select retiro_fecha, retiro_codigo,retiro_importe,cuenta_numero,cheque_numero
					from gd_esquema.Maestra
					where retiro_codigo is not null)






