USE [BespokeDb]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[UserTypes]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserPermissions]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[UserPermissions]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[Permissions]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[Payments]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Table [dbo].[BranchesMenu]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[BranchesMenu]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 12/12/2018 9:48:30 PM ******/
DROP TABLE [dbo].[Branches]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NULL,
	[Since] [date] NULL,
	[Logo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchesMenu]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchesMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Intro] [nvarchar](300) NULL,
	[Price] [decimal](18, 0) NULL,
	[Code] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_BranchesMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NULL,
	[Name] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_BranchesMenuCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceUserId] [int] NULL,
	[DestinationUserId] [int] NULL,
	[MenuBranchId] [int] NULL,
	[IsApproved] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[IsPayment] [bit] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Permission] [nvarchar](500) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermissions]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PermissionId] [int] NULL,
 CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NULL,
	[UserTypeId] [int] NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](9) NULL,
	[Name] [nvarchar](100) NULL,
	[Surname] [nvarchar](100) NULL,
	[Phone] [nvarchar](11) NULL,
	[IsActive] [bit] NULL,
	[Deneme] [nchar](10) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 12/12/2018 9:48:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([Id], [Name], [Since], [Logo]) VALUES (1, N'Gran Karaköyy', CAST(N'2015-10-10' AS Date), N'2.PNG')
INSERT [dbo].[Branches] ([Id], [Name], [Since], [Logo]) VALUES (2, N'Kanyon Starbuck', CAST(N'2016-10-10' AS Date), N'starbucks.png')
INSERT [dbo].[Branches] ([Id], [Name], [Since], [Logo]) VALUES (3, N'Bosnak Karaköy', CAST(N'2014-10-10' AS Date), N'bosnak.jpg')
INSERT [dbo].[Branches] ([Id], [Name], [Since], [Logo]) VALUES (1005, N'Limonade', CAST(N'2018-12-11' AS Date), N'lemon.png')
INSERT [dbo].[Branches] ([Id], [Name], [Since], [Logo]) VALUES (2002, N'Just Roof', CAST(N'2018-12-11' AS Date), N'just.png')
SET IDENTITY_INSERT [dbo].[Branches] OFF
SET IDENTITY_INSERT [dbo].[BranchesMenu] ON 

INSERT [dbo].[BranchesMenu] ([Id], [CategoryId], [Name], [Intro], [Price], [Code], [IsActive]) VALUES (1, 3, N'Çay', N'Ince Belli', CAST(3 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[BranchesMenu] ([Id], [CategoryId], [Name], [Intro], [Price], [Code], [IsActive]) VALUES (2, 3, N'Kola', N'Şekerli', CAST(5 AS Decimal(18, 0)), NULL, 1)
SET IDENTITY_INSERT [dbo].[BranchesMenu] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [BranchId], [Name], [IsActive]) VALUES (3, 1, N'Sıcak İçecekler', 1)
INSERT [dbo].[Categories] ([Id], [BranchId], [Name], [IsActive]) VALUES (4, 1, N'Soğuk İçecekler', 1)
INSERT [dbo].[Categories] ([Id], [BranchId], [Name], [IsActive]) VALUES (2003, 1, N'Alkollüler', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [SourceUserId], [DestinationUserId], [MenuBranchId], [IsApproved]) VALUES (1, 3, 4, 2, 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [Permission]) VALUES (1, N'Şube Ekleme')
INSERT [dbo].[Permissions] ([Id], [Permission]) VALUES (2, N'Ürün Ekleme')
INSERT [dbo].[Permissions] ([Id], [Permission]) VALUES (3, N'Kullanıcı Ekleme')
INSERT [dbo].[Permissions] ([Id], [Permission]) VALUES (4, N'Admin')
SET IDENTITY_INSERT [dbo].[Permissions] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [BranchId], [UserTypeId], [Username], [Password], [Name], [Surname], [Phone], [IsActive], [Deneme]) VALUES (1, NULL, 1, N'mehmetcan', N'123456', N'Mehmet', N'Köse', N'5533396563', 1, NULL)
INSERT [dbo].[Users] ([Id], [BranchId], [UserTypeId], [Username], [Password], [Name], [Surname], [Phone], [IsActive], [Deneme]) VALUES (2, NULL, 2, N'büşra', N'123', N'Büşra', N'Köse', N'5536522145', 1, NULL)
INSERT [dbo].[Users] ([Id], [BranchId], [UserTypeId], [Username], [Password], [Name], [Surname], [Phone], [IsActive], [Deneme]) VALUES (4, 1, 3, N'semih', N'123', N'Semih', N'Sipahi', N'5536277010', 1, NULL)
INSERT [dbo].[Users] ([Id], [BranchId], [UserTypeId], [Username], [Password], [Name], [Surname], [Phone], [IsActive], [Deneme]) VALUES (2002, 2002, 4, N'talha_gul', N'123456', N'Talha', N'Gul', N'5553263235', 1, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserTypes] ON 

INSERT [dbo].[UserTypes] ([Id], [Type]) VALUES (1, N'Garson')
INSERT [dbo].[UserTypes] ([Id], [Type]) VALUES (2, N'Şef')
INSERT [dbo].[UserTypes] ([Id], [Type]) VALUES (3, N'Normal Üye')
INSERT [dbo].[UserTypes] ([Id], [Type]) VALUES (4, N'Admin')
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
