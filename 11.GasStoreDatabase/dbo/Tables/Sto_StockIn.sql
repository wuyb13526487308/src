CREATE TABLE [Sto_StockIn]
(
	[Id] varchar(50) NOT NULL,
	[InNo] varchar(50) NOT NULL,
	[InDate] datetime NOT NULL,
	[InOperID] varchar(50) NOT NULL,
	[Context] varchar(200),
	[State] smallint,
	[Auditor] varchar(50),
	[AuditDate] datetime,
	[StoreId] varchar(50) NOT NULL,
	[StoreUnitId] varchar(50), 
    [InType] SMALLINT NOT NULL DEFAULT 0
)
;
GO
ALTER TABLE [Sto_StockIn] 
 ADD CONSTRAINT [PK_Sto_StockIn]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Sto_StockIn] 
 ADD CONSTRAINT [unique_inNo] UNIQUE NONCLUSTERED ([InNo])
;
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'入库类型，0 采购 1 退料 2 期初',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sto_StockIn',
    @level2type = N'COLUMN',
    @level2name = N'InType'