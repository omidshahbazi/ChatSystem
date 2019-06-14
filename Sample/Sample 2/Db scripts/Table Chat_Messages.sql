
CREATE TABLE [dbo].[ChatMessages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL,
	[MessageBody] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MessageDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_ChatMessages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]