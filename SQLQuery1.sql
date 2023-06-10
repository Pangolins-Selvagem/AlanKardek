CREATE TABLE [dbo].[tb_usuario] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [nm_usuario]      NVARCHAR (100) NOT NULL,
    [tx_email]        NVARCHAR (100) NOT NULL,
    [tx_senha]        NVARCHAR (10)  NOT NULL,
    [tp_usuario]      NVARCHAR (1)   NOT NULL,
    [in_privilegiado] NVARCHAR (1)   NOT NULL,
    [tx_turma]        NVARCHAR (10)  NOT NULL,
    [tp_sit]          NVARCHAR (7)   CONSTRAINT [DEFAULT_tb_usuario_tp_sit] DEFAULT 'Inativo' NOT NULL,
    CONSTRAINT [PK_dbo.tb_usuario] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ck_usuario1] CHECK ([tp_usuario]='P' OR [tp_usuario]='U' OR [tp_usuario]='A'),
    CONSTRAINT [ck_usuario2] CHECK ([in_privilegiado]='N' OR [in_privilegiado]='S'),
    CONSTRAINT [ck_usuario3] CHECK ([tp_sit]='Inativo' OR [tp_sit]='Ativo'),
    CONSTRAINT [un_usuario1] UNIQUE NONCLUSTERED ([nm_usuario] ASC),
    CONSTRAINT [un_usuario2] UNIQUE NONCLUSTERED ([tx_email] ASC)
);
