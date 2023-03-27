CREATE TABLE [dbo].[PreparationGuides] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [RecipeId]   INT           NOT NULL,
    [CreateDate] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_PreparationGuides] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PreparationGuides_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PreparationGuides_RecipeId]
    ON [dbo].[PreparationGuides]([RecipeId] ASC);

