﻿CREATE TABLE USER_ACCOUNT (
	USER_ACCOUNT_ID		INT IDENTITY(1,1)	NOT NULL,
	USERNAME			VARCHAR(50)			NOT NULL,
	PASSWORD_HASH		VARCHAR(MAX)		NOT NULL,
	PASSWORD_SALT		VARCHAR(MAX)		NOT NULL
)
