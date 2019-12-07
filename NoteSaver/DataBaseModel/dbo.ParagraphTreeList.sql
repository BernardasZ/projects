CREATE TABLE [dbo].[ParagraphTreeList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParentId] INT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL
)
