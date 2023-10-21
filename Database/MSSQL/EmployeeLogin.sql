CREATE TABLE [Employee].[EmployeeLogin](
		"Id" int NOT NULL,
		"Username" [nvarchar](450) NOT NULL,
		"PasswordHash" varbinary(max) NOT NULL,
		"PasswordSalt" varbinary(max) NOT NULL,
		"EmpRegId" int NOT NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT PK_EMPLOYEE PRIMARY KEY ("Id")
);