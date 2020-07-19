-- DotnetCoreSample.dbo.M_Account definition

-- Drop table

-- DROP TABLE DotnetCoreSample.dbo.M_Account GO

CREATE TABLE DotnetCoreSample.dbo.M_Account (
	Id varchar(100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	UserName varchar(100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	PassWord varchar(100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	Email varchar(255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	AccountGroup varchar(100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	CONSTRAINT M_Account_PK PRIMARY KEY (Id)
) GO;