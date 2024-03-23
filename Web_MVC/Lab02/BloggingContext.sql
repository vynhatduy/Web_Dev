Create Table Blog
(
	BlogID int primary key,
	Name nvarchar(500),
)
Create Table Post
(
	PostID int primary key,
	Title nvarchar(500),
	Content ntext,
	BlogID int references Blog(BlogID)
)