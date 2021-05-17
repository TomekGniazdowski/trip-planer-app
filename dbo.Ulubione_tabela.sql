CREATE TABLE [dbo].[Ulubione_tabela] (
    [Id_ulubione]        INT          IDENTITY (1, 1) NOT NULL,
    [poczatek_wycieczki] VARCHAR (50) NOT NULL,
    [cel_wycieczki]      VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_ulubione] ASC)
);

