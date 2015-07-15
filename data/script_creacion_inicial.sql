-----	 ****************************** CREATE SCHEMA ****************************** -----

CREATE SCHEMA QUIEN_BAJO_EL_KERNEL AUTHORIZATION dbo
GO

-----	 ****************************** CREATE TABLES ****************************** -----


CREATE TABLE QUIEN_BAJO_EL_KERNEL.FACTURA (
	numero numeric(18)  NOT NULL,
	fecha datetime NULL,
	cliente_numero_doc numeric(10) NULL,
	cliente_tipo_doc numeric(18) NULL
)
GO


CREATE TABLE QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION (
	id_modificacion numeric(18) IDENTITY(1,1) NOT NULL,
	cuenta numeric(18) NOT NULL,
	fecha datetime NULL,
	nuevo_tipo_cuenta	NUMERIC(1,0) NOT NULL
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
	activo bit NOT NULL default (1),
	habilitado bit not null default (1)
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
	codigo numeric(18) NOT NULL,
	origen numeric(18) NULL,
	destino numeric(18) NULL,
	fecha datetime NULL,
	importe numeric(18,2) NULL,
	costo numeric(18,2) NULL,
	moneda_tipo numeric(1) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TARJETA (
	tarjeta_numero varchar(16) NOT NULL,
	fecha_emision datetime NULL,
	fecha_vencimiento datetime NULL,
	codigo_seguridad varchar(3) NULL,
	cod_emisor int NOT NULL
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
	saldo numeric(18,2) NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (
	id_funcionalidad NUMERIC(10) IDENTITY(1,1) NOT NULL,
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

CREATE TABLE QUIEN_BAJO_EL_KERNEL.EMISOR_TARJETA(
	id_emisor	int IDENTITY(1,1) NOT NULL,
	emisor_descripcion	varchar(255) NOT NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_TRANSFERENCIAS(
	transferencia	NUMERIC(18,0) NOT NULL,
	descripcion varchar(255),
	importe NUMERIC(18,2),
	factura_numero NUMERIC(18,0) NOT NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_ACTIVACION_CUENTA(
	cuenta	NUMERIC(18,0) NOT NULL,
	descripcion varchar(255),
	importe NUMERIC(18,2),
	factura_numero NUMERIC(18,0) NOT NULL
)
GO


CREATE TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_MODIFICACION_CUENTA(
	id_modificacion	NUMERIC(18,0) NOT NULL,
	cuenta	NUMERIC(18,0) NOT NULL,
	descripcion varchar(255),
	importe NUMERIC(18,2),
	factura_numero NUMERIC(18,0) NOT NULL
)
GO

CREATE TABLE QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION(
	id_transaccion	NUMERIC(18,0) NOT NULL,
	descripcion varchar(255),
	costo	NUMERIC(18,2) NOT NULL
)
GO



-----	 ****************************** PRIMARY KEYS ****************************** -----


ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_TRANSFERENCIAS ADD CONSTRAINT PK_ITEM_FACTURA_TRANSFERENCIA
	PRIMARY KEY CLUSTERED (transferencia)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_ACTIVACION_CUENTA ADD CONSTRAINT PK_ITEM_FACTURA_ACT_CUENTA
	PRIMARY KEY CLUSTERED (cuenta)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_MODIFICACION_CUENTA ADD CONSTRAINT PK_ITEM_FACTURA_MOD_CUENTA
	PRIMARY KEY CLUSTERED (id_modificacion)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD ADD CONSTRAINT PK_FUNCIONALIDAD
	PRIMARY KEY CLUSTERED (id_funcionalidad)
GO




ALTER TABLE QUIEN_BAJO_EL_KERNEL.FACTURA ADD CONSTRAINT PK_FACTURA
	PRIMARY KEY CLUSTERED (numero)
GO


ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION ADD CONSTRAINT PK_CUENTA_MODIFICACION
	PRIMARY KEY CLUSTERED (id_modificacion)

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

ALTER TABLE QUIEN_BAJO_EL_KERNEL.EMISOR_TARJETA ADD CONSTRAINT PK_EMISOR
	PRIMARY KEY CLUSTERED (id_emisor)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION ADD CONSTRAINT PK_TRANSACCION
	PRIMARY KEY CLUSTERED (id_transaccion)
GO
-----	 ****************************** FOREIGN KEYS ****************************** -----


ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_TRANSFERENCIAS ADD CONSTRAINT FK_I_FACT_TRANSF
	FOREIGN KEY (factura_numero) REFERENCES QUIEN_BAJO_EL_KERNEL.FACTURA(numero)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_MODIFICACION_CUENTA ADD CONSTRAINT FK_I_FACT_MODCTA
	FOREIGN KEY (factura_numero) REFERENCES QUIEN_BAJO_EL_KERNEL.FACTURA(numero)
GO
ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_ACTIVACION_CUENTA ADD CONSTRAINT FK_I_FACT_ACTCTA
	FOREIGN KEY (factura_numero) REFERENCES QUIEN_BAJO_EL_KERNEL.FACTURA(numero)
GO
ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_TRANSFERENCIAS ADD CONSTRAINT FK_IF_TRANSF_TRANSF
	FOREIGN KEY (transferencia) REFERENCES QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA(codigo)
GO
ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_MODIFICACION_CUENTA ADD CONSTRAINT FK_IF_MODCTA_MODCTA
	FOREIGN KEY (id_modificacion) REFERENCES QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION(id_modificacion)
GO
ALTER TABLE QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_ACTIVACION_CUENTA ADD CONSTRAINT FK_IF_ACTCTA_ACTCTA
	FOREIGN KEY (cuenta) REFERENCES QUIEN_BAJO_EL_KERNEL.CUENTA(numero)
GO


ALTER TABLE QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD_ROL ADD CONSTRAINT FK_FUNCIONALIDADROL_FUNCIONALIDAD
	FOREIGN KEY (id_funcionalidad) REFERENCES QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (id_funcionalidad)
GO



ALTER TABLE QUIEN_BAJO_EL_KERNEL.FACTURA ADD CONSTRAINT FK_FACTURA_CLIENTE
	FOREIGN KEY (cliente_tipo_doc,cliente_numero_doc) REFERENCES QUIEN_BAJO_EL_KERNEL.CLIENTE (tipo_documento,numero_documento)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION ADD CONSTRAINT FK_CUENTA_MODIFICACION_CUENTA
	FOREIGN KEY (cuenta) REFERENCES QUIEN_BAJO_EL_KERNEL.CUENTA (numero)
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



ALTER TABLE QUIEN_BAJO_EL_KERNEL.CLIENTE ADD CONSTRAINT FK_CLIENTE_USUARIO
	FOREIGN KEY (username) REFERENCES QUIEN_BAJO_EL_KERNEL.USUARIO (username)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.USUARIO_LOG ADD CONSTRAINT FK_USUARIO_LOG_USUARIO
	FOREIGN KEY (username) REFERENCES QUIEN_BAJO_EL_KERNEL.USUARIO (username)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.TARJETA ADD CONSTRAINT FK_EMISOR
	FOREIGN KEY (cod_emisor) REFERENCES QUIEN_BAJO_EL_KERNEL.EMISOR_TARJETA (id_emisor)
GO

ALTER TABLE QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION ADD CONSTRAINT FK_MODIF_TIPO_CUENTA
	FOREIGN KEY (nuevo_tipo_cuenta) REFERENCES QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA (codigo)
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
		  @costo numeric(18, 2),
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
      costo,
      origen,
      destino
    FROM inserted

    OPEN unCursor
    FETCH NEXT FROM unCursor INTO @montoImporte,@costo, @cuentaNumeroOrigen, @cuentaNumeroDestino
    WHILE @@FETCH_STATUS = 0
    BEGIN
      UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
      SET Saldo = Saldo - @montoImporte 
      WHERE numero = @cuentaNumeroOrigen

      UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
      SET Saldo = Saldo + @montoImporte
      WHERE numero = @cuentaNumeroDestino
      FETCH NEXT FROM unCursor INTO @montoImporte,@costo, @cuentaNumeroOrigen, @cuentaNumeroDestino
    END

    CLOSE unCursor
    DEALLOCATE unCursor
  END
  ELSE
  BEGIN
    SELECT
      @montoImporte = importe,
      @costo = costo,
      @cuentaNumeroOrigen = origen,
      @cuentaNumeroDestino = destino      
    FROM inserted

    UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
    SET Saldo = Saldo - @montoImporte - @costo
    WHERE numero = @cuentaNumeroOrigen

    UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
    SET Saldo = Saldo + @montoImporte
    WHERE numero = @cuentaNumeroDestino
  END
END
GO
-----	 ****************************** VISTAS PARA LA MIGRACION ****************************** -----

CREATE VIEW quien_bajo_el_kernel.facturas_transferencias AS
SELECT
ROW_NUMBER() OVER (ORDER BY m.Factura_Numero) AS ID_Transf
,m.Factura_Numero
,m.Factura_Fecha
,m.Cuenta_Dest_Numero
,m.Cuenta_Numero
,m.Trans_Costo_Trans
,m.Trans_Importe
,m.Transf_Fecha
,m.Cli_Nro_Doc
,m.Cli_Tipo_Doc_Cod
,m.Item_Factura_Descr
,m.Item_Factura_Importe
FROM
gd_esquema.Maestra m
WHERE
m.Factura_Numero IS NOT NULL

GO



-----	 ****************************** INSERTS ****************************** -----

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

INSERT INTO QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA(codigo, descripcion, duracion, costo)
		VALUES(1, 'Gratis', 30, 0)
GO
		
INSERT INTO QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA(codigo, descripcion, duracion, costo)
		VALUES(2, 'Bronce', 50, 30)
GO
	
INSERT INTO QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA(codigo, descripcion, duracion, costo)
		VALUES(3, 'Plata', 70, 50)
GO
		
INSERT INTO QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA(codigo, descripcion, duracion, costo)
		VALUES(4, 'Oro', 90, 70)
GO


INSERT INTO QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION(id_transaccion,descripcion,costo) values (1, 'Apertura de cuenta', 1)
GO
INSERT INTO QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION(id_transaccion,descripcion,costo) values (2, 'Modificacion de cuenta', 1)
GO
INSERT INTO QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION(id_transaccion,descripcion,costo) values (3, 'Transferencia', 1)
GO


INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('ABM_ROL')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('ABM_CLIENTE')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('ABM_CUENTA')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('ASOCIAR_DESASOCIAR_TC')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('DEPOSITO')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('RETIRO')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('TRANSFERENCIA')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('FACTURACION')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('CONSULTA_SALDO')
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.FUNCIONALIDAD (descripcion) values ('LISTADO_ESTADISTICO')
GO

INSERT INTO [QUIEN_BAJO_EL_KERNEL].[Usuario]([username], [password], [activo], [habilitado]) VALUES ('admin', 0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7, 1, 1)
GO

INSERT INTO  [QUIEN_BAJO_EL_KERNEL].[ROL] (nombre,activo) values ('Administrador',1)
GO

INSERT INTO  [QUIEN_BAJO_EL_KERNEL].[ROL] (nombre,activo) values ('Cliente',1)
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

INSERT INTO [QUIEN_BAJO_EL_KERNEL].[Usuario]
([username], [password], [activo], [habilitado])  
(select distinct  cli_nro_doc, 0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7, 1, 1
	from gd_esquema.Maestra	   )
GO

INSERT INTO [QUIEN_BAJO_EL_KERNEL].USUARIO_ROL (id_rol,username) (select distinct  2,username
	from QUIEN_BAJO_EL_KERNEL.USUARIO where username<>'admin'	   )
GO

insert into QUIEN_BAJO_EL_KERNEL.CLIENTE (tipo_documento,numero_documento,
					 pais_codigo,nombre,apellido,dom_calle,
					 dom_nro,dom_piso,dom_dpto,fecha_nacimiento,
					 mail, username)
			       (select distinct  cli_tipo_doc_cod,cli_nro_doc,cli_pais_codigo,
						   cli_nombre,cli_apellido,cli_dom_calle,
						   cli_dom_nro,cli_dom_piso,cli_dom_depto,
						   cli_fecha_nac,cli_mail, cli_nro_doc
					from gd_esquema.Maestra
				   )
GO

insert into QUIEN_BAJO_EL_KERNEL.CUENTA (numero,fecha_creacion,estado_codigo,pais_codigo,fecha_cierre,
				   cliente_tipo_doc,cliente_numero_doc,moneda_tipo,saldo,tipo_cuenta)
			 (select distinct cuenta_numero,cuenta_fecha_creacion,4,
									cuenta_pais_codigo,cuenta_fecha_cierre,cli_tipo_doc_cod,
									cli_nro_doc,1,0,1
					from gd_esquema.Maestra
					)
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.EMISOR_TARJETA (emisor_descripcion)
			 (SELECT DISTINCT Tarjeta_Emisor_Descripcion
				FROM gd_esquema.Maestra
			   WHERE Tarjeta_Emisor_Descripcion IS NOT NULL)
GO

insert into QUIEN_BAJO_EL_KERNEL.TARJETA (tarjeta_numero, fecha_emision,fecha_vencimiento,
					 codigo_seguridad, cod_emisor)
			  (select distinct tarjeta_numero,
							   tarjeta_fecha_emision,
							   tarjeta_fecha_vencimiento,
							   tarjeta_codigo_seg,
							   CASE tarjeta_emisor_descripcion
								WHEN 'Master Card' THEN 1
								WHEN 'American Express' THEN 2
								WHEN 'Visa' THEN 3
							   END
				from gd_esquema.Maestra
			   where Tarjeta_Numero is not null)
GO

insert into QUIEN_BAJO_EL_KERNEL.DEPOSITO (deposito_codigo,fecha, importe, cuenta_numero, moneda_tipo,tarjeta_numero)
				 (select deposito_codigo,deposito_fecha, deposito_importe,
							  cuenta_numero, 1,tarjeta_numero
					  from gd_esquema.Maestra
					  where deposito_codigo is not null)
GO


insert into QUIEN_BAJO_EL_KERNEL.BANCO  (codigo,nombre,direccion)
			 (select distinct banco_cogido,banco_nombre,banco_direccion
					from gd_esquema.Maestra
					where banco_cogido is not null
					)
GO

insert into QUIEN_BAJO_EL_KERNEL.CHEQUE (numero,fecha,importe,codigo_banco,moneda_tipo)
			 (select cheque_numero,cheque_fecha,cheque_importe,banco_cogido,1
					from gd_esquema.Maestra
					where cheque_numero is not null)
GO

insert into QUIEN_BAJO_EL_KERNEL.RETIRO (fecha,codigo,importe,cuenta,cheque)
			 (select retiro_fecha, retiro_codigo,retiro_importe,cuenta_numero,cheque_numero
					from gd_esquema.Maestra
					where retiro_codigo is not null)
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.transferencia (codigo,origen,destino,fecha,importe,costo,moneda_tipo)
	(SELECT
	id_transf,
	cuenta_numero,
	cuenta_dest_numero,
	transf_fecha,
	trans_importe,
	trans_costo_trans,
	'1'
	FROM QUIEN_BAJO_EL_KERNEL.facturas_transferencias )
GO


INSERT INTO QUIEN_BAJO_EL_KERNEL.factura (numero,fecha,cliente_numero_doc,cliente_tipo_doc)
			(SELECT
			Factura_Numero
			,Factura_Fecha
			,Cli_Nro_Doc
			,Cli_Tipo_Doc_Cod
			 FROM
			 QUIEN_BAJO_EL_KERNEL.facturas_transferencias )
GO

INSERT INTO QUIEN_BAJO_EL_KERNEL.item_factura_transferencias (transferencia,descripcion,importe,factura_numero)
	(SELECT
	ID_Transf
	,Item_Factura_Descr
	,Item_Factura_Importe
	,Factura_Numero
	FROM QUIEN_BAJO_EL_KERNEL.facturas_transferencias)

GO
-----	 ****************************** STORED PROCEDURES ****************************** -----

---------------		SP necesarios para migracion		---------------

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

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[InsertaCuenta]
@an_num_cuenta			NUMERIC(18,0),
@an_cod_pais			NUMERIC(18,0),
@an_moneda_tipo			NUMERIC(1,0),
@an_cuenta_tipo			NUMERIC(1,0),
@an_cliente_doc			NUMERIC(10,0),
@an_cliente_tipo_doc	NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO QUIEN_BAJO_EL_KERNEL.CUENTA([numero],[pais_codigo],[moneda_tipo],[tipo_cuenta],[cliente_numero_doc],[cliente_tipo_doc])
		 VALUES (@an_num_cuenta, @an_cod_pais, @an_moneda_tipo, @an_cuenta_tipo, @an_cliente_doc, @an_cliente_tipo_doc)

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
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.SELECT_ROL_BY_ID
(@id numeric(10,0))
AS 
BEGIN
SELECT * FROM QUIEN_BAJO_EL_KERNEL.ROL f 
WHERE f.id = @id
END
GO
---------------		SP ConsultaSaldos	---------------

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getUltimosCincoDepositosByCuenta(@cuenta varchar(255))
AS
BEGIN
select top 5 * from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].DEPOSITO  where cuenta_numero=@cuenta  order by fecha desc
END
GO


CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getUltimosCincoRetirosByCuenta(@cuenta varchar(255))
AS
BEGIN
select top 5 * from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].RETIRO  where cuenta= @cuenta order by fecha desc
END
GO


CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getUltimasDiezTransferenciasByCuenta(@cuenta varchar(255))
AS 
BEGIN
select top 10 *  from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].TRANSFERENCIA  where origen= @cuenta or destino= @cuenta  order by fecha desc
END
GO


CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetTiposMonedaByCuenta (@cuenta varchar(255))
AS
BEGIN
	SELECT c2.codigo,c2.descripcion FROM QUIEN_BAJO_EL_KERNEL.CUENTA c1
	inner join QUIEN_BAJO_EL_KERNEL.TIPO_MONEDA c2 on c1.moneda_tipo= c2.codigo
	where numero=@cuenta
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.insertTransferencia (@origen numeric(18,0), @destino numeric(18,0), @importe numeric(18,2), @costo numeric(18,2), @moneda_tipo numeric(1,0))
AS 
BEGIN
insert into [QUIEN_BAJO_EL_KERNEL].TRANSFERENCIA (origen, destino,fecha ,importe, costo, moneda_tipo) values 
(@origen, @destino, GETDATE(), @importe, @costo, @moneda_tipo)
END
GO


---------------		SP Listados	---------------

--- 1.-Clientes que alguna de sus cuentas fueron inhabilitadas por no pagar los costos de transacción ---

--- 2.- Cliente con mayor cantidad de comisiones facturadas en todas sus cuentas --

create view QUIEN_BAJO_EL_KERNEL.ComisionesFacturadas as
-- Transferencias
select cl.apellido, cl.nombre, f.cliente_numero_doc, f.cliente_tipo_doc , f.fecha
from QUIEN_BAJO_EL_KERNEL.FACTURA f
inner join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_TRANSFERENCIAS i on f.numero=i.factura_numero
inner join QUIEN_BAJO_EL_KERNEL.CLIENTE cl on f.cliente_numero_doc=cl.numero_documento and f.cliente_tipo_doc= cl.tipo_documento
UNION ALL
-- Activacion cuenta
select cl.apellido, cl.nombre, f.cliente_numero_doc, f.cliente_tipo_doc  , f.fecha as CantidadComisiones
from QUIEN_BAJO_EL_KERNEL.FACTURA f
inner join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_ACTIVACION_CUENTA i on f.numero=i.factura_numero
inner join QUIEN_BAJO_EL_KERNEL.CLIENTE cl on f.cliente_numero_doc=cl.numero_documento and f.cliente_tipo_doc= cl.tipo_documento

UNION ALL
-- Modificacion cuenta
select cl.apellido, cl.nombre, f.cliente_numero_doc, f.cliente_tipo_doc, f.fecha as CantidadComisiones
from QUIEN_BAJO_EL_KERNEL.FACTURA f
inner join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_MODIFICACION_CUENTA i on f.numero=i.factura_numero
inner join QUIEN_BAJO_EL_KERNEL.CLIENTE cl on f.cliente_numero_doc=cl.numero_documento and f.cliente_tipo_doc= cl.tipo_documento
GO


CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.ClientesComisionesFacturadas (@fechaDesde date, @fechaHasta date)
AS
BEGIN
select top 5 c.apellido, c.nombre,c.cliente_numero_doc, c.cliente_tipo_doc, COUNT(*) as CantidadComisiones
from QUIEN_BAJO_EL_KERNEL.ComisionesFacturadas c
--where c.fecha >=@fechaDesde and c.fecha<=@fechaHasta
group by c.cliente_numero_doc, c.cliente_tipo_doc,c.apellido, c.nombre
order by CantidadComisiones desc
END
GO

--- 3.- Clientes con mayor cantidad de transacciones realizadas entre cuentas propias ---
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
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.ClientesConMayorTransacciones (@fechaDesde date, @fechaHasta date)
AS
BEGIN
select  top 5 tipo_documento,numero_documento,apellido,nombre, SUM(cantTransacciones) as cantTrancciones from  QUIEN_BAJO_EL_KERNEL.TransaccionesClientes
where fecha>=@fechaDesde and fecha <= @fechaHasta
group by tipo_documento,numero_documento,apellido,nombre
order by cantTrancciones desc
END
GO

--- 4.- Países con mayor cantidad de movimientos tanto ingresos como egresos ---

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

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.PaisesConMayorIngresosEgresos (@fechaDesde date, @fechaHasta date)
AS
BEGIN
select top 5 pais_codigo, SUM(cantMovimientos) as cantMovimientos from QUIEN_BAJO_EL_KERNEL.MovimientosPaises
where fecha>=@fechaDesde and fecha <= @fechaHasta
group by pais_codigo
order by cantMovimientos desc
END
GO

--- 5.- Total facturado para los distintos tipos de cuentas ---





------------------------------------------------------------------


---------------		SP XXX	---------------



-----	 ****************************** EXEC PROCS ****************************** -----

/*exec QUIEN_BAJO_EL_KERNEL.completar_transacciones
GO
*/

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

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[DeleteUsuarioLog]
@username nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM [QUIEN_BAJO_EL_KERNEL].USUARIO_LOG
	WHERE username = username AND login_correcto = 0
	
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_USUARIO 
(
@username varchar(255)
,@password varbinary(max)
,@pregunta_secreta varchar(255)
,@respuesta_secreta varchar(255)
,@activo bit
,@habilitado bit 
)
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.USUARIO 
(username
,password
,pregunta_secreta
,respuesta_secreta
,activo
,habilitado)
VALUES
(@username
,@password
,@pregunta_secreta
,@respuesta_secreta
,@activo
,@habilitado)



END
GO

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[InsertUsuarioLog]
@username nvarchar(255),
@login_correcto bit
AS
BEGIN
	SET NOCOUNT ON;
	
	IF (EXISTS (SELECT * FROM [QUIEN_BAJO_EL_KERNEL].USUARIO WHERE username = @username))
	BEGIN
		INSERT INTO [QUIEN_BAJO_EL_KERNEL].USUARIO_LOG
		(
			username,
			fecha,
			login_correcto
		)
		VALUES
		(
			@username,
			GETDATE(),
			@login_correcto
		)
		
		IF ((SELECT COUNT(*) FROM [QUIEN_BAJO_EL_KERNEL].USUARIO_LOG WHERE username = @username AND login_correcto = 0) >= 3 AND @login_correcto = 0)
		BEGIN
			UPDATE [QUIEN_BAJO_EL_KERNEL].USUARIO SET habilitado = 0 WHERE username = @username
		END
	END
END
GO

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetTiposEstadoCuenta]
AS
BEGIN
	SELECT * FROM QUIEN_BAJO_EL_KERNEL.TIPO_ESTADO_CUENTA t ORDER BY t.codigo ASC;
END
GO

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

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetCuentas]
@an_pais		NUMERIC(18,0) = NULL,
@an_estado		NUMERIC(1,0) = NULL,
@an_moneda		NUMERIC(1,0) = NULL,
@an_tipo_cuenta	NUMERIC(1,0) = NULL
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
		   
