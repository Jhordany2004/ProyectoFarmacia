drop database Farmacia;
Create database Farmacia;
Use Farmacia;

ALTER AUTHORIZATION ON DATABASE::Farmacia TO sa
GO
	-- Tabla de Usuarios
	CREATE TABLE Usuarios (
		UsuarioID INT PRIMARY KEY IDENTITY(1,1),
		Nombre VARCHAR(50) NOT NULL,
		Contraseña VARCHAR(50) NOT NULL
	);
	-- Tabla de Categorias
	CREATE TABLE Categorias (
		CategoriaID INT PRIMARY KEY IDENTITY(1,1),
		Nombre VARCHAR(50) NOT NULL
	);

	-- Tabla de Clientes
	CREATE TABLE Clientes (
		ClienteID INT PRIMARY KEY IDENTITY(1,1),
		Nombre VARCHAR(50) NOT NULL,
		DNI VARCHAR(20) NOT NULL,
		CategoriaID INT,
		FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID)
	);
	select * from Usuarios
	-- Tabla de Ventas
	CREATE TABLE Ventas (
		VentaID INT PRIMARY KEY IDENTITY(1,1),
		ClienteID INT,
		UsuarioID INT NULL,
		FechaVenta DATE NOT NULL,
		TotalVenta DECIMAL(10, 2) NOT NULL,
		FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
		FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
	);

	-- Tabla de Detalles de Venta
	CREATE TABLE DetallesVenta (
		DetalleID INT PRIMARY KEY IDENTITY(1,1),
		VentaID INT,
		Cantidad INT NOT NULL,
		PrecioUnitario DECIMAL(10, 2) NOT NULL,
		Descuento DECIMAL(5, 2),  -- Descuento como porcentaje, puede ser NULL
		TotalProducto DECIMAL(10, 2) NOT NULL,
		FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID)
	);
	select * from DetallesVenta
	-- Tabla de Medicina
	CREATE TABLE Medicina (
			MedicinaID INT PRIMARY KEY IDENTITY(1,1),
			Nombre VARCHAR(100) NOT NULL,
			Descripcion VARCHAR(255),
			PrecioVenta DECIMAL(10, 2) NOT NULL,
			Stock INT NOT NULL
		);

	-- Añadir la columna MedicinaID a la tabla DetallesVenta
	ALTER TABLE DetallesVenta
	ADD MedicinaID INT,
	FOREIGN KEY (MedicinaID) REFERENCES Medicina(MedicinaID);

	-- Tabla de Proveedores
	CREATE TABLE Proveedores (
		ProveedorID INT PRIMARY KEY IDENTITY(1,1),
		NombreProveedor VARCHAR(100) NOT NULL,
		DireccionProveedor VARCHAR(255),
		TelefonoProveedor VARCHAR(20)
	);

	-- Modificar la tabla de Medicina
	ALTER TABLE Medicina
	ADD ProveedorID INT NULL,
	FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID);



	------------------Inserciones--------------------
	-- Insertar datos en la tabla de Proveedores
	INSERT INTO Proveedores (NombreProveedor, DireccionProveedor, TelefonoProveedor)
	VALUES
		('ABC Pharmaceuticals', '123 Main Street, Cityville', '555-1234'),
		('XYZ Medical Supplies', '456 Oak Avenue, Townburg', '555-5678'),
		('MediCorp Ltd.', '789 Elm Road, Villagetown', '555-9876'),
	    ('Health Solutions Inc.', '101 Pine Lane, Hamletville', '555-4321'),
		('PharmaTech Innovations', '202 Cedar Street, Boroughburg', '555-8765'),
		('Global Health Distributors', '303 Maple Drive, Settlement City', '555-2345'),
		('Sunrise Pharmaceuticals', '404 Birch Avenue, Townsville', '555-6789'),
	    ('MediLink Solutions', '505 Oak Lane, Cityburg', '555-3456'),
		('Everwell Pharma', '606 Pine Road, Villagetown', '555-7890'),
	    ('MediSupply Co.', '707 Elm Lane, Hamletville', '555-1234');

	-- Insertar usuarios en la tabla de Usuarios
	INSERT INTO Usuarios (Nombre, Contraseña)
	VALUES 
		('Admind', 'clave');

	-- Insertar categorías en la tabla de Categorías
	INSERT INTO Categorias (Nombre)
	VALUES 
		('Regular'),
		('Afiliado');

	-- Insertar clientes en la tabla de Clientes
	INSERT INTO Clientes (Nombre, DNI, CategoriaID)
	VALUES 
		('Pablo', '76843911A', 1), -- Regular
		('Isabella', '91485673B', 2), -- Afiliado
		('Mateo', '84512699C', 1), -- Regular
		('Valentina', '76158943D', 2), -- Afiliado
		('Santiago', '76458912E', 1), -- Regular
		('Daniel', '12312312F', 2), -- Afiliado
		('Nicolás', '45645656G', 1), -- Regular
		('Mía', '78978989H', 2), -- Afiliado
		('Lucas', '11010022I', 1), -- Regular
		('Alejandro', '62375289J', 2),-- Afiliado
		('Gabriela', '74619030D', 1),-- Regular
		('Juan', '73198422K', 2),-- Afiliado
		('Diego', '65874921L', 1),-- Regular
		('Andrés', '89541232N', 2),-- Afiliado
		('Felipe', '85614273M', 1),-- Regular
		('Isabel', '68712456X', 2),-- Afiliado
		('Olivia', '75128436C', 1),-- Regular
		('Carlos', '83794655V', 2),-- Afiliado
		('Ricardo', '72491833B', 1),-- Regular
		('Jorge', '84126834G', 2);-- Afiliado
		
	-- Insertar medicinas en la tabla Medicina
	INSERT INTO Medicina (Nombre, Descripcion, PrecioVenta, Stock)
	VALUES 
	        ('Paracetamol', 'Alivio del dolor y la fiebre', 5.99, 100),
		    ('Ibuprofeno', 'Antiinflamatorio y analgésico', 7.50, 80),
		    ('Amoxicilina', 'Antibiótico de amplio espectro', 12.75, 50),
		    ('Omeprazol', 'Inhibidor de la bomba de protones', 9.25, 60),
		    ('Loratadina', 'Antihistamínico para alergias', 6.99, 120),
		    ('Aspirina', 'Alivio del dolor y antiinflamatorio', 4.99, 90),
	        ('Ranitidina', 'Antagonista de los receptores H2', 8.50, 70),
	        ('Cetirizina', 'Antihistamínico para alergias', 5.75, 110),
	        ('Diazepam', 'Ansiolítico y relajante muscular', 10.25, 40),
	        ('Metformina', 'Control de la glucosa en la diabetes', 7.99, 85),
            ('Salbutamol', 'Broncodilatador para problemas respiratorios', 6.99, 60),
	        ('Hidroclorotiazida', 'Diurético para la presión arterial', 8.50, 75),
	        ('Atorvastatina', 'Reducción del colesterol', 11.75, 30),
	        ('Escitalopram', 'Antidepresivo', 9.25, 55),
	        ('Losartan', 'Bloqueador de los receptores de angiotensina', 12.99, 40),
            ('Clopidogrel', 'Anticoagulante', 15.99, 20),
	        ('Levotiroxina', 'Hormona tiroidea', 10.50, 65),
	        ('Ciprofloxacino', 'Antibiótico de amplio espectro', 8.75, 45),
	        ('Fluoxetina', 'Antidepresivo', 9.25, 55),
	        ('Tramadol', 'Analgésico opioide', 12.99, 30),
            ('Furosemida', 'Diurético para la presión arterial', 7.99, 80),
	        ('Esomeprazol', 'Inhibidor de la bomba de protones', 11.50, 25),
	        ('Hidromorfona', 'Analgésico opioide', 15.75, 15),
	        ('Prednisona', 'Corticosteroide', 8.25, 50),
	        ('Mometasona', 'Corticosteroide tópico', 14.99, 35);

	----------------INSERTAR VENTAS------------------------

	     -- INSERTAR VENTA 1
	INSERT INTO Ventas (ClienteID, UsuarioID, FechaVenta, TotalVenta)
	VALUES 
		(1, 1, '2023-11-08', (2 * 5.99) + (1 * 7.50)); -- Cliente1, Usuario1
		-- Insertar detalles de venta 1
	INSERT INTO DetallesVenta (VentaID, Cantidad, PrecioUnitario, Descuento, TotalProducto, MedicinaID)
	VALUES 
		(SCOPE_IDENTITY(), 2, 5.99, 0.1, (2 * 5.99), 1); -- Venta1, Paracetamol, 2 unidades, $5.99 c/u, 10% descuento, total $11.38


		-- INSERTAR VENTA 2
	INSERT INTO Ventas (ClienteID, UsuarioID, FechaVenta, TotalVenta)
	VALUES
		(2, 1, '2023-11-09', (3 * 12.75)); -- Cliente2, Usuario1
		-- Insertar detalles de venta 2
	INSERT INTO DetallesVenta (VentaID, Cantidad, PrecioUnitario, Descuento, TotalProducto, MedicinaID)
	VALUES 
		(SCOPE_IDENTITY(), 1, 7.50, NULL, (1 * 7.50), 2); -- Venta2, Ibuprofeno, 1 unidad, $7.50 c/u, sin descuento, total $7.50


		-- INSERTAR VENTA 3
	INSERT INTO Ventas (ClienteID, UsuarioID, FechaVenta, TotalVenta)
	VALUES
		(3, 1, '2023-11-10', (1 * 9.25) + (2 * 6.99)); -- Cliente3, Usuario1
		-- Insertar detalles de venta 3
	INSERT INTO DetallesVenta (VentaID, Cantidad, PrecioUnitario, Descuento, TotalProducto, MedicinaID)
	VALUES 
		(SCOPE_IDENTITY(), 3, 12.75, NULL, (3 * 12.75), 3); -- Venta3, Amoxicilina, 3 unidades, $12.75 c/u, sin descuento, total $38.25


		-- INSERTAR VENTA 4
	INSERT INTO Ventas (ClienteID, UsuarioID, FechaVenta, TotalVenta)
	VALUES
		(4, 1, '2023-11-11', (5 * 5.99)); -- Cliente4, Usuario1
		-- Insertar detalles de venta 4
	INSERT INTO DetallesVenta (VentaID, Cantidad, PrecioUnitario, Descuento, TotalProducto, MedicinaID)
	VALUES 
		(SCOPE_IDENTITY(), 1, 9.25, 0.05, (1 * 9.25), 4); -- Venta4, Omeprazol, 1 unidad, $9.25 c/u, 5% descuento, total $8.79


		-- INSERTAR VENTA 5
	INSERT INTO Ventas (ClienteID, UsuarioID, FechaVenta, TotalVenta)
	VALUES
		(5, 1, '2023-11-12', 0); -- Cliente5, Usuario1
		-- Insertar detalles de venta 5
	INSERT INTO DetallesVenta (VentaID, Cantidad, PrecioUnitario, Descuento, TotalProducto, MedicinaID)
	VALUES 
		(SCOPE_IDENTITY(), 2, 6.99, NULL, (2 * 6.99), 5); -- Venta5, Loratadina, 2 unidades, $6.99 c/u, sin descuento, total $13.98

	


	--Creacion del Procedimiento almacenado para el Proveedor--
	create PROCEDURE spEditaProvedor
    (@ProveedorID int,
     @NombreProveedor varchar(100),
     @DireccionProveedor varchar(255),
     @TelefonoProveedor varchar(20)
     )
     as
    begin
    update Proveedores set
    NombreProveedor=@NombreProveedor,
    DireccionProveedor = @DireccionProveedor,
    TelefonoProveedor= @TelefonoProveedor
    where ProveedorID =@ProveedorID

    end
    go