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
		   ),
		   ('Lady Coin'
           ,'You find a nice looking silver coin, it has a lady''s face engraved on it, it''s probably worth something.'
           ,45
           ,10
           ,400),
		   ('Engraved blade'
           ,'As you roam the dark hallways, you find a beautifully engraved blade on the wall. It''s dull, probably can''t even cut butter, but it might just be worth something'
           ,150
           ,80
           ,200),
		   ('Tophat'
           ,'You just found a tophat, you put it on and look in a conveniently placed mirror. You look ridiculous, but you might just be able to sell it.'
           ,45
           ,10
           ,400)
GO


