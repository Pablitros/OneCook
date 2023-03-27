CREATE TABLE [dbo].[Ingredients] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [Quantity]         NVARCHAR (MAX) NOT NULL,
    [IngredientListId] INT            NOT NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Ingredients_IngredientLists_IngredientListId] FOREIGN KEY ([IngredientListId]) REFERENCES [dbo].[IngredientLists] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Ingredients_IngredientListId]
    ON [dbo].[Ingredients]([IngredientListId] ASC);

