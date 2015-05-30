USE [GD2C2014]
GO

/************ DROP SPs **************************/
DECLARE @CantidadSPs int
SELECT @CantidadSPs = COUNT(*) FROM sys.objects WHERE type in (N'P', N'PC') AND SCHEMA_NAME(schema_id) = N'Frutillitas'
WHILE @CantidadSPs > 0
BEGIN
	DECLARE @SPName nvarchar(max)
	SELECT TOP 1 @SPName = name FROM sys.objects WHERE type in (N'P', N'PC') AND SCHEMA_NAME(schema_id) = N'Frutillitas'
	DECLARE @Sql nvarchar(max)
	SET @Sql = 'DROP PROCEDURE [Frutillitas].' + @SPName
	exec sp_executesql @Sql
	SET @CantidadSPs = @CantidadSPs - 1
END
GO

/************ CREATE TABLE AND SCHEMA ***********/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_UsuarioRol_Rol]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[UsuarioRol]'))
ALTER TABLE [Frutillitas].[UsuarioRol] DROP CONSTRAINT [FK_UsuarioRol_Rol]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_UsuarioRol_Usuario]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[UsuarioRol]'))
ALTER TABLE [Frutillitas].[UsuarioRol] DROP CONSTRAINT [FK_UsuarioRol_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_UsuarioLog_Usuario]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[UsuarioLog]'))
ALTER TABLE [Frutillitas].[UsuarioLog] DROP CONSTRAINT [FK_UsuarioLog_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_UsuarioHotel_Hotel]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[UsuarioHotel]'))
ALTER TABLE [Frutillitas].[UsuarioHotel] DROP CONSTRAINT [FK_UsuarioHotel_Hotel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_UsuarioHotel_Usuario]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[UsuarioHotel]'))
ALTER TABLE [Frutillitas].[UsuarioHotel] DROP CONSTRAINT [FK_UsuarioHotel_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_RolFuncionalidad_Funcionalidad]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[RolFuncionalidad]'))
ALTER TABLE [Frutillitas].[RolFuncionalidad] DROP CONSTRAINT [FK_RolFuncionalidad_Funcionalidad]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_RolFuncionalidad_Rol]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[RolFuncionalidad]'))
ALTER TABLE [Frutillitas].[RolFuncionalidad] DROP CONSTRAINT [FK_RolFuncionalidad_Rol]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_ReservaTipoHabitacion_Reserva]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[ReservaTipoHabitacion]'))
ALTER TABLE [Frutillitas].[ReservaTipoHabitacion] DROP CONSTRAINT [FK_ReservaTipoHabitacion_Reserva]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_ReservaTipoHabitacion_TipoHabitacion]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[ReservaTipoHabitacion]'))
ALTER TABLE [Frutillitas].[ReservaTipoHabitacion] DROP CONSTRAINT [FK_ReservaTipoHabitacion_TipoHabitacion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_ReservaLog_Reserva]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[ReservaLog]'))
ALTER TABLE [Frutillitas].[ReservaLog] DROP CONSTRAINT [FK_ReservaLog_Reserva]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_ReservaLog_Usuario]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[ReservaLog]'))
ALTER TABLE [Frutillitas].[ReservaLog] DROP CONSTRAINT [FK_ReservaLog_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_ReservaLog_Tipo]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[ReservaLog]'))
ALTER TABLE [Frutillitas].[ReservaLog] DROP CONSTRAINT [FK_ReservaLog_Tipo]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Reserva_Cliente]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Reserva]'))
ALTER TABLE [Frutillitas].[Reserva] DROP CONSTRAINT [FK_Reserva_Cliente]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Reserva_Hotel]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Reserva]'))
ALTER TABLE [Frutillitas].[Reserva] DROP CONSTRAINT [FK_Reserva_Hotel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Reserva_Regimen]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Reserva]'))
ALTER TABLE [Frutillitas].[Reserva] DROP CONSTRAINT [FK_Reserva_Regimen]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Reserva_Estado]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Reserva]'))
ALTER TABLE [Frutillitas].[Reserva] DROP CONSTRAINT [FK_Reserva_Estado]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_HotelRegimen_Hotel]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[HotelRegimen]'))
ALTER TABLE [Frutillitas].[HotelRegimen] DROP CONSTRAINT [FK_HotelRegimen_Hotel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_HotelRegimen_Regimen]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[HotelRegimen]'))
ALTER TABLE [Frutillitas].[HotelRegimen] DROP CONSTRAINT [FK_HotelRegimen_Regimen]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_HotelInhabilitacion_Hotel]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[HotelInhabilitacion]'))
ALTER TABLE [Frutillitas].[HotelInhabilitacion] DROP CONSTRAINT [FK_HotelInhabilitacion_Hotel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Hotel_Ciudad]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Hotel]'))
ALTER TABLE [Frutillitas].[Hotel] DROP CONSTRAINT [FK_Hotel_Ciudad]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Habitacion_Hotel]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Habitacion]'))
ALTER TABLE [Frutillitas].[Habitacion] DROP CONSTRAINT [FK_Habitacion_Hotel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Habitacion_TipoHabitacion]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Habitacion]'))
ALTER TABLE [Frutillitas].[Habitacion] DROP CONSTRAINT [FK_Habitacion_TipoHabitacion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[UQ_Habitacion_Hotel_Numero]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Habitacion]'))
ALTER TABLE [Frutillitas].[Habitacion] DROP CONSTRAINT [UQ_Habitacion_Hotel_Numero]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Factura_Estadia]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Factura]'))
ALTER TABLE [Frutillitas].[Factura] DROP CONSTRAINT [FK_Factura_Estadia]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Factura_TipoPago]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Factura]'))
ALTER TABLE [Frutillitas].[Factura] DROP CONSTRAINT [FK_Factura_TipoPago]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Factura_Cliente]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Factura]'))
ALTER TABLE [Frutillitas].[Factura] DROP CONSTRAINT [FK_Factura_Cliente]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_FacturaItem_Factura]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[FacturaItem]'))
ALTER TABLE [Frutillitas].[FacturaItem] DROP CONSTRAINT [FK_FacturaItem_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_TarjetaDeCredito_Factura]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[TarjetaDeCredito]'))
ALTER TABLE [Frutillitas].[TarjetaDeCredito] DROP CONSTRAINT [FK_TarjetaDeCredito_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_EstadiaConsumible_Consumible]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[EstadiaConsumible]'))
ALTER TABLE [Frutillitas].[EstadiaConsumible] DROP CONSTRAINT [FK_EstadiaConsumible_Consumible]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_EstadiaConsumible_Estadia]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[EstadiaConsumible]'))
ALTER TABLE [Frutillitas].[EstadiaConsumible] DROP CONSTRAINT [FK_EstadiaConsumible_Estadia]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_EstadiaCliente_Cliente]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[EstadiaCliente]'))
ALTER TABLE [Frutillitas].[EstadiaCliente] DROP CONSTRAINT [FK_EstadiaCliente_Cliente]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_EstadiaCliente_Estadia]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[EstadiaCliente]'))
ALTER TABLE [Frutillitas].[EstadiaCliente] DROP CONSTRAINT [FK_EstadiaCliente_Estadia]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Estadia_Reserva]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Estadia]'))
ALTER TABLE [Frutillitas].[Estadia] DROP CONSTRAINT [FK_Estadia_Reserva]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Cliente_Pais]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Cliente]'))
ALTER TABLE [Frutillitas].[Cliente] DROP CONSTRAINT [FK_Cliente_Pais]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Cliente_TipoDocumento]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Cliente]'))
ALTER TABLE [Frutillitas].[Cliente] DROP CONSTRAINT [FK_Cliente_TipoDocumento]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Frutillitas].[FK_Ciudad_Pais]') AND parent_object_id = OBJECT_ID(N'[Frutillitas].[Ciudad]'))
ALTER TABLE [Frutillitas].[Ciudad] DROP CONSTRAINT [FK_Ciudad_Pais]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[UsuarioHotel]') AND type in (N'U'))
DROP TABLE [Frutillitas].[UsuarioHotel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Ciudad]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Ciudad]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Cliente]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Cliente]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Consumible]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Consumible]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Estadia]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Estadia]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[EstadiaCliente]') AND type in (N'U'))
DROP TABLE [Frutillitas].[EstadiaCliente]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[EstadiaConsumible]') AND type in (N'U'))
DROP TABLE [Frutillitas].[EstadiaConsumible]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[EstadiaDetalle]') AND type in (N'U'))
DROP TABLE [Frutillitas].[EstadiaDetalle]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Factura]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Factura]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[FacturaItem]') AND type in (N'U'))
DROP TABLE [Frutillitas].[FacturaItem]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[FacturaTipoPago]') AND type in (N'U'))
DROP TABLE [Frutillitas].[FacturaTipoPago]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[TarjetaDeCredito]') AND type in (N'U'))
DROP TABLE [Frutillitas].[TarjetaDeCredito]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Funcionalidad]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Funcionalidad]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Habitacion]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Habitacion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Hotel]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Hotel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[HotelIncrementoEstrella]') AND type in (N'U'))
DROP TABLE [Frutillitas].[HotelIncrementoEstrella]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[HotelInhabilitacion]') AND type in (N'U'))
DROP TABLE [Frutillitas].[HotelInhabilitacion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[HotelRegimen]') AND type in (N'U'))
DROP TABLE [Frutillitas].[HotelRegimen]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Pais]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Pais]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Regimen]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Regimen]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Reserva]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Reserva]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[ReservaLogTipo]') AND type in (N'U'))
DROP TABLE [Frutillitas].[ReservaLogTipo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[ReservaLog]') AND type in (N'U'))
DROP TABLE [Frutillitas].[ReservaLog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[ReservaEstado]') AND type in (N'U'))
DROP TABLE [Frutillitas].[ReservaEstado]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[ReservaTipoHabitacion]') AND type in (N'U'))
DROP TABLE [Frutillitas].[ReservaTipoHabitacion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Rol]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Rol]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[RolFuncionalidad]') AND type in (N'U'))
DROP TABLE [Frutillitas].[RolFuncionalidad]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[TipoDocumento]') AND type in (N'U'))
DROP TABLE [Frutillitas].[TipoDocumento]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[TipoHabitacion]') AND type in (N'U'))
DROP TABLE [Frutillitas].[TipoHabitacion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Usuario]') AND type in (N'U'))
DROP TABLE [Frutillitas].[Usuario]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[UsuarioLog]') AND type in (N'U'))
DROP TABLE [Frutillitas].[UsuarioLog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[UsuarioRol]') AND type in (N'U'))
DROP TABLE [Frutillitas].[UsuarioRol]
GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Frutillitas')
DROP SCHEMA [Frutillitas]
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Frutillitas')
EXEC sys.sp_executesql N'CREATE SCHEMA [Frutillitas] AUTHORIZATION [dbo]'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[UsuarioHotel]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[UsuarioHotel](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[usuarioId] [int] NULL,
	[hotelId] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[UsuarioRol]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[UsuarioRol](
	[usuarioId] [int] NULL,
	[rolId] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[UsuarioLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[UsuarioLog](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[usuarioId] [int] NULL,
	[fecha] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[username] [nvarchar](255) NULL,
	[password] [varbinary](MAX) NULL,
	[habilitado] [bit] NULL,
	[nombre] [nvarchar](255) NULL,
	[apellido] [nvarchar](255) NULL,
	[tipoDocumentoId] [int] NULL,
	[numeroDocumento] [numeric](18, 0) NULL,
	[mail] [nvarchar](255) NULL,
	[telefono] [nvarchar](255) NULL,
	[direccion] [nvarchar](255) NULL,
	[fechaNacimiento] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[TipoHabitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[TipoHabitacion](
	[codigo] [numeric](18, 0) NOT NULL PRIMARY KEY,
	[descripcion] [nvarchar](255) NULL,
	[porcentual] [numeric](18, 2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[TipoDocumento]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[TipoDocumento](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nombre] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[RolFuncionalidad]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[RolFuncionalidad](
	[rolId] [int] NULL,
	[funcionalidadId] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Rol]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Rol](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nombre] [nvarchar](255) NULL,
	[activo] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[ReservaTipoHabitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[ReservaTipoHabitacion](
	[reservaCodigo] [numeric](18, 0) NULL,
	[tipoHabitacionCodigo] [numeric](18, 0) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[ReservaEstado]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[ReservaEstado](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[descripcion] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[ReservaLogTipo]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[ReservaLogTipo](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[descripcion] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[ReservaLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[ReservaLog](
	[reservaCodigo] [numeric](18, 0) NULL,
	[fecha] [datetime] NULL,
	[usuarioId] [int] NULL,
	[tipoId] [int] NOT NULL,
	[motivo] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Reserva]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Reserva](
	[codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[fechaDesde] [datetime] NULL,
	[fechaHasta] [datetime] NULL,
	[regimenCodigo] [numeric](18, 0) NULL,
	[hotelId] [int] NULL,
	[estadoId] [int] NULL,
	[clienteId] [int] NULL,
	[fechaCreacion] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Regimen]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Regimen](
	[codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY, /*Como no hay codigo lo dejo como autoincremental*/
	[descripcion] [nvarchar](255) NULL,
	[precio] [numeric](18, 2) NULL,
	[consumiblesGratis] [bit] NULL,
	[activo] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Pais]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Pais](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nombre] [nvarchar](255) NULL,
	[nacionalidad] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[HotelRegimen]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[HotelRegimen](
	[hotelId] [int] NULL,
	[regimenCodigo] [numeric](18, 0) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[HotelInhabilitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[HotelInhabilitacion](
	[hotelId] [int] NULL,
	[fechaInicio] [datetime] NULL,
	[fechaFin] [datetime] NULL,
	[descripcion] [nvarchar](255) NULL,
	[fechaCreacion] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Hotel]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Hotel](
	[id] [int] IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[nombre] [nvarchar](255) NULL,
	[ciudadId] [int] NULL,
	[direccion] [nvarchar](255) NULL,
	[estrellas] [numeric](18, 0) NULL,
	[mail] [nvarchar](255) NULL,
	[fechaCreacion] [datetime] NULL,
	[telefono] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[HotelIncrementoEstrella]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[HotelIncrementoEstrella](
	[id] [int] IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[incremento] [numeric](18, 0) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Habitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Habitacion](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[hotelId] [int] NULL,
	[tipoCodigo] [numeric](18, 0) NULL,
	[numero] [numeric](18, 0) NULL,
	[piso] [numeric](18, 0) NULL,
	[frente] [nvarchar](50) NULL,/*Hay que cambiar esto, por ahora esta tal como viene (S, N)*/
	[descripcion] [nvarchar](255) NULL,
	[activa] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Funcionalidad]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Funcionalidad](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nombre] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Factura]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Factura](
	[numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[fecha] [datetime] NULL,
	[total] [numeric](18, 2) NULL,
	[estadiaId] [int] NULL,
	[clienteId] [int] NULL,
	[tipoPagoId] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[FacturaItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[FacturaItem](
	[facturaNumero] [numeric](18, 0) NULL,
	[descripcion] [nvarchar](255) NULL,
	[precio] [numeric](18, 2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[FacturaTipoPago]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[FacturaTipoPago](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[descripcion] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[TarjetaDeCredito]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[TarjetaDeCredito](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[facturaNumero] [numeric](18, 0) NULL,
	[numero] [numeric](16, 0) NULL,
	[codigo] [nvarchar](10) NULL,
	[fechaVencimiento] [datetime] NULL,
	[codigoSeguridad] [numeric](4, 0) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[EstadiaConsumible]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[EstadiaConsumible](
	[estadiaId] [int] NULL,
	[consumibleCodigo] [numeric](18, 0) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[EstadiaCliente]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[EstadiaCliente](
	[estadiaId] [int] NULL,
	[clienteId] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Estadia]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Estadia](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[reservaCodigo] [numeric](18, 0) NULL,
	[fechaDesde] [datetime] NULL,
	[fechaHasta] [datetime] NULL,
	[usuarioCheckInId] [int] NULL,
	[usuarioCheckOutId] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Consumible]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Consumible](
	[codigo] [numeric](18, 0) NOT NULL PRIMARY KEY,
	[descripcion] [nvarchar](255) NULL,
	[precio] [numeric](18, 2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Cliente]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Cliente](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[tipoDocumentoId] [int] NULL,
	[numeroDocumento] [numeric](18, 0) NULL,
	[nombre] [nvarchar](255) NULL,
	[apellido] [nvarchar](255) NULL,
	[fechaNacimiento] [datetime] NULL,
	[mail] [nvarchar](255) NULL,
	[direccion] [nvarchar](255) NULL,
	[nacionalidadId] [int] NULL,
	[habilitado] [bit] NULL,
	[telefono] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Frutillitas].[Ciudad]') AND type in (N'U'))
BEGIN
CREATE TABLE [Frutillitas].[Ciudad](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nombre] [nvarchar](255) NULL,
	[paisId] [int] NULL
) ON [PRIMARY]
END
GO

/*****************************************************/


/******************* CONSTRAINS *********************/
ALTER TABLE [Frutillitas].[UsuarioHotel] ADD CONSTRAINT FK_UsuarioHotel_Hotel FOREIGN KEY (hotelId) REFERENCES [Frutillitas].[Hotel](id)
GO
ALTER TABLE [Frutillitas].[UsuarioHotel] ADD CONSTRAINT FK_UsuarioHotel_Usuario FOREIGN KEY (usuarioId) REFERENCES [Frutillitas].[Usuario](id)
GO
ALTER TABLE [Frutillitas].[UsuarioRol] ADD CONSTRAINT FK_UsuarioRol_Usuario FOREIGN KEY (usuarioId) REFERENCES [Frutillitas].[Usuario](id)
GO
ALTER TABLE [Frutillitas].[UsuarioRol] ADD CONSTRAINT FK_UsuarioRol_Rol FOREIGN KEY (rolId) REFERENCES [Frutillitas].[Rol](id)
GO
ALTER TABLE [Frutillitas].[UsuarioLog] ADD CONSTRAINT FK_UsuarioLog_Usuario FOREIGN KEY (usuarioId) REFERENCES [Frutillitas].[Usuario](id)
GO
ALTER TABLE [Frutillitas].[RolFuncionalidad] ADD CONSTRAINT FK_RolFuncionalidad_Funcionalidad FOREIGN KEY (funcionalidadId) REFERENCES [Frutillitas].[Funcionalidad](id)
GO
ALTER TABLE [Frutillitas].[RolFuncionalidad] ADD CONSTRAINT FK_RolFuncionalidad_Rol FOREIGN KEY (rolId) REFERENCES [Frutillitas].[Rol](id)
GO
ALTER TABLE [Frutillitas].[ReservaTipoHabitacion] ADD CONSTRAINT FK_ReservaTipoHabitacion_Reserva FOREIGN KEY (reservaCodigo) REFERENCES [Frutillitas].[Reserva](codigo)
GO
ALTER TABLE [Frutillitas].[ReservaTipoHabitacion] ADD CONSTRAINT FK_ReservaTipoHabitacion_TipoHabitacion FOREIGN KEY (tipoHabitacionCodigo) REFERENCES [Frutillitas].[TipoHabitacion](codigo)
GO
ALTER TABLE [Frutillitas].[ReservaLog] ADD CONSTRAINT FK_ReservaLog_Reserva FOREIGN KEY (reservaCodigo) REFERENCES [Frutillitas].[Reserva](codigo)
GO
ALTER TABLE [Frutillitas].[ReservaLog] ADD CONSTRAINT FK_ReservaLog_Usuario FOREIGN KEY (usuarioId) REFERENCES [Frutillitas].[Usuario](id)
GO
ALTER TABLE [Frutillitas].[ReservaLog] ADD CONSTRAINT FK_ReservaLog_Tipo FOREIGN KEY (tipoId) REFERENCES [Frutillitas].[ReservaLogTipo](id)
GO
ALTER TABLE [Frutillitas].[Reserva] ADD CONSTRAINT FK_Reserva_Regimen FOREIGN KEY (regimenCodigo) REFERENCES [Frutillitas].[Regimen](codigo)
GO
ALTER TABLE [Frutillitas].[Reserva] ADD CONSTRAINT FK_Reserva_Hotel FOREIGN KEY (hotelId) REFERENCES [Frutillitas].[Hotel](id)
GO
ALTER TABLE [Frutillitas].[Reserva] ADD CONSTRAINT FK_Reserva_Estado FOREIGN KEY (estadoId) REFERENCES [Frutillitas].[ReservaEstado](id)
GO
ALTER TABLE [Frutillitas].[Reserva] ADD CONSTRAINT FK_Reserva_Cliente FOREIGN KEY (clienteId) REFERENCES [Frutillitas].[Cliente](id)
GO
ALTER TABLE [Frutillitas].[HotelRegimen] ADD CONSTRAINT FK_HotelRegimen_Hotel FOREIGN KEY (hotelId) REFERENCES [Frutillitas].[Hotel](id)
GO
ALTER TABLE [Frutillitas].[HotelRegimen] ADD CONSTRAINT FK_HotelRegimen_Regimen FOREIGN KEY (regimenCodigo) REFERENCES [Frutillitas].[Regimen](codigo)
GO
ALTER TABLE [Frutillitas].[HotelInhabilitacion] ADD CONSTRAINT FK_HotelInhabilitacion_Hotel FOREIGN KEY (hotelId) REFERENCES [Frutillitas].[Hotel](id)
GO
ALTER TABLE [Frutillitas].[Hotel] ADD CONSTRAINT FK_Hotel_Ciudad FOREIGN KEY (ciudadId) REFERENCES [Frutillitas].[Ciudad](id)
GO
ALTER TABLE [Frutillitas].[Habitacion] ADD CONSTRAINT FK_Habitacion_Hotel FOREIGN KEY (hotelId) REFERENCES [Frutillitas].[Hotel](id)
GO
ALTER TABLE [Frutillitas].[Habitacion] ADD CONSTRAINT FK_Habitacion_TipoHabitacion FOREIGN KEY (tipoCodigo) REFERENCES [Frutillitas].[TipoHabitacion](codigo)
GO
ALTER TABLE [Frutillitas].[Habitacion] ADD CONSTRAINT UQ_Habitacion_Hotel_Numero UNIQUE (hotelId, numero)
GO
ALTER TABLE [Frutillitas].[Factura] ADD CONSTRAINT FK_Factura_Estadia FOREIGN KEY (estadiaId) REFERENCES [Frutillitas].[Estadia](id)
GO
ALTER TABLE [Frutillitas].[Factura] ADD CONSTRAINT FK_Factura_TipoPago FOREIGN KEY (tipoPagoId) REFERENCES [Frutillitas].[FacturaTipoPago](id)
GO
ALTER TABLE [Frutillitas].[Factura] ADD CONSTRAINT FK_Factura_Cliente FOREIGN KEY (clienteId) REFERENCES [Frutillitas].[Cliente](id)
GO
ALTER TABLE [Frutillitas].[FacturaItem] ADD CONSTRAINT FK_FacturaItem_Factura FOREIGN KEY (facturaNumero) REFERENCES [Frutillitas].[Factura](numero)
GO
ALTER TABLE [Frutillitas].[TarjetaDeCredito] ADD CONSTRAINT FK_TarjetaDeCredito_Factura FOREIGN KEY (facturaNumero) REFERENCES [Frutillitas].[Factura](numero)
GO
ALTER TABLE [Frutillitas].[EstadiaConsumible] ADD CONSTRAINT FK_EstadiaConsumible_Estadia FOREIGN KEY (estadiaId) REFERENCES [Frutillitas].[Estadia](id)
GO
ALTER TABLE [Frutillitas].[EstadiaConsumible] ADD CONSTRAINT FK_EstadiaConsumible_Consumible FOREIGN KEY (consumibleCodigo) REFERENCES [Frutillitas].[Consumible](codigo)
GO
ALTER TABLE [Frutillitas].[EstadiaCliente] ADD CONSTRAINT FK_EstadiaCliente_Estadia FOREIGN KEY (estadiaId) REFERENCES [Frutillitas].[Estadia](id)
GO
ALTER TABLE [Frutillitas].[EstadiaCliente] ADD CONSTRAINT FK_EstadiaCliente_Cliente FOREIGN KEY (clienteId) REFERENCES [Frutillitas].[Cliente](id)
GO
ALTER TABLE [Frutillitas].[Estadia] ADD CONSTRAINT FK_Estadia_Reserva FOREIGN KEY (reservaCodigo) REFERENCES [Frutillitas].[Reserva](codigo)
GO
ALTER TABLE [Frutillitas].[Cliente] ADD CONSTRAINT FK_Cliente_TipoDocumento FOREIGN KEY (tipoDocumentoId) REFERENCES [Frutillitas].[TipoDocumento](id)
GO
ALTER TABLE [Frutillitas].[Cliente] ADD CONSTRAINT FK_Cliente_Pais FOREIGN KEY (nacionalidadId) REFERENCES [Frutillitas].[Pais](id)
GO
ALTER TABLE [Frutillitas].[Ciudad] ADD CONSTRAINT FK_Ciudad_Pais FOREIGN KEY (paisId) REFERENCES [Frutillitas].[Pais](id)
GO
ALTER TABLE [Frutillitas].[Estadia] ADD CONSTRAINT FK_Estadia_UsuarioCheckIn FOREIGN KEY (usuarioCheckInId) REFERENCES [Frutillitas].[Usuario](id)
GO
ALTER TABLE [Frutillitas].[Estadia] ADD CONSTRAINT FK_Estadia_UsuarioCheckOut FOREIGN KEY (usuarioCheckOutId) REFERENCES [Frutillitas].[Usuario](id)
GO

/******************* MIGRATION **********************/
INSERT INTO [Frutillitas].[TipoDocumento] ([nombre]) VALUES ('Pasaporte')
GO

INSERT INTO [Frutillitas].[Pais]([nombre], [nacionalidad]) VALUES ('Argentina', 'Argentino')
GO

INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Usuario')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Hotel')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Habitacion')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Regimen')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Cliente')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Reserva')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Estadia')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('EstadiaConsumible')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Factura')
GO
INSERT INTO [Frutillitas].[Funcionalidad]([nombre]) VALUES ('Listado')
GO

INSERT INTO [Frutillitas].[Rol]([nombre], [activo]) VALUES ('Administrador', 1)
GO
INSERT INTO [Frutillitas].[Rol]([nombre], [activo]) VALUES ('Recepcionista', 1)
GO
INSERT INTO [Frutillitas].[Rol]([nombre], [activo]) VALUES ('Guest', 1)
GO

INSERT INTO [Frutillitas].[RolFuncionalidad]([rolId], [funcionalidadId])
SELECT r.[id], f.[id]
FROM [Frutillitas].[Rol] r, [Frutillitas].[Funcionalidad] f
WHERE r.[nombre] = 'Administrador'
GO

INSERT INTO [Frutillitas].[RolFuncionalidad]([rolId], [funcionalidadId])
SELECT r.[id], f.[id]
FROM [Frutillitas].[Rol] r, [Frutillitas].[Funcionalidad] f
WHERE r.[nombre] = 'Recepcionista' AND f.[nombre] IN ('Cliente', 'Reserva', 'Estadia', 'EstadiaConsumible', 'Factura')
GO

INSERT INTO [Frutillitas].[RolFuncionalidad]([rolId], [funcionalidadId])
SELECT r.[id], f.[id]
FROM [Frutillitas].[Rol] r, [Frutillitas].[Funcionalidad] f
WHERE r.[nombre] = 'Guest' AND f.[nombre] = 'Reserva'
GO

INSERT INTO [Frutillitas].[Usuario]([username], [password], [habilitado]) VALUES ('admin', 0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7, 1)
GO

INSERT INTO [Frutillitas].[UsuarioRol]([usuarioId], [rolId])
SELECT u.[id], r.[id]
FROM [Frutillitas].[Usuario] u, [Frutillitas].[Rol] r
WHERE u.[username] = 'admin' AND r.[nombre] = 'Administrador'
GO

INSERT INTO [Frutillitas].[Usuario]([username], [password], [habilitado]) VALUES ('guest', 0x84983c60f7daadc1cb8698621f802c0d9f9a3c3c295c810748fb048115c186ec, 1)
GO
INSERT INTO [Frutillitas].[UsuarioRol]([usuarioId], [rolId])
SELECT u.[id], r.[id]
FROM [Frutillitas].[Usuario] u, [Frutillitas].[Rol] r
WHERE u.[username] = 'guest' AND r.[nombre] = 'Guest'
GO

INSERT INTO [Frutillitas].[Ciudad]([nombre], [paisId])
SELECT DISTINCT [Hotel_Ciudad], 1 /*El único pais que hay*/
FROM [GD2C2014].[gd_esquema].[Maestra]
GO

INSERT INTO [Frutillitas].[Cliente](
	[tipoDocumentoId],
	[numeroDocumento],
	[nombre],
	[apellido],
	[fechaNacimiento],
	[mail],
	[direccion],
	[nacionalidadId],
	[habilitado],
	[telefono])
SELECT DISTINCT 
	1, /*El único tipo que hay*/
	[Cliente_Pasaporte_Nro],
	[Cliente_Nombre],
    [Cliente_Apellido],
    [Cliente_Fecha_Nac],
    [Cliente_Mail],
    [Cliente_Dom_Calle] + ' ' + CAST([Cliente_Nro_Calle] as nvarchar(255)) + ' ' + CAST([Cliente_Piso] as nvarchar(255)) + ' ' + [Cliente_Depto],
    1/*[Cliente_Nacionalidad]*/,
    1,
    NULL
FROM [GD2C2014].[gd_esquema].[Maestra]
GO

INSERT INTO [Frutillitas].[Consumible]([codigo], [descripcion], [precio])
SELECT DISTINCT [Consumible_Codigo] ,[Consumible_Descripcion] ,[Consumible_Precio]      
FROM [GD2C2014].[gd_esquema].[Maestra] WHERE [Consumible_Codigo] IS NOT NULL
GO

INSERT INTO [Frutillitas].[Regimen]([descripcion], [precio], [consumiblesGratis], [activo])
SELECT DISTINCT [Regimen_Descripcion], [Regimen_Precio], 1, 1
FROM [GD2C2014].[gd_esquema].[Maestra]
WHERE [Regimen_Descripcion] LIKE 'all inclusive%'
GO

INSERT INTO [Frutillitas].[Regimen]([descripcion], [precio], [consumiblesGratis], [activo])
SELECT DISTINCT [Regimen_Descripcion], [Regimen_Precio], 0, 1
FROM [GD2C2014].[gd_esquema].[Maestra]
WHERE [Regimen_Descripcion] NOT LIKE 'all inclusive%'
GO

INSERT INTO [Frutillitas].[Hotel]([ciudadId], [direccion], [estrellas], [mail], [fechaCreacion])
SELECT DISTINCT (SELECT [id] FROM [Frutillitas].[Ciudad] WHERE [nombre] LIKE [Hotel_Ciudad]), [Hotel_Calle] + ' ' + CAST([Hotel_Nro_Calle] as nvarchar(255)), [Hotel_CantEstrella], NULL, GETDATE()
FROM [GD2C2014].[gd_esquema].[Maestra]
GO

UPDATE [Frutillitas].[Hotel] SET [nombre] = ('Hotel ' + [direccion])
GO

INSERT INTO [Frutillitas].[UsuarioHotel]([usuarioId], [hotelId])
SELECT (SELECT [id] FROM [Frutillitas].[Usuario] WHERE [username] = 'admin'), [id]
FROM [Frutillitas].[Hotel]
GO

INSERT INTO [Frutillitas].[HotelIncrementoEstrella]([incremento])
SELECT TOP 1 [Hotel_Recarga_Estrella] FROM [GD2C2014].[gd_esquema].[Maestra]
GO

/*Por ahora dejo un todos contra todos, después hay que preguntar si solo ponemos los minimos*/
INSERT INTO [Frutillitas].[HotelRegimen]([hotelId], [regimenCodigo])
SELECT h.[id], r.[codigo]
FROM [Frutillitas].[Hotel] h, [Frutillitas].[Regimen] r
GO

INSERT INTO [Frutillitas].[TipoHabitacion]([codigo], [descripcion], [porcentual])
SELECT DISTINCT [Habitacion_Tipo_Codigo], [Habitacion_Tipo_Descripcion], [Habitacion_Tipo_Porcentual]
FROM [GD2C2014].[gd_esquema].[Maestra]
GO

INSERT INTO [Frutillitas].[Habitacion]([hotelId], [tipoCodigo], [numero], [piso], [frente], [descripcion], [activa])
SELECT DISTINCT (SELECT [id] FROM [Frutillitas].[Hotel] WHERE [direccion] = [Hotel_Calle] + ' ' + CAST([Hotel_Nro_Calle] as nvarchar(255))), [Habitacion_Tipo_Codigo], [Habitacion_Numero], [Habitacion_Piso], [Habitacion_Frente], NULL/*Ni idea la descripcion*/, 1
FROM [GD2C2014].[gd_esquema].[Maestra]
GO

INSERT INTO [Frutillitas].[ReservaEstado]([descripcion]) VALUES ('Correcta')
GO
INSERT INTO [Frutillitas].[ReservaEstado]([descripcion]) VALUES ('Modificada')
GO
INSERT INTO [Frutillitas].[ReservaEstado]([descripcion]) VALUES ('Cancelada-Recepcion')
GO
INSERT INTO [Frutillitas].[ReservaEstado]([descripcion]) VALUES ('Cancelada-Cliente')
GO
INSERT INTO [Frutillitas].[ReservaEstado]([descripcion]) VALUES ('Cancelada-No-Show')
GO
INSERT INTO [Frutillitas].[ReservaEstado]([descripcion]) VALUES ('Efectivizada')
GO

INSERT INTO [Frutillitas].[ReservaLogTipo]([descripcion]) VALUES ('Creacion')
GO
INSERT INTO [Frutillitas].[ReservaLogTipo]([descripcion]) VALUES ('Modificacion')
GO
INSERT INTO [Frutillitas].[ReservaLogTipo]([descripcion]) VALUES ('Cancelacion')
GO

SET IDENTITY_INSERT [Frutillitas].[Reserva] ON
GO
INSERT INTO [Frutillitas].[Reserva]([codigo], [fechaDesde], [fechaHasta], [regimenCodigo], [hotelId], [estadoId], [clienteId], [fechaCreacion])
SELECT DISTINCT [Reserva_Codigo], [Reserva_Fecha_Inicio], DATEADD(day, [Reserva_Cant_Noches], [Reserva_Fecha_Inicio]),	
	(SELECT [codigo] FROM [Frutillitas].[Regimen] WHERE [descripcion] = [Regimen_Descripcion]),
	(SELECT [id] FROM [Frutillitas].[Hotel] WHERE [direccion] = [Hotel_Calle] + ' ' + CAST([Hotel_Nro_Calle] as nvarchar(255))),	
    (SELECT [id] FROM [Frutillitas].[ReservaEstado] WHERE [descripcion] = 'Correcta'),
    c.[id],
	DATEADD(day, -1, [Reserva_Fecha_Inicio])
FROM [GD2C2014].[gd_esquema].[Maestra]
INNER JOIN [Frutillitas].[Cliente] c ON [numeroDocumento] = [Cliente_Pasaporte_Nro] AND [nombre] = [Cliente_Nombre] AND [apellido] = [Cliente_Apellido]
GO
SET IDENTITY_INSERT [Frutillitas].[Reserva] OFF
GO

INSERT INTO [Frutillitas].[ReservaTipoHabitacion]([reservaCodigo], [tipoHabitacionCodigo])
SELECT DISTINCT r.[codigo], [Habitacion_Tipo_Codigo]
FROM [Frutillitas].[Reserva] r
INNER JOIN [GD2C2014].[gd_esquema].[Maestra] ON r.[codigo] = [Reserva_Codigo]
GO

INSERT INTO [Frutillitas].[Estadia]([reservaCodigo], [fechaDesde], [fechaHasta])
SELECT DISTINCT [Reserva_Codigo], [Estadia_Fecha_Inicio], DATEADD(day, [Estadia_Cant_Noches], [Estadia_Fecha_Inicio])
FROM [GD2C2014].[gd_esquema].[Maestra]
WHERE [Estadia_Fecha_Inicio] IS NOT NULL AND [Estadia_Cant_Noches] IS NOT NULL
GO

UPDATE [Frutillitas].[Reserva] SET [estadoId] = (SELECT [id] FROM [Frutillitas].[ReservaEstado] WHERE [descripcion] = 'Efectivizada')
WHERE [codigo] IN (SELECT DISTINCT [reservaCodigo] FROM [Frutillitas].[Estadia])

UPDATE [Frutillitas].[Reserva] SET [estadoId] = (SELECT [id] FROM [Frutillitas].[ReservaEstado] WHERE [descripcion] = 'Cancelada-No-Show')
WHERE [fechaDesde] < GETDATE()

INSERT INTO [Frutillitas].[EstadiaConsumible]([estadiaId], [consumibleCodigo])
SELECT [id], [Consumible_Codigo] FROM [Frutillitas].[Estadia]
INNER JOIN [GD2C2014].[gd_esquema].[Maestra] ON [reservaCodigo] = [Reserva_Codigo]
WHERE [Consumible_Codigo] IS NOT NULL
GO

INSERT INTO [Frutillitas].[FacturaTipoPago]([descripcion]) VALUES ('Efectivo')
GO
INSERT INTO [Frutillitas].[FacturaTipoPago]([descripcion]) VALUES ('Tarjeta')
GO

SET IDENTITY_INSERT [Frutillitas].[Factura] ON
GO
INSERT INTO [Frutillitas].[Factura]([numero], [fecha], [total], [estadiaId], [tipoPagoId], [clienteId])
SELECT DISTINCT [Factura_Nro], [Factura_Fecha], [Factura_Total] + ([Item_Factura_Monto] * [Estadia_Cant_Noches]), e.[id], (SELECT [id] FROM [Frutillitas].[FacturaTipoPago] WHERE [descripcion] = 'Efectivo'), r.[clienteId]
FROM [Frutillitas].[Estadia] e
INNER JOIN [Frutillitas].[Reserva] r ON r.[codigo] = e.[reservaCodigo]
INNER JOIN [GD2C2014].[gd_esquema].[Maestra] ON e.[reservaCodigo] = [Reserva_Codigo]
WHERE [Factura_Nro] IS NOT NULL AND [Consumible_Precio] IS NULL AND [Item_Factura_Monto] IS NOT NULL
GO
SET IDENTITY_INSERT [Frutillitas].[Factura] OFF
GO

INSERT INTO [Frutillitas].[FacturaItem]([facturaNumero], [descripcion], [precio])
SELECT f.[numero], 'Consumible: ' + c.[descripcion], c.[precio]
FROM [Frutillitas].[Factura] f
INNER JOIN [Frutillitas].[Estadia] e ON f.[estadiaId] = e.[id]
INNER JOIN [Frutillitas].[EstadiaConsumible] ec ON ec.[estadiaId] = e.[id]
INNER JOIN [Frutillitas].[Consumible] c ON c.[codigo] = ec.[consumibleCodigo]
GO

INSERT INTO [Frutillitas].[FacturaItem]([facturaNumero], [descripcion], [precio])
SELECT f.[numero], 'Estadia: ' + STR([Estadia_Cant_Noches]) + ' noches', [Item_Factura_Monto] * [Estadia_Cant_Noches]
FROM [Frutillitas].[Factura] f
INNER JOIN [GD2C2014].[gd_esquema].[Maestra] ON [Factura_Nro] = f.[numero]
WHERE [Consumible_Precio] IS NULL AND [Item_Factura_Monto] IS NOT NULL
GO

INSERT INTO [Frutillitas].[EstadiaCliente]([estadiaId], [clienteId])
SELECT e.[id], r.[clienteId]
FROM [Frutillitas].[Estadia] e
INNER JOIN [Frutillitas].[Reserva] r ON e.[reservaCodigo] = r.[codigo]
GO