END
GO

USE [GD1C2015]
GO
/****** Object:  StoredProcedure [QUIEN_BAJO_EL_KERNEL].[CerrarCuenta]    Script Date: 07/12/2015 03:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[CerrarCuenta]
@an_nro_cuenta	NUMERIC(18,0)
AS
BEGIN
DECLARE @items_a_facturar	NUMERIC(18,0),
		@items_facturados	NUMERIC(18,0)
	--Primero verifico que tenga pago todos los costos de las transacciones
	--Hacer un count de modificaciones de cuenta + activacion + transferencias
	--y si la cantidad es igual a los items de factura, se puede inhabilitar
	SELECT @items_a_facturar = (SELECT COUNT(*)
								  FROM QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA t
								 WHERE t.origen = @an_nro_cuenta)
								+
							   (SELECT COUNT(*)
							      FROM QUIEN_BAJO_EL_KERNEL.CUENTA c
							     WHERE c.numero = @an_nro_cuenta)
							    +
							   (SELECT COUNT(*)
							      FROM QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION cm
							     WHERE cm.cuenta = @an_nro_cuenta)
							     
	SELECT @items_facturados = (SELECT COUNT(*)
								  FROM QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_ACTIVACION_CUENTA ia
								 WHERE ia.cuenta = @an_nro_cuenta)
								+
							   (SELECT COUNT(*)
								  FROM QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_MODIFICACION_CUENTA im,
									   QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION c
								 WHERE im.id_modificacion = c.id_modificacion
								   AND c.cuenta = @an_nro_cuenta)
								+
							   (SELECT COUNT(*)
								  FROM QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_TRANSFERENCIAS it,
									   QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA t
								 WHERE it.transferencia = t.codigo
								   AND t.origen = @an_nro_cuenta)
								   
	IF @items_a_facturar <> @items_facturados
		--No pago todas las transacciones
		RETURN -1
	ELSE
		BEGIN
		--Ya pago todas las transacciones, se puede cerrar la cuenta
		UPDATE QUIEN_BAJO_EL_KERNEL.CUENTA
		   SET fecha_cierre = GETDATE(),
			   estado_codigo = 2
		 WHERE numero = @an_nro_cuenta
		END
	
END
GO

CREATE PROCEDURE [QUIEN_BAJO_EL_KERNEL].[GetCuentaByNumero]
@an_nro_cuenta	NUMERIC(18,0)
AS
BEGIN
	SELECT c.numero,
		   c.moneda_tipo,
		   c.pais_codigo,
		   c.tipo_cuenta,
		   c.cliente_numero_doc,
		   c.cliente_tipo_doc
	  FROM QUIEN_BAJO_EL_KERNEL.CUENTA c
	 WHERE c.numero = @an_nro_cuenta
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetTipoDocumento
AS
BEGIN
	SELECT * FROM QUIEN_BAJO_EL_KERNEL.TIPO_DOCUMENTO
END
GO

------------------------- Retiro ----------------------------
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.Insert_retiro(@fecha datetime , @importe numeric(18,2),
													 @cuenta numeric(18,0), @cheque numeric(18,0))
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.Retiro (fecha,importe,cuenta,cheque)
values
(@fecha,@importe,@cuenta,@cheque)
END
GO

------------------------ Facturacion ---------------------------
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetTransferenciasSinFacturar (@tipoDoc numeric(18),@numeroDoc numeric (18))
AS
BEGIN
	SELECT codigo as Codigo,tt.costo as Costo, 3 as TipoTransaccion
	FROM QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA t 
	inner join QUIEN_BAJO_EL_KERNEL.CUENTA c on t.origen = c.numero
	inner join QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA tt on tt.codigo = c.tipo_cuenta
	left join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_TRANSFERENCIAS i on t.codigo = i.transferencia
	where i.factura_numero is null and c.cliente_numero_doc=@numeroDoc and c.cliente_tipo_doc=@tipoDoc

	
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetAperturaCuentasSinFacturar (@tipoDoc numeric(18),@numeroDoc numeric (18))
AS
BEGIN
	select numero as Codigo,tt.costo as Costo , 1 as TipoTransaccion
	FROM QUIEN_BAJO_EL_KERNEL.CUENTA c
	inner join QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA tt on tt.codigo = c.tipo_cuenta
	left join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_ACTIVACION_CUENTA i on c.numero = i.cuenta
	where i.factura_numero is null and estado_codigo=4 and cliente_numero_doc=@numeroDoc and cliente_tipo_doc=@tipoDoc

END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetModifCuentasSinFacturar (@tipoDoc numeric(18),@numeroDoc numeric (18))
AS
BEGIN

	SELECT c.id_modificacion as Codigo, tt.costo as Costo, 2 as TipoTransaccion 
	FROM QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION c
	left join QUIEN_BAJO_EL_KERNEL.ITEM_FACTURA_MODIFICACION_CUENTA i on c.cuenta = i.cuenta
	inner join QUIEN_BAJO_EL_KERNEL.CUENTA c2 on c2.numero = c.cuenta
	inner join QUIEN_BAJO_EL_KERNEL.TIPO_CUENTA tt on tt.codigo = c2.tipo_cuenta
	where i.factura_numero is null and c2.cliente_numero_doc=@numeroDoc and c2.cliente_tipo_doc=@tipoDoc
	
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetTiposTransaccion 
AS
BEGIN
	SELECT * 
	FROM QUIEN_BAJO_EL_KERNEL.TIPO_TRANSACCION	
END
GO

drop procedure QUIEN_BAJO_EL_KERNEL.GetTransferenciasSinFacturar
drop procedure QUIEN_BAJO_EL_KERNEL.GetAperturaCuentasSinFacturar 
drop procedure QUIEN_BAJO_EL_KERNEL.GetModifCuentasSinFacturar 
select * from QUIEN_BAJO_EL_KERNEL.CLIENTE c where c.numero_documento=5806212
select * from QUIEN_BAJO_EL_KERNEL.CUENTA where numero=1111111111111383
------------------------------- Clientes ----------------------------------

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_CLIENTE 
(
  @tipoDocCod numeric(18,0)
 ,@dni numeric(10,0)
 ,@paisCod numeric(18,0)
 ,@apellido  varchar(255)
 ,@nombre varchar(255)
 ,@dom_calle varchar(255)
 ,@dom_nro numeric(18,0)
 ,@dom_piso numeric(18,0)
 ,@dom_dpto varchar(255)
 ,@fechaNac datetime
 ,@mail varchar(255)
 ,@localidad varchar(255)
 ,@username varchar(255)
 )

AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.CLIENTE
(tipo_documento
 ,numero_documento
 ,pais_codigo
 ,nombre
 ,apellido
 ,dom_calle
 ,dom_nro
 ,dom_piso
 ,dom_dpto
 ,fecha_nacimiento
 ,mail
 ,localidad
 ,username)
 VALUES
 (@tipoDocCod
 ,@dni
 ,@paisCod
 ,@apellido
 ,@nombre
 ,@dom_calle
 ,@dom_nro
 ,@dom_piso
 ,@dom_dpto
 ,@fechaNac
 ,@mail
 ,@localidad
 ,@username)

select scope_identity()

END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetClientes
AS
BEGIN
	SELECT *
	  FROM QUIEN_BAJO_EL_KERNEL.CLIENTE
END
GO

CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.getClienteByUsername(@username varchar(255))
AS 
BEGIN
select * from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].CLIENTE  where username= @username 
END
GO

---------------------- Cheque -------------------------------
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.Insert_cheque(@numero numeric(18), @fecha datetime , @importe numeric(18,2),
													 @codigo_banco numeric(18,0), @moneda_tipo numeric(1,0), 
													 @nombre_destinatario varchar(255))
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.CHEQUE (numero,fecha,importe,codigo_banco,moneda_tipo,nombre_destinatario)
values
(@numero,@fecha,@importe,@codigo_banco,@moneda_tipo,@nombre_destinatario)
END
GO

------------------------------ Banco -----------------------------------
CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.GetBancos
AS
BEGIN
	SELECT * FROM QUIEN_BAJO_EL_KERNEL.BANCO
END
GO



-----	 ****************************** TRIGGERS necesarios post-migracion ****************************** -----
CREATE TRIGGER QUIEN_BAJO_EL_KERNEL.TransferenciasManejoID
ON QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
INSTEAD OF INSERT
AS
BEGIN
DECLARE   @codigo numeric(18, 0),
          @origen numeric(18, 0),
          @destino numeric(18, 0),
          @fecha datetime,
          @importe numeric(18, 2),
          @costo numeric(18, 2),
          @moneda_tipo numeric(1, 0)
          
select @codigo=COUNT(*)+1 from QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA
 
SELECT
    @origen = origen,
    @destino = destino,
    @fecha = fecha,
    @importe = importe,
    @costo = costo,
    @moneda_tipo = moneda_tipo
  FROM inserted

INSERT INTO QUIEN_BAJO_EL_KERNEL.TRANSFERENCIA (codigo,origen, destino, fecha, importe, costo, moneda_tipo)
VALUES (@codigo,@origen, @destino, @fecha, @importe, @costo, @moneda_tipo)

END
GO


CREATE TRIGGER QUIEN_BAJO_EL_KERNEL.RetirosManejoID
ON QUIEN_BAJO_EL_KERNEL.Retiro
INSTEAD OF INSERT
AS
BEGIN
DECLARE   @codigo numeric(18, 0),
          @fecha datetime,
          @importe numeric(18, 2),
          @cuenta numeric(18, 0),
          @cheque numeric(18, 0)
          
select @codigo=MAX(codigo)+1 from QUIEN_BAJO_EL_KERNEL.Retiro
 
SELECT
    @fecha = fecha,
    @importe = importe,
    @cuenta = cuenta,
    @cheque = cheque
  FROM inserted

INSERT INTO QUIEN_BAJO_EL_KERNEL.Retiro (codigo,fecha, importe, cuenta, cheque)
VALUES (@codigo,@fecha, @importe, @cuenta, @cheque)

END
GO

CREATE TRIGGER QUIEN_BAJO_EL_KERNEL.ModificacionCuenta
ON QUIEN_BAJO_EL_KERNEL.CUENTA
AFTER UPDATE
AS
	SET NOCOUNT ON
	DECLARE
		@nro_cuenta	NUMERIC(18,0),
		@tipo_viejo	NUMERIC(1,0),
		@tipo_nuevo	NUMERIC(1,0)
IF UPDATE(tipo_cuenta)
BEGIN
	SELECT @tipo_nuevo = tipo_cuenta,
		   @nro_cuenta = numero
	  FROM inserted
	
	IF @tipo_nuevo <> 1
		INSERT INTO QUIEN_BAJO_EL_KERNEL.CUENTA_MODIFICACION(cuenta, fecha,nuevo_tipo_cuenta)
			 VALUES (@nro_cuenta, GETDATE(), @tipo_nuevo)
			 
	
END
GO
