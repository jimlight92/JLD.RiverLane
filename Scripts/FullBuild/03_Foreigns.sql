ALTER TABLE SETTINGS
ADD CONSTRAINT FK_SETTINGS_ADDRESS FOREIGN KEY (CONTACT_ADDRESS_ID)
REFERENCES ADDRESS(ADDRESS_ID)
GO