﻿ALTER TABLE ADDRESS
ADD CONSTRAINT PK_ADDRESS PRIMARY KEY CLUSTERED (ADDRESS_ID)
GO

ALTER TABLE EXTRA_ALBUM
ADD CONSTRAINT PK_EXTRA_ALBUM PRIMARY KEY CLUSTERED (EXTRA_ALBUM_ID)
GO

ALTER TABLE EXTRA_POINT
ADD CONSTRAINT PK_EXTRA_POINT PRIMARY KEY CLUSTERED (EXTRA_POINT_ID)
GO

ALTER TABLE MESSAGE
ADD CONSTRAINT PK_MESSAGE PRIMARY KEY CLUSTERED (MESSAGE_ID)
GO

ALTER TABLE PRICE
ADD CONSTRAINT PK_PRICE PRIMARY KEY CLUSTERED (PRICE_ID)
GO

ALTER TABLE PRICE_POINT
ADD CONSTRAINT PK_PRICE_POINT PRIMARY KEY CLUSTERED (PRICE_POINT_ID)
GO

ALTER TABLE RECOMMEND
ADD CONSTRAINT PK_RECOMMEND PRIMARY KEY CLUSTERED (RECOMMEND_ID)
GO

ALTER TABLE SETTINGS
ADD CONSTRAINT PK_SETTINGS PRIMARY KEY CLUSTERED (SETTINGS_ID)
GO

ALTER TABLE USER_ACCOUNT
ADD CONSTRAINT PK_USER_ACCOUNT PRIMARY KEY CLUSTERED (USER_ACCOUNT_ID)
GO 