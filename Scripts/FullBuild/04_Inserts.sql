INSERT INTO ADDRESS(HOUSE_NAME, STREET, TOWN, CITY, POSTCODE)
VALUES('House Name', 'Street', 'Town', 'City', 'Postcode')

INSERT INTO SETTINGS(CONTACT_NUMBER, CONTACT_EMAIL, CONTACT_ADDRESS_ID)
VALUES('ContactNumber', 'jl.developer92@gmail.com', @@IDENTITY)
GO

INSERT INTO USER_ACCOUNT(USERNAME, PASSWORD_HASH, PASSWORD_SALT)
VALUES('super', 'zKlMXly80p6rCrJ327ajo0xAbzYXmeGZDyngFCJyPTg=', 'DkF0PgQokQaOOGWBoplZs49Fces3abxn/HpFN+DsrdE=')
GO