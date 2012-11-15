CREATE TABLE [dbo].[BoardItem]
(
	[Id] INT NOT NULL , 
    [BoardId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(256) NOT NULL, 
    CONSTRAINT [FK_BoardItem_Board] FOREIGN KEY ([BoardId]) REFERENCES [Board]([Id]), 
    PRIMARY KEY ([BoardId])
)
