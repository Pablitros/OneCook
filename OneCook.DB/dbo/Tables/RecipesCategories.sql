CREATE TABLE [dbo].[RecipesCategories] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [RecipeId]   INT NOT NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT [PK_RecipesCategories] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RecipesCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RecipesCategories_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RecipesCategories_RecipeId]
    ON [dbo].[RecipesCategories]([RecipeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RecipesCategories_CategoryId]
    ON [dbo].[RecipesCategories]([CategoryId] ASC);

