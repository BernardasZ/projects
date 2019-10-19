
CREATE PROCEDURE [dbo].[Feature_UpdateClassifierId]
	@featureId INT,
	@classifierId INT
AS
BEGIN
	UPDATE [IgnitisHomework].[dbo].[Feature]
	SET [ClassifierId] = @classifierId
	WHERE Id = @featureId
END
