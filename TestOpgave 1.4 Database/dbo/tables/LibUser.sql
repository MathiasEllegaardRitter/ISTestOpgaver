CREATE TABLE [dbo].[LibUser]
(
    [name] NVARCHAR(100) NOT NULL, 
    [libraryUserNo] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_LibUser] PRIMARY KEY ([libraryUserNo])
)
