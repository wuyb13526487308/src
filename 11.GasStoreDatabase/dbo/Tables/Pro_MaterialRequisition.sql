CREATE TABLE [Pro_MaterialRequisition]
(
	[Id] varchar(50) NOT NULL,
	[ProCode] varchar(50) NOT NULL,
	[ProName] varchar(200),
	[PMR_No] varchar(50) NOT NULL,
	[Creator] varchar(50),
	[CreateDate] datetime DEFAULT getdate(),
	[Picker] varchar(50),
	[Status] smallint
)
;
GO
ALTER TABLE [Pro_MaterialRequisition] 
 ADD CONSTRAINT [PK_Pro_MaterialRequisition]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Pro_MaterialRequisition] 
 ADD CONSTRAINT [unique_pmr] UNIQUE NONCLUSTERED ([ProCode],[PMR_No])
;