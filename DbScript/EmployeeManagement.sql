USE [EmployeeManagement]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/4/2024 12:23:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeProjects]    Script Date: 12/4/2024 12:23:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProjects](
	[EmployeeProjectId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[ProjectId] [int] NULL,
	[AssignedDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/4/2024 12:23:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[HireDate] [date] NOT NULL,
	[JobTitle] [nvarchar](100) NULL,
	[Salary] [decimal](10, 2) NOT NULL,
	[DepartmentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 12/4/2024 12:23:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](100) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/4/2024 12:23:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/4/2024 12:23:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[RoleId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (1, N'Human Resources')
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (2, N'Finance')
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (3, N'IT')
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (4, N'Marketing')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeProjects] ON 

INSERT [dbo].[EmployeeProjects] ([EmployeeProjectId], [EmployeeId], [ProjectId], [AssignedDate]) VALUES (1, 1, 1, CAST(N'2023-02-15' AS Date))
INSERT [dbo].[EmployeeProjects] ([EmployeeProjectId], [EmployeeId], [ProjectId], [AssignedDate]) VALUES (2, 2, 2, CAST(N'2024-03-05' AS Date))
INSERT [dbo].[EmployeeProjects] ([EmployeeProjectId], [EmployeeId], [ProjectId], [AssignedDate]) VALUES (3, 3, 3, CAST(N'2022-07-01' AS Date))
INSERT [dbo].[EmployeeProjects] ([EmployeeProjectId], [EmployeeId], [ProjectId], [AssignedDate]) VALUES (4, 4, 1, CAST(N'2023-03-20' AS Date))
SET IDENTITY_INSERT [dbo].[EmployeeProjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email], [PhoneNumber], [HireDate], [JobTitle], [Salary], [DepartmentId]) VALUES (1, N'John', N'Doe', N'john.doe@example.com', N'1234567890', CAST(N'2020-05-15' AS Date), N'Software Engineer', CAST(60000.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email], [PhoneNumber], [HireDate], [JobTitle], [Salary], [DepartmentId]) VALUES (2, N'Jane', N'Smith', N'jane.smith@example.com', N'0987654321', CAST(N'2019-11-20' AS Date), N'Marketing Manager', CAST(70000.00 AS Decimal(10, 2)), 4)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email], [PhoneNumber], [HireDate], [JobTitle], [Salary], [DepartmentId]) VALUES (3, N'Emily', N'Davis', N'emily.davis@example.com', N'5678901234', CAST(N'2021-01-10' AS Date), N'HR Specialist', CAST(50000.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email], [PhoneNumber], [HireDate], [JobTitle], [Salary], [DepartmentId]) VALUES (4, N'Michael', N'Brown', N'michael.brown@example.com', N'2345678901', CAST(N'2018-09-01' AS Date), N'Finance Analyst', CAST(65000.00 AS Decimal(10, 2)), 2)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [EndDate]) VALUES (1, N'Project A', CAST(N'2023-01-01' AS Date), CAST(N'2023-12-31' AS Date))
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [EndDate]) VALUES (2, N'Project B', CAST(N'2024-03-01' AS Date), NULL)
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [EndDate]) VALUES (3, N'Project C', CAST(N'2022-06-01' AS Date), CAST(N'2022-12-31' AS Date))
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Employee')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Manager')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Username], [Password], [Email], [RoleId], [EmployeeId]) VALUES (1, N'admin', N'admin123', N'admin@example.com', 1, NULL)
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Email], [RoleId], [EmployeeId]) VALUES (2, N'manager', N'manager123', N'manager@example.com', 2, 2)
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Email], [RoleId], [EmployeeId]) VALUES (3, N'employee_user', N'employee123', N'employee@example.com', 3, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__A9D105345723B784]    Script Date: 12/4/2024 12:23:31 PM ******/
ALTER TABLE [dbo].[Employees] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Roles__8A2B61607986DB54]    Script Date: 12/4/2024 12:23:31 PM ******/
ALTER TABLE [dbo].[Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E44027604F]    Script Date: 12/4/2024 12:23:31 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Users__7AD04F1013A3C949]    Script Date: 12/4/2024 12:23:31 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534C3B91938]    Script Date: 12/4/2024 12:23:31 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeProjects]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeeProjects]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
