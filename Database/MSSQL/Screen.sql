CREATE TABLE [Screen](
		"ProjectCode" [nvarchar](16) NOT NULL,
		"ModuleCode" [nvarchar](16) NOT NULL,
		"ScreenCode" [nvarchar](16) NOT NULL,
		"ScreenName" [nvarchar](128) NOT NULL,
		"URL" [nvarchar](512) NULL,
		"Icon" [nvarchar](512) NULL,
		"ScDescription" [nvarchar](512) NULL,
		"ParentsCode" [nvarchar](16) NULL,
		"Sequence" [nvarchar](16) NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT UK_SCREENID UNIQUE ("ProjectCode", "ModuleCode", "ScreenCode")
);