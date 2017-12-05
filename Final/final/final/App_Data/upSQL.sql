CREATE TABLE dbo.Buyer
(
BuyerID INT IDENTITY (1,1) NOT NULL,
BuyerName	NVARCHAR(128) NOT NULL,
CONSTRAINT[PK_dbo.Buyer] PRIMARY KEY CLUSTERED (BuyerID ASC)
);


CREATE TABLE dbo.Seller
(
SellerID INT IDENTITY (1,1) NOT NULL,
SellerName	NVARCHAR(128) NOT NULL,
CONSTRAINT[PK_dbo.Seller] PRIMARY KEY CLUSTERED (SellerID ASC)
);


CREATE TABLE dbo.Item
(
ItemID INT IDENTITY (1,1) NOT NULL,
ItemName	NVARCHAR(128) NOT NULL,
ItemDescription NVARCHAR (128) NOT NULL,
SellerID INT,
CONSTRAINT[PK_dbo.Item] PRIMARY KEY CLUSTERED (ItemID ASC),
CONSTRAINT FK_SellerID FOREIGN KEY (SellerID)
REFERENCES Seller(SellerID)
);


CREATE TABLE dbo.Bid
(
BidID INT IDENTITY (1,1) NOT NULL,
ItemID	INT,
BuyerID INT,
Price DECIMAL NOT NULL,
BidTime datetime NOT NULL,
CONSTRAINT[PK_dbo.Bid] PRIMARY KEY CLUSTERED (BidID ASC),
CONSTRAINT FK_ItemID FOREIGN KEY (ItemID)
REFERENCES Item(ItemID),
CONSTRAINT FK_BuyerID FOREIGN KEY (BuyerID)
REFERENCES Buyer(BuyerID)
);


INSERT INTO dbo.Buyer (BuyerName) VALUES 
	('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall');
GO


INSERT INTO dbo.Seller (SellerName) VALUES 
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene');
GO


INSERT INTO dbo.Item (ItemName, ItemDescription, SellerID) VALUES 
	('Abraham Lincoln Hammer', 'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', '3'),
	('Albert Einsteins Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927', '1'),
	('Bob Dylan Love Poems', 'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', '2');
GO


INSERT INTO dbo.Bid (ItemID, BuyerID, Price, BidTime) VALUES 
	('1','3', '250000', '2017-12-04 09:04:22'),
	('3','1', '95000','2017-12-04 08:44:03');
GO

