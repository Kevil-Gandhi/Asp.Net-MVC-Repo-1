# P_01

This is my first Asp.Net Core MVC using C# project with CRUD and Search Functionality.....

Table Structure 

Table name : book 
Structure :
  CREATE TABLE [dbo].[book] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [title] VARCHAR (50)   NULL,
    [price] DECIMAL (7, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-> Auto Increment Id features.
