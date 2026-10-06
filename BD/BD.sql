--DROP DATABASE AGENDA;
GO
create database AGENDA; 
GO
use AGENDA; 
GO  
--DROP TABLE AGENDA_CONTACTOS
CREATE TABLE AGENDA_CONTACTOS(
	ID_CONTACTO INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_AGENDA_CONTACTOS PRIMARY KEY (ID_CONTACTO),
	NOMBRE VARCHAR(100) NOT NULL,
	APELLIDO VARCHAR(100) NOT NULL,
	TELEFONO VARCHAR(30) NOT NULL,
	CORREO VARCHAR(150) NOT NULL,
	--Auditoria
	FECHA_ADICION DATETIME NOT NULL DEFAULT GETDATE(), 
	ADICIONADO_POR VARCHAR(50) NOT NULL, 
	FECHA_MODIFICACION DATETIME NULL, 
	MODIFICADO_POR VARCHAR(50) NULL, 
);
GO
  
--------------------------------------------------------------CRUD
--------------------------------------Procedimiento para Crear registros
create procedure sp_CrearContacto
	@NOMBRE VARCHAR(100), 
	@APELLIDO VARCHAR(100),
	@TELEFONO VARCHAR(30),
	@CORREO VARCHAR(150),
	@ADICIONADO_POR VARCHAR(50)
as 
begin 
--Es especialmente útil cuando los procedimientos forman parte de una aplicación, 
--porque evita que mensajes como (1 row affected) interfieran con la respuesta que espera la aplicación.
SET NOCOUNT ON; 

 insert into AGENDA_CONTACTOS (NOMBRE, APELLIDO, TELEFONO, CORREO,FECHA_ADICION, ADICIONADO_POR)
 values (@NOMBRE, @APELLIDO, @TELEFONO, @CORREO, GETDATE(), @ADICIONADO_POR);
 
 -- Retornar el ID generado
 SELECT SCOPE_IDENTITY() AS ID_CONTACTO;
end; 
go

select * from AGENDA_CONTACTOS;

EXEC sp_CrearContacto 'Aome', 'Cascante', '27712771', 'aome@gmail.com', 'admin';
EXEC sp_CrearContacto 'Nanami', 'Cascante', '87872121', 'nanami@gmail.com', 'admin';
EXEC sp_CrearContacto 'Saitama', 'Cascante', '61615353', 'saitama@gmail.com', 'admin';
EXEC sp_CrearContacto 'Saitama Antonio', 'Cascante', '61615353', 'saitama@gmail.com', 'admin';

select * from AGENDA_CONTACTOS;
go
--------------------------------------Procedimiento para Leer registros (Read)
create procedure sp_ConsultarContactos
as 
begin 
    select ID_CONTACTO, NOMBRE, APELLIDO, TELEFONO, CORREO,
	       FECHA_ADICION, ADICIONADO_POR, FECHA_MODIFICACION, MODIFICADO_POR 
	from AGENDA_CONTACTOS; 
end; 
go
create procedure sp_ConsultarContactoPorTelefono 
		@TELEFONO VARCHAR(30)
as 
begin 
    select ID_CONTACTO, NOMBRE, APELLIDO, TELEFONO, CORREO,
	       FECHA_ADICION, ADICIONADO_POR, FECHA_MODIFICACION, MODIFICADO_POR 
	from AGENDA_CONTACTOS
	where TELEFONO = @TELEFONO;
end; 
go
create procedure sp_ConsultarContactoPorCorreo
		@CORREO VARCHAR(150)
as 
begin 
    select ID_CONTACTO, NOMBRE, APELLIDO, TELEFONO, CORREO,
	       FECHA_ADICION, ADICIONADO_POR, FECHA_MODIFICACION, MODIFICADO_POR 
	from AGENDA_CONTACTOS
	where CORREO =@CORREO;
end; 
go 
 
create procedure sp_ConsultarContactoPorNombre
		@NOMBRE VARCHAR(100)
as 
begin 
    select ID_CONTACTO, NOMBRE, APELLIDO, TELEFONO, CORREO,
	       FECHA_ADICION, ADICIONADO_POR, FECHA_MODIFICACION, MODIFICADO_POR 
	from AGENDA_CONTACTOS
	where  UPPER(NOMBRE  ) like UPPER('%'+@NOMBRE+'%');
end; 
go
select * 
from AGENDA_CONTACTOS where  UPPER(NOMBRE) like '%sai%';
 
EXEC sp_ConsultarContactoPorTelefono '87872121';
EXEC sp_ConsultarContactoPorCorreo 'saitama@gmail.com';
EXEC sp_ConsultarContactoPorNombre 'sai';
go
--------------------------------------Procedimiento para Actualizar Registros (Update) 
create procedure sp_ActualizarContacto
	@ID_CONTACTO INT, 
	@NOMBRE VARCHAR(100), 
	@APELLIDO VARCHAR(100),
	@TELEFONO VARCHAR(30),
	@CORREO VARCHAR(150),
	@MODIFICADO_POR VARCHAR(50)
as  	
begin 
UPDATE AGENDA_CONTACTOS
		SET  NOMBRE=@NOMBRE, 
		     APELLIDO=@APELLIDO,
			 TELEFONO =@TELEFONO,
			 CORREO=@CORREO, 
			 MODIFICADO_POR = @MODIFICADO_POR
		WHERE ID_CONTACTO = @ID_CONTACTO; 
end; 
go
EXEC sp_ConsultarContactos;
EXEC sp_ActualizarContacto 4, 'Akamaru', 'Cascante', '61696169', 'akamaru@gmail.com', 'soporte';
go
--------------------------------------Procedimiento para Eliminar Registros (Delete)
create procedure sp_EliminarContacto
	@ID_CONTACTO INT
as 
begin 
	delete AGENDA_CONTACTOS
	where ID_CONTACTO = @ID_CONTACTO;
end;

go
EXEC sp_ConsultarContactos;
EXEC sp_EliminarContacto 4;
EXEC sp_ConsultarContactos;