-- Seed data for books database
MERGE INTO Books AS Target
USING (VALUES 
	('Deep Work', 'Cal Newport', 'Business', 2016, 1),
	('I Will Teach You To Be Rich', 'Ramit Sethi', 'Personal Fianance', 2009, 0)
)
AS Source (Title, Author, Genre, PublicationYear, IsOwned)
ON Target.Title = Source.Title AND Target.Author = Source.Author
WHEN NOT MATCHED BY TARGET THEN
INSERT (Title, Author, Genre, PublicationYear, IsOwned)
VALUES (Title, Author, Genre, PublicationYear, IsOwned);

-- Seed data for tags database
MERGE INTO Tags AS Target
USING (VALUES 
	('Yearly Read', 5),
	('Yearly Read', 6)
)
AS Source (TagName, BookId)
ON Target.TagName = Source.TagName AND Target.BookId = Source.BookId
WHEN NOT MATCHED BY TARGET THEN
INSERT (TagName, BookId)
VALUES (TagName, BookId);