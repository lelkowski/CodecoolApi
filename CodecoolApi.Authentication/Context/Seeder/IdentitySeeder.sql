USE [CodecoolApiIdentity]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1e176c7f-b383-4163-bccf-8eba48e04a71', N'user', N'USER', N'bec71945-777f-4c15-8b1c-5076b8876630')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3e299a6b-7d25-44d3-93fb-c89f73b43fd8', N'admin', N'ADMIN', N'96bc852b-8689-4639-8a62-6feacd9a4a20')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bd42e374-3aaa-4a60-9327-2bcb6e9ccc40', N'admin', N'ADMIN', N'admin@admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEOcbKADqPs749r/7Lb+7IATfbtyF8REoqeEUSkj9ydiiVK90ECSaCO80101fWbjLLQ==', N'RMUUL5D3ZCXYE3PBSVVC2KJCHIPJ5C35', N'b6a14760-b931-4a9f-bc8e-373165baea25', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bd42e374-3aaa-4a60-9327-2bcb6e9ccc40', N'3e299a6b-7d25-44d3-93fb-c89f73b43fd8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220809100038_Init', N'6.0.7')
GO
