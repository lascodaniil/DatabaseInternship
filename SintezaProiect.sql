GO
IF DB_ID('DBChat') IS NOT NULL 
BEGIN
	DROP DATABASE DBChat;
END
GO

GO
CREATE DATABASE [DBChat]
GO

USE [DBChat]
IF OBJECT_ID(N'User',N'U') IS NOT NULL
	DROP TABLE [User]
ELSE
	CREATE TABLE [User]
	(
		ID BIGINT  NOT NULL UNIQUE,
		FirstName NVARCHAR(255) NOT NULL,
		LastName NVARCHAR(255)NOT NULL,
		Email NVARCHAR(255) NOT NULL UNIQUE, 
		PRIMARY KEY (Email)
	);	


IF OBJECT_ID(N'BlockList',N'U') IS NOT NULL
	DROP TABLE [BlockList]
ELSE
CREATE TABLE BlockList
	(
		ID_BlockedUser BIGINT IDENTITY (1,1) NOT NULL,
		Email NVARCHAR(255),
		BlockedDate DATETIME2 DEFAULT GETDATE(),
		UnblockedDate DATETIME2 
		PRIMARY KEY(Email)
	    FOREIGN KEY (Email) REFERENCES [User](Email) ON DELETE CASCADE

	);


IF OBJECT_ID(N'Message',N'U') IS NOT NULL
	DROP TABLE [Message]
ELSE
CREATE TABLE [Message]
	(
		Message_ID BIGINT IDENTITY(1,1) NOT NULL,
		Id_User BIGINT NOT NULL,
		Chat_ID BIGINT NOT NULL UNIQUE,
		DateCreated DATETIME2 DEFAULT GETDATE(),
		FOREIGN KEY(Id_User) REFERENCES  [User](ID),
		PRIMARY KEY(Message_ID),
		
	);

IF OBJECT_ID(N'Attachment',N'U') IS NOT NULL
	DROP TABLE [Attachments]
ELSE
CREATE TABLE Attachments
	(
		Attachment_ID BIGINT IDENTITY(1,1) NOT NULL,
		Attachment_Name NVARCHAR(255) NOT NULL,
		Attachment_Size NVARCHAR(255),
		CreatedTime DATETIME2 DEFAULT GETDATE() not null,
		Message_ID BIGINT 
		FOREIGN KEY(Message_ID) REFERENCES  [Message](Message_ID)
		PRIMARY KEY(Attachment_ID)
	);

IF OBJECT_ID(N'Chat',N'U') IS NOT NULL
	DROP TABLE [Chat]
ELSE
CREATE TABLE Chat
	(
		Chat_ID BIGINT IDENTITY(1,1) NOT NULL,
		ChatName NVARCHAR(255)
		PRIMARY KEY(Chat_ID)
	);

IF OBJECT_ID(N'Subscriptions',N'U') IS NOT NULL
	DROP TABLE [Subscriptions]
ELSE
CREATE TABLE Subscriptions
	(
		ID BIGINT IDENTITY(1,1) NOT NULL,
		ID_User BIGINT NOT NULL,
		ID_Chat BIGINT NOT NULL,
		FOREIGN KEY(ID_User) REFERENCES  [User](ID),
		FOREIGN KEY(ID_Chat) REFERENCES  [Chat](Chat_ID),
		PRIMARY KEY(ID)
	);
