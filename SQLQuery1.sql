CREATE TABLE [dbo].[CarImages] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CarId]     INT            NULL,
    [ImagePath] NVARCHAR (MAX) NULL,
    [Date]      DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id])
);