CREATE TABLE [dbo].[School] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)   NOT NULL,
    [Address]        NVARCHAR (50)   NOT NULL,
    [Motto]          NVARCHAR (50)   NOT NULL,
    [AverageTuition] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

