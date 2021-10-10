CREATE OR ALTER PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName+ ' ' + LastName AS 'Full Name'
	FROM AccountHolders
END

EXEC dbo.usp_GetHoldersFullName

