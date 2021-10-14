CREATE TABLE [dbo].[Borrow]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [bookIsbn] NVARCHAR(100) NOT NULL, 
    [libUserId] INT NOT NULL, 
    [dateStart] DATETIME NOT NULL, 
    [dateEnd] DATETIME NOT NULL, 
    [hasReturned] INT NOT NULL, 
    [deliveryDate] DATETIME NULL
)
