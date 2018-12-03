CREATE TABLE [Sto_StockInItem]
(
	[Id] varchar(50) NOT NULL,
	[InNo] varchar(50) NOT NULL,
	[MatNo] varchar(50) NOT NULL,
	[MatName] varchar(50),
	[GuiGe] varchar(50),
	[UnitNo] varchar(50),
	[Price] money,
	[Quantity] numeric(10,2) NOT NULL,
	[Context] varchar(200),
	[BigClass] varchar(50)
)
;
GO
ALTER TABLE [Sto_StockInItem] 
 ADD CONSTRAINT [PK_Sto_StockInItem]
	PRIMARY KEY CLUSTERED ([Id])
;