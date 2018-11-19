CREATE TABLE [Sto_Material]
(
	[Id] varchar(50) NOT NULL,
	[MatNo] varchar(50) NOT NULL,
	[BarCode] varchar(50),
	[MatName] varchar(100) NOT NULL,
	[JianPin] varchar(50),
	[BigClass] varchar(50) NOT NULL,
	[GuiGe] varchar(50),
	[MaxStoreQuantity] int NOT NULL DEFAULT 0,
	[WarnStoreQuantity] int NOT NULL DEFAULT 0,
	[UnitNo] varchar(50),
	[Context] varchar(200)
)
;
GO
ALTER TABLE [Sto_Material] 
 ADD CONSTRAINT [PK_Sto_Material]
	PRIMARY KEY CLUSTERED ([Id])
;