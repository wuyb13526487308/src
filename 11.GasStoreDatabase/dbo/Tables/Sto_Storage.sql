CREATE TABLE [Sto_Storage]
(
	[Id] varchar(50) NOT NULL,
	[StoreNo] varchar(50),
	[StoreName] varchar(50),
	[Context] varchar(500)
)
;
GO
ALTER TABLE [Sto_Storage] 
 ADD CONSTRAINT [PK_Sto_Store]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Sto_Storage] 
 ADD CONSTRAINT [unique_storeNo] UNIQUE NONCLUSTERED ([StoreNo])
;