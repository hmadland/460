-- Form table
CREATE TABLE dbo.Forms
(
	ID			INT IDENTITY (1,1) NOT NULL,
	FirstName	NVARCHAR(64) NOT NULL,
	LastName	NVARCHAR(128) NOT NULL,
	DOB			DateTime NOT NULL,
	NewAddress		NVARCHAR(128) NOT NULL,
	City		NVARCHAR(128) NOT NULL,
	NewState	NVARCHAR(128) NOT NULL,
	Zip			INT NOT NULL,
	TodayDate	DateTime NOT NULL,
	CONSTRAINT [PK_dbo.Forms] PRIMARY KEY CLUSTERED (ID ASC)
);

INSERT INTO dbo.Forms (FirstName,LastName,DOB,NewAddress, City, NewState, Zip, TodayDate) VALUES 
	('Buffy','Summers','1981-01-19 00:00:00','1630 Revello Drive','Sunnydale','California','95037','2017-10-30 00:00:00'),
	('Xander','Harris','1981-01-25 00:00:00','1630 Revello Drive','Sunnydale','California','95037','2017-10-30 00:00:00'),
	('Willow','Rosenberg','1955-05-10 00:00:00','1630 Revello Drive','Sunnydale','California','95037','2017-11-30 00:00:00'),
	('Rupert','Giles','1981-01-28 00:00:00','1630 Main St.','Sunnydale','California','95037','2017-10-01 00:00:00'),
	('Spike','Pratt','1797-04-02 00:00:00','Sunnydale Cemetery','Sunnydale','California','95037','2017-11-01 00:00:00');
GO