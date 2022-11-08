CREATE TABLE [UserWiseProjectRolePermission](
		"RoleCode" [nvarchar](32) NOT NULL,
		"ProjectCode" [nvarchar](16) NOT NULL,
		"RegistrationId" [nvarchar](128) NOT NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT FK_URREGISTRATION FOREIGN KEY ("RegistrationId")
		REFERENCES [dbo].[UserRegistration]("Id"),
		CONSTRAINT FK_URROLE FOREIGN KEY ("RoleCode")
		REFERENCES [dbo].[Role]("RoleCode"),
		CONSTRAINT FK_URPROJECT FOREIGN KEY ("ProjectCode")
		REFERENCES [dbo].[Project]("ProjectCode")
);