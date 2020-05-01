﻿CREATE TABLE dbo.Debtors (
	Number VARCHAR(255) NOT NULL,
	Name VARCHAR(255) NOT NULL,
	Telephone VARCHAR(255) NULL,
	Mobile VARCHAR(255) NULL,
	Email VARCHAR(255) NULL,
	IsClosed BIT NOT NULL CONSTRAINT dfDebtors DEFAULT 0,
	CONSTRAINT pkDebtors PRIMARY KEY CLUSTERED (Number)
);