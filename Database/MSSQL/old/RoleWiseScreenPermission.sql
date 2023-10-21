CREATE TABLE [RoleWiseScreenPermission](
		"RoleCode" [nvarchar](16) NOT NULL,
		"ProjectCode" [nvarchar](16) NOT NULL,
		"ModuleCode" [nvarchar](16) NOT NULL,
		"ScreenCode" [nvarchar](16) NOT NULL,
		"IsAdd" [nvarchar](2) NULL,
		"IsView" [nvarchar](2) NULL,
		"IsEdit" [nvarchar](2) NULL,
		"IsDeleted" [nvarchar](2) NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT UK_ROLEWISESCREENPERMISSION UNIQUE ("RoleCode", "ProjectCode", "ModuleCode", "ScreenCode")
);