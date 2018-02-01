--USE db_library
--GO

CREATE PROCEDURE usp_SharpstownDueToday
-- This procedure retrieves the book titles, borrower's name, 
-- and borrower's addresses where a book is due to the Sharpstown 
-- branch today
AS
BEGIN
	DECLARE @Today DATE
	SET @Today = GETDATE()

	SELECT a4.Title AS 'Book Due', a1.Name AS 'Borrower Name', a1.Address AS 'Borrower Address'
	FROM tbl_borrower a1
	INNER JOIN tbl_book_loans a2 ON a2.CardNo = a1.CardNo
	INNER JOIN tbl_library_branch a3 ON a3.BranchId = a2.BranchId
	INNER JOIN tbl_book a4 ON a4.BookId = a2.BookId
	WHERE a2.DueDate = @Today AND a3.BranchName = 'Sharpstown'
END