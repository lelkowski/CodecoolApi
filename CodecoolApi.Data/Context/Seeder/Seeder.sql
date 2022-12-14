USE [CodecoolApi]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [Name], [Description], [Counter]) VALUES (1, N'Microsoft Corporation', N'American multinational technology corporation which produces computer software, consumer electronics, personal computers, and related services headquartered at the Microsoft Redmond campus located in Redmond, Washington, United States. Its best-known software products are the Windows line of operating systems, the Microsoft Office suite, and the Internet Explorer and Edge web browsers', 3)
INSERT [dbo].[Authors] ([Id], [Name], [Description], [Counter]) VALUES (2, N'Joel Murach', N'Oldest son of publishing pioneer Mike Murach. Joel has been writing and editing books about computer programming for over 20 years now. During that time, he has written extensively on a wide range of Java, .NET, web, and database technologies.', 2)
INSERT [dbo].[Authors] ([Id], [Name], [Description], [Counter]) VALUES (3, N'Codepip', N'Codepip is the platform for your favorite web development games. Gain an edge in your next interview or project.', 2)
INSERT [dbo].[Authors] ([Id], [Name], [Description], [Counter]) VALUES (4, N'Tim Corey', N'One of the best developer YouTubers out there. No fluff, no flair, just straight coding and explaining what he''s doing.  You can find his channel there: ''https://www.youtube.com/user/IAmTimCorey''', 2)
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([Id], [Name], [Definition]) VALUES (1, N'Microsoft Documentation', N'Microsoft Docs is the library of technical documentation for end users, developers, and IT professionals who work with Microsoft products.')
INSERT [dbo].[Types] ([Id], [Name], [Definition]) VALUES (2, N'Textbook', N'Textbook is a book containing a comprehensive compilation of content in a branch of study with the intention of explaining it.')
INSERT [dbo].[Types] ([Id], [Name], [Definition]) VALUES (3, N'Educational Games', N'Educational games are games that are designed to help people learn about certain subjects, expand concepts, reinforce development, understand a historical event or culture, or assist them in learning a skill as they play.')
INSERT [dbo].[Types] ([Id], [Name], [Definition]) VALUES (4, N'Video tutorial', N'Video tutorial
is a video material that
focuses mostly on guiding
step-by-step in dedicated
topic')
SET IDENTITY_INSERT [dbo].[Types] OFF
GO
SET IDENTITY_INSERT [dbo].[Materials] ON 

INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (1, N'Tutorial: Get started with ASP.NET Core', 1, N'This tutorial shows how to create and run an ASP.NET Core web app using the .NET Core CLI.', N'https://docs.microsoft.com/en-gb/aspnet/core/getting-started/?view=aspnetcore-6.0&tabs=windows', 1, CAST(N'2022-07-19T21:36:56.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (2, N'Tutorial: Get started with EF Core in an ASP.NET MVC web app', 1, N'This tutorial teaches ASP.NET Core MVC and Entity Framework Core with controllers and views. Razor Pages is an alternative programming model.', N'https://docs.microsoft.com/en-gb/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0', 1, CAST(N'2022-07-19T21:30:03.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (3, N'Get started with ASP.NET Core MVC', 1, N'This tutorial teaches ASP.NET Core MVC web development with controllers and views.', N'https://docs.microsoft.com/en-gb/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-6.0&tabs=visual-studio', 1, CAST(N'2022-07-18T22:11:39.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (4, N'Murach''s ASP.NET Core MVC', 2, N'If you know the basics of C#, you''re ready to learn how to create web applications using Microsoft''s powerful technology, ASP.NET Core MVC (Model-View-Controller). And there''s no more practical way to do it than with this book.', N'Codecoolʼs library
at Ślusarska 9', 2, CAST(N'2022-07-19T21:36:56.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (6, N'Murach''s C# (7th Edition)', 2, N'This C# book has been a favorite of developers ever since the 1st edition came out in 2004. So you can be sure that this latest edition will deliver the professional skills you''re looking for today. In fact, it will teach you the C# essentials more easily than ever, as it shows you how to take advantage of the most recent releases of C#, .NET, and Visual Studio.', N'Codecoolʼs library
at Ślusarska 9', 2, CAST(N'2022-07-19T21:30:03.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (7, N'FLEXBOX FROGGY', 3, N'Flexbox Froggy, a game where you help Froggy and friends by writing CSS code! Guide this frog to the lilypad on the right by using correct CSS code', N'https://flexboxfroggy.com/', 3, CAST(N'2022-07-18T21:25:54.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (8, N'CSS Surgeon', 3, N'An irresponsible doctor has removed CSS Sam''s vital organs. In this game, you must operate on your patient and restore 14 missing organs including their ruby lips, rusty nail, and fused backbone. Your instrument of choice is CSS transform, a property that makes it easy to move, rotate, scale, and skew elements.', N'https://codepip.com/games/css-surgeon/', 3, CAST(N'2022-07-19T21:36:56.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (9, N'Introduction to ASP.NET MVC in C#: Basics, Advanced Topics, Tips, Tricks, Best Practices, and More', 4, N'In this video, I walk you through ASP.NET MVC. I show you what it is, how to configure it, how to set it up, what all of the different files represent, and more. Learn about the best practices surrounding MVC along the way.', N'https://www.youtube.com/watch?v=phyV-OQNeRM', 4, CAST(N'2022-07-19T21:30:03.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [Title], [AuthorId], [Description], [Location], [EducationalMaterialTypeId], [DateOfCreation]) VALUES (10, N'Intro to Docker - A Tool Every Developer Should Know', 4, N'Docker is a powerful tool that allows developers to set up environments quickly, configure complex systems and servers easily, and deploy software reliably, yet it is also a source of great confusion. In this video, we will get a look at what Docker is, how it works, and how to use it in our development tasks.', N'https://www.youtube.com/watch?v=WcQ3-M4-jik', 4, CAST(N'2022-07-18T22:11:39.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Materials] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (1, 1, N'Nice tutorial, props', 7)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (2, 1, N'I finally know what .Net core is!', 10)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (3, 1, N'Meh', 3)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (4, 2, N'I love ef core', 10)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (5, 2, N'I hate ef core', 3)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (6, 3, N'I don''t understand', 2)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (8, 4, N'Too hard language', 1)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (9, 4, N'Ez', 6)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (10, 6, N'Pretty nice', 7)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (11, 7, N'Frog died', 1)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (12, 7, N'Easy ', 10)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (13, 8, N'Couldnt register, unsub', 1)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (14, 9, N'Great tutorial, 10/10', 9)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (15, 9, N'I will share info of this great tutorial', 6)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (16, 10, N'Still don''t know what docker is about', 2)
INSERT [dbo].[Reviews] ([Id], [EducationalMaterialId], [TextReview], [DigitReview]) VALUES (17, 10, N'Best tutorial there is', 8)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808113855_Init', N'6.0.7')
GO
