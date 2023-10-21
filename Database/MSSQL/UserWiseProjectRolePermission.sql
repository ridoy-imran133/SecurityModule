CREATE TABLE [UserWiseProjectRolePermission](
		"Id" [nvarchar](128) NOT NULL,
		"RoleCode" [nvarchar](32) NOT NULL,
		"ProjectCode" [nvarchar](16) NOT NULL,
		"RegistrationId" [nvarchar](128) NULL,
		"EmpRegId" int NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT PK_USERWISEPROJECTROLEPERMISSION PRIMARY KEY ("Id")
);