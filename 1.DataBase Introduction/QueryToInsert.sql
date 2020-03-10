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
  INSERT INTO [dbo].[Active_Users] ( Chat_ID, UserSession) VALUES ( 4,'Session111')
  INSERT INTO [dbo].[Active_Users] ( Chat_ID, UserSession) VALUES ( 5,'Session222')
  INSERT INTO [dbo].[Active_Users] ( Chat_ID, UserSession) VALUES ( 3,'Session333')