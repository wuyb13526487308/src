CREATE TABLE [Sto_StockSettlementItem]
(
	[Id] varchar(50) NOT NULL,
	[SettNo] varchar(50) NOT NULL,
	[StoreId] varchar(50) NOT NULL,
	[MatNo] varchar(50) NOT NULL,
	[GuiGe] varchar(50),
	[UnitNo] varchar(50),
	[B_Price] datetime NOT NULL,
	[B_Quantity] numeric(10,2) NOT NULL,
	[UpToTime] datetime NOT NULL,
	[E_Quantity] datetime NOT NULL,
	[E_Price] money NOT NULL,
	[Context] varchar(200)
)
;
GO
ALTER TABLE [Sto_StockSettlementItem] 
 ADD CONSTRAINT [PK_Sto_StockSettlementItem]
	PRIMARY KEY CLUSTERED ([Id])
;