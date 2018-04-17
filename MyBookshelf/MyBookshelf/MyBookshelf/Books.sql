CREATE TABLE [dbo].[Books]
(
	[BookId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Title] VARCHAR(MAX) NOT NULL, 
    [Author] VARCHAR(MAX) NOT NULL, 
    [Genre] VARCHAR(MAX) NULL, 
    [PublicationYear] INT NULL, 
    [IsOwned] BIT NOT NULL
)
