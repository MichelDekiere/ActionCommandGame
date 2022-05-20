USE [ActionCommandGame]
GO

INSERT INTO [dbo].[PositiveGameEvent]
           ([Name]
           ,[Description]
           ,[Money]
           ,[Experience]
           ,[Probability])
     VALUES
           ('Hallways, endless hallways'
           ,'Do these hallways ever end? If you believed in horrorstories you''d think they move to create an endless labyrinth, but that can''t possibly be the case ... can it?'
		   ,0
           ,0
           ,1000),
		   ('Piece of empty paper',
		   'You hold it to the light and warm it up to reveal secret texts, but it remains empty. Now you feel kind of stupid ...'
		   ,0
           ,5
           ,1000			
		   ),
		   ('Crimson Glass',
		   'You find a beautiful crimson coloured wineglass, if you didn''t know any better you''d think it got it''s colour from drinking blood from it, isn''t that strange? Well it''s probably worth something.'
		   , 300,
		   35,
		   400
		   ),
		   ('Snake Ring',
		   'You find a ring in the form of snake wrapped around your finger, it looks kind of cool. Probably worth something'
		   , 200,
		   30,
		   500
		   ),
		   ('Coin purse',
		   'You find a satchel full of gold coins ... Jackpot!',
		   500,
		   35,
		   25
		   )

GO


