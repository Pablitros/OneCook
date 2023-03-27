CREATE TABLE [dbo].[UserLevels] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [LevelName] NVARCHAR (100)  NOT NULL,
    [Price]     DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_UserLevels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

