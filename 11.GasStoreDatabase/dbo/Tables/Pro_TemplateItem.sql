CREATE TABLE [Pro_TemplateItem]
(
	[Id] varchar(50) NOT NULL,
	[TemplateId] varchar(50) NOT NULL,
	[MatNo] varchar(50) NOT NULL,
	[MatName] varchar(50),
	[UnitNo] varchar(50),
	[GuiGe] varchar(50),
	[Quantity] int DEFAULT 1,
	[OrderId] int,
	[Context] varchar(100)
)
;
GO
ALTER TABLE [Pro_TemplateItem] 
 ADD CONSTRAINT [PK_Pro_TemplateItem]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Pro_TemplateItem] 
 ADD CONSTRAINT [unique_matNoTemplateId] UNIQUE NONCLUSTERED ([TemplateId],[MatNo])
;