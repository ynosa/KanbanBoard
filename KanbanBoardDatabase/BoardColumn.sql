CREATE TABLE [dbo].[BoardColumn]
(
	[Id] UNIQUEIDENTIFIER NOT NULL , 
    [BoardId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(256) NOT NULL, 
    [Position] SMALLINT NOT NULL, 
    CONSTRAINT [FK_BoardColumn_Board] FOREIGN KEY ([BoardId]) REFERENCES [Board]([Id]), 
    PRIMARY KEY ([Id])
)
