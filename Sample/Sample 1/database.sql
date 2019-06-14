/****** Object:  Table [dbo].[message]    Script Date: 04/03/2007 16:37:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[message](
	[message_id] [int] IDENTITY(1,1) NOT NULL,
	[chat_id] [int] NOT NULL CONSTRAINT [DF_message_chat_id]  DEFAULT ((0)),
	[user_id] [int] NOT NULL CONSTRAINT [DF_message_user_id]  DEFAULT ((0)),
	[user_name] [nvarchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[message] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[post_time] [datetime] NOT NULL CONSTRAINT [DF_message_post_time]  DEFAULT (getdate()),
 CONSTRAINT [PK_message] PRIMARY KEY CLUSTERED 
(
	[message_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
