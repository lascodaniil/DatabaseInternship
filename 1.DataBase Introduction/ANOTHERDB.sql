
IF DB_ID('DBLanguagesProject') IS NOT NULL 
BEGIN
	DROP DATABASE DBLanguagesProject;
END
GO

GO
CREATE DATABASE [DBLanguagesProject]
GO

USE [DBLanguagesProject]

IF OBJECT_ID(N'Student',N'U') IS NOT NULL
	DROP TABLE Student
ELSE
	CREATE TABLE Student
	(
		StudentId BIGINT  IDENTITY(1,1) NOT NULL UNIQUE,
		FirstName NVARCHAR(255) NOT NULL,
		LastName NVARCHAR(255)NOT NULL,
		Email NVARCHAR(255) NOT NULL UNIQUE, 
		RegisterDate DATETIME2 DEFAULT GETDATE(),
		PRIMARY KEY (StudentId)
	);	


IF OBJECT_ID(N'Teacher',N'U') IS NOT NULL
	DROP TABLE Teacher
ELSE
CREATE TABLE Teacher
	(
		TeacherId BIGINT IDENTITY (1,1) NOT NULL,
		FirstName NVARCHAR(255),
		LastName NVARCHAR(255),
		Email NVARCHAR(255),
		PRIMARY KEY(TeacherId)
	);


IF OBJECT_ID(N'Languages',N'U') IS NOT NULL
	DROP TABLE Languages
ELSE
CREATE TABLE [Languages]
	(
		LanguageId BIGINT IDENTITY (1,1) NOT NULL,
		[Language] NVARCHAR(255),
		PRIMARY KEY(LanguageId)
	);


IF OBJECT_ID(N'TeacherLanguages',N'U') IS NOT NULL
	DROP TABLE TeacherLanguages
ELSE
CREATE TABLE TeacherLanguages
	(
		TeacherLanguagesId BIGINT IDENTITY (1,1) NOT NULL,
		LanguageId BIGINT NOT NULL ,
		TeacherId BIGINT NOT NULL,
		FOREIGN KEY(LanguageId) REFERENCES  [Languages](LanguageId),
		FOREIGN KEY(TeacherId) REFERENCES  [Teacher](TeacherId),
		PRIMARY KEY(TeacherLanguagesId)
	);


IF OBJECT_ID(N'LevelCourse',N'U') IS NOT NULL
	DROP TABLE LevelCourse
ELSE
CREATE TABLE LevelCourse
	(
		LevelId BIGINT IDENTITY (1,1) NOT NULL UNIQUE,
		LevelName NVARCHAR(255) NOT NULL UNIQUE
	);


IF OBJECT_ID(N'Courses',N'U') IS NOT NULL
	DROP TABLE Courses
ELSE
CREATE TABLE Courses
	(
		CourseId BIGINT IDENTITY (1,1) NOT NULL,
		LanguageId BIGINT NOT NULL,
		LevelCourseId BIGINT NOT NULL,
		StartDate DATETIME2 DEFAULT GETDATE(),
		EndDate DATETIME2 DEFAULT GETDATE(),
		FOREIGN KEY(LevelCourseId) REFERENCES  LevelCourse(LevelId),
		PRIMARY KEY(CourseId)
	);

	
IF OBJECT_ID(N' EnrolledStudents ',N'U') IS NOT NULL
	DROP TABLE EnrolledStudents
ELSE
CREATE TABLE EnrolledStudents
	(
		RecordId BIGINT IDENTITY (1,1) NOT NULL,
		StudentId BIGINT NOT NULL,
		CourseId BIGINT NOT NULL,
		FOREIGN KEY(StudentId) REFERENCES  [Student](StudentId),
		FOREIGN KEY(CourseId) REFERENCES  [Courses](CourseId),
		PRIMARY KEY(RecordId)
	);



IF OBJECT_ID(N' TeacherCoursers ',N'U') IS NOT NULL
	DROP TABLE TeacherCoursers
ELSE
CREATE TABLE TeacherCoursers
	(
		TeacherCoursersId BIGINT IDENTITY (1,1) NOT NULL,
		CourseId BIGINT NOT NULL,
		TeacherId BIGINT NOT NULL,

		FOREIGN KEY(CourseId) REFERENCES  [Courses](CourseId),
		FOREIGN KEY(TeacherId) REFERENCES  [Teacher](TeacherId),

		PRIMARY KEY(TeacherCoursersId)
	);

