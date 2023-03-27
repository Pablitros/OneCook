CREATE TABLE [dbo].[Followers] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [FollowerListId]  INT           NOT NULL,
    [UserFollowingId] INT           NOT NULL,
    [CreateDate]      DATETIME2 (7) DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    CONSTRAINT [PK_Followers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Followers_FollowerLists_FollowerListId] FOREIGN KEY ([FollowerListId]) REFERENCES [dbo].[FollowerLists] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Followers_Users_UserFollowingId] FOREIGN KEY ([UserFollowingId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Followers_UserFollowingId]
    ON [dbo].[Followers]([UserFollowingId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Followers_FollowerListId]
    ON [dbo].[Followers]([FollowerListId] ASC);

