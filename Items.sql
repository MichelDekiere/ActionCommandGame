USE [ActionCommandGame]
GO


DELETE FROM [dbo].[Item]

INSERT INTO [dbo].[Item]
           ([Name]
           ,[Description]
           ,[Price]
           ,[Fuel]
           ,[Attack]
           ,[Defense]
           ,[ActionCooldownSeconds])
     VALUES
			/* Attack Items */
           ('Screwdriver',
		   'A tool, maybe you can use it as a weapon',
		   50,
		   0,
		   50,
		   0,
		   0),
		   /* Defense Items */
		   ('Iron plated Armor',
		   NULL,
		   1000,
		   0,
		   0,
		   500,
		   0),
		   /* Food Items */
		   ('Developer Food',
		   NULL,
		   1,
		   1000,
		   0,
		   0,
		   1)
GO


