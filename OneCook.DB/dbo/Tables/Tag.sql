﻿CREATE TABLE [dbo].[Tag] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([Id] ASC)
);

