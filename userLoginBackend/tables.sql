USE [Login]
GO
/****** Object:  Table [dbo].[Activity_Logs]    Script Date: 25/06/2024 11:06:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity_Logs](
	[logId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [varchar](50) NULL,
	[activity] [varchar](255) NOT NULL,
	[timestamp] [datetime2](7) NULL,
 CONSTRAINT [PK__Activity__7839F64DB11CC6A9] PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 25/06/2024 11:06:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[reportId] [int] IDENTITY(1,1) NOT NULL,
	[reportName] [varchar](100) NOT NULL,
	[reportData] [text] NOT NULL,
	[generatedBy] [varchar](50) NULL,
	[generatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK__Reports__1C9B4E2DB70235FA] PRIMARY KEY CLUSTERED 
(
	[reportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25/06/2024 11:06:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[passwordHash] [varchar](255) NOT NULL,
	[email] [varchar](100) NULL,
	[role] [nvarchar](10) NOT NULL,
	[profilePicture] [varchar](255) NULL,
	[createdAt] [datetime2](7) NULL,
	[updatedAt] [datetime2](7) NULL,
	[userDOB] [date] NOT NULL,
	[PhoneNumber] [nchar](10) NOT NULL,
 CONSTRAINT [PK__Users__CB9A1CFF8DDF7FA4] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__AB6E6164C826B575]    Script Date: 25/06/2024 11:06:54 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__AB6E6164C826B575] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__F3DBC5727FEB2F2D]    Script Date: 25/06/2024 11:06:54 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__F3DBC5727FEB2F2D] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activity_Logs] ADD  CONSTRAINT [DF__Activity___times__3F466844]  DEFAULT (getdate()) FOR [timestamp]
GO
ALTER TABLE [dbo].[Reports] ADD  CONSTRAINT [DF__Reports__generat__4316F928]  DEFAULT (getdate()) FOR [generatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__createdAt__3A81B327]  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__updatedAt__3B75D760]  DEFAULT (getdate()) FOR [updatedAt]
GO
ALTER TABLE [dbo].[Activity_Logs]  WITH CHECK ADD  CONSTRAINT [FK__Activity___userI__403A8C7D] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Activity_Logs] CHECK CONSTRAINT [FK__Activity___userI__403A8C7D]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK__Reports__generat__440B1D61] FOREIGN KEY([generatedBy])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK__Reports__generat__440B1D61]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__role__398D8EEE] CHECK  (([role]='Student' OR [role]='Librarian' OR [role]='Admin'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__role__398D8EEE]
GO
