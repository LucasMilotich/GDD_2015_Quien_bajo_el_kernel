CREATE PROCEDURE QUIEN_BAJO_EL_KERNEL.INSERT_ROL [(@nombre varchar(255), @activo BIT)]
AS 
BEGIN

insert into QUIEN_BAJO_EL_KERNEL.ROL (nombre,activo) values (@nombre,@activo)

END




/*INSERT INTO [GD1C2015].[QUIEN_BAJO_EL_KERNEL].[ROL]
           ([id]
           ,[nombre]
           ,[activo])
     VALUES
           (<id, numeric(10,0),>
           ,<nombre, varchar(255),>
           ,<activo, numeric(1,0),>)
GO*/

