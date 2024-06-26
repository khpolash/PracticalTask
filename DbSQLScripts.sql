USE [PracticalTaskDb]
GO
/****** Object:  Table [dbo].[Corporate_Customer_Tbl]    Script Date: 5/21/2024 11:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corporate_Customer_Tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Individual_Customer_Tbl]    Script Date: 5/21/2024 11:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Individual_Customer_Tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting_Minutes_Details_Tbl]    Script Date: 5/21/2024 11:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting_Minutes_Details_Tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MeetingId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting_Minutes_Master_Tbl]    Script Date: 5/21/2024 11:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting_Minutes_Master_Tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CorporateCustomerId] [int] NULL,
	[IndividualCustomerId] [int] NULL,
	[MeetingDate] [datetime] NULL,
	[MeetingPlace] [nvarchar](200) NULL,
	[AttendsFormClientSide] [nvarchar](max) NULL,
	[AttendsFormHostSide] [nvarchar](max) NULL,
	[MeetingAgenda] [nvarchar](max) NULL,
	[MeetingDiscussion] [nvarchar](max) NULL,
	[MeetingDecision] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Unit_Tbl]    Script Date: 5/21/2024 11:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Unit_Tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products_Service_Tbl]    Script Date: 5/21/2024 11:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products_Service_Tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](128) NULL,
	[UnitId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Corporate_Customer_Tbl] ON 

INSERT [dbo].[Corporate_Customer_Tbl] ([Id], [CustomerName]) VALUES (1, N'ddd')
SET IDENTITY_INSERT [dbo].[Corporate_Customer_Tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Individual_Customer_Tbl] ON 

INSERT [dbo].[Individual_Customer_Tbl] ([Id], [CustomerName]) VALUES (1, N'abc')
INSERT [dbo].[Individual_Customer_Tbl] ([Id], [CustomerName]) VALUES (2, N'xyzd')
SET IDENTITY_INSERT [dbo].[Individual_Customer_Tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Meeting_Minutes_Details_Tbl] ON 

INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (1, 1, 1, 123)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (2, 2, 1, 393)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (3, 3, 3, 20)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (4, 3, 5, 33)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (5, 4, 3, 20)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (6, 5, 1, 381)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (7, 5, 3, 4234)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (8, 5, 4, 55)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (14, 7, 1, 677)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (15, 7, 3, 34)
INSERT [dbo].[Meeting_Minutes_Details_Tbl] ([Id], [MeetingId], [ProductId], [Quantity]) VALUES (16, 7, 4, 43)
SET IDENTITY_INSERT [dbo].[Meeting_Minutes_Details_Tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Meeting_Minutes_Master_Tbl] ON 

INSERT [dbo].[Meeting_Minutes_Master_Tbl] ([Id], [CorporateCustomerId], [IndividualCustomerId], [MeetingDate], [MeetingPlace], [AttendsFormClientSide], [AttendsFormHostSide], [MeetingAgenda], [MeetingDiscussion], [MeetingDecision]) VALUES (1, NULL, 1, CAST(N'2024-05-20T22:56:00.000' AS DateTime), N'qweqwwee', N'jbkbnb', N'kjkj', N'kbkb', N'kbbb', N'bb')
INSERT [dbo].[Meeting_Minutes_Master_Tbl] ([Id], [CorporateCustomerId], [IndividualCustomerId], [MeetingDate], [MeetingPlace], [AttendsFormClientSide], [AttendsFormHostSide], [MeetingAgenda], [MeetingDiscussion], [MeetingDecision]) VALUES (2, 1, NULL, CAST(N'2015-03-08T18:47:00.000' AS DateTime), N'Dolorem sint id sed ', N'Quod ex eum enim est', N'Cumque soluta culpa', N'Pariatur Quos id n', N'Dolores dignissimos ', N'Sint in laboris ess')
INSERT [dbo].[Meeting_Minutes_Master_Tbl] ([Id], [CorporateCustomerId], [IndividualCustomerId], [MeetingDate], [MeetingPlace], [AttendsFormClientSide], [AttendsFormHostSide], [MeetingAgenda], [MeetingDiscussion], [MeetingDecision]) VALUES (3, NULL, 1, CAST(N'2015-03-08T18:47:00.000' AS DateTime), N'Dolorem sint id sed ', N'Quod ex eum enim est', N'Cumque soluta culpa', N'Pariatur Quos id n', N'Dolores dignissimos ', N'Sint in laboris ess')
INSERT [dbo].[Meeting_Minutes_Master_Tbl] ([Id], [CorporateCustomerId], [IndividualCustomerId], [MeetingDate], [MeetingPlace], [AttendsFormClientSide], [AttendsFormHostSide], [MeetingAgenda], [MeetingDiscussion], [MeetingDecision]) VALUES (4, 1, NULL, CAST(N'2015-03-08T18:47:00.000' AS DateTime), N'Dolorem sint id sed ', N'Quod ex eum enim est', N'Cumque soluta culpa', N'Pariatur Quos id n', N'Dolores dignissimos ', N'Sint in laboris ess')
INSERT [dbo].[Meeting_Minutes_Master_Tbl] ([Id], [CorporateCustomerId], [IndividualCustomerId], [MeetingDate], [MeetingPlace], [AttendsFormClientSide], [AttendsFormHostSide], [MeetingAgenda], [MeetingDiscussion], [MeetingDecision]) VALUES (5, NULL, 2, CAST(N'1998-11-15T23:17:00.000' AS DateTime), N'Obcaecati laborum qu', N'Quam eveniet ab ill', N'Voluptas dolorem lab', N'Quasi eu minima offi', N'Elit et anim vero f', N'Illo modi esse dolo')
INSERT [dbo].[Meeting_Minutes_Master_Tbl] ([Id], [CorporateCustomerId], [IndividualCustomerId], [MeetingDate], [MeetingPlace], [AttendsFormClientSide], [AttendsFormHostSide], [MeetingAgenda], [MeetingDiscussion], [MeetingDecision]) VALUES (7, NULL, 2, CAST(N'2009-11-09T22:29:00.000' AS DateTime), N'Velit nobis nostrud', N'Officia animi nesci', N'Omnis quam neque atq', N'Consectetur ex culpa', N'Sequi rem tempor ape', N'Ut sed excepturi pos')
SET IDENTITY_INSERT [dbo].[Meeting_Minutes_Master_Tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Unit_Tbl] ON 

INSERT [dbo].[Product_Unit_Tbl] ([Id], [UnitName]) VALUES (1, N'kg')
INSERT [dbo].[Product_Unit_Tbl] ([Id], [UnitName]) VALUES (2, N'Pitch')
SET IDENTITY_INSERT [dbo].[Product_Unit_Tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Products_Service_Tbl] ON 

INSERT [dbo].[Products_Service_Tbl] ([Id], [ProductName], [UnitId]) VALUES (1, N'abc', 2)
INSERT [dbo].[Products_Service_Tbl] ([Id], [ProductName], [UnitId]) VALUES (3, N'xyz', 1)
INSERT [dbo].[Products_Service_Tbl] ([Id], [ProductName], [UnitId]) VALUES (4, N'lmn', 1)
INSERT [dbo].[Products_Service_Tbl] ([Id], [ProductName], [UnitId]) VALUES (5, N'def', 2)
INSERT [dbo].[Products_Service_Tbl] ([Id], [ProductName], [UnitId]) VALUES (6, N'ijk', 1)
SET IDENTITY_INSERT [dbo].[Products_Service_Tbl] OFF
GO
ALTER TABLE [dbo].[Meeting_Minutes_Details_Tbl]  WITH CHECK ADD FOREIGN KEY([MeetingId])
REFERENCES [dbo].[Meeting_Minutes_Master_Tbl] ([Id])
GO
ALTER TABLE [dbo].[Meeting_Minutes_Details_Tbl]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products_Service_Tbl] ([Id])
GO
ALTER TABLE [dbo].[Meeting_Minutes_Master_Tbl]  WITH CHECK ADD FOREIGN KEY([CorporateCustomerId])
REFERENCES [dbo].[Corporate_Customer_Tbl] ([Id])
GO
ALTER TABLE [dbo].[Meeting_Minutes_Master_Tbl]  WITH CHECK ADD FOREIGN KEY([IndividualCustomerId])
REFERENCES [dbo].[Individual_Customer_Tbl] ([Id])
GO
ALTER TABLE [dbo].[Products_Service_Tbl]  WITH CHECK ADD FOREIGN KEY([UnitId])
REFERENCES [dbo].[Product_Unit_Tbl] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[Meeting_Minutes_Details_Save_SP]    Script Date: 5/21/2024 11:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Meeting_Minutes_Details_Save_SP]
    @MeetingId INT,
    @ProductId INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;

   INSERT INTO Meeting_Minutes_Details_Tbl (
        MeetingId,
        ProductId,
        Quantity
    )
    VALUES (
        @MeetingId,
        @ProductId,
        @Quantity
    );

    RETURN 0;
END
GO
/****** Object:  StoredProcedure [dbo].[Meeting_Minutes_Master_Save_SP]    Script Date: 5/21/2024 11:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Meeting_Minutes_Master_Save_SP]
	@CorporateCustomerId INT = NULL,
    @IndividualCustomerId INT = NULL,
    @MeetingDate DATETIME = NULL,
    @MeetingPlace NVARCHAR(200) = NULL,
    @AttendsFormClientSide NVARCHAR(MAX) = NULL,
    @AttendsFormHostSide NVARCHAR(MAX) = NULL,
    @MeetingAgenda NVARCHAR(MAX) = NULL,
    @MeetingDiscussion NVARCHAR(MAX) = NULL,
    @MeetingDecision NVARCHAR(MAX) = NULL,
    @MeetingId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Meeting_Minutes_Master_Tbl (
        CorporateCustomerId,
        IndividualCustomerId,
        MeetingDate,
        MeetingPlace,
        AttendsFormClientSide,
        AttendsFormHostSide,
        MeetingAgenda,
        MeetingDiscussion,
        MeetingDecision
    )
    VALUES (
        @CorporateCustomerId,
        @IndividualCustomerId,
        @MeetingDate,
        @MeetingPlace,
        @AttendsFormClientSide,
        @AttendsFormHostSide,
        @MeetingAgenda,
        @MeetingDiscussion,
        @MeetingDecision
    );
	
    SET @MeetingId = SCOPE_IDENTITY();

    RETURN 0;
END

GO
