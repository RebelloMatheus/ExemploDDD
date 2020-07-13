IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Profissionais] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Profissionais] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Restaurantes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Restaurantes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Votacoes] (
    [Id] uniqueidentifier NOT NULL,
    [Data] datetime2 NOT NULL,
    [ProfissionalId] uniqueidentifier NOT NULL,
    [RestauranteId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Votacoes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Votacoes_Profissionais_ProfissionalId] FOREIGN KEY ([ProfissionalId]) REFERENCES [Profissionais] ([Id]),
    CONSTRAINT [FK_Votacoes_Restaurantes_RestauranteId] FOREIGN KEY ([RestauranteId]) REFERENCES [Restaurantes] ([Id])
);

GO

CREATE INDEX [IX_Votacoes_ProfissionalId] ON [Votacoes] ([ProfissionalId]);

GO

CREATE INDEX [IX_Votacoes_RestauranteId] ON [Votacoes] ([RestauranteId]);

GO

CREATE UNIQUE INDEX [IX_Votacoes_Data_ProfissionalId_RestauranteId] ON [Votacoes] ([Data], [ProfissionalId], [RestauranteId]);

GO


                    INSERT INTO Profissionais (Id, Nome)
                            VALUES  (NEWID(), 'Profissional 1'),
                                    (NEWID(), 'Profissional 2'),
                                    (NEWID(), 'Profissional 3'),
                                    (NEWID(), 'Profissional 4'),
                                    (NEWID(), 'Profissional 5'),
                                    (NEWID(), 'Profissional 6');
                    INSERT INTO Restaurantes (Id, Nome)
                            VALUES  (NEWID(), 'Restaurante 1'),
                                    (NEWID(), 'Restaurante 2'),
                                    (NEWID(), 'Restaurante 3'),
                                    (NEWID(), 'Restaurante 4'),
                                    (NEWID(), 'Restaurante 5'),
                                    (NEWID(), 'Restaurante 6');

                

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200712220249_InitialCreate', N'3.1.5');

GO

