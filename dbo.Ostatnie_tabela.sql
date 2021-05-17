CREATE TABLE [dbo].[Ostatnie_tabela] (
    [Id_ostatnie]        INT          IDENTITY (1, 1) NOT NULL,
    [poczatek_wycieczki] VARCHAR (50) NOT NULL,
    [cel_wycieczki]      VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_ostatnie] ASC)
);

