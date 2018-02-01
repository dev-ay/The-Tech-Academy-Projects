USE db_library
GO

CREATE PROCEDURE usp_LostTribeSharpstown
-- This procedure retrieves the names of all borrowers who do not
-- have any books checked out.
AS
BEGIN
	SELECT *
	FROM tbl_borrower a1
	LEFT JOIN tbl_book_loans a2 ON a2.CardNo = a1.CardNo
	WHERE a2.BookId IS NULL
END