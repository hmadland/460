CREATE TABLE dbo.Artists
(
ArtistID INT IDENTITY (1,1) NOT NULL,
FullName	NVARCHAR(128) NOT NULL,
DOB			Date NOT NULL,
BirthCity	NVARCHAR(128) NOT NULL,
BirthCountry NVARCHAR(128) NOT NULL
CONSTRAINT[PK_dbo.Artists] PRIMARY KEY CLUSTERED (ArtistID ASC)
);


CREATE TABLE dbo.ArtWorks
(
ArtWorkID INT IDENTITY (1,1) NOT NULL,
Title	NVARCHAR(128) NOT NULL,
Artist	NVARCHAR(128) NOT NULL,
ArtistID INT,
CONSTRAINT[PK_dbo.ArtWorks] PRIMARY KEY CLUSTERED (ArtWorkID ASC),
CONSTRAINT FK_ArtistID FOREIGN KEY (ArtistID)
REFERENCES Artists(ArtistID)
);

CREATE TABLE dbo.Genres
(
GenreID INT IDENTITY (1,1) NOT NULL,
GName	NVARCHAR(128) NOT NULL,
CONSTRAINT[PK_dbo.Genres] PRIMARY KEY CLUSTERED (GenreID ASC),
);


CREATE TABLE dbo.Classifications
(
ClassID INT IDENTITY (1,1) NOT NULL,
Artwork	NVARCHAR(128) NOT NULL,
Genre	NVARCHAR(128) NOT NULL,
ArtWorkID INT,
GenreID INT,
CONSTRAINT[PK_dbo.Classifications] PRIMARY KEY CLUSTERED (ClassID ASC),
CONSTRAINT FK_ArtWorkID FOREIGN KEY (ArtWorkID)
REFERENCES ArtWorks(ArtWorkID),
CONSTRAINT FK_GenreID FOREIGN KEY (GenreID)
REFERENCES Genres(GenreID)
);



INSERT INTO dbo.Artists (FullName, DOB, BirthCity, BirthCountry) VALUES 
	('M.C. Escher', '1898-06-17 00:00:00', 'Leeuwarden','Netherlands'),
	('Leonardo Da Vinci', '1519-05-02 00:00:00', 'Vinci','Italy'),
	('Hatip Mehmed Efendi', '1680-11-18 00:00:00','Unknown','Unknown'),
	('Salvador Dali', '1904-05-11 00:00:00', 'Figueres','Spain');
GO

INSERT INTO dbo.ArtWorks (Title, Artist, ArtistID) VALUES 
	('Circle Limit III','M.C. Escher', '1'),
    ('Twon Tree','M.C. Escher', '1'),
	('Mona Lisa','Leonardo Da Vinci', '2'),
	('The Vitruvian Man','Leonardo Da Vinci', '2'),
	('Ebru','Hatip Mehmed Efendi', '3'),
	('Honey Is Sweeter Than Blood','Salvador Dali','4');
GO

INSERT INTO dbo.Genres(GName) VALUES 
	('Tesselation'),
    ('Surrealism'),
	('Portrait'),
	('Renaissance');
GO

INSERT INTO dbo.Classifications(Artwork, Genre, ArtWorkID, GenreID) VALUES 
	('Circle Limit III','Tesselation', '2','1'),
    ('Twon Tree','Tesselation', '3','1'),
	('Twon Tree','Surrealism', '3', '2'),
	('Mona Lisa','Portrait', '4', '3'),
	('Mona Lisa','Renaissance','4', '4'),
	('The Vitruvian Man','Renaissance', '5', '4'),
	('Ebru','Tesselation','6', '1'),
	('Honey Is Sweeter Than Blood','Surrealism','7', '2');
GO