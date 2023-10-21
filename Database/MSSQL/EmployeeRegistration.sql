CREATE TABLE [Employee].[EmployeeRegistration](
		"Id" int NOT NULL,
		"FullName" [nvarchar](450) NOT NULL,
		"PhoneNumber" [nvarchar](32) NOT NULL,
		"Email" [nvarchar](256) NOT NULL,
		"Address" [nvarchar](450) NOT NULL,
		"Gender" [nvarchar](16) NULL,
		"DateOfBirth" DATETIME NULL,
		"ECName" [nvarchar](450) NULL,
		"ECPhoneNumber" [nvarchar](16) NULL,		
		"MaritalStatus" [nvarchar](16) NULL,
		"HasSystemAccess" [nvarchar](2) NULL,
		"UserName" [nvarchar](256) NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT PK_EMPLOYEEREGISTRATION PRIMARY KEY ("Id")
)