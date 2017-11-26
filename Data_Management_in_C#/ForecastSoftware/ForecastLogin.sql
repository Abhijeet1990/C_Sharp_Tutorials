CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] VARCHAR(50) NULL, 
    [Password] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
