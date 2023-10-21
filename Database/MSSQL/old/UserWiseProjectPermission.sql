CREATE TABLE [UserWiseProjectPermission](
		"ProjectCode" [nvarchar](16) NOT NULL,
		"RegistrationId" [nvarchar](128) NOT NULL,
		"FullUrl" [nvarchar](512) NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT FK_REGISTRATION FOREIGN KEY ("RegistrationId")
		REFERENCES [dbo].[UserRegistration]("Id"),
		CONSTRAINT FK_PROJECT FOREIGN KEY ("ProjectCode")
		REFERENCES [dbo].[Project]("ProjectCode")
);