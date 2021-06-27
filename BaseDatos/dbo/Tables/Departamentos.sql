﻿CREATE TABLE [dbo].[Departamentos]
(
	Id_Departamento INT NOT NULL IDENTITY (1,1) CONSTRAINT PK_Departamento PRIMARY KEY CLUSTERED (Id_Departamento)
   ,Descripcion VARCHAR(250) NOT NULL
   ,Ubicacion VARCHAR(250) NOT NULL
   ,Estado BIT NOT NULL
)
WITH (DATA_COMPRESSION = PAGE)
GO
