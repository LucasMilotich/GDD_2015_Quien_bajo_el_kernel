-----	 ****************************** CREATE SCHEMA ****************************** -----

CREATE SCHEMA QUIEN_BAJO_EL_KERNEL AUTHORIZATION dbo
GO

-----	 ****************************** CREATE TABLES ****************************** -----

CREATE TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA ( 
	numero_item numeric(18)  NOT NULL,
	descripcion varchar(255) NULL,
	importe numeric(18,2) NULL,
	factura_numero numeric(18) NULL,
	id_transaccion numeric(18) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.FACTURA ( 
	numero numeric(18)  NOT NULL,
	fecha datetime NULL,
	cliente_numero_doc numeric(10) NULL,
	cliente_tipo_doc numeric(18) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION ( 
	cuenta numeric(18) NOT NULL,
	transaccion numeric(18) NOT NULL,
	fecha datetime NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD_ROL ( 
	id_rol numeric(10) NOT NULL,
	id_funcionalidad numeric(10) NOT NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.USUARIO_ROL ( 
	id_rol numeric(10) NOT NULL,
	username varchar(255) NOT NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.ROL ( 
	id numeric(10) identity(1,1) NOT NULL,
	nombre varchar(255) NULL,
	activo bit NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.USUARIO ( 
	username varchar(255) NOT NULL,
	password varbinary(max) NULL,
	pregunta_secreta varchar(255) NULL,
	respuesta_secreta varchar(255) NULL,
	activo bit NOT NULL default (1)
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA ( 
	codigo numeric(1) NOT NULL,
	descripcion varchar(255) NULL,
	duracion numeric(10) NULL,
	costo numeric(18,2) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA ( 
	codigo numeric(1) NOT NULL,
	descripcion varchar(255) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION ( 
	codigo numeric(10) NOT NULL,
	descripcion varchar(255) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TRANSACCIONES ( 
	id_transaccion numeric(18) identity(1,1)  NOT NULL,
	operacion_tipo numeric(10) NOT NULL,
	fecha datetime NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA ( 
	codigo numeric(1) NOT NULL,
	descripcion varchar(250) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TIPO_DOCUMENTO ( 
	codigo numeric(18) NOT NULL,
	descripcion varchar(255) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.PAIS ( 
	codigo_pais numeric(18) NOT NULL,
	descripcion_pais varchar(250) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.BANCO ( 
	codigo numeric(18) NOT NULL,
	nombre varchar(255) NULL,
	direccion varchar(255) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.CHEQUE ( 
	numero numeric(18)  NOT NULL,
	fecha datetime NULL,
	importe numeric(18,2) NULL,
	codigo_banco numeric(18) NULL,
	moneda_tipo numeric(1) NULL,
	nombre_destinatario varchar(255) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.RETIRO ( 
	codigo numeric(18)  NOT NULL,
	fecha datetime NULL,
	importe numeric(18,2) NULL,
	cuenta numeric(18) NULL,
	cheque numeric(18) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA ( 
	codigo numeric(18) identity(1,1) NOT NULL,
	origen numeric(18) NULL,
	destino numeric(18) NULL,
	fecha datetime NULL,
	importe numeric(18,2) NULL,
	costo numeric(18,2) NULL,
	moneda_tipo numeric(1) NULL,
	id_transaccion numeric(18) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TARJETA ( 
	tarjeta_numero varchar(16) NOT NULL,
	fecha_emision datetime NULL,
	fecha_vencimiento datetime NULL,
	codigo_seguridad varchar(3) NULL,
	emisor_descripcion varchar(255) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.DEPOSITO ( 
	deposito_codigo numeric(18)  NOT NULL,
	fecha datetime NULL,
	importe numeric(18,2) NULL,
	cuenta_numero numeric(18) NULL,
	moneda_tipo numeric(1) NULL,
	tarjeta_numero varchar(16) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.CLIENTE ( 
	tipo_documento numeric(18) NOT NULL,
	numero_documento numeric(10) NOT NULL,
	pais_codigo numeric(18) NULL,
	nombre varchar(255) NULL,
	apellido varchar(255) NULL,
	dom_calle varchar(255) NULL,
	dom_nro numeric(18) NULL,
	dom_piso numeric(18) NULL,
	dom_dpto varchar(10) NULL,
	fecha_nacimiento datetime NULL,
	mail varchar(255) NULL,
	localidad varchar(255) NULL,
	username varchar(255) NOT NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.CUENTA ( 
	numero numeric(18)  NOT NULL,
	fecha_creacion datetime NOT NULL,
	estado_codigo numeric(1) NULL,
	pais_codigo numeric(18) NULL,
	fecha_cierre datetime NULL,
	cliente_tipo_doc numeric(18) NULL,
	cliente_numero_doc numeric(10) NULL,
	moneda_tipo numeric(1) NULL,
	tipo_cuenta numeric(1) NULL,
	id_transaccion numeric(18) NULL,
	saldo numeric(18,2) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (
	id_funcionalidad numeric(10) NOT NULL,
	descripcion varchar(255) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.USUARIO_LOG(
	id int IDENTITY(1,1) NOT NULL ,
	username varchar(255) NULL,
	fecha datetime NULL,
	login_correcto bit NULL
)
GO
-----	 ****************************** PRIMARY KEYS ****************************** -----

ALTER TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD ADD CONSTRAINT PK_FUNCIONALIDAD 
	PRIMARY KEY CLUSTERED (id_funcionalidad)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA ADD CONSTRAINT PK_ITEM_FACTURA 
	PRIMARY KEY CLUSTERED (numero_item)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.FACTURA ADD CONSTRAINT PK_FACTURA 
	PRIMARY KEY CLUSTERED (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION ADD CONSTRAINT PK_CUENTA_MODIFICACION 
	PRIMARY KEY CLUSTERED (cuenta, transaccion)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD_ROL ADD CONSTRAINT PK_FUNCIONALIDAD_ROL 
	PRIMARY KEY CLUSTERED (id_rol, id_funcionalidad)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.USUARIO_ROL ADD CONSTRAINT PK_USUARIO_ROL 
	PRIMARY KEY CLUSTERED (id_rol, username)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.ROL ADD CONSTRAINT PK_ROL 
	PRIMARY KEY CLUSTERED (id)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.USUARIO ADD CONSTRAINT PK_USUARIO 
	PRIMARY KEY CLUSTERED (username)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA ADD CONSTRAINT PK_TIPO_CUENTA 
	PRIMARY KEY CLUSTERED (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA ADD CONSTRAINT PK_TIPO_ESTADO_CUENTA 
	PRIMARY KEY CLUSTERED (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION ADD CONSTRAINT PK_TIPO_TRANSACCION 
	PRIMARY KEY CLUSTERED (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TRANSACCIONES ADD CONSTRAINT PK_TRANSACCIONES 
	PRIMARY KEY CLUSTERED (id_transaccion)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA ADD CONSTRAINT PK_TIPO_MONEDA 
	PRIMARY KEY CLUSTERED (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TIPO_DOCUMENTO ADD CONSTRAINT PK_TIPO_DOCUMENTO 
	PRIMARY KEY CLUSTERED (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.PAIS ADD CONSTRAINT PK_PAIS 
	PRIMARY KEY CLUSTERED (codigo_pais)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.BANCO ADD CONSTRAINT PK_BANCO 
	PRIMARY KEY CLUSTERED (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CHEQUE ADD CONSTRAINT PK_CHEQUE 
	PRIMARY KEY CLUSTERED (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.RETIRO ADD CONSTRAINT PK_RETIRO 
	PRIMARY KEY CLUSTERED (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA ADD CONSTRAINT PK_TRANSFERENCIA 
	PRIMARY KEY CLUSTERED (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TARJETA ADD CONSTRAINT PK_TARJETA 
	PRIMARY KEY CLUSTERED (tarjeta_numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.DEPOSITO ADD CONSTRAINT PK_DEPOSITO 
	PRIMARY KEY CLUSTERED (deposito_codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CLIENTE ADD CONSTRAINT PK_CLIENTE 
	PRIMARY KEY CLUSTERED (tipo_documento, numero_documento)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA ADD CONSTRAINT PK_CUENTA 
	PRIMARY KEY CLUSTERED (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.USUARIO_LOG ADD CONSTRAINT PK_ID
	PRIMARY KEY CLUSTERED (id)
GO


-----	 ****************************** FOREIGN KEYS ****************************** -----


ALTER TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD_ROL ADD CONSTRAINT FK_FUNCIONALIDADROL_FUNCIONALIDAD 
	FOREIGN KEY (id_funcionalidad) REFERENCES QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (id_funcionalidad)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA ADD CONSTRAINT FK_ITEM_FACTURA_FACTURA 
	FOREIGN KEY (factura_numero) REFERENCES QUIEN_BAJO_EL_KERNEL.FACTURA (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA ADD CONSTRAINT FK_ITEM_FACTURA_TRANSACCIONES 
	FOREIGN KEY (id_transaccion) REFERENCES QUIEN_BAJO_EL_KERNEL.TRANSACCIONES (id_transaccion)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.FACTURA ADD CONSTRAINT FK_FACTURA_CLIENTE 
	FOREIGN KEY (cliente_tipo_doc,cliente_numero_doc) REFERENCES QUIEN_BAJO_EL_KERNEL.CLIENTE (tipo_documento,numero_documento)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION ADD CONSTRAINT FK_CUENTA_MODIFICACION_CUENTA 
	FOREIGN KEY (cuenta) REFERENCES QUIEN_BAJO_EL_KERNEL.CUENTA (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION ADD CONSTRAINT FK_CUENTA_MODIFICACION_TRANSACCIONES 
	FOREIGN KEY (transaccion) REFERENCES QUIEN_BAJO_EL_KERNEL.TRANSACCIONES (id_transaccion)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD_ROL ADD CONSTRAINT FK_FUNCIONALIDAD_ROL_ROL 
	FOREIGN KEY (id_rol) REFERENCES QUIEN_BAJO_EL_KERNEL.ROL (id)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.USUARIO_ROL ADD CONSTRAINT FK_USUARIO_ROL_ROL 
	FOREIGN KEY (id_rol) REFERENCES QUIEN_BAJO_EL_KERNEL.ROL (id)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.USUARIO_ROL ADD CONSTRAINT FK_USUARIO_ROL_USUARIO 
	FOREIGN KEY (username) REFERENCES QUIEN_BAJO_EL_KERNEL.USUARIO (username)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TRANSACCIONES ADD CONSTRAINT FK_TRANSACCIONES_TIPO_TRANSACCION 
	FOREIGN KEY (operacion_tipo) REFERENCES QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CHEQUE ADD CONSTRAINT FK_CHEQUE_BANCO 
	FOREIGN KEY (codigo_banco) REFERENCES QUIEN_BAJO_EL_KERNEL.BANCO (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CHEQUE ADD CONSTRAINT FK_CHEQUE_TIPO_MONEDA 
	FOREIGN KEY (moneda_tipo) REFERENCES QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.RETIRO ADD CONSTRAINT FK_RETIRO_CHEQUE 
	FOREIGN KEY (cheque) REFERENCES QUIEN_BAJO_EL_KERNEL.CHEQUE (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.RETIRO ADD CONSTRAINT FK_RETIRO_CUENTA 
	FOREIGN KEY (cuenta) REFERENCES QUIEN_BAJO_EL_KERNEL.CUENTA (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA ADD CONSTRAINT FK_TRANSFERENCIA_CUENTA 
	FOREIGN KEY (origen) REFERENCES QUIEN_BAJO_EL_KERNEL.CUENTA (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA ADD CONSTRAINT FK_TRANSFERENCIA_CUENTA_DESTINO 
	FOREIGN KEY (destino) REFERENCES QUIEN_BAJO_EL_KERNEL.CUENTA (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA ADD CONSTRAINT FK_TRANSFERENCIA_TIPO_MONEDA 
	FOREIGN KEY (moneda_tipo) REFERENCES QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA ADD CONSTRAINT FK_TRANSFERENCIA_TRANSACCIONES 
	FOREIGN KEY (id_transaccion) REFERENCES QUIEN_BAJO_EL_KERNEL.TRANSACCIONES (id_transaccion)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.DEPOSITO ADD CONSTRAINT FK_DEPOSITO_CUENTA 
	FOREIGN KEY (cuenta_numero) REFERENCES QUIEN_BAJO_EL_KERNEL.CUENTA (numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.DEPOSITO ADD CONSTRAINT FK_DEPOSITO_TARJETA 
	FOREIGN KEY (tarjeta_numero) REFERENCES QUIEN_BAJO_EL_KERNEL.TARJETA (tarjeta_numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.DEPOSITO ADD CONSTRAINT FK_DEPOSITO_TIPO_MONEDA 
	FOREIGN KEY (moneda_tipo) REFERENCES QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CLIENTE ADD CONSTRAINT FK_CLIENTE_PAIS 
	FOREIGN KEY (pais_codigo) REFERENCES QUIEN_BAJO_EL_KERNEL.PAIS (codigo_pais)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CLIENTE ADD CONSTRAINT FK_CLIENTE_TIPO_DOCUMENTO 
	FOREIGN KEY (tipo_documento) REFERENCES QUIEN_BAJO_EL_KERNEL.TIPO_DOCUMENTO (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA ADD CONSTRAINT FK_CUENTA_CLIENTE 
	FOREIGN KEY (cliente_tipo_doc, cliente_numero_doc) REFERENCES QUIEN_BAJO_EL_KERNEL.CLIENTE (tipo_documento, numero_documento)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA ADD CONSTRAINT FK_CUENTA_PAIS 
	FOREIGN KEY (pais_codigo) REFERENCES QUIEN_BAJO_EL_KERNEL.PAIS (codigo_pais)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA ADD CONSTRAINT FK_CUENTA_TIPO_CUENTA 
	FOREIGN KEY (tipo_cuenta) REFERENCES QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA ADD CONSTRAINT FK_CUENTA_TIPO_ESTADO_CUENTA 
	FOREIGN KEY (estado_codigo) REFERENCES QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA (codigo)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA ADD CONSTRAINT FK_CUENTA_TRANSACCIONES 
	FOREIGN KEY (id_transaccion) REFERENCES QUIEN_BAJO_EL_KERNEL.TRANSACCIONES (id_transaccion)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CLIENTE ADD CONSTRAINT FK_CLIENTE_USUARIO 
	FOREIGN KEY (username) REFERENCES QUIEN_BAJO_EL_KERNEL.USUARIO (username)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.USUARIO_LOG ADD CONSTRAINT FK_USUARIO_LOG_USUARIO 
	FOREIGN KEY (username) REFERENCES QUIEN_BAJO_EL_KERNEL.USUARIO (username)
GO

-----	 ****************************** TRIGGERS necesarios pre-migracion ****************************** -----

CREATE TRIGGER QUIEN_BAJO_EL_KERNEL.DepositoActualizarSaldo
ON QUIEN_BAJO_EL_KERNEL.DEPOSITO
AFTER INSERT
AS
BEGIN
  DECLARE @montoImporte numeric(18, 2),
          @cuentaNumero numeric(18)

  IF ((SELECT
      COUNT(*)
    FROM inserted)
    > 1)
  BEGIN
    DECLARE unCursor CURSOR FOR
    SELECT
      importe,
      cuenta_numero
    FROM inserted

    OPEN unCursor
    FETCH NEXT FROM unCursor INTO @montoImporte, @cuentaNumero
    WHILE @@FETCH_STATUS = 0
    BEGIN
      UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
      SET Saldo = Saldo + @montoImporte
      WHERE numero = @cuentaNumero
      FETCH NEXT FROM unCursor INTO @montoImporte, @cuentaNumero
    END
    CLOSE unCursor
    DEALLOCATE unCursor
  END
  ELSE
  BEGIN
    SELECT
      @montoImporte = importe,
      @cuentaNumero = cuenta_numero
    FROM inserted
    UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
    SET Saldo = Saldo + @montoImporte
    WHERE numero = @cuentaNumero
  END
END
GO

CREATE TRIGGER QUIEN_BAJO_EL_KERNEL.RetiroActualizarSaldo
ON QUIEN_BAJO_EL_KERNEL.RETIRO
AFTER INSERT
AS
BEGIN
  DECLARE @montoImporte numeric(18, 2),
          @cuentaNumero numeric(18)
  IF ((SELECT
      COUNT(*)
    FROM inserted)
    > 1)
  BEGIN

    DECLARE unCursor CURSOR FOR
    SELECT
      importe,
      cuenta
    FROM inserted

    OPEN unCursor
    FETCH NEXT FROM unCursor INTO @montoImporte, @cuentaNumero
    WHILE @@FETCH_STATUS = 0
    BEGIN
      UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
      SET Saldo = Saldo - @montoImporte
      WHERE numero = @cuentaNumero
      FETCH NEXT FROM unCursor INTO @montoImporte, @cuentaNumero
    END

    CLOSE unCursor
    DEALLOCATE unCursor

  END
  ELSE
  BEGIN
    SELECT
      @montoImporte = importe,
      @cuentaNumero = cuenta
    FROM inserted
    UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
    SET Saldo = Saldo - @montoImporte
    WHERE numero = @cuentaNumero
  END
END
GO

CREATE TRIGGER QUIEN_BAJO_EL_KERNEL.TransferenciaActualizarSaldo
ON QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
AFTER INSERT
AS
BEGIN
  DECLARE @montoImporte numeric(18, 2),
          @cuentaNumeroOrigen numeric(18),
          @cuentaNumeroDestino numeric(18)
  IF ((SELECT
      COUNT(*)
    FROM inserted)
    > 1)
  BEGIN
    DECLARE unCursor CURSOR FOR
    SELECT
      importe,
      origen,
      destino
    FROM inserted

    OPEN unCursor
    FETCH NEXT FROM unCursor INTO @montoImporte, @cuentaNumeroOrigen, @cuentaNumeroDestino
    WHILE @@FETCH_STATUS = 0
    BEGIN
      UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
      SET Saldo = Saldo - @montoImporte
      WHERE numero = @cuentaNumeroOrigen

      UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
      SET Saldo = Saldo + @montoImporte
      WHERE numero = @cuentaNumeroDestino
      FETCH NEXT FROM unCursor INTO @montoImporte, @cuentaNumeroOrigen, @cuentaNumeroDestino
    END

    CLOSE unCursor
    DEALLOCATE unCursor
  END
  ELSE
  BEGIN
    SELECT
      @montoImporte = importe,
      @cuentaNumeroOrigen = origen,
      @cuentaNumeroDestino = destino
    FROM inserted

    UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
    SET Saldo = Saldo - @montoImporte
    WHERE numero = @cuentaNumeroOrigen

    UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
    SET Saldo = Saldo + @montoImporte
    WHERE numero = @cuentaNumeroDestino
  END
END
GO

-----	 ****************************** INSERTS ****************************** -----

insert into QUIEN_BAJO_EL_KERNEL.tipo_transaccion (codigo,descripcion)
											values	  (1,'Transferencia')
GO	
										
insert into QUIEN_BAJO_EL_KERNEL.tipo_transaccion (codigo,descripcion)
    											values  (2,'Activacion')
GO

insert into QUIEN_BAJO_EL_KERNEL.tipo_transaccion (codigo,descripcion)
												values  (3,'Modificacion')
GO												  									  

insert into QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA (codigo,descripcion) values (1, 'Pendiente de activacion')
GO

insert into QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA (codigo,descripcion) values (2, 'Cerrada')
GO

insert into QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA (codigo,descripcion) values (3, 'Inhabilitada')
GO

insert into QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA (codigo,descripcion) values (4, 'Habilitada')
GO

insert into QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA (codigo,descripcion) values (1,'U$S')
GO

INSERT INTO [QUIEN_BAJO_EL_KERNEL].[Usuario]([username], [password], [activo]) VALUES ('admin', 0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7, 1)
GO

INSERT INTO  [QUIEN_BAJO_EL_KERNEL].[ROL] (nombre,activo) values ('admin',1)
GO

INSERT INTO  [QUIEN_BAJO_EL_KERNEL].[USUARIO_ROL] (id_rol,username) values (1,'admin')
GO

insert into QUIEN_BAJO_EL_KERNEL.TIPO_DOCUMENTO (codigo,descripcion)
			 (select distinct cli_tipo_doc_cod,cli_tipo_doc_desc
					from gd_esquema.Maestra
					
			 )
GO			 

insert into QUIEN_BAJO_EL_KERNEL.PAIS (codigo_pais, descripcion_pais)
		   (select distinct Cli_Pais_Codigo,Cli_Pais_Desc from gd_esquema.Maestra
			UNION
			select  distinct cuenta_pais_codigo,cuenta_pais_desc
			from gd_esquema.Maestra
		  		 )
GO				 

insert into QUIEN_BAJO_EL_KERNEL.CLIENTE (tipo_documento,numero_documento,
					 pais_codigo,nombre,apellido,dom_calle,
					 dom_nro,dom_piso,dom_dpto,fecha_nacimiento,
					 mail,username)
			       (select distinct  cli_tipo_doc_cod,cli_nro_doc,cli_pais_codigo,
						   cli_nombre,cli_apellido,cli_dom_calle,
						   cli_dom_nro,cli_dom_piso,cli_dom_depto,
						   cli_fecha_nac,cli_mail, 'admin'
					from gd_esquema.Maestra
						   		
				   )
				   
GO

insert into QUIEN_BAJO_EL_KERNEL.CUENTA (numero,fecha_creacion,estado_codigo,pais_codigo,fecha_cierre,
				   cliente_tipo_doc,cliente_numero_doc,moneda_tipo,saldo)
			 (select distinct cuenta_numero,cuenta_fecha_creacion,'4',
									cuenta_pais_codigo,cuenta_fecha_cierre,cli_tipo_doc_cod,
									cli_nro_doc,'1','0'
					from gd_esquema.Maestra
					)
GO

insert into QUIEN_BAJO_EL_KERNEL.TARJETA (tarjeta_numero, fecha_emision,fecha_vencimiento,
					 codigo_seguridad, emisor_descripcion)
			  (select distinct tarjeta_numero, tarjeta_fecha_emision,tarjeta_fecha_vencimiento,
					 tarjeta_codigo_seg, tarjeta_emisor_descripcion
					 from gd_esquema.Maestra
					 where Tarjeta_Numero is not null)					 
GO

insert into QUIEN_BAJO_EL_KERNEL.DEPOSITO (deposito_codigo,fecha, importe, cuenta_numero, tarjeta_numero)
				 (select deposito_codigo,deposito_fecha, deposito_importe, 
							  cuenta_numero, tarjeta_numero
					  from gd_esquema.Maestra
					  where deposito_codigo is not null)
GO

insert into QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA (origen,destino,fecha,importe, costo)
				    (select cuenta_numero,cuenta_dest_numero,
						   transf_fecha,trans_importe,trans_costo_trans
						   from gd_esquema.Maestra
						   where transf_fecha is not null)					   
GO

insert into QUIEN_BAJO_EL_KERNEL.BANCO  (codigo,nombre,direccion)
			 (select distinct banco_cogido,banco_nombre,banco_direccion 
					from gd_esquema.Maestra
					where banco_cogido is not null
					)				
GO

insert into QUIEN_BAJO_EL_KERNEL.CHEQUE (numero,fecha,importe,codigo_banco)		
			 (select cheque_numero,cheque_fecha,cheque_importe,banco_cogido
					from gd_esquema.Maestra
					where cheque_numero is not null)
GO

insert into QUIEN_BAJO_EL_KERNEL.RETIRO (fecha,codigo,importe,cuenta,cheque)
			 (select retiro_fecha, retiro_codigo,retiro_importe,cuenta_numero,cheque_numero
					from gd_esquema.Maestra
					where retiro_codigo is not null)

GO



-----	 ****************************** STORED PROCEDURES ****************************** -----

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.completar_transacciones
AS
BEGIN

  DECLARE @CANT_CUENTAS numeric(18, 0)
  DECLARE @CANT_CUENTAS_MODIF numeric(18, 0)
  DECLARE @CANT_TRANSF numeric(18, 0)
  DECLARE @i numeric(18, 0)
  DECLARE @cuenta numeric(18, 0)
  DECLARE @transf numeric(18, 0)


  SELECT
    @CANT_CUENTAS = COUNT(*)
  FROM QUIEN_BAJO_EL_KERNEL.CUENTA
  SELECT
    @CANT_CUENTAS_MODIF = COUNT(*)
  FROM QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION
  SELECT
    @CANT_TRANSF = COUNT(*)
  FROM QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA

  -- LIMPIO

  UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
  SET id_transaccion = NULL
  UPDATE QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
  SET id_transaccion = NULL
  DELETE FROM QUIEN_BAJO_EL_KERNEL.TRANSACCIONES
  DBCC CHECKIDENT ('QUIEN_BAJO_EL_KERNEL.TRANSACCIONES', RESEED, 1)


  SET @i = 1

  WHILE @i <= @CANT_CUENTAS
  BEGIN

    INSERT INTO QUIEN_BAJO_EL_KERNEL.TRANSACCIONES (operacion_tipo)
      VALUES (2)
    SET @i = @i + 1

  END

  SET @i = 0
  UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
  SET @i = id_transaccion = @i + 1
  WHERE id_transaccion IS NULL


  SET @i = 1

  WHILE @i <= @CANT_TRANSF
  BEGIN

    INSERT INTO QUIEN_BAJO_EL_KERNEL.TRANSACCIONES (operacion_tipo)
      VALUES (1)

    SET @i = @i + 1

  END
  SET @i = @CANT_CUENTAS
  UPDATE QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
  SET @i = id_transaccion = @i + 1
  WHERE id_transaccion IS NULL


END
GO

---------------		SP Cuenta		---------------
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetMaxNroCuenta
AS
BEGIN

	SELECT MAX(c.numero)+1 FROM QUIEN_BAJO_EL_KERNEL.CUENTA c;
END
GO

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetPaises]
AS
BEGIN	
	SELECT * FROM QUIEN_BAJO_EL_KERNEL.PAIS p ORDER BY p.descripcion_pais ASC;
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetTipoMoneda
AS
BEGIN
	SELECT * FROM QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA
END
GO

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetTiposCuenta]
AS
BEGIN
	SELECT * FROM QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA t ORDER BY t.codigo ASC;
END
GO

---------------		SP Funcionalidad		---------------

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetFuncionalidadesByRol]
@rolId numeric(10,0)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
		f.*
	FROM [QUIEN_BAJO_EL_KERNEL].FUNCIONALIDAD f
	INNER JOIN [QUIEN_BAJO_EL_KERNEL].FUNCIONALIDAD_ROL fr ON fr.id_funcionalidad = f.id_funcionalidad
	WHERE
		fr.id_rol = @rolId
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.SELECT_FUNCIONALIDAD
AS 
BEGIN
	SELECT * FROM QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD f
END
GO

---------------		SP Rol		---------------
CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetRolesByUsername]
@username nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
		r.*
	FROM [QUIEN_BAJO_EL_KERNEL].Rol r
	INNER JOIN [QUIEN_BAJO_EL_KERNEL].USUARIO_ROL ur ON ur.id_rol = r.id
	WHERE
		ur.username = @username AND
		r.activo = 1
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_ROL_FUNCIONALIDAD (@id_rol numeric(10,0), @id_funcionalidad numeric(10,0))
AS 
BEGIN
insert into QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD_ROL (id_rol,id_funcionalidad) values (@id_rol,@id_funcionalidad)
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_ROL (@nombre varchar(255), @activo BIT)
AS 
BEGIN
insert into QUIEN_BAJO_EL_KERNEL.ROL (nombre,activo) values (@nombre,@activo)
 select scope_identity()
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.SELECT_ROL 
(@nombre varchar(255) = null ,
@activo BIT  = null)
AS 
BEGIN
SELECT * FROM QUIEN_BAJO_EL_KERNEL.ROL f 
WHERE (@nombre is null or f.nombre like '%' + @nombre + '%') AND
	  (@activo is null or f.activo = @activo)
END

-----	 ****************************** EXEC PROCS ****************************** -----

exec QUIEN_BAJO_EL_KERNEL.completar_transacciones
GO


---------------		SP Usuarios		---------------

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetUsuarioByUsernameAndPassword]
@username nvarchar(255),
@password varbinary(max)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
		u.*
	FROM [QUIEN_BAJO_EL_KERNEL].Usuario u
	WHERE 
		u.username = @username AND
		u.password = @password AND
		u.activo = 1
END
GO

---------------		SP Listados		---------------

-----	 ****************************** TRIGGERS necesarios post-migracion ****************************** -----

CREATE TRIGGER QUIEN_BAJO_EL_KERNEL.TransferenciaInsertarIdTransaccion
ON QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
INSTEAD OF INSERT
AS
BEGIN
  DECLARE @codigo numeric(18, 0),
          @origen numeric(18, 0),
          @destino numeric(18, 0),
          @fecha datetime,
          @importe numeric(18, 2),
          @costo numeric(18, 2),
          @moneda_tipo numeric(1, 0),
          @id_transaccion numeric(18, 0)

  INSERT INTO QUIEN_BAJO_EL_KERNEL.TRANSACCIONES (operacion_tipo, fecha)
    VALUES (1, GETDATE())

  SET @id_transaccion = (SELECT
    SCOPE_IDENTITY())

  SELECT
    @codigo = codigo,
    @origen = origen,
    @destino = destino,
    @fecha = fecha,
    @importe = importe,
    @costo = costo,
    @moneda_tipo = moneda_tipo
  FROM inserted

  INSERT INTO QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA (origen, destino, fecha, importe, costo, moneda_tipo, id_transaccion)
    VALUES (@origen, @destino, @fecha, @importe, @costo, @moneda_tipo, @id_transaccion)
END
GO


