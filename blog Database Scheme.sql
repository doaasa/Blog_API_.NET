Create Database Blog;

Use Blog;


Create Table Article(
Ar_ID int NOT NULL PRIMARY KEY identity (1,1),
Ar_Name nvarchar(100),
Ar_Status int,
Ar_Content nvarchar(max),
Ar_AuthorID int,
FOREIGN KEY (Ar_AuthorID) REFERENCES Authors(A_ID)

)


Create Table Authors(
A_ID int NOT NULL PRIMARY KEY identity (1,1),
A_Name nvarchar(100),
A_AGE int,
A_Address nvarchar(100)
)