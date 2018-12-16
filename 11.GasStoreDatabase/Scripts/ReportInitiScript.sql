-- =============================================
-- Script Template
-- =============================================
GO
delete from ReportPaperKind;
delete from ReportDataType;
delete from ReportParameterType;

insert into ReportPaperKind (PaperName,EnumName,EnumValue,PaperWidth,PaperHeight) values ('用户自定义','Custom',0,200,200);
insert into ReportPaperKind (PaperName,EnumName,EnumValue,PaperWidth,PaperHeight) values ('A3','A3',8,297,420);
insert into ReportPaperKind (PaperName,EnumName,EnumValue,PaperWidth,PaperHeight) values ('A4','A4',9,210,297);
insert into ReportPaperKind (PaperName,EnumName,EnumValue,PaperWidth,PaperHeight) values ('A5','A5',11,148,210);
insert into ReportPaperKind (PaperName,EnumName,EnumValue,PaperWidth,PaperHeight) values ('B4','B4',12,250,353);
insert into ReportPaperKind (PaperName,EnumName,EnumValue,PaperWidth,PaperHeight) values ('B5','B5',13,176,250);
GO

INSERT INTO ReportDataType (DataType, TypeName) VALUES ('System.String', N'字符型')
INSERT INTO ReportDataType (DataType, TypeName) VALUES ('System.Int16', N'短整型')
INSERT INTO ReportDataType (DataType, TypeName) VALUES ('System.Int32', N'整型')
INSERT INTO ReportDataType (DataType, TypeName) VALUES ('System.Decimal', N'实数')
INSERT INTO ReportDataType (DataType, TypeName) VALUES ('System.Boolean', N'布尔型')
INSERT INTO ReportDataType (DataType, TypeName) VALUES ('System.DateTime', N'日期型')

INSERT INTO ReportParameterType (ID, DataType) VALUES (22, '字符型')
INSERT INTO ReportParameterType (ID, DataType) VALUES (8, '整型')
INSERT INTO ReportParameterType (ID, DataType) VALUES (16, '短整型')
INSERT INTO ReportParameterType (ID, DataType) VALUES (4, '日期型')
INSERT INTO ReportParameterType (ID, DataType) VALUES (2, '布尔型')
INSERT INTO ReportParameterType (ID, DataType) VALUES (5, '实数')