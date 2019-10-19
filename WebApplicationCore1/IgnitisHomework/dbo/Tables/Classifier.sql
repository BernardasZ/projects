CREATE TABLE [dbo].[Classifier] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [ClassifierTypeId] INT            NOT NULL,
    [Value]            NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Classifier] PRIMARY KEY CLUSTERED ([Id] ASC)
);

