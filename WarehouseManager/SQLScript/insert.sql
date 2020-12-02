USE [Warehouse]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'K9', N'ad', N'0123456789', N'a@gmail.com', NULL, NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (2, N'DG', N'ad 2', N'0123456789', N'b@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Suplier] ON 

INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'Kteam 1', N'địa chỉ', N'0123456789', N'email@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Suplier] OFF
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (1, N'Kg')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (2, N'Thùng')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (3, N'Bao')
SET IDENTITY_INSERT [dbo].[Unit] OFF
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [QRCode], [BarCode]) VALUES (N'1', N'Xi măng', 3, 1, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [QRCode], [BarCode]) VALUES (N'2', N'Gạch', 1, 1, NULL, NULL)
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'1', CAST(0x0000A8580019484B AS DateTime))
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'2', CAST(0x0000A8580019484B AS DateTime))
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutputInfo], [IdCustomer], [Count], [Status]) VALUES (N'1', N'1', N'1', 1, 10, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutputInfo], [IdCustomer], [Count], [Status]) VALUES (N'2', N'2', N'1', 1, 200, NULL)
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'1', CAST(0x0000A8580019484B AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'2', CAST(0x0000A8580019484B AS DateTime))
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [OutputPrice], [Status]) VALUES (N'1', N'1', N'1', 50, 200000, 300000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [OutputPrice], [Status]) VALUES (N'2', N'2', N'1', 1000, 200, 500, NULL)
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (1, N'RongK9', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (2, N'Nhân viên', N'staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
