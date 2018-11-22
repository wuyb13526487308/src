CREATE TABLE [Sto_StockSettlement]
(
	[Id] varchar(50) NOT NULL,
	[SettNo] varchar(12) NOT NULL,
	[SettleDate] datetime NOT NULL,
	[OperName] varchar(50) NOT NULL,
	[SettType] bit DEFAULT 0,
	[Context] varchar(200)
)
;
GO
ALTER TABLE [Sto_StockSettlement] 
 ADD CONSTRAINT [PK_Sto_StockHistory]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Sto_StockSettlement] 
 ADD CONSTRAINT [unique_settNo] UNIQUE NONCLUSTERED ([SettNo])
;