
CREATE PROCEDURE [dbo].[Feature_GetFeaturesByFormId]
	@formId INT
AS
BEGIN
	SELECT * 
	FROM [IgnitisHomework].[dbo].[Feature] AS F
	WHERE F.[FormId] = @formId
END
