CREATE DATABASE db_TiendaMascotas;
GO
USE db_TiendaMascotas;
GO

CREATE TABLE [Mascotas](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Cod_Mascota] NVARCHAR(50) NOT NULL,
[Nombre] NVARCHAR(50) DEFAULT '',
[Tipo_Mascota] NVARCHAR(50) NOT NULL,
[Raza] NVARCHAR(50) NOT NULL,
[Edad] INT NOT NULL
);
GO

CREATE TABLE [Clientes](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre] NVARCHAR(50) NOT NULL,
[Numero] NVARCHAR(50) NOT NULL,
[Cedula] NVARCHAR(50) NOT NULL,
[Email] NVARCHAR(150)
);
GO

CREATE TABLE [Mascotas_Clientes](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Cliente] INT NOT NULL REFERENCES [Clientes] ([Id]),
[Mascota] INT NOT NULL REFERENCES [Mascotas] ([Id])
);
GO

CREATE TABLE [Metodos_De_Pagos](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Tipo_Metodo_Pago] NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE [Facturas](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Num_Factura] NVARCHAR(50) NOT NULL,
[Cliente] INT NOT NULL REFERENCES [Clientes] ([Id]),
[Metodo_De_Pago] INT NOT NULL REFERENCES [Metodos_De_Pagos] ([Id]),
[IVA] DECIMAL(18,2) NOT NULL,
[Total] DECIMAL(18,2) NOT NULL,
[Fecha] DATE DEFAULT GETDATE()
);
GO

CREATE TABLE [Servicios](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Precio] DECIMAL(18,2) NOT NULL,
[Tipo_Servicio] NVARCHAR(50) NOT NULL,
[Descripcion] NVARCHAR(50)
);
GO

CREATE TABLE [Detalles_Facturas](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Factura] INT NOT NULL REFERENCES [Facturas] ([Id]),
[Servicio] INT NOT NULL REFERENCES [Servicios] ([Id]),
[Mascota] INT NOT NULL REFERENCES [Mascotas] ([Id]),
[Fecha_Servicio] DATE DEFAULT GETDATE(),
[Estado] NVARCHAR(50),
[IVA] DECIMAL(18,2) NOT NULL,
[Precio_Venta] DECIMAL(18,2) NOT NULL
);
GO

CREATE TABLE [Auditorias](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Usuario] NVARCHAR(50) NOT NULL,
[Entidad] NVARCHAR(50) NOT NULL,
[Operacion] NVARCHAR(50) NOT NULL,
[Fecha] DATE DEFAULT GETDATE(),
[Detalles] NVARCHAR(150)
);
GO

CREATE TABLE [Roles](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre] NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Usuarios](
[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Email] NVARCHAR(50) NOT NULL,
[Contraseña] NVARCHAR(50) NOT NULL,
[Rol] INT NOT NULL REFERENCES [Roles] ([Id])
);
GO

INSERT INTO Mascotas(Cod_Mascota,Nombre,Tipo_Mascota,Raza,Edad)
VALUES  ('1234','Princesa','Perro','Criollo',2),
        ('5678','Dakota','Perro','Pinscher',5),
        ('9101','Toby','Perro','Criollo',8),
        ('6521','Rayo','Gato','Persa',1),
        ('3981','Tomas','Gato','Criollo',11);
GO


INSERT INTO Clientes(Cedula, Nombre, Numero, Email)
VALUES  ('134359226','Sara','525321','sara@gmail.com'),
        ('211254983','Luz','623541','luz@gmail.com'),
        ('658971546','Juan','782136','juan@gmail.com'),
        ('102365789','Maria','102548','maria@gmail.com'),
        ('107895367','Felipe','698712','felipe@gmail.com');

GO

INSERT INTO Metodos_De_Pagos(Tipo_Metodo_Pago)
VALUES  ('Efectivo'),
		('Tarjeta'),
		('Pse'),
		('Transferencia');
GO
		
INSERT INTO Servicios(Precio,Tipo_Servicio,Descripcion)
VALUES  (55000.00,'Baño','Se utiliza jabon neutro'),
		(40000.00,'Vacuna','Se aplica dosis según edad'),
		(50000.00,'Corte','Se utiliza crema piel sensible'),
		(120000.00,'Guarderia','Los dias que se requieran');

GO


INSERT INTO [Mascotas_Clientes] (Cliente,Mascota)
VALUES 
(2,1),
(3,1),
(1,2),
(4,4),
(3,2);
GO
INSERT INTO Facturas (Num_Factura,Cliente,Metodo_De_Pago,IVA,Total,Fecha)
VALUES
('10',3,1,0.0,55000.0,'2-08-2024'),
('11',4,2,0.0,90000.0,'1-09-2024'),
('12',2,1,0.0,40000.0,'3-09-2024'),
('20',3,3,0.0,50000.0,'3-09-2024');
GO
 INSERT INTO Detalles_Facturas (Factura,Servicio,Mascota,Fecha_Servicio,Estado,IVA,Precio_Venta)
VALUES
(1,1,2,'2-08-2024','Terminado',0.0,55000),
(2,2,4,'1-09-2024','Terminado',0.0,40000),
(2,3,4,'1-09-2024','Terminado',0.0,50000),
(3,3,1,'3-09-2024','En proceso',0.0,50000),
(4,3,2,'2-09-2024','En proceso',0.0,50000);
GO
INSERT INTO Roles (Nombre)
VALUES
('Admin'),
('Trabajador');
GO

INSERT INTO Usuarios(Email,Contraseña,Rol)
VALUES  ('sofia@gmail.com','1234',1),
        ('susi@gmail.com','susi1',2);

GO