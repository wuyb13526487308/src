﻿CREATE TABLE ReportTableProvider ( 
	TB_ID int identity(1,1)  NOT NULL,
	RD_ID int,
	DS_Table varchar(50), 
    CONSTRAINT [PK_ReportTableProvider] PRIMARY KEY ([TB_ID])
)