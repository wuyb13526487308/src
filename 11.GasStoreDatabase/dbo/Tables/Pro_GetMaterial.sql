CREATE TABLE [Pro_GetMaterial]
(
	[Id] varchar(50) NOT NULL,
	[ProCode] varchar(50) NOT NULL,
	[ProName] varchar(200),
	[MatNo] varchar(50) NOT NULL,
	[MatName] varchar(50),
	[GuiGe] varchar(50),
	[UnitNo] varchar(50),
	[Quantity] numeric(10,2),
	[GetDate] datetime,
	[PMR_No] varchar(50) NOT NULL,
	[Picker] varchar(50),
	[Context] varchar(200)
)
;
GO
ALTER TABLE [Pro_GetMaterial] 
 ADD CONSTRAINT [PK_Pro_GetMaterial]
	PRIMARY KEY CLUSTERED ([Id])
;