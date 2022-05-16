USE [ActionCommandGame]
GO

DELETE FROM [dbo].[Player]

INSERT INTO [dbo].[Player]
           ([Name]
           ,[Money]
           ,[Experience]
           ,[UserId])
     VALUES
           ('John Doe'
           , 100
           , 0
           ,'a93e2c4c-3660-46b6-b5f9-c1a0e182a9a0'),
		   ('John Francks'
           , 100000
           , 2000
           ,'a93e2c4c-3660-46b6-b5f9-c1a0e182a9a0'),
		   ('Luc Doleman'
           , 500
           , 5
           ,'a93e2c4c-3660-46b6-b5f9-c1a0e182a9a0'),
		   ('Emilio Fratilleci'
           , 12345
           , 200
           ,'a93e2c4c-3660-46b6-b5f9-c1a0e182a9a0')
GO