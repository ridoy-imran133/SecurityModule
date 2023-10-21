CREATE TABLE [Project](
		"ProjectCode" [nvarchar](16) NOT NULL UNIQUE,
		"ProjectName" [nvarchar](64) NOT NULL,
		"Description" [nvarchar](512) NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL
);