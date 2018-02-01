--CREATE DATABASE db_library

USE [db_library]

-- CREATE TABLES --

CREATE TABLE tbl_borrower (
	CardNo INT PRIMARY KEY NOT NULL IDENTITY (1000,1),
	Name VARCHAR(80) NOT NULL,
	Address VARCHAR(80),
	Phone VARCHAR(20)
);

CREATE TABLE tbl_library_branch (
	BranchId INT PRIMARY KEY NOT NULL,
	BranchName VARCHAR(50),
	Address VARCHAR(80)
); 

CREATE TABLE tbl_publisher (
	Name VARCHAR(80) PRIMARY KEY NOT NULL,
	Address VARCHAR(80) NOT NULL,
	Phone VARCHAR(20) NOT NULL
);

CREATE TABLE tbl_book (
	BookId INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	Title VARCHAR(80) NOT NULL,	
	PublisherName VARCHAR(80) NOT NULL CONSTRAINT fk_Name FOREIGN KEY REFERENCES tbl_publisher(Name) ON UPDATE CASCADE ON DELETE CASCADE,
);

CREATE TABLE tbl_book_authors (
	BookId INT NOT NULL CONSTRAINT fk_BookId FOREIGN KEY REFERENCES tbl_book(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	AuthorName VARCHAR(80)
);

CREATE TABLE tbl_book_loans (
	BookId INT NOT NULL CONSTRAINT fk_LoanBookId FOREIGN KEY REFERENCES tbl_book(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	BranchId INT NOT NULL CONSTRAINT fk_LoanBranchId FOREIGN KEY REFERENCES tbl_library_branch(BranchId) ON UPDATE CASCADE ON DELETE CASCADE,
	CardNo INT NOT NULL CONSTRAINT fk_CardNo FOREIGN KEY REFERENCES tbl_borrower(CardNo) ON UPDATE CASCADE ON DELETE CASCADE,
	DateOut	DATE NOT NULL,
	DueDate DATE NOT NULL
);

CREATE TABLE tbl_book_coppies (
	BookId INT NOT NULL CONSTRAINT fk_CopyBookId FOREIGN KEY REFERENCES tbl_book(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	BranchId INT NOT NULL CONSTRAINT fk_CopyBranchId FOREIGN KEY REFERENCES tbl_library_branch(BranchId) ON UPDATE CASCADE ON DELETE CASCADE,
	No_Of_Coppies INT NOT NULL
);

-- POPULATE TABLES --

INSERT INTO tbl_borrower (Name, Address, Phone)
	VALUES
	('Edythe Nowicki', '3478 Whispering Pines Circle', '786-298-2324'),
	('William Karcher', '3608 Hidden Meadow Drive', '972-412-1089'),
	('Lisa Butcher', '620 Cimmaron Road', '714-581-2431'),
	('Tanya McDonough', '2722 Alpha Avenue', '904-233-0554'),
	('Kassie Spencer', '4386 D Street', '586-524-2397'),
	('Judith Grayson', '206 Hazelwood Avenue', '515-474-3848'),
	('Tara Hanes', '3922 Leisure Lane', '805-596-0047'),
	('Angela Combs', '4870 Bluff Street', '301-823-2770'),
	('Amy Davila', '163 Fancher Drive', '214-316-0642'),
	('Norman Sierra', '3118 Walnut Drive', '701-429-8851'),
	('Danielle Marie', '4040 NW Cedar Blvd', '503-234-5567') -- this user intentionally has no books checked out
;

INSERT INTO tbl_library_branch (BranchId, BranchName, Address)
	VALUES
	(1, 'Sharsptown', '160 Rosewood Lane'),
	(2, 'Central', '2561 Thompson Drive'),
	(3, 'North West', '3238 Dog Hill Lane'),
	(4, 'Longview', '3207 Archwood Avenue')
;

INSERT INTO tbl_publisher (Name, Address, Phone)
	VALUES
	('New American Library', 'New York City, NY', '697-262-2905'), 
	('Scribner', 'New York City, NY', '212-632-4915'), 
	('Picador USA', 'New York City, NY', '888-330-8477'), 
	('Crown Archetype', 'Danvers, MA', '978-750-8400'), 
	('Bard Press', 'Austin, TX', '512-266-2112'), 
	('Harper Collins', 'New York City, NY', '800-242-7737'), 
	('Penguin Books', 'New York City, NY', '212-366-2000'), 
	('Riverhead Books', 'New York City, NY', '817-244-9228'), 
	('Grand Central Publishing', 'New York City, NY', '888-224-2981'), 
	('Business Plus', 'New York City, NY', '371-172-3856'), 
	('L&R Business', 'Grimes, IA', '515-505-7604'), 
	('Harmony Books', 'New York City, NY', '505-551-8964'), 
	('Henry Holt and Company', 'New York City, NY', '646-307-5095'), 
	('Black Irish Books', 'Belfast, Ireland', '839-998-0278'), 
	('Macmillan Publishers', 'London, England', '879-146-3833'), 
	('Bantam Books', 'New York City, NY', '888-418-8992'), 
	('Random House', 'New York City, NY', '212-782-9000') 
;

INSERT INTO tbl_book (Title, PublisherName)
	VALUES
	('The Green Mile', 'New American Library'),
	('Bag of Bones', 'Scribner'),
	('The Lost Tribe', 'Picador USA'),
	('The 4 Hour Body', 'Crown Archetype'),
	('The One Thing', 'Bard Press'),
	('Never Split the Difference', 'Harper Collins'),
	('Captivate', 'Penguin Books'),
	('Drive', 'Riverhead Books'),
	('Deep Work', 'Grand Central Publishing'),
	('So Good They Can''t Ignore You', 'Business Plus'),
	('Re-Work', 'L&R Business'),
	('Daring Greatly', 'Penguin Books'),
	('Rejection Proof', 'Harmony Books'),
	('Six of Crows', 'Henry Holt and Company'),
	('The War of Art', 'Black Irish Books'),
	('Cinder', 'Macmillan Publishers'),
	('Getting Things Done', 'Penguin Books'),
	('Emotional Intelegence', 'Bantam Books'),
	('The Power of Habit', 'Random House'),
	('A Discovery of Witches', 'Penguin Books')
;

INSERT INTO tbl_book_authors (BookId, AuthorName)
	VALUES
	(32, 'Stephen King'),
	(33, 'Stephen King'),
	(34, 'Mark Lee'),
	(35, 'Tim Ferris'),
	(36, 'Gary Keller'),
	(37, 'Chris Voss'),
	(38, 'Vanessa Van Edwards'),
	(39, 'Daniel Pink'),
	(40, 'Cal Newport'),
	(41, 'Cal Newport'),
	(42, 'David Heinnemier Hansson'),
	(43, 'Brene Brown'),
	(44, 'Jia Jiang'),
	(45, 'Leigh Bardugo'),
	(46, 'Stephen Pressfield'),
	(47, 'Marissa Meyer'),
	(48, 'David Allen'),
	(49, 'Daniel Goleman'),
	(50, 'Charles Duhigg'),
	(51, 'Deborah Harkness')
;

-- There are at least 50 loans in the BOOK_LOANS table.
-- at least 2 borrowers have more than 5 books loaned to them.
INSERT INTO tbl_book_loans (BookId, BranchId, CardNo, DateOut, DueDate)
	VALUES
	(32, 2, 1001, '2018-01-01', '2018-01-20'),
	(33, 2, 1000, '2018-01-05', '2018-01-25'),
	(34, 1, 1000, '2018-01-05', '2018-01-25'),
	(35, 2, 1000, '2018-01-05', '2018-01-25'),
	(36, 2, 1000, '2018-01-05', '2018-01-25'),
	(37, 2, 1000, '2018-01-05', '2018-01-25'),
	(38, 2, 1000, '2018-01-05', '2018-01-25'),
	(39, 2, 1001, '2018-01-01', '2018-01-20'),
	(40, 2, 1001, '2018-01-01', '2018-01-20'),
	(41, 2, 1001, '2018-01-01', '2018-01-20'),
	(42, 2, 1001, '2018-01-01', '2018-01-20'),
	(43, 3, 1001, '2018-01-01', '2018-01-20'),
	(44, 3, 1002, '2018-01-10', '2018-01-30'),
	(45, 3, 1002, '2018-01-10', '2018-01-30'),
	(46, 3, 1002, '2018-01-10', '2018-01-30'),
	(47, 3, 1002, '2018-01-10', '2018-01-30'),
	(48, 3, 1003, '2018-01-15', '2018-02-04'),
	(49, 3, 1003, '2018-01-15', '2018-02-04'),
	(50, 3, 1003, '2018-01-15', '2018-02-04'),
	(51, 3, 1003, '2018-01-15', '2018-02-04'),
	(32, 2, 1004, '2018-01-10', '2018-01-30'),
	(33, 2, 1004, '2018-01-10', '2018-01-30'),
	(34, 1, 1004, '2018-01-10', '2018-01-30'),
	(35, 1, 1004, '2018-01-10', '2018-01-30'),
	(36, 1, 1005, '2018-01-25', '2018-02-14'),
	(37, 1, 1005, '2018-01-25', '2018-02-14'),
	(38, 1, 1005, '2018-01-25', '2018-02-14'),
	(39, 1, 1005, '2018-01-25', '2018-02-14'),
	(40, 1, 1006, '2018-01-15', '2018-02-04'),
	(41, 1, 1006, '2018-01-15', '2018-02-04'),
	(42, 1, 1006, '2018-01-15', '2018-02-04'),
	(43, 1, 1006, '2018-01-15', '2018-02-04'),
	(44, 1, 1007, '2018-01-30', '2018-02-19'),
	(45, 3, 1007, '2018-01-30', '2018-02-19'),
	(46, 3, 1007, '2018-01-30', '2018-02-19'),
	(47, 3, 1007, '2018-01-30', '2018-02-19'),
	(48, 3, 1008, '2018-01-31', '2018-02-20'),
	(49, 3, 1008, '2018-01-31', '2018-02-20'),
	(50, 3, 1008, '2018-01-31', '2018-02-20'),
	(51, 3, 1008, '2018-01-31', '2018-02-20'),
	(35, 4, 1009, '2018-01-31', '2018-02-20'),
	(36, 4, 1009, '2018-01-10', '2018-01-30'),
	(37, 4, 1009, '2018-01-10', '2018-01-30'),
	(38, 4, 1009, '2018-01-10', '2018-01-30'),
	(39, 4, 1009, '2018-01-10', '2018-01-30'),
	(40, 2, 1009, '2018-01-10', '2018-01-30'),
	(41, 3, 1009, '2018-01-10', '2018-01-30'),
	(42, 3, 1009, '2018-01-10', '2018-01-30'),
	(43, 3, 1009, '2018-01-10', '2018-01-30'),
	(44, 3, 1009, '2018-01-10', '2018-01-30'),
	(45, 3, 1009, '2018-01-10', '2018-01-30'),
	(46, 3, 1009, '2018-01-10', '2018-01-30')
;

--- Each library branch has at least 10 book titles, and at least two copies of each of those titles.
INSERT INTO tbl_book_coppies (BookId, BranchId, No_Of_Coppies)
	VALUES
--Central, Branch 2
	(32, 2, 2),
	(33, 2, 2),
	(35, 2, 9),
	(36, 2, 5),
	(37, 2, 6),
	(38, 2, 6),
	(39, 2, 10),
	(40, 2, 5),
	(41, 2, 9),
	(42, 2, 7),
--Sharptown, Branch 1
	(34, 1, 2),
	(35, 1, 6),
	(36, 1, 5),
	(37, 1, 7),
	(38, 1, 4),
	(39, 1, 8),
	(40, 1, 5),
	(41, 1, 9),
	(42, 1, 7),
	(43, 1, 8),
	(44, 1, 9),
--North West, Branch 3
	(41, 3, 9),
	(42, 3, 6),
	(43, 3, 9),
	(44, 3, 10),
	(45, 3, 9),
	(46, 3, 7),
	(47, 3, 10),
	(48, 3, 10),
	(49, 3, 8),
	(50, 3, 8),
	(51, 3, 9),
--Longview, Branch 4
	(35, 3, 10),
	(36, 3, 8),
	(37, 3, 5),
	(38, 3, 6),
	(39, 3, 6),
	(43, 3, 6),
	(44, 3, 7),
	(45, 3, 10),
	(46, 3, 7),
	(47, 3, 9),
	(48, 3, 10),
	(51, 3, 10)
;
