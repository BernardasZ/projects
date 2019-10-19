CREATE TABLE [dbo].[Feature] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FormId]       INT            NOT NULL,
    [ClassifierId] INT            NULL,
    [Name]         NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Feature_Classifier] FOREIGN KEY ([ClassifierId]) REFERENCES [dbo].[Classifier] ([Id]),
    CONSTRAINT [FK_Feature_Form] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id])
);

