USE [ActionCommandGame]
GO

INSERT INTO [dbo].[NegativeGameEvent]
           ([Name]
           ,[Description]
           ,[DefenseWithGearDescription]
           ,[DefenseWithoutGearDescription]
           ,[DefenseLoss]
           ,[Probability])
     VALUES
           ('Collapse'
           ,'As you walk, you hear an ominous rumbling upstairs. The floorboards creek. 
		   The roof collapsed! Whatever was up there is now in here with you. You run as fast and as quietly as you can out of there. It didn''t see you'
           ,'Your gear took most of the hit, you make it out unscathed ... this time.'
           ,'Some of the rubble did a number on you, you''re severely bruised on you shoulder, you need to sit down for a while.'
           ,5
           ,100),
		   ('Ratbite',
		   'As you walk down the hallway you see rats near the walls. You''re so busy looking at the rats that you accidentally step on anothers tail,
		   it screetches and bites your foot.',
		   'Your boots made sure that it''ts teeth didn''t hurt you.'
			, 'Your raggedy shoes barely offer any protection, you can''t put your full weight on it for a while ... hopefully it doesn''t get infected',
			3,
			50
		   ),
		   ('Mold',
		   'You come across a type of mold.',
		   'Your gloves make sure you don''t come into contact with it, but a bit of the smell got in your nose. Immediately you feel lightheaded, probably shouldn''t
		   stick around this mold for too long.',
		   'You make the mistake of touching it, as soon as it comes into contact with your skin you start to feel sick. You pass out and ...
		   wake up in another room? You have no idea where you are or how you got there. Did someone move you here? You start to feel watched and paranoid.',
		   2,
		   50
		   )

GO


