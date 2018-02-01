USE db_library
GO

CREATE PROCEDURE usp_LostTribeSharpstown
-- This procedure counts how many copies of the book "The Lost Tribe"
-- are at the "Sharpstown" library branch
AS
BEGIN
	SELECT COUNT(Title)
	FROM tbl_book a1
	INNER JOIN tbl_book_authors a2 ON a2.BookId = a1.BookId
	INNER JOIN tbl_publisher a3 ON a3.Name = a1.PublisherName
	INNER JOIN tbl_book_loans a4 ON a4.BookId = a1.BookId
	INNER JOIN tbl_book_coppies a5 ON a5.BookId = a1.BookId
	INNER JOIN tbl_borrower a6 ON a6.CardNo = a4.CardNo
	INNER JOIN tbl_library_branch a7 ON a7.BranchId = a4.BranchId
	WHERE Title = 'The Lost Tribe' AND BranchName = 'Sharpstown'
	
END