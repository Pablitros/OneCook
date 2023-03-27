CREATE TABLE [dbo].[FollowerLists] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT [PK_FollowerLists] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FollowerLists_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_FollowerLists_UserId]
    ON [dbo].[FollowerLists]([UserId] ASC);

