CREATE TABLE [dbo].[Task]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [BoardColumnId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(256) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Position] SMALLINT NOT NULL, 
    CONSTRAINT [FK_Task_ToBoardColumn] FOREIGN KEY ([BoardColumnId]) REFERENCES [BoardColumn]([Id])
)
