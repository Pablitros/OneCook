CREATE TABLE [dbo].[Comments] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RecipeId]   INT            NOT NULL,
    [CreateDate] DATETIME2 (7)  NOT NULL,
    [Commentary] NVARCHAR (400) NOT NULL,
    [UserId]     INT            NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Comments_UserId]
    ON [dbo].[Comments]([UserId] ASC);

