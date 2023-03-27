CREATE TABLE [dbo].[IngredientLists] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [RecipeId]   INT           NOT NULL,
    [CreateDate] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_IngredientLists] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IngredientLists_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_IngredientLists_RecipeId]
    ON [dbo].[IngredientLists]([RecipeId] ASC);

