CREATE TABLE [dbo].[Recipes] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [UserId]       INT            NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    [CreateDate]   DATETIME2 (7)  NOT NULL,
    [TimeCreation] INT            NOT NULL,
    [MainImage]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Recipes_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Recipes_UserId]
    ON [dbo].[Recipes]([UserId] ASC);

