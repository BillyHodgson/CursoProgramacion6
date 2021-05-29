CREATE TABLE [dbo].[MarcaVehiculo]
(

	  MarcaVehiculoId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_MArca_Vehiculo PRIMARY KEY  CLUSTERED (MarcaVehiculoId)
	, Descripcion VARCHAR(250) NOT NULL 
	, Estado BIT NOT NULL
	  
) WITH (DATA_COMPRESSION = PAGE)
GO

