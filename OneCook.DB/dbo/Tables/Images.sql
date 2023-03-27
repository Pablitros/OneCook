CREATE TABLE [dbo].[Images] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ImagePath]  NVARCHAR (MAX) NOT NULL,
    [CreateDate] DATETIME2 (7)  NOT NULL,
    [RecipeId]   INT            NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Images_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Images_RecipeId]
    ON [dbo].[Images]([RecipeId] ASC);

