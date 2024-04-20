# ECommerce

# Table Queries

CREATE TABLE Product(
   ID SERIAL  PRIMARY KEY     NOT NULL,
   NAME           TEXT    NOT NULL,
   PRICE            INT     NOT NULL,
   CATEGORY        TEXT,
   COLOR			TEXT,
   DESCRIPTION          TEXT,
   IMAGEPATH	   TEXT,
	QUANTITY	INT     NOT NULL
);