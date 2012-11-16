/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


DECLARE @board1 uniqueidentifier, @board2 uniqueidentifier
DECLARE @column11 uniqueidentifier, @column12 uniqueidentifier, @column21 uniqueidentifier
DECLARE @task111 uniqueidentifier,@task112 uniqueidentifier,@task113 uniqueidentifier,@task114 uniqueidentifier,@task121 uniqueidentifier,@task122 uniqueidentifier
declare @task211 uniqueidentifier,@task212 uniqueidentifier

SET @board1 = '7ccdd743-5bb3-4dd2-9fd8-01c48fa6b484'
SET @board2 = '7dc10898-7cd3-44ac-99ab-9039755870f6'
SET @column11 = '3f821bd9-53b9-482b-9978-e1ef868628bc'
SET @column12 = '3cccc4d5-b6ac-4d88-a85d-832dd85863ef'
SET @column21 = '90e13bc8-05cf-4e32-b535-fbcabce976de'

SET @task111 = '27fbd52d-572d-49f2-a22e-603aa52ca4ca'
SET @task112 = 'c5868119-f977-4570-8225-a6c4287950ec'
SET @task113 = '10ccfe89-fc30-408a-b42b-a0c5828fa456'
SET @task114 = '09bb7a69-f312-4a02-9a63-a2202000c3ce'
SET @task121 = '3549d15d-51d7-40e3-a1dd-a5596a68b818'
SET @task122 = 'e1091451-79bd-4381-955e-9b6141c44d61'

SET @task211 = '202346e5-81b8-4653-a2d7-3f201ce4a890'
SET @task212 = '88e07ef5-bb86-4939-bff3-a82c3c352b31'


MERGE INTO [dbo].[Board] as Target
USING (VALUES
  (@board1, N'Admin', N'Board 1'),
  (@board2, N'Admin', N'Board 2')
)
AS Source (Id,UserName,BoardName)
ON Target.Id= Source.Id
-- update matched rows
WHEN MATCHED THEN
UPDATE SET UserName = Source.UserName, BoardName = Source.BoardName
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id,UserName,BoardName)
VALUES (Id,UserName,BoardName)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

MERGE INTO [dbo].[BoardColumn] as Target
USING (VALUES
  (@column11, @board1, N'Board 1 Column1',0),
  (@column12, @board1, N'Board 1 Column1',1),
  (@column21, @board2, N'Board 1 Column1',0)
)
AS Source (Id,BoardId,Name,Position)
ON Target.Id = Source.Id
-- update matched rows
WHEN MATCHED THEN
UPDATE SET Name = Source.Name, BoardId = Source.BoardId, Position = Source.Position
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id,BoardId,Name,Position)
VALUES (Id,BoardId,Name,Position)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;


MERGE INTO [dbo].[Task] as Target
USING (VALUES
  (@task111, @column11, N'Board 1 Column1 Task1',N'',0),
  (@task112, @column11, N'Board 1 Column1 Task2',N'',1),
  (@task113, @column11, N'Board 1 Column1 Task3',N'',2),
  (@task114, @column11, N'Board 1 Column1 Task4',N'',3),
  (@task121, @column12, N'Board 1 Column2 Task1',N'',0),
  (@task122, @column12, N'Board 1 Column1 Task2',N'',1),
  (@task211, @column21, N'Board 2 Column1 Task1',N'',0),
  (@task212, @column21, N'Board 2 Column1 Task2',N'',1)
)
AS Source (Id,BoardColumnId,Name,[Description],Position)
ON Target.Id = Source.Id
-- update matched rows
WHEN MATCHED THEN
UPDATE SET Name = Source.Name, BoardColumnId = Source.BoardColumnId, Position = Source.Position
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id,BoardColumnId,Name,[Description],Position)
VALUES (Id,BoardColumnId,Name,[Description],Position)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

