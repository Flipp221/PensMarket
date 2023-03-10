USE [Pen]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 19.01.2023 18:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[id_Company] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[City] [varchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[id_Company] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 19.01.2023 18:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id_Customer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[Patronymic] [varchar](50) NULL,
	[Phone] [varchar](11) NULL,
	[Password] [varchar](50) NULL,
	[id_TypeCustomer] [int] NULL,
	[id_Role] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id_Customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 19.01.2023 18:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id_Order] [int] IDENTITY(1,1) NOT NULL,
	[id_Customer] [int] NULL,
	[id_Pen] [int] NULL,
	[DateOrder] [datetime] NULL,
	[Buy_Done] [bit] NULL,
	[PriceOrder] [varchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pens]    Script Date: 19.01.2023 18:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pens](
	[id_Pen] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[PricePen] [varchar](50) NULL,
	[id_TypePen] [int] NOT NULL,
	[id_Company] [int] NOT NULL,
 CONSTRAINT [PK_Pen] PRIMARY KEY CLUSTERED 
(
	[id_Pen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 19.01.2023 18:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id_Role] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeCustomer]    Script Date: 19.01.2023 18:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeCustomer](
	[id_TypeCustomer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_TypeCustomer] PRIMARY KEY CLUSTERED 
(
	[id_TypeCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypePen]    Script Date: 19.01.2023 18:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePen](
	[Id_TypePen] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_TypePen] PRIMARY KEY CLUSTERED 
(
	[Id_TypePen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([id_Company], [Name], [City]) VALUES (1, N'Abobas', N'Aboba city')
INSERT [dbo].[Company] ([id_Company], [Name], [City]) VALUES (2, N'Dobavlenie', N'Krasnodar')
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id_Customer], [Name], [Surname], [Patronymic], [Phone], [Password], [id_TypeCustomer], [id_Role]) VALUES (1, N'Oleg', N'Olegov', N'Olegovich', N'88005553535', N'Oleg', 1, 1)
INSERT [dbo].[Customer] ([id_Customer], [Name], [Surname], [Patronymic], [Phone], [Password], [id_TypeCustomer], [id_Role]) VALUES (4, N'Filipp', N'Filipp', N'Filipp', N'8888', N'Filipp', 2, 2)
INSERT [dbo].[Customer] ([id_Customer], [Name], [Surname], [Patronymic], [Phone], [Password], [id_TypeCustomer], [id_Role]) VALUES (10, N'Дмитрий', N'Граница', N'Абобович', N'88005553535', N'123', 1, 2)
INSERT [dbo].[Customer] ([id_Customer], [Name], [Surname], [Patronymic], [Phone], [Password], [id_TypeCustomer], [id_Role]) VALUES (11, N'qwe', N'qwert', N'qwer', N'42342342334', N'qwe', 1, 2)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id_Order], [id_Customer], [id_Pen], [DateOrder], [Buy_Done], [PriceOrder]) VALUES (1, 1, 1, CAST(N'2023-01-16T00:00:00.000' AS DateTime), 1, N'200')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Pens] ON 

INSERT [dbo].[Pens] ([id_Pen], [Name], [Color], [PricePen], [id_TypePen], [id_Company]) VALUES (1, N'Ручка один', N'Янтарный', N'200', 3, 1)
INSERT [dbo].[Pens] ([id_Pen], [Name], [Color], [PricePen], [id_TypePen], [id_Company]) VALUES (3, N'Ручка два', N'Арбузный', N'1500', 2, 1)
INSERT [dbo].[Pens] ([id_Pen], [Name], [Color], [PricePen], [id_TypePen], [id_Company]) VALUES (9, N'Ручка три', N'Фиолетовая ', N'250', 1, 2)
SET IDENTITY_INSERT [dbo].[Pens] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id_Role], [Name]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([id_Role], [Name]) VALUES (2, N'Пользователь')
INSERT [dbo].[Roles] ([id_Role], [Name]) VALUES (3, N'Модератор')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeCustomer] ON 

INSERT [dbo].[TypeCustomer] ([id_TypeCustomer], [Name]) VALUES (1, N'Физическое лицо')
INSERT [dbo].[TypeCustomer] ([id_TypeCustomer], [Name]) VALUES (2, N'Юидическое лицо')
SET IDENTITY_INSERT [dbo].[TypeCustomer] OFF
GO
SET IDENTITY_INSERT [dbo].[TypePen] ON 

INSERT [dbo].[TypePen] ([Id_TypePen], [Name]) VALUES (1, N'Шариковая')
INSERT [dbo].[TypePen] ([Id_TypePen], [Name]) VALUES (2, N'Гелевая')
INSERT [dbo].[TypePen] ([Id_TypePen], [Name]) VALUES (3, N'Перьевая')
INSERT [dbo].[TypePen] ([Id_TypePen], [Name]) VALUES (4, N'Капилярная')
SET IDENTITY_INSERT [dbo].[TypePen] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Roles] FOREIGN KEY([id_Role])
REFERENCES [dbo].[Roles] ([id_Role])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Roles]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_TypeCustomer] FOREIGN KEY([id_TypeCustomer])
REFERENCES [dbo].[TypeCustomer] ([id_TypeCustomer])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_TypeCustomer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([id_Customer])
REFERENCES [dbo].[Customer] ([id_Customer])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Pen] FOREIGN KEY([id_Pen])
REFERENCES [dbo].[Pens] ([id_Pen])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Pen]
GO
ALTER TABLE [dbo].[Pens]  WITH CHECK ADD  CONSTRAINT [FK_Pen_Company] FOREIGN KEY([id_Company])
REFERENCES [dbo].[Company] ([id_Company])
GO
ALTER TABLE [dbo].[Pens] CHECK CONSTRAINT [FK_Pen_Company]
GO
ALTER TABLE [dbo].[Pens]  WITH CHECK ADD  CONSTRAINT [FK_Pen_TypePen] FOREIGN KEY([id_TypePen])
REFERENCES [dbo].[TypePen] ([Id_TypePen])
GO
ALTER TABLE [dbo].[Pens] CHECK CONSTRAINT [FK_Pen_TypePen]
GO
