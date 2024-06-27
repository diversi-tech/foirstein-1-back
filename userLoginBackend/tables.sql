alter database [Login]

USE [Login]
GO
/****** Object:  Table [dbo].[Activity_Logs]    Script Date: 20/06/2024 13:26:04 ******/

GO
/****** Object:  Table [dbo].[Activity_Logs]    Script Date: 24/06/2024 20:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity_Logs](
	[logId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[activity] [varchar](255) NOT NULL,
	[timestamp] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 24/06/2024 20:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[reportId] [int] IDENTITY(1,1) NOT NULL,
	[reportName] [varchar](100) NOT NULL,
	[reportData] [text] NOT NULL,
	[generatedBy] [int] NULL,
	[generatedAt] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
	[reportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24/06/2024 20:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [int] NOT NULL,
	[username] [varchar](50) NOT NULL,
	[passwordHash] [varchar](255) NOT NULL,
	[email] [varchar](100) NULL,
	[role] [nvarchar](10) NOT NULL,
	[profilePicture] [varchar](255) NULL,
	[createdAt] [datetime2](7) NULL,
	[updatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK__Users__CB9A1CFF8DDF7FA4] PRIMARY KEY CLUSTERED
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (1, N'user1', N'password1hash', N'use1@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T20:35:14.7500000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (2, N'user2', N'password2hash', N'user2@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T20:34:37.5833333' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (3, N'user3', N'password3hash', N'user3@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T20:32:54.0700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (4, N'user4', N'password4hash', N'user4@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T20:32:56.4133333' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (5, N'user5', N'password5hash', N'user5@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T20:32:59.2500000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (6, N'user6', N'password6hash', N'user6@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T20:33:02.4000000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (12, N'user7', N'password7hash', N'user7@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (13, N'user8', N'password8hash', N'user8@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (14, N'user9', N'password9hash', N'user9@example.com', N'Student', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (15, N'user10', N'password10hash', N'user10@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (16, N'user11', N'password11hash', N'user11@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (17, N'user12', N'password12hash', N'user12@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (18, N'user13', N'password13hash', N'user13@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (19, N'user14', N'password14hash', N'user14@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (20, N'user15', N'password15hash', N'user15@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (21, N'user16', N'password16hash', N'user16@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (22, N'user17', N'password17hash', N'user17@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (23, N'user18', N'password18hash', N'user18@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (24, N'user19', N'password19hash', N'user19@example.com', N'Admin', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
INSERT [dbo].[Users] ([userId], [username], [passwordHash], [email], [role], [profilePicture], [createdAt], [updatedAt]) VALUES (25, N'user20', N'password20hash', N'user20@example.com', N'Librarian', NULL, CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2), CAST(N'2024-06-24T14:17:22.2700000' AS DateTime2))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__AB6E6164C826B575]    Script Date: 24/06/2024 20:47:56 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__AB6E6164C826B575] UNIQUE NONCLUSTERED
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__F3DBC5727FEB2F2D]    Script Date: 24/06/2024 20:47:56 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__F3DBC5727FEB2F2D] UNIQUE NONCLUSTERED
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activity_Logs] ADD  DEFAULT (getdate()) FOR [timestamp]
GO
ALTER TABLE [dbo].[Reports] ADD  DEFAULT (getdate()) FOR [generatedAt]
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
