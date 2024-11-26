CREATE DATABASE db_Tienda_MASCOTAS;
GO
USE db_Tienda_MASCOTAS;
GO

CREATE TABLE [Mascotas](
[Id] INT NOT NULL IDENTITY (1,1),
[Cod_Mascota] NVARCHAR (50) NOT NULL,
[Nombre] NVARCHAR(50) DEFAULT 'UNNAMED',
[Tipo_Mascota] NVARCHAR(50) NOT NULL,
[Raza] NVARCHAR(50) NOT NULL,
[Edad] INT NOT NULL,

CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Clientes](

[Id] INT NOT NULL IDENTITY (1,1),
[Nombre] NVARCHAR(50) NOT NULL,
[Numero] INT NOT NULL,
[Cedula] NVARCHAR(50) NOT NULL,
[Email] NVARCHAR(150)

CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Mascotas_Clientes](

[Id] INT NOT NULL IDENTITY (1,1),
[Cliente] INT NOT NULL,
[Mascota] INT NOT NULL

CONSTRAINT [PK_Mascotas_Clientes] PRIMARY KEY CLUSTERED ([Id]),
CONSTRAINT [FK_Mascotas] FOREIGN KEY ([Mascota]) REFERENCES [Mascotas] ([Id]) ON DELETE No Action ON UPDATE No Action,
CONSTRAINT [FK_Clientes] FOREIGN KEY ([Cliente]) REFERENCES [Clientes] ([Id]) ON DELETE No Action ON UPDATE No Action
);

GO

CREATE TABLE [Metodos_De_Pagos](

[Id] INT NOT NULL IDENTITY (1,1),
[Tipo_Metodo_Pago] NVARCHAR(100) NOT NULL,

CONSTRAINT [PK_Metodos_De_Pagos] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Facturas](

[Id] INT NOT NULL IDENTITY (1,1),
[Num_Factura] INT NOT NULL,
[Cliente] INT NOT NULL,
[Metodo_De_Pago] INT NOT NULL,
[IVA] DECIMAL(18,2) NOT NULL,
[Total] DECIMAL(18,2) NOT NULL,
[Fecha] DATE DEFAULT GETDATE(),

CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED ([Id]),
CONSTRAINT [FK_Cliente] FOREIGN KEY ([Cliente]) REFERENCES [Clientes] ([Id]),
CONSTRAINT [FK_Metodo_De_Pago] FOREIGN KEY ([Metodo_De_Pago]) REFERENCES [Metodos_De_Pagos] ([Id])
);
GO

CREATE TABLE [Servicios](

[Id] INT NOT NULL IDENTITY (1,1),
[Precio] DECIMAL(18,2) NOT NULL,
[Tipo_Servicio] NVARCHAR(50) NOT NULL,
[Descripcion] NVARCHAR(50),

CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Detalles_Facturas](

[Id] INT NOT NULL IDENTITY (1,1),
[Factura] INT NOT NULL,
[Servicio] INT NOT NULL,
[Mascota] INT NOT NULL,
[Fecha_Servicio] DATE DEFAULT GETDATE(),
[Estado] NVARCHAR(50),
[IVA] DECIMAL(18,2) NOT NULL,
[Precio_Venta] DECIMAL(18,2) NOT NULL,

CONSTRAINT [PK_Detalles_Facturas] PRIMARY KEY CLUSTERED ([Id]),
CONSTRAINT [FK_Facturas] FOREIGN KEY ([Factura]) REFERENCES [Facturas] ([Id]),
CONSTRAINT [FK_Servicio] FOREIGN KEY ([Servicio]) REFERENCES [Servicios] ([Id]),
CONSTRAINT [FK_Mascota] FOREIGN KEY ([Mascota]) REFERENCES [Mascotas] ([Id])
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
VALUES  ('134359226','Sara',525321,'sara@gmail.com'),
        ('211254983','Luz',623541,'luz@gmail.com'),
        ('658971546','Juan',782136,'juan@gmail.com'),
        ('102365789','Maria',102548,'maria@gmail.com'),
        ('107895367','Felipe',698712,'felipe@gmail.com');

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
(10,3,1,0.0,55000.0,'2-08-2024'),
(11,4,2,0.0,90000.0,'1-09-2024'),
(12,2,1,0.0,40000.0,'3-09-2024'),
(20,3,3,0.0,50000.0,'3-09-2024');
GO
 INSERT INTO Detalles_Facturas (Factura,Servicio,Mascota,Fecha_Servicio,Estado,IVA,Precio_Venta)
VALUES
(1,1,2,'2-08-2024','Terminado',0.0,55000),
(2,2,4,'1-09-2024','Terminado',0.0,40000),
(2,3,4,'1-09-2024','Terminado',0.0,50000),
(3,3,1,'3-09-2024','En proceso',0.0,50000),
(4,3,2,'2-09-2024','En proceso',0.0,50000);
GO