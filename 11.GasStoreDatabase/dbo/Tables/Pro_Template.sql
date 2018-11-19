CREATE TABLE [Pro_Template]
(
	[Id] varchar(50) NOT NULL,
	[TemplateId] varchar(50) NOT NULL,
	[TemplateType] int NOT NULL,
	[TemplateName] varchar(50) NOT NULL,
	[LastTime] datetime,
	[LastOperator] varchar(50),
	[Context] varchar(100)
)
;
GO
ALTER TABLE [Pro_Template] 
 ADD CONSTRAINT [PK_Pro_Template]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Pro_Template] 
 ADD CONSTRAINT [unique_templateId] UNIQUE NONCLUSTERED ([TemplateId])
;