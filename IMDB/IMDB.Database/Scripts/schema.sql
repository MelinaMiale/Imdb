create table dbo.Actors (
	Id BIGINT IDENTITY NOT NULL,
	FirstName NVARCHAR(128) not null,
	LastName NVARCHAR(128) not null,
	Nationality NVARCHAR(128) null,
	Age INT not null,
	ProfileFoto NVARCHAR(255) null unique,
	primary key (Id)
)
GO


create table dbo.Characters (
	Id BIGINT IDENTITY NOT NULL,
	CharacterName NVARCHAR(30) null unique,
	ActorId BIGINT not null,
	MovieId BIGINT not null,
	primary key (Id)
)
GO


create table dbo.Movies (
	Id BIGINT IDENTITY NOT NULL,
	Title NVARCHAR(128) not null unique,
	Nationality NVARCHAR(128) null,
	ReleaseDate DATETIME2 null,
	Poster NVARCHAR(255) null unique,
	primary key (Id)
)
GO


alter table dbo.Characters 
add constraint FK_1291E7CF 
foreign key (ActorId) 
references dbo.Actors
GO


alter table dbo.Characters 
add constraint FK_6CB7AD18 
foreign key (MovieId) 
references dbo.Movies
GO

