-- Form table
CREATE TABLE dbo.Forms
(
	ID			INT IDENTITY (1,1) NOT NULL,
	FirstName	NVARCHAR(64) NOT NULL,
	LastName	NVARCHAR(128) NOT NULL,
	DOB			DateTime NOT NULL,
	NewAddress		NVARCHAR(128) NOT NULL,
	City		NVARCHAR(128) NOT NULL,
	NewState	NVARCHAR(64) NOT NULL,
	Zip			INT NOT NULL,
	County		NVARCHAR(128) NOT NULL,
	CONSTRAINT [PK_dbo.Forms] PRIMARY KEY CLUSTERED (ID ASC)
);

INSERT INTO dbo.Forms (FirstName, LastName, DOB, NewAddress, City, NewState, Zip, County) VALUES 
	('Buffy','Summers','1981-01-19 00:00:00','1630 Revello Drive','Sunnydale','California','95037', 'Santa Barbara'),
	('Xander','Harris','1981-01-25 00:00:00','1630 Revello Drive','Sunnydale','California','95037' ,'Santa Barbara'),
	('Willow','Rosenberg','1955-05-10 00:00:00','1630 Revello Drive','Sunnydale','California','95037', 'Santa Barbara'),
	('Rupert','Giles','1981-01-28 00:00:00','1630 Main St.','Sunnydale','California','95037', 'Santa Barbara'),
	('Spike','Pratt','1797-04-02 00:00:00','Sunnydale Cemetery','Sunnydale','California','95037', 'Santa Barbara');
GO