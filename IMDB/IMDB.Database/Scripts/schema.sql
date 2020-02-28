create table dbo.Actors (
	Id BIGINT IDENTITY NOT NULL,
	FirstName NVARCHAR(128) not null,
	LastName NVARCHAR(128) not null,
	Nationality INT not null,
	Age INT not null,
	ProfileFoto NVARCHAR(255) null,
	primary key (Id)
)
GO


create table dbo.Courses (
	Id BIGINT IDENTITY NOT NULL,
	Title NVARCHAR(128) not null unique,
	Nationality INT not null,
	ReleaseDate DATETIME2 null,
	Poster NVARCHAR(255) null unique,
	primary key (Id)
)
GO

