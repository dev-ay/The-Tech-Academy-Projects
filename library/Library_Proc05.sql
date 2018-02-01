--USE db_library
--GO

CREATE PROCEDURE usp_BooksLoaned
-- This procedure retrieves branch name and total number of 
-- books loaned out from that branch
AS
BEGIN
	SELECT a2.BranchName, COUNT(a1.BranchId) AS 'Books_Checked_Out'
	FROM tbl_book_loans a1
	INNER JOIN tbl_library_branch a2 ON a2.BranchId = a1.BranchId
	GROUP BY a2.BranchName -- COUNT does not work without GROUP BY
END