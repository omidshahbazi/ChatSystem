
CREATE PROCEDURE [dbo].[SPChatMessagesGetLastMessage]
AS
SELECT
	ISNULL(MAX(CM.MessageId),0) AS LastMessageID
FROM
	ChatMessages CM
