

CREATE PROCEDURE [dbo].[SPChatMessagesInsert]
	@RoomId int
	,@MessageBody varchar(250)
	,@MessageDate datetime
	,@UserId int
	,@IsSystem bit
AS
INSERT INTO ChatMessages
(
	RoomId
	,MessageBody
	,MessageDate
	,UserId
	,IsSystem
)
VALUES
(
	@RoomId
	,@MessageBody
	,@MessageDate
	,@UserId
	,@IsSystem
)
