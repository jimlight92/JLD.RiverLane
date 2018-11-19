INSERT INTO ADDRESS(HOUSE_NAME, STREET, TOWN, CITY, POSTCODE)
VALUES('House Name', 'Street', 'Town', 'City', 'Postcode')
GO

INSERT INTO EXTRA_ALBUM(TITLE, NUMBER_OF_PAGES, PRICE, EXTRA_TEXT)
VALUES
('30 page Layflat Premium', 30, 195, 'additional pages - £3.50 each'),
('40 page Hardback', 40, 95, 'additional pages £ on request'),
('40 page Small Hardback', 40, 65, 'additional pages £ on request')
GO

INSERT INTO EXTRA_POINT(TEXT)
VALUES
('Back up USB Drive of images - <strong>£15</strong>'),
('Travel & Accommodation beyond 60/100 mile radius of BA5 - <strong>50p per mile & £100 per night</strong> (dependant on location of wedding and travelling time required)'),
('Additional pages in Hardback Wedding Album - <strong>£1.80 each</strong>'),
('Additional pages in Layflat Premium Wedding Album - <strong>£3.50 each</strong>'),
('Professionally printed images can be produced, price on application as it is dependant on the size and format required (i.e onto Canvas, Framed, Perspex, Print only)')
GO

INSERT INTO PRICE(TITLE, DESCRIPTION, VALUE, PACKAGE_TYPE)
VALUES
('Engagement Pre Wedding Shoot <span class=''normal-font''>-</span> 2 Hour Photo Shoot', 'Photos can be used for wedding invites, guest signing board or unique reception place names. <br/> An ideal way for those of you not comfortable in front of the camera to have a bit of fun!', 150, 1),
('Half Day Package', 'Bride''s Arrival - Ceremony - Reception', 695, 2),
('Full Day Package', 'Bridal/Groom Preparations - Bride''s Arrival - Ceremony - Reception - Speeches', 995, 4),
('Additional Evening Package', 'First dance and evening entertainment', 250, 5)
GO

DECLARE @PRE_WEDDING_ID INT = (SELECT PRICE_ID FROM PRICE WHERE PACKAGE_TYPE = 1);
DECLARE @HALF_DAY_ID INT = (SELECT PRICE_ID FROM PRICE WHERE PACKAGE_TYPE = 2);
DECLARE @FULL_DAY_ID INT = (SELECT PRICE_ID FROM PRICE WHERE PACKAGE_TYPE = 4);
DECLARE @ADDITIONAL_ID INT = (SELECT PRICE_ID FROM PRICE WHERE PACKAGE_TYPE = 5);

INSERT INTO PRICE_POINT(PRICE_ID, DESCRIPTION)
VALUES
(@PRE_WEDDING_ID, 'Location of your choice (within a suitable local area)'),
(@PRE_WEDDING_ID, 'Travel expenses included up to 60 miles from BA5'),
(@PRE_WEDDING_ID, '100 Pictures presented on USB Drive with license granted to the couple to print or reproduce the images themselves for personal use'),
(@HALF_DAY_ID, 'Travel up to 60 miles from BA5'),
(@HALF_DAY_ID, 'Coverage of bride''s arrival at ceremony until guests are seated for reception dinner'),
(@HALF_DAY_ID, 'Approx 500 pictures presented on USB Drive with license granted to the couple to print or reproduce the images themselves for personal use'),
(@HALF_DAY_ID, '40 page Hardback Wedding Photo Book with approx 80 pictures'),
(@FULL_DAY_ID, 'Travel up to 100 miles from BA5'),
(@FULL_DAY_ID, 'Coverage of bridal preparations before ceremony until after speeches'),
(@FULL_DAY_ID, 'Approx 1000 pictures presented on USB Drive with license granted to the couple to print or reproduce the images themselves for personal use'),
(@FULL_DAY_ID, '30 page Layflat Premium Hardback Wedding Photo Book with approx 60 pictures'),
(@ADDITIONAL_ID, 'Coverage of the evening celebrations to capture crazy dancing and flamboyant guests!'),
(@ADDITIONAL_ID, 'Only available when booking one of the above packages.')
GO

INSERT INTO RECOMMEND(COMPANY_NAME, EMAIL, COMPANY_DESCRIPTION, PHONE, WEBSITE_URL, WEBSITE_TEXT, LOCATION)
VALUES
('The Bishop''s Palace', '', 'Wedding Venue', '01749 988111', 'http://www.bishopspalace.org.uk/wedding-receptions', 'bishopspalace.org.uk/wedding-receptions', 0),
('Minsky''s Barbershop', '', 'Male Hair Stylists', '01749 939432', 'https://www.facebook.com/MinskysWells', 'View the FaceBook page!', 0),
('Jim Light', 'jimlight@jimlightdevelopment.co.uk', 'Web Developer', '07875 609847', '', '', 0),
('Claire Gainard', 'cgainard@hotmail.co.uk', 'Wedding Stylist', '01749 345479', '', '', 0),
('Caroline James', '', 'Makeup and Hairstyling', '07973 505099', 'http://carolinejamesmakeupartist.co.uk', 'carolinejamesmakeupartist.co.uk', 1),
('The Hair Lounge', '', 'Hair Stylists', '01244 570071', 'http://www.thehairloungerossett.co.uk', 'thehairloungerossett.co.uk', 1),
('UK Wedding Favours', '', 'Favours', '01282 850032', 'http://www.ukweddingfavours.co.uk', 'ukweddingfavours.co.uk', 1),
('Quintessential Cakes Newton le Willows', 'katy@quinncakes.co.uk', 'Wedding Cakes', '0777 9619922', 'http://www.quinncakes.co.uk', 'quinncakes.co.uk', 1),
('Alfresco Disco DJs', 'frankiemann.fm@googlemail.com', 'DJs', '07941 558172', '', '', 1)
GO

INSERT INTO SETTINGS(CONTACT_NUMBER, CONTACT_EMAIL, CONTACT_ADDRESS_ID)
VALUES('ContactNumber', 'jl.developer92@gmail.com', (SELECT TOP 1 ADDRESS_ID FROM ADDRESS))
GO

INSERT INTO USER_ACCOUNT(USERNAME, PASSWORD_HASH, PASSWORD_SALT)
VALUES('super', 'zKlMXly80p6rCrJ327ajo0xAbzYXmeGZDyngFCJyPTg=', 'DkF0PgQokQaOOGWBoplZs49Fces3abxn/HpFN+DsrdE=')
GO