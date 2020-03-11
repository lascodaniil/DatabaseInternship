INSERT INTO [dbo].[User] (FirstName,LastName,Email) VALUES ('Lasco','Daniil','lascodaniil@gmail.com')
INSERT INTO [dbo].[User] (FirstName,LastName,Email) VALUES ('Lasco','Valentin','lascovalentin@gmail.com')
INSERT INTO [dbo].[User] (FirstName,LastName,Email) VALUES ('Didna','Guzun','didinaguzun@gmail.com')
INSERT INTO [dbo].[User] (FirstName,LastName,Email) VALUES ('Lasco','Ion','lascoion@gmail.com')
INSERT INTO [dbo].[User] (FirstName,LastName,Email) VALUES ('Ignat','Eugeniu','ignatuegeniu@gmail.com')
INSERT INTO [dbo].[User] (FirstName,LastName,Email) VALUES ('Adrian','Covaci','adriancovaci@gmail.com')


INSERT INTO [dbo].[Chat] (ChatRoomName, Active, AdminRoom) VALUES ('EnglishRoom', 1,2)
INSERT INTO [dbo].[Chat] (ChatRoomName, Active, AdminRoom) VALUES ('GermanRoom', 1,1)
INSERT INTO [dbo].[Chat] (ChatRoomName, Active, AdminRoom) VALUES ('RussianRoom', 1,3)
INSERT INTO [dbo].[Chat] (ChatRoomName, Active, AdminRoom) VALUES ('FrenchRoom', 1,1)


  -- AICI ATENT LA 4,5,3 DUPA ORDINEA INSERARII!!
INSERT INTO [dbo].[Active_Users] ( Chat_ID, UserSession) VALUES ( 1,'Session111')
INSERT INTO [dbo].[Active_Users] ( Chat_ID, UserSession) VALUES ( 2,'Session222')
INSERT INTO [dbo].[Active_Users] ( Chat_ID, UserSession) VALUES ( 3,'Session333')


INSERT INTO Message_records ( message_text, ID_User,Chat_Name ) VALUES ('HELLO WORLD', 1,'EnglishRoom')
SELECT * FROM Message_records

SELECT message_text FROM Message_records as m  JOIN [dbo].[User] as u on m.ID_User = u.ID


-- ALTER TABLE Chat ALTER COLUMN ChatRoomName NVARCHAR(255) NOT NULL UNIQUE CHECK (ChatRoomName LIKE '%[a-Z][1-9]%')




INSERT INTO [dbo].[Chat] (ChatRoomName, Active, AdminRoom) VALUES ('FrenchRoom123', 1,1)
