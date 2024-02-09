use vcartDB
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
GO
-- Admin password - Admin@12345678
-- User password - User@12345678
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [PhoneNumber], [EmailConfirmed], [CreatedDate]) VALUES (1, N'Admin', N'admin@gmail.com', N'$2a$11$NulP7XYlUOjMELsrj/me0uO/1OIQiHnMl.DVUk7LgB5SqjyWSas5K', N'8956890522', 0, CAST(N'2021-12-21T11:03:11.457' AS DateTime))
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [PhoneNumber], [EmailConfirmed], [CreatedDate]) VALUES (2, N'User', N'user@gmail.com', N'$2a$11$oNn03spA.XrRD8shVW9Z2.72X6ljCU/S6fjOZOTybNVFLtEr6Kb5y', N'8956890522', 0, CAST(N'2021-12-21T11:05:19.160' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 2)
GO

SET IDENTITY_INSERT [dbo].[Categories] ON
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Men Wear')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Kid Wear')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Women Wear')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemTypes] ON
GO
INSERT [dbo].[ItemTypes] ([Id], [Name]) VALUES (1, N'Shirt')
GO
INSERT [dbo].[ItemTypes] ([Id], [Name]) VALUES (2, N'T-Shirt')
GO
SET IDENTITY_INSERT [dbo].[ItemTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (1, N'Men Formal Shirt', N'Men Slim Fit Solid Spread Collar Formal Shirt', CAST(299.00 AS Decimal(18, 2)), N'/images/men_shirt_1.webp', 1, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (2, N'Men Slim Fit Shirt', N'Men Slim Fit Solid Spread Collar Formal Shirt', CAST(399.00 AS Decimal(18, 2)), N'/images/men_shirt_2.webp', 1, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (3, N'Men Regular Fit Shirt', N'Men Regular Fit Solid Button Down Collar Formal Shirt', CAST(499.00 AS Decimal(18, 2)), N'/images/men_shirt_3.webp', 1, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (4, N'Boys Regular Fit Shirt', N'Boys Regular Fit Solid Mandarin Collar Casual Shirt', CAST(399.00 AS Decimal(18, 2)), N'/images/kids_shirt_1.webp', 1, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (5, N'Boys Slim Fit Shirt', N'Boys Slim Fit Printed Casual Shirt', CAST(499.00 AS Decimal(18, 2)), N'/images/kids_shirt_2.webp', 1, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (6, N'Men Printed T-Shirt', N'Men Printed, Typography Round Neck Grey T-Shirt', CAST(599.00 AS Decimal(18, 2)), N'/images/men_tshirt_1.webp', 1, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (7, N'Men Striped T-Shirt', N'Men Striped Round Neck Dark Blue, Black T-Shirt', CAST(99.00 AS Decimal(18, 2)), N'/images/men_tshirt_2.webp', 2, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (8, N'Women Solid Skirt', N'Women Solid Flared Light Green Skirt', CAST(99.00 AS Decimal(18, 2)), N'/images/women_skirt_1.webp', 2, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (9, N'Women Colorblock Skirt', N'Women Colorblock Flared Maroon Skirt', CAST(99.00 AS Decimal(18, 2)), N'/images/women_skirt_2.webp', 2, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (10, N'Focus Tshirt Women', N'Focus Tshirt Women Typography Round Neck Black T-Shirt', CAST(99.00 AS Decimal(18, 2)), N'/images/women_tshirt_1.webp', 3, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (11, N'Casual Regular Sleeves Top', N'Casual Regular Sleeves Embroidered Women White Top', CAST(99.00 AS Decimal(18, 2)), N'/images/women_tshirt_2.webp', 3, 1, GETDATE())
GO
INSERT [dbo].[Items] ([Id], [Name], [Description], [UnitPrice], [ImageUrl], [CategoryId], [ItemTypeId], CreatedDate) VALUES (12, N'Women Printed T-Shirt', N'Women Printed Round Neck White T-Shirt', CAST(99.00 AS Decimal(18, 2)), N'/images/women_tshirt_3.webp', 3, 1, GETDATE())
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO