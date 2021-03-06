
CREATE PROCEDURE [dbo].[SPChatMessagesGet]
	@LastMessageID int = 0,
	@RoomId int = 1
AS
SELECT
	CM.MessageId,
	CM.MessageBody,
	CM.UserId,
	'User ' + convert(varchar, CM.UserId) AS UserName,
	MessageDate
FROM
	ChatMessages CM
WHERE
	CM.MessageID > @LastMessageID
	AND
	CM.RoomId = @RoomId

