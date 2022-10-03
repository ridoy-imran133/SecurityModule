CREATE TABLE [Role](
		"RoleCode" [nvarchar](32) NOT NULL,
		"RoleName" [nvarchar](128) NOT NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT PK_ROLE PRIMARY KEY ("RoleCode")
)