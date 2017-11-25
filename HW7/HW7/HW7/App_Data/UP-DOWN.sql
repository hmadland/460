--up
CREATE TABLE dbo.GiphyLogs
(
	giphyID			INT IDENTITY (1,1)	NOT NULL,
	queryTime			DATETIME	NOT NULL,
	queryClientAgent	VARCHAR(128),
	giphyQuery		VARCHAR(128),
	CONSTRAINT [PK_dbo.GiphyLogs] PRIMARY KEY CLUSTERED (giphyID ASC)
);

--down
DROP TABLE dbo.GiphyLogs;