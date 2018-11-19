CREATE TABLE dbo.ADDRESS (
	ADDRESS_ID					INT IDENTITY(1, 1)	NOT NULL,
	HOUSE_NAME					VARCHAR(50)			NULL,
	STREET						VARCHAR(50)			NULL,
	TOWN						VARCHAR(50)			NULL,
	CITY						VARCHAR(50)			NULL,
	POSTCODE					VARCHAR(10)			NULL
)
GO

CREATE TABLE dbo.EXTRA_ALBUM (
	EXTRA_ALBUM_ID				INT IDENTITY(1, 1)	NOT NULL,
	TITLE						VARCHAR(100)		NOT NULL,
	NUMBER_OF_PAGES				INT					NOT NULL,
	PRICE						DECIMAL(5, 2)		NOT NULL,
	EXTRA_TEXT					VARCHAR(1000)		NOT NULL
)
GO

CREATE TABLE dbo.EXTRA_POINT (
	EXTRA_POINT_ID				INT IDENTITY(1, 1)	NOT NULL,
	TEXT						VARCHAR(1000)		NOT NULL
)
GO

CREATE TABLE dbo.MESSAGE (
	MESSAGE_ID					INT IDENTITY(1, 1)	NOT NULL,
	NAME						VARCHAR(50)			NOT NULL,
	EMAIL						VARCHAR(200)		NOT NULL,
	LOCATION					VARCHAR(100)		NULL,
	PHONE						VARCHAR(50)			NOT NULL,
	MESSAGE						VARCHAR(4000)		NOT NULL,
	DATE_RECEIVED				DATETIME			NOT NULL,
	WEDDING_LOCATION			VARCHAR(100)		NOT NULL,
	HOW_DID_YOU_FIND_ME			VARCHAR(200)		NOT NULL,
	PACKAGE_TYPE				INT					NULL,
	WEDDING_DATE				DATETIME			NOT NULL
)
GO

CREATE TABLE dbo.PRICE (
	PRICE_ID					INT IDENTITY(1, 1)	NOT NULL,
	TITLE						VARCHAR(100)		NOT NULL,
	DESCRIPTION					VARCHAR(1000)		NOT NULL,
	VALUE						DECIMAL(6, 2)		NOT NULL,
	PACKAGE_TYPE				INT					NOT NULL,
)
GO

CREATE TABLE dbo.PRICE_POINT (
	PRICE_POINT_ID				INT IDENTITY(1, 1)	NOT NULL,
	PRICE_ID					INT					NOT NULL,
	DESCRIPTION					VARCHAR(4000)		NOT NULL
)
GO

CREATE TABLE dbo.RECOMMEND (
	RECOMMEND_ID				INT IDENTITY(1, 1)	NOT NULL,
	COMPANY_NAME				VARCHAR(100)		NOT NULL,
	EMAIL						VARCHAR(200)		NOT NULL,
	COMPANY_DESCRIPTION			VARCHAR(200)		NULL,
	PHONE						VARCHAR(50)			NOT NULL,
	WEBSITE_URL					VARCHAR(200)		NOT NULL,
	WEBSITE_TEXT				VARCHAR(200)		NOT NULL,
	LOCATION					INT					NOT NULL
)
GO

CREATE TABLE dbo.SETTINGS (
	SETTINGS_ID					INT IDENTITY(1, 1)	NOT NULL,
	CONTACT_EMAIL				VARCHAR(200)		NOT NULL,
	CONTACT_NUMBER				VARCHAR(30)			NOT NULL,
	CONTACT_ADDRESS_ID			INT					NOT NULL
)
GO

CREATE TABLE dbo.USER_ACCOUNT (
	USER_ACCOUNT_ID				INT IDENTITY(1,1)	NOT NULL,
	USERNAME					VARCHAR(50)			NOT NULL,
	PASSWORD_HASH				VARCHAR(MAX)		NOT NULL,
	PASSWORD_SALT				VARCHAR(MAX)		NOT NULL
)
GO
