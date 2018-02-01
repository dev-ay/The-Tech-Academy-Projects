--USE db_library
--GO

CREATE PROCEDURE usp_MoreThanFiveBooks
-- This procedure retrieves the names, addresses, and number of books 
-- checked out for all borrowers who have more than 5 books checked out
AS
BEGIN
	SELECT a1.Name, a1.Address, COUNT(a2.BookId) AS 'Books_Checked_Out'
	FROM tbl_borrower a1
	INNER JOIN tbl_book_loans a2 ON a2.CardNo = a1.CardNo
	GROUP BY a1.Name, a1.Address -- COUNT does not work without GROUP BY
	HAVING COUNT(a2.BookId) > 5 -- Use HAVING with agregrate, not WHERE
END