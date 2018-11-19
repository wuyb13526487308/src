CREATE TABLE [Pro_MaterialRequisitionItem]
(
	[Id] varchar(50) NOT NULL,
	[ProCode] varchar(50) NOT NULL,
	[MR_Id] varchar(50) NOT NULL,
	[MatNo] varchar(50) NOT NULL,
	[MatName] varchar(50),
	[GuiGe] varchar(50),
	[UnitNo] varchar(50),
	[Quantity] numeric(10,2) NOT NULL
)
;
GO
ALTER TABLE [Pro_MaterialRequisitionItem] 
 ADD CONSTRAINT [PK_Pro_MaterialRequisitionItem]
	PRIMARY KEY CLUSTERED ([Id])
;