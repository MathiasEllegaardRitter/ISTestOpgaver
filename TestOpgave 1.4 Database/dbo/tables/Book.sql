CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [title] NVARCHAR(100) NOT NULL, 
    [author] NVARCHAR(100) NOT NULL, 
    [isbnNo] NVARCHAR(100) NOT NULL, 
    [isBorrowed] INT NOT NULL
)
