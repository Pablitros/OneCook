CREATE TABLE [dbo].[Likes] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [RecipeId]   INT           NOT NULL,
    [CreateDate] DATETIME2 (7) NOT NULL,
    [UserId]     INT           NOT NULL,
    CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Likes_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Likes_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Likes_UserId]
    ON [dbo].[Likes]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Likes_RecipeId]
    ON [dbo].[Likes]([RecipeId] ASC);

