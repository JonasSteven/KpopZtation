CREATE TABLE Customer(
	[CustomerID] INT PRIMARY KEY IDENTITY(1,1),
	[CustomerName] VARCHAR(50) NOT NULL,
	[CustomerEmail] VARCHAR(50) NOT NULL,
	[CustomerPassword] VARCHAR(50) NOT NULL,
	[CustomerGender] VARCHAR(6) NOT NULL,
	[CustomerAddress] VARCHAR(100) NOT NULL,
	[CustomerRole] VARCHAR(5) NOT NULL
)

CREATE TABLE Artist(
	[ArtistID] INT PRIMARY KEY IDENTITY(1,1),
	[ArtistName] VARCHAR(50) NOT NULL,
	[ArtistImage] VARCHAR(50) NOT NULL
)

CREATE TABLE Album(
	[AlbumID] INT PRIMARY KEY IDENTITY(1,1),
	[ArtistID] INT FOREIGN KEY REFERENCES Artist([ArtistID]),
	[AlbumName] VARCHAR(50) NOT NULL,
	[AlbumImage] VARCHAR(50) NOT NULL,
	[AlbumPrice] INT NOT NULL,
	[AlbumStock] INT NOT NULL,
	[AlbumDescription] VARCHAR(255) NOT NULL
)

CREATE TABLE Cart(
	[CustomerID] INT NOT NULL,
	[AlbumID] INT NOT NULL,
	[Qty] INT NOT NULL,
	PRIMARY KEY(CustomerID, AlbumID),
	FOREIGN KEY(CustomerID) REFERENCES Customer([CustomerID]),
	FOREIGN KEY(AlbumID) REFERENCES Album([AlbumID])
)

CREATE TABLE TransactionHeader(
	[TransactionID] INT PRIMARY KEY IDENTITY(1,1),
	[TransactionDate] DATE NOT NULL,
	[CustomerID] INT FOREIGN KEY REFERENCES Customer([CustomerID])
)

CREATE TABLE TransactionDetail(
	[TransactionID] INT NOT NULL,
	[AlbumID] INT FOREIGN KEY REFERENCES Album([AlbumID]),
	[Qty] INT NOT NULL
	PRIMARY KEY(TransactionID, AlbumID),
	FOREIGN KEY(TransactionID) REFERENCES TransactionHeader([TransactionID]),
	FOREIGN KEY(AlbumID) REFERENCES Album([AlbumID])
)