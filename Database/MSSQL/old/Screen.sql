CREATE TABLE [Screen](
		"ProjectCode" [nvarchar](16) NOT NULL,
		"ModuleCode" [nvarchar](16) NOT NULL,
		"ScreenCode" [nvarchar](16) NOT NULL,
		"ScreenName" [nvarchar](128) NOT NULL,
		"Description" [nvarchar](512) NULL,
		"URL" [nvarchar](512) NULL,
		"Icon" [nvarchar](512) NULL,
		"Description" [nvarchar](512) NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT UK_SCREENID UNIQUE ("ProjectCode", "ModuleCode", "ScreenCode")
);