DELETE FROM [LikedTrack]
WHERE [Id]>2;
GO

INSERT INTO [dbo].[LikedTrack]
           ([DateLiked]
           ,[User_id]
           ,[Track_id])
SELECT
    DATEADD(ss, -(ROW_NUMBER() OVER(ORDER BY [Id] ASC)), GETUTCDATE()),
    (SELECT [Id] FROM [User] WHERE [UserName] = 'ted'),
    [Id]
FROM [Track] WHERE [ID] > 4
GO