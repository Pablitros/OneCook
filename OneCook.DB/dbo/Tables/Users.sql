CREATE TABLE [dbo].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Username]    NVARCHAR (20)  NOT NULL,
    [Email]       NVARCHAR (200) NOT NULL,
    [Password]    NVARCHAR (20)  NULL,
    [Description] NVARCHAR (400) NOT NULL,
    [UserUID]     NVARCHAR (MAX) NULL,
    [UserLevelId] INT            NOT NULL,
    [UserImage]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_UserLevels_UserLevelId] FOREIGN KEY ([UserLevelId]) REFERENCES [dbo].[UserLevels] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_UserLevelId]
    ON [dbo].[Users]([UserLevelId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email]
    ON [dbo].[Users]([Email] ASC);

