CREATE TABLE [dbo].[TagList] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [RecipeId] INT NOT NULL,
    [TagId]    INT NOT NULL,
    CONSTRAINT [PK_TagList] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TagList_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TagList_Tag_TagId] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TagList_TagId]
    ON [dbo].[TagList]([TagId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TagList_RecipeId]
    ON [dbo].[TagList]([RecipeId] ASC);

