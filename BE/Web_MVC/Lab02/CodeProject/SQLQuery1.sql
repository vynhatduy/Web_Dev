Create database BloggingContext
go
use BloggingContext
go
create table Blog
(
	BlogId int primary key,
	BlogName text
)
go
create table Post
(
	PostId int primary key,
	Title text,
	Content text,
	BlogId int references Blog(BlogId)
)
go