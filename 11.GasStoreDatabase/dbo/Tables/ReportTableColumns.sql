CREATE TABLE ReportTableColumns ( 
	TB_ID int NOT NULL,
	ColumnName varchar(50) NOT NULL,
	ColumnType varchar(50) NOT NULL,
	ColumnLength smallint NOT NULL, 
    CONSTRAINT [PK_ReportTableColumns] PRIMARY KEY ([TB_ID], [ColumnName])
)