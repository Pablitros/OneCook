CREATE TABLE [dbo].[Favorites] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [RecipeId]   INT NOT NULL,
    [CreateDate] INT NOT NULL,
    [UserId]     INT NOT NULL,
    CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Favorites_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Favorites_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Favorites_UserId]
    ON [dbo].[Favorites]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Favorites_RecipeId]
    ON [dbo].[Favorites]([RecipeId] ASC);

