USE [Demo]
GO

/****** Object:  Table [dbo].[SentMessages]    Script Date: 17.03.20 13:09:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SentMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateAndTime] [datetime2](7) NOT NULL,
	[Recipient] [nvarchar](max) NULL,
	[MobileNumber] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
 CONSTRAINT [PK_SentMessages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

