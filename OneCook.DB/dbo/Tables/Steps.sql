CREATE TABLE [dbo].[Steps] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [PreparationGuideId] INT            NOT NULL,
    [Content]            NVARCHAR (400) NOT NULL,
    [TimeUsed]           NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Steps] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Steps_PreparationGuides_PreparationGuideId] FOREIGN KEY ([PreparationGuideId]) REFERENCES [dbo].[PreparationGuides] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Steps_PreparationGuideId]
    ON [dbo].[Steps]([PreparationGuideId] ASC);

