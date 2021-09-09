USE neptuno
GO

-- CREATE TABLES

CREATE TABLE  Productos (
	IdProducto INT IDENTITY ,
	NombreProducto VARCHAR(30), 
	IdProveedor INT,
	IdCategoria INT, 
	PrecioUnidad MONEY, 
	Stock INT,
	Suspendido INT,
	CostoUnidad MONEY,
	CONSTRAINT PK_Productos PRIMARY KEY (IdProducto)
)

CREATE TABLE Proveedores (
	IdProveedor INT IDENTITY,
	NombreProveedor VARCHAR(100),
	CONSTRAINT PK_Proveedores PRIMARY KEY (IdProveedor)
)

CREATE TABLE Categorias (
	IdCategoria INT IDENTITY,
	NombreCategoria VARCHAR(100),
	CONSTRAINT PK_Categorias PRIMARY KEY (IdCategoria)
)



--EXEC sp_helptext usp_Producto_Actualizar

-- DROP PROCEDURE --

IF EXISTS (SELECT * FROM sysobjects WHERE name='usp_Proveedor_Listar')
  DROP PROCEDURE usp_Proveedor_Listar
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='usp_Categoria_Listar')
  DROP PROCEDURE usp_Categoria_Listar
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='usp_Producto_Listar')
  DROP PROCEDURE usp_Producto_Listar
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='usp_Producto_Buscar')
  DROP PROCEDURE usp_Producto_Buscar
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='usp_Producto_Adicionar')
  DROP PROCEDURE usp_Producto_Adicionar
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='usp_Producto_Eliminar')
  DROP PROCEDURE usp_Producto_Eliminar
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='usp_Producto_Actualizar')
  DROP PROCEDURE usp_Producto_Actualizar
GO

-- CREATE PROCEDURE --
--SP Listar Proveedores
CREATE PROC usp_Proveedor_Listar
AS
BEGIN
  SELECT * FROM Proveedores
END
GO

--SP Listar Categorias
CREATE PROC usp_Categoria_Listar
AS
BEGIN
  SELECT * FROM Categorias
END
GO

--SP Listar Productos
CREATE PROCEDURE usp_Producto_Listar
AS
BEGIN
  SELECT * FROM Productos -- ORDER BY EmployeeID DESC
END
GO

--SP Buscar Producto
CREATE PROC usp_Producto_Buscar
  @idProducto AS INT
AS
BEGIN
  SELECT *
    FROM Productos 
    WHERE IdProducto = @idProducto
END
GO

--SP Adicionar productos 
CREATE PROC usp_Producto_Adicionar
  @Nombre NVARCHAR(40),
  @IdProveedor INT,
  @IdCategoria INT,
  @Precio MONEY,
  @Stock SMALLINT,
  @IdProducto INT OUTPUT
AS
BEGIN
  INSERT INTO Productos (NombreProducto, IdProveedor, IdCategoria, PrecioUnidad, Stock,Suspendido,CostoUnidad)
    VALUES (@Nombre,@IdProveedor,@IdCategoria,@Precio,@Stock,0,0)
	SET @IdProducto = @@IDENTITY
END
GO

--SP Eliminar producto
CREATE PROC usp_Producto_Eliminar
  @idProducto AS INT
AS
BEGIN
  DELETE FROM Productos WHERE IdProducto = @idProducto
END
GO

--SP Actualizar productos 
CREATE PROC usp_Producto_Actualizar
  @Nombre VARCHAR(40),
  @IdProveedor INT,
  @IdCategoria INT,
  @Precio MONEY,
  @Stock INT,
  @IdProducto INT OUTPUT
AS
BEGIN
  UPDATE productos SET NombreProducto = @Nombre,
                       IdProveedor = @IdProveedor , 
					   IdCategoria =@IdCategoria,
					   PrecioUnidad = @Precio,
					   Stock=@Stock
			     WHERE IdProducto = @IdProducto;
  RETURN 0
END
GO


