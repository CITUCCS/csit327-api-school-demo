CREATE TABLE [dbo].[Student] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (255) NULL,
    [Email]    VARCHAR (255) NULL,
    [SchoolId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StudentSchool] FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[School] ([Id])
);

