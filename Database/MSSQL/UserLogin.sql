CREATE TABLE [UserLogin](
		"Id" [nvarchar](128) NOT NULL,
		"Username" [nvarchar](450) NOT NULL,
		"PasswordHash" varbinary(max) NOT NULL,
		"PasswordSalt" varbinary(max) NOT NULL,
		"RegistrationId" [nvarchar](128) NOT NULL,
		"IsActive" [nvarchar](2) NULL,
		"IsDelete" [nvarchar](2) NULL,
		"CreatedBy" [nvarchar](64) NULL,
		"CreatedDate" DATETIME NULL,
		"ModifiedBy" [nvarchar](64) NULL,
		"ModifiedDate" DATETIME NULL,
		CONSTRAINT PK_USER PRIMARY KEY ("Id"),
		CONSTRAINT FK_USERREGISTRATION FOREIGN KEY ("RegistrationId")
		REFERENCES [dbo].[UserRegistration]("Id")
);