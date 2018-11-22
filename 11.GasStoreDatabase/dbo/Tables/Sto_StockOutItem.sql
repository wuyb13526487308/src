CREATE TABLE [Sto_StockOutItem]
(
	[Id] varchar(50) NOT NULL,
	[OutNo] varchar(50) NOT NULL,
	[MatNo] varchar(50) NOT NULL,
	[MatName] varchar(50),
	[GuiGe] varchar(50),
	[UnitNo] varchar(50),
	[Price] varchar(50),
	[Quantity] numeric(10,2),
	[Context] varchar(200)
)
;
GO
ALTER TABLE [Sto_StockOutItem] 
 ADD CONSTRAINT [PK_Sto_StockOutItem]
	PRIMARY KEY CLUSTERED ([Id])
;