using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinControl.API.Data.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alerta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReferenciaId = table.Column<int>(type: "int", nullable: true),
                    ReferenciaTipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVisualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartaoCredito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bandeira = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UltimosDigitos = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Limite = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiaFechamento = table.Column<int>(type: "int", nullable: false),
                    DiaVencimento = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Icone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartaoCredito_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Icone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoAlerta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    AlertaOrcamento = table.Column<bool>(type: "bit", nullable: false),
                    PercentualAlertaOrcamento = table.Column<int>(type: "int", nullable: false, defaultValue: 80),
                    AlertaSaldoBaixo = table.Column<bool>(type: "bit", nullable: false),
                    ValorMinimoSaldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AlertaFaturaVencimento = table.Column<bool>(type: "bit", nullable: false),
                    DiasAntesFatura = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    AlertaMetaAtingida = table.Column<bool>(type: "bit", nullable: false),
                    AlertaPagamentoRecorrente = table.Column<bool>(type: "bit", nullable: false),
                    DiasAntesPagamento = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoAlerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoAlerta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NomeModelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Padrao"),
                    PromptSistema = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MaxTokensResposta = table.Column<int>(type: "int", nullable: false, defaultValue: 512),
                    MaxMensagensContexto = table.Column<int>(type: "int", nullable: false, defaultValue: 6),
                    Temperatura = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false, defaultValue: 0.7m),
                    ResumirConversasAntigas = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IncluirDadosFinanceiros = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoChat_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Banco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Agencia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NumeroConta = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SaldoInicial = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SaldoAtual = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Icone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConversaChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TotalMensagens = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversaChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversaChat_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planejamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    MesInicio = table.Column<int>(type: "int", nullable: false),
                    AnoInicio = table.Column<int>(type: "int", nullable: false),
                    MesFim = table.Column<int>(type: "int", nullable: false),
                    AnoFim = table.Column<int>(type: "int", nullable: false),
                    ReceitaPrevista = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DespesaPrevista = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ReceitaRealizada = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DespesaRealizada = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planejamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planejamento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromptPersonalizado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Favorito = table.Column<bool>(type: "bit", nullable: false),
                    VezesUtilizado = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptPersonalizado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromptPersonalizado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRevogacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubstituidoPor = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CriadoPorIp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RevogadoPorIp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartaoCreditoId = table.Column<int>(type: "int", nullable: false),
                    MesReferencia = table.Column<int>(type: "int", nullable: false),
                    AnoReferencia = table.Column<int>(type: "int", nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fatura_CartaoCredito_CartaoCreditoId",
                        column: x => x.CartaoCreditoId,
                        principalTable: "CartaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ValorObjetivo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValorAtual = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataLimite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Icone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meta_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MensagemChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversaChatId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokensUtilizados = table.Column<int>(type: "int", nullable: true),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensagemChat_ConversaChat_ConversaChatId",
                        column: x => x.ConversaChatId,
                        principalTable: "ConversaChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanejamentoCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanejamentoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ValorPrevisto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValorRealizado = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanejamentoCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanejamentoCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanejamentoCategoria_Planejamento_PlanejamentoId",
                        column: x => x.PlanejamentoId,
                        principalTable: "Planejamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    SubCategoriaId = table.Column<int>(type: "int", nullable: true),
                    ValorLimite = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MesReferencia = table.Column<int>(type: "int", nullable: false),
                    AnoReferencia = table.Column<int>(type: "int", nullable: false),
                    AlertaAtivado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PercentualAlerta = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamento_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orcamento_SubCategoria_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orcamento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagamentoRecorrente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: true),
                    CartaoCreditoId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    SubCategoriaId = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Frequencia = table.Column<int>(type: "int", nullable: false),
                    DiaVencimento = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProximaGeracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoRecorrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoRecorrente_CartaoCredito_CartaoCreditoId",
                        column: x => x.CartaoCreditoId,
                        principalTable: "CartaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagamentoRecorrente_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagamentoRecorrente_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagamentoRecorrente_SubCategoria_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagamentoRecorrente_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parcelamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CartaoCreditoId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    SubCategoriaId = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    QuantidadeParcelas = table.Column<int>(type: "int", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelamento_CartaoCredito_CartaoCreditoId",
                        column: x => x.CartaoCreditoId,
                        principalTable: "CartaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcelamento_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcelamento_SubCategoria_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcelamento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComandoChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MensagemChatId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoComando = table.Column<int>(type: "int", nullable: false),
                    DadosExtraidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadeCriada = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntidadeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MensagemErro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RequerConfirmacao = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExecucao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandoChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComandoChat_MensagemChat_MensagemChatId",
                        column: x => x.MensagemChatId,
                        principalTable: "MensagemChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandoChat_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: true),
                    ContaDestinoId = table.Column<int>(type: "int", nullable: true),
                    CartaoCreditoId = table.Column<int>(type: "int", nullable: true),
                    FaturaId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    SubCategoriaId = table.Column<int>(type: "int", nullable: true),
                    PagamentoRecorrenteId = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_CartaoCredito_CartaoCreditoId",
                        column: x => x.CartaoCreditoId,
                        principalTable: "CartaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_ContaDestinoId",
                        column: x => x.ContaDestinoId,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_Fatura_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Fatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_PagamentoRecorrente_PagamentoRecorrenteId",
                        column: x => x.PagamentoRecorrenteId,
                        principalTable: "PagamentoRecorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_SubCategoria_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParcelamentoId = table.Column<int>(type: "int", nullable: false),
                    FaturaId = table.Column<int>(type: "int", nullable: true),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TransacaoId = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcela_Fatura_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Fatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcela_Parcelamento_ParcelamentoId",
                        column: x => x.ParcelamentoId,
                        principalTable: "Parcelamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcela_Transacao_TransacaoId",
                        column: x => x.TransacaoId,
                        principalTable: "Transacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "DataAtualizacao", "DataCriacao", "Email", "Nome", "SenhaHash" },
                values: new object[] { 1, true, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@fincontrol.com", "Usuario Padrao", "hash_temporario" });

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_UsuarioId_Status",
                table: "Alerta",
                columns: new[] { "UsuarioId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCredito_UsuarioId",
                table: "CartaoCredito",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_UsuarioId",
                table: "Categoria",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandoChat_MensagemChatId",
                table: "ComandoChat",
                column: "MensagemChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandoChat_UsuarioId_Status",
                table: "ComandoChat",
                columns: new[] { "UsuarioId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoAlerta_UsuarioId",
                table: "ConfiguracaoAlerta",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoChat_UsuarioId",
                table: "ConfiguracaoChat",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_UsuarioId",
                table: "Conta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversaChat_UsuarioId_DataCriacao",
                table: "ConversaChat",
                columns: new[] { "UsuarioId", "DataCriacao" });

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_CartaoCreditoId_MesReferencia_AnoReferencia",
                table: "Fatura",
                columns: new[] { "CartaoCreditoId", "MesReferencia", "AnoReferencia" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MensagemChat_ConversaChatId_Ordem",
                table: "MensagemChat",
                columns: new[] { "ConversaChatId", "Ordem" });

            migrationBuilder.CreateIndex(
                name: "IX_Meta_ContaId",
                table: "Meta",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_UsuarioId",
                table: "Meta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_CategoriaId",
                table: "Orcamento",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_SubCategoriaId",
                table: "Orcamento",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_UsuarioId_CategoriaId_MesReferencia_AnoReferencia",
                table: "Orcamento",
                columns: new[] { "UsuarioId", "CategoriaId", "MesReferencia", "AnoReferencia" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoRecorrente_CartaoCreditoId",
                table: "PagamentoRecorrente",
                column: "CartaoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoRecorrente_CategoriaId",
                table: "PagamentoRecorrente",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoRecorrente_ContaId",
                table: "PagamentoRecorrente",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoRecorrente_SubCategoriaId",
                table: "PagamentoRecorrente",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoRecorrente_UsuarioId",
                table: "PagamentoRecorrente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_FaturaId",
                table: "Parcela",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_ParcelamentoId",
                table: "Parcela",
                column: "ParcelamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_TransacaoId",
                table: "Parcela",
                column: "TransacaoId",
                unique: true,
                filter: "[TransacaoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelamento_CartaoCreditoId",
                table: "Parcelamento",
                column: "CartaoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelamento_CategoriaId",
                table: "Parcelamento",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelamento_SubCategoriaId",
                table: "Parcelamento",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelamento_UsuarioId",
                table: "Parcelamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Planejamento_UsuarioId",
                table: "Planejamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanejamentoCategoria_CategoriaId",
                table: "PlanejamentoCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanejamentoCategoria_PlanejamentoId_CategoriaId",
                table: "PlanejamentoCategoria",
                columns: new[] { "PlanejamentoId", "CategoriaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromptPersonalizado_UsuarioId",
                table: "PromptPersonalizado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_Token",
                table: "RefreshToken",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UsuarioId",
                table: "RefreshToken",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoria_CategoriaId",
                table: "SubCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_CartaoCreditoId",
                table: "Transacao",
                column: "CartaoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_CategoriaId",
                table: "Transacao",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ContaDestinoId",
                table: "Transacao",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ContaId",
                table: "Transacao",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_Data",
                table: "Transacao",
                column: "Data");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_FaturaId",
                table: "Transacao",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_PagamentoRecorrenteId",
                table: "Transacao",
                column: "PagamentoRecorrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_SubCategoriaId",
                table: "Transacao",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_UsuarioId_Data",
                table: "Transacao",
                columns: new[] { "UsuarioId", "Data" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerta");

            migrationBuilder.DropTable(
                name: "ComandoChat");

            migrationBuilder.DropTable(
                name: "ConfiguracaoAlerta");

            migrationBuilder.DropTable(
                name: "ConfiguracaoChat");

            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "PlanejamentoCategoria");

            migrationBuilder.DropTable(
                name: "PromptPersonalizado");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "MensagemChat");

            migrationBuilder.DropTable(
                name: "Parcelamento");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Planejamento");

            migrationBuilder.DropTable(
                name: "ConversaChat");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "PagamentoRecorrente");

            migrationBuilder.DropTable(
                name: "CartaoCredito");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "SubCategoria");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
