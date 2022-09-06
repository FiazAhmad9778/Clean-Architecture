USE [ihakeem_dev]
GO
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([Id], [Name], [Type]) VALUES (1, N'LKTitle', N'Number')
INSERT [dbo].[Lookup] ([Id], [Name], [Type]) VALUES (2, N'LKRelation', N'Number')
INSERT [dbo].[Lookup] ([Id], [Name], [Type]) VALUES (3, N'LKGender', N'Number')
INSERT [dbo].[Lookup] ([Id], [Name], [Type]) VALUES (4, N'LKLanguage', N'Number')
INSERT [dbo].[Lookup] ([Id], [Name], [Type]) VALUES (5, N'LKMaritialStatus', N'Number')
INSERT [dbo].[Lookup] ([Id], [Name], [Type]) VALUES (6, N'LKEthnicity', N'Number')
INSERT [dbo].[Lookup] ([Id], [Name], [Type]) VALUES (7, N'LKBloodGroup', N'Number')
INSERT [dbo].[Lookup] ([Id], [Name], [Type]) VALUES (8, N'LKEducationType', N'Number')
SET IDENTITY_INSERT [dbo].[Lookup] OFF

SET IDENTITY_INSERT [dbo].[LookupData] ON 

INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (1, 1, N'1', N'Mr')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (2, 1, N'2', N'Ms')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (5, 2, N'3', N'Father')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (6, 2, N'4', N'Mother')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (7, 2, N'5', N'Brother')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (8, 2, N'6', N'Sister')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (9, 3, N'7', N'Male')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (10, 3, N'8', N'Female')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (11, 3, N'9', N'Other')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (12, 4, N'10', N'Arabic')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (13, 4, N'11', N'English')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (14, 5, N'12', N'Married')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (15, 5, N'13', N'Single')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (16, 6, N'14', N'German')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (17, 6, N'15', N'Spanish')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (18, 7, N'16', N'A')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (19, 7, N'17', N'AB+')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (20, 7, N'18', N'AB-')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (21, 7, N'19', N'A-')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (22, 7, N'20', N'O-')
INSERT [dbo].[LookupData] ([Id], [LookupId], [Code], [Value]) VALUES (23, 7, N'21', N'Master of Medicine')
SET IDENTITY_INSERT [dbo].[LookupData] OFF
