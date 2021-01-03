CREATE DATABASE BookBookDB
GO

USE BookBookDB
GO

CREATE TABLE MsUser (
	UserID INT IDENTITY(1, 1),
	Username VARCHAR(100),
	Password VARCHAR(100),
	Name VARCHAR(100)
)

GO
INSERT INTO MsUser
VALUES ('Arya', '123', 'Arya Arya')

GO
-- =============================================
-- Author		: Arya Surya
-- Create date	: 13 Jan 2020
-- Description	: Check if user exists so that it could access the token
-- =============================================
CREATE PROCEDURE bn_BookDB_GetUser
	@Username VARCHAR(100),
	@Password VARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		Username, 
		Password 
	FROM 
		MsUser
	WHERE 
		Username = @Username
		AND Password = @Password
END

GO
CREATE TABLE MsBook (
	BookID INT IDENTITY(1, 1),
	BookName VARCHAR(100),
	BookDesc VARCHAR(100),
	BookQty INT
)

GO
INSERT INTO MsBook
VALUES ('Buku SQL', 'Buku tentang SQL', 3)

GO
CREATE PROCEDURE bn_BookDB_GetAllbook
AS
BEGIN
	SET NOCOUNT ON;

	SELECT BookID, BookName, BookDesc, BookQty
	FROM MsBook
END

GO
CREATE PROCEDURE bn_BookDB_UpdateBook
@BookID INT,
@BookName VARCHAR(100),
@BookDesc VARCHAR(100),
@BookQty INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE MsBook
	SET BookName = @BookName,
	BookDesc = @BookDesc,
	BookQty = @BookQty
	WHERE BookID = @BookID
END

GO
CREATE PROCEDURE bn_BookDB_DeleteBook
@BookID INT
AS 
BEGIN
	SET NOCOUNT ON;

	DELETE FROM MsBook
	WHERE BookID = @BookID
END

GO
CREATE PROCEDURE bn_BookDB_GetOneBook
@BookID INT
AS 
BEGIN
	SET NOCOUNT ON;
	
	SELECT * 
	FROM MsBook
	WHERE BookID = @BookID
END

GO
CREATE PROCEDURE bn_BookDB_InsertBook
@BookName VARCHAR(100),
@BookDesc VARCHAR(100),
@BookQty INT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO MsBook
	VALUES (@BookName, @BookDesc, @BookQty)
END

GO
CREATE PROCEDURE bn_BookDB_GetLoginData
@UserName VARCHAR(100),
@Password VARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM MsUser
	WHERE Username = @UserName
	AND Password = @Password
END

CREATE TABLE BorrowBook(
	BookID INT,
	BookName VARCHAR(100),
	BookDesc VARCHAR(100)
)

GO
CREATE PROCEDURE bn_BookDB_Borrow
@BookID INT,
@BookName VARCHAR(100),
@BookDesc VARCHAR(100),
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO BorrowBook
	VALUES (@BookId,@BookName,@BookDesc)

	UPDATE MsBook SET BookQty=BookQty-1 WHERE BookID=@BookID
END

GO
CREATE PROCEDURE bn_BookDB_BorrowIndex
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM BorrowBook
END