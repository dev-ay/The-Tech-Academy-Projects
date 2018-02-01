--USE db_library
--GO

CREATE PROCEDURE usp_SKingCentral
-- This procedure retrieves the titles and number of coppies of all books
-- authored by Stephen King residing at the Central branch
AS
BEGIN
	SELECT a1.Title, a3.No_Of_Coppies
	FROM tbl_book a1
	INNER JOIN tbl_book_authors a2 ON a2.BookId = a1.BookId
	INNER JOIN tbl_book_coppies a3 ON a3.BookId = a1.BookId
	INNER JOIN tbl_library_branch a4 ON a4.BranchId = a3.BranchId
	WHERE a2.AuthorName = 'Stephen King' AND a4.BranchName = 'Central'
END