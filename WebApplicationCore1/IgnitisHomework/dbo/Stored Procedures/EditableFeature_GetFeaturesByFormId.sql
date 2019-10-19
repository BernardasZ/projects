
CREATE PROCEDURE [dbo].[EditableFeature_GetFeaturesByFormId]
	@formId INT
AS
BEGIN
	SELECT * 
	FROM [IgnitisHomework].[dbo].[EditableFeatureView] AS V
	WHERE V.[FormId] = @formId
	ORDER BY V.[FeatureId]
END
