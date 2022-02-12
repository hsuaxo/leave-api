USE master;  
GO
CREATE DATABASE Permisos
ON
  (NAME = Permisos_data,  
   FILENAME = 'D:\Permisos.mdf', -- UTILIZAR LA RUTA MAS CONVENIENTE
   SIZE = 10,  
   MAXSIZE = 50,  
   FILEGROWTH = 5 )  
  LOG ON  
  (NAME = Permisos_log,  
   FILENAME = 'D:\Permisos.ldf', -- UTILIZAR LA RUTA MAS CONVENIENTE
   SIZE = 5MB,  
   MAXSIZE = 25MB,  
   FILEGROWTH = 5MB );  
GO
CREATE LOGIN [PERMISOS_API_USER] WITH PASSWORD=N'SU2Q8D9PBBG1', 
  DEFAULT_DATABASE=[Permisos], 
  DEFAULT_LANGUAGE=[us_english], 
  CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;
GO
USE [Permisos];
GO
CREATE USER [PERMISOS_API_USER] FOR LOGIN [PERMISOS_API_USER] WITH DEFAULT_SCHEMA=[dbo];
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO [PERMISOS_API_USER]
GO
CREATE TABLE Permiso (
  Id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  NombresEmpleado nvarchar(100) NOT NULL,
  ApellidosEmpleado nvarchar(100) NOT NULL,
  TipoPermiso int NOT NULL,
  FechaPermiso date NOT NULL
);
GO
CREATE TABLE TipoPermiso (
  Id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  Descripcion nvarchar(100) NOT NULL
);
GO
ALTER TABLE Permiso ADD FOREIGN KEY (TipoPermiso) REFERENCES TipoPermiso(Id);
GO
INSERT TipoPermiso (Descripcion)
SELECT 'Enfermedad'
UNION ALL
SELECT 'Diligencia'
UNION ALL
SELECT 'Otro';
GO