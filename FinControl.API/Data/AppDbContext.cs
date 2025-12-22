using FinControl.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinControl.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<CartaoCredito> CartoesCredito { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<PagamentoRecorrente> PagamentosRecorrentes { get; set; }
        public DbSet<Parcelamento> Parcelamentos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Planejamento> Planejamentos { get; set; }
        public DbSet<PlanejamentoCategoria> PlanejamentoCategorias { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<ConfiguracaoAlerta> ConfiguracoesAlerta { get; set; }
        public DbSet<ConversaChat> Conversas { get; set; }
        public DbSet<MensagemChat> Mensagens { get; set; }
        public DbSet<PromptPersonalizado> PromptsPersonalizados { get; set; }
        public DbSet<ConfiguracaoChat> ConfiguracoesChat { get; set; }
        public DbSet<ComandoChat> ComandosChat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurarUsuario(modelBuilder);
            ConfigurarConta(modelBuilder);
            ConfigurarCartaoCredito(modelBuilder);
            ConfigurarFatura(modelBuilder);
            ConfigurarCategoria(modelBuilder);
            ConfigurarSubCategoria(modelBuilder);
            ConfigurarPagamentoRecorrente(modelBuilder);
            ConfigurarParcelamento(modelBuilder);
            ConfigurarParcela(modelBuilder);
            ConfigurarTransacao(modelBuilder);
            ConfigurarRefreshToken(modelBuilder);
            ConfigurarMeta(modelBuilder);
            ConfigurarOrcamento(modelBuilder);
            ConfigurarPlanejamento(modelBuilder);
            ConfigurarPlanejamentoCategoria(modelBuilder);
            ConfigurarAlerta(modelBuilder);
            ConfigurarConfiguracaoAlerta(modelBuilder);
            ConfigurarConversaChat(modelBuilder);
            ConfigurarMensagemChat(modelBuilder);
            ConfigurarPromptPersonalizado(modelBuilder);
            ConfigurarConfiguracaoChat(modelBuilder);
            ConfigurarComandoChat(modelBuilder);
        }

        private void ConfigurarUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(u => u.SenhaHash)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(u => u.DataCriacao)
                    .IsRequired();

                entity.Property(u => u.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasIndex(u => u.Email)
                    .IsUnique();
            });
        }

        private void ConfigurarConta(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>(entity =>
            {
                entity.ToTable("Conta");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Tipo)
                    .IsRequired();

                entity.Property(c => c.Banco)
                    .HasMaxLength(100);

                entity.Property(c => c.Agencia)
                    .HasMaxLength(20);

                entity.Property(c => c.NumeroConta)
                    .HasMaxLength(30);

                entity.Property(c => c.SaldoInicial)
                    .HasPrecision(18, 2);

                entity.Property(c => c.SaldoAtual)
                    .HasPrecision(18, 2);

                entity.Property(c => c.Cor)
                    .HasMaxLength(20);

                entity.Property(c => c.Icone)
                    .HasMaxLength(50);

                entity.Property(c => c.DataCriacao)
                    .IsRequired();

                entity.Property(c => c.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(c => c.Usuario)
                    .WithMany(u => u.Contas)
                    .HasForeignKey(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigurarCartaoCredito(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartaoCredito>(entity =>
            {
                entity.ToTable("CartaoCredito");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Bandeira)
                    .HasMaxLength(50);

                entity.Property(c => c.UltimosDigitos)
                    .HasMaxLength(4);

                entity.Property(c => c.Limite)
                    .HasPrecision(18, 2);

                entity.Property(c => c.DiaFechamento)
                    .IsRequired();

                entity.Property(c => c.DiaVencimento)
                    .IsRequired();

                entity.Property(c => c.Cor)
                    .HasMaxLength(20);

                entity.Property(c => c.Icone)
                    .HasMaxLength(50);

                entity.Property(c => c.DataCriacao)
                    .IsRequired();

                entity.Property(c => c.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(c => c.Usuario)
                    .WithMany(u => u.CartoesCredito)
                    .HasForeignKey(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigurarFatura(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.ToTable("Fatura");
                entity.HasKey(f => f.Id);

                entity.Property(f => f.MesReferencia)
                    .IsRequired();

                entity.Property(f => f.AnoReferencia)
                    .IsRequired();

                entity.Property(f => f.DataFechamento)
                    .IsRequired();

                entity.Property(f => f.DataVencimento)
                    .IsRequired();

                entity.Property(f => f.ValorTotal)
                    .HasPrecision(18, 2);

                entity.Property(f => f.ValorPago)
                    .HasPrecision(18, 2);

                entity.Property(f => f.Status)
                    .IsRequired();

                entity.Property(f => f.DataCriacao)
                    .IsRequired();

                entity.HasOne(f => f.CartaoCredito)
                    .WithMany(c => c.Faturas)
                    .HasForeignKey(f => f.CartaoCreditoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(f => new { f.CartaoCreditoId, f.MesReferencia, f.AnoReferencia })
                    .IsUnique();
            });
        }

        private void ConfigurarCategoria(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categoria");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Descricao)
                    .HasMaxLength(255);

                entity.Property(c => c.Cor)
                    .HasMaxLength(20);

                entity.Property(c => c.Icone)
                    .HasMaxLength(50);

                entity.Property(c => c.DataCriacao)
                    .IsRequired();

                entity.Property(c => c.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(c => c.Usuario)
                    .WithMany(u => u.Categorias)
                    .HasForeignKey(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigurarSubCategoria(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategoria>(entity =>
            {
                entity.ToTable("SubCategoria");
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Descricao)
                    .HasMaxLength(255);

                entity.Property(s => s.DataCriacao)
                    .IsRequired();

                entity.Property(s => s.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(s => s.Categoria)
                    .WithMany(c => c.SubCategorias)
                    .HasForeignKey(s => s.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigurarPagamentoRecorrente(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PagamentoRecorrente>(entity =>
            {
                entity.ToTable("PagamentoRecorrente");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(p => p.Valor)
                    .HasPrecision(18, 2);

                entity.Property(p => p.Tipo)
                    .IsRequired();

                entity.Property(p => p.Frequencia)
                    .IsRequired();

                entity.Property(p => p.DiaVencimento)
                    .IsRequired();

                entity.Property(p => p.DataInicio)
                    .IsRequired();

                entity.Property(p => p.DataCriacao)
                    .IsRequired();

                entity.Property(p => p.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(p => p.Usuario)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Conta)
                    .WithMany()
                    .HasForeignKey(p => p.ContaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.CartaoCredito)
                    .WithMany()
                    .HasForeignKey(p => p.CartaoCreditoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Categoria)
                    .WithMany()
                    .HasForeignKey(p => p.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.SubCategoria)
                    .WithMany()
                    .HasForeignKey(p => p.SubCategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigurarParcelamento(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcelamento>(entity =>
            {
                entity.ToTable("Parcelamento");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(p => p.ValorTotal)
                    .HasPrecision(18, 2);

                entity.Property(p => p.QuantidadeParcelas)
                    .IsRequired();

                entity.Property(p => p.DataCompra)
                    .IsRequired();

                entity.Property(p => p.DataCriacao)
                    .IsRequired();

                entity.Property(p => p.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(p => p.Usuario)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.CartaoCredito)
                    .WithMany()
                    .HasForeignKey(p => p.CartaoCreditoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Categoria)
                    .WithMany()
                    .HasForeignKey(p => p.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.SubCategoria)
                    .WithMany()
                    .HasForeignKey(p => p.SubCategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigurarParcela(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcela>(entity =>
            {
                entity.ToTable("Parcela");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.NumeroParcela)
                    .IsRequired();

                entity.Property(p => p.Valor)
                    .HasPrecision(18, 2);

                entity.Property(p => p.DataVencimento)
                    .IsRequired();

                entity.Property(p => p.Pago)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.Property(p => p.DataCriacao)
                    .IsRequired();

                entity.HasOne(p => p.Parcelamento)
                    .WithMany(pr => pr.Parcelas)
                    .HasForeignKey(p => p.ParcelamentoId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.Fatura)
                    .WithMany()
                    .HasForeignKey(p => p.FaturaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Transacao)
                    .WithOne(t => t.Parcela)
                    .HasForeignKey<Parcela>(p => p.TransacaoId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }

        private void ConfigurarTransacao(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.ToTable("Transacao");
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Descricao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(t => t.Valor)
                    .HasPrecision(18, 2);

                entity.Property(t => t.Tipo)
                    .IsRequired();

                entity.Property(t => t.Data)
                    .IsRequired();

                entity.Property(t => t.Observacao)
                    .HasMaxLength(500);

                entity.Property(t => t.Status)
                    .IsRequired();

                entity.Property(t => t.DataCriacao)
                    .IsRequired();

                entity.HasOne(t => t.Usuario)
                    .WithMany(u => u.Transacoes)
                    .HasForeignKey(t => t.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Conta)
                    .WithMany(c => c.Transacoes)
                    .HasForeignKey(t => t.ContaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.ContaDestino)
                    .WithMany()
                    .HasForeignKey(t => t.ContaDestinoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CartaoCredito)
                    .WithMany(c => c.Transacoes)
                    .HasForeignKey(t => t.CartaoCreditoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Fatura)
                    .WithMany(f => f.Transacoes)
                    .HasForeignKey(t => t.FaturaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Categoria)
                    .WithMany(c => c.Transacoes)
                    .HasForeignKey(t => t.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SubCategoria)
                    .WithMany(s => s.Transacoes)
                    .HasForeignKey(t => t.SubCategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.PagamentoRecorrente)
                    .WithMany(p => p.Transacoes)
                    .HasForeignKey(t => t.PagamentoRecorrenteId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(t => t.Data);
                entity.HasIndex(t => new { t.UsuarioId, t.Data });
            });
        }

        private void ConfigurarRefreshToken(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Token)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(r => r.DataExpiracao)
                    .IsRequired();

                entity.Property(r => r.DataCriacao)
                    .IsRequired();

                entity.Property(r => r.SubstituidoPor)
                    .HasMaxLength(512);

                entity.Property(r => r.CriadoPorIp)
                    .HasMaxLength(50);

                entity.Property(r => r.RevogadoPorIp)
                    .HasMaxLength(50);

                entity.HasOne(r => r.Usuario)
                    .WithMany(u => u.RefreshTokens)
                    .HasForeignKey(r => r.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(r => r.Token);
            });
        }

        private void ConfigurarMeta(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meta>(entity =>
            {
                entity.ToTable("Meta");
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(m => m.Descricao)
                    .HasMaxLength(500);

                entity.Property(m => m.ValorObjetivo)
                    .HasPrecision(18, 2);

                entity.Property(m => m.ValorAtual)
                    .HasPrecision(18, 2);

                entity.Property(m => m.Cor)
                    .HasMaxLength(20);

                entity.Property(m => m.Icone)
                    .HasMaxLength(50);

                entity.Property(m => m.Status)
                    .IsRequired();

                entity.Property(m => m.DataCriacao)
                    .IsRequired();

                entity.HasOne(m => m.Usuario)
                    .WithMany(u => u.Metas)
                    .HasForeignKey(m => m.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Conta)
                    .WithMany()
                    .HasForeignKey(m => m.ContaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigurarOrcamento(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orcamento>(entity =>
            {
                entity.ToTable("Orcamento");
                entity.HasKey(o => o.Id);

                entity.Property(o => o.ValorLimite)
                    .HasPrecision(18, 2);

                entity.Property(o => o.MesReferencia)
                    .IsRequired();

                entity.Property(o => o.AnoReferencia)
                    .IsRequired();

                entity.Property(o => o.AlertaAtivado)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.Property(o => o.DataCriacao)
                    .IsRequired();

                entity.Property(o => o.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(o => o.Usuario)
                    .WithMany(u => u.Orcamentos)
                    .HasForeignKey(o => o.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Categoria)
                    .WithMany()
                    .HasForeignKey(o => o.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.SubCategoria)
                    .WithMany()
                    .HasForeignKey(o => o.SubCategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(o => new { o.UsuarioId, o.CategoriaId, o.MesReferencia, o.AnoReferencia })
                    .IsUnique();
            });
        }

        private void ConfigurarPlanejamento(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planejamento>(entity =>
            {
                entity.ToTable("Planejamento");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(p => p.Descricao)
                    .HasMaxLength(500);

                entity.Property(p => p.Tipo)
                    .IsRequired();

                entity.Property(p => p.ReceitaPrevista)
                    .HasPrecision(18, 2);

                entity.Property(p => p.DespesaPrevista)
                    .HasPrecision(18, 2);

                entity.Property(p => p.ReceitaRealizada)
                    .HasPrecision(18, 2);

                entity.Property(p => p.DespesaRealizada)
                    .HasPrecision(18, 2);

                entity.Property(p => p.DataCriacao)
                    .IsRequired();

                entity.Property(p => p.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(p => p.Usuario)
                    .WithMany(u => u.Planejamentos)
                    .HasForeignKey(p => p.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigurarPlanejamentoCategoria(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanejamentoCategoria>(entity =>
            {
                entity.ToTable("PlanejamentoCategoria");
                entity.HasKey(pc => pc.Id);

                entity.Property(pc => pc.ValorPrevisto)
                    .HasPrecision(18, 2);

                entity.Property(pc => pc.ValorRealizado)
                    .HasPrecision(18, 2);

                entity.Property(pc => pc.DataCriacao)
                    .IsRequired();

                entity.HasOne(pc => pc.Planejamento)
                    .WithMany(p => p.Categorias)
                    .HasForeignKey(pc => pc.PlanejamentoId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pc => pc.Categoria)
                    .WithMany()
                    .HasForeignKey(pc => pc.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(pc => new { pc.PlanejamentoId, pc.CategoriaId })
                    .IsUnique();
            });
        }

        private void ConfigurarAlerta(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alerta>(entity =>
            {
                entity.ToTable("Alerta");
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Tipo)
                    .IsRequired();

                entity.Property(a => a.Titulo)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(a => a.Mensagem)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(a => a.Status)
                    .IsRequired();

                entity.Property(a => a.ReferenciaTipo)
                    .HasMaxLength(50);

                entity.Property(a => a.DataCriacao)
                    .IsRequired();

                entity.HasOne(a => a.Usuario)
                    .WithMany(u => u.Alertas)
                    .HasForeignKey(a => a.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(a => new { a.UsuarioId, a.Status });
            });
        }

        private void ConfigurarConfiguracaoAlerta(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfiguracaoAlerta>(entity =>
            {
                entity.ToTable("ConfiguracaoAlerta");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.PercentualAlertaOrcamento)
                    .HasDefaultValue(80);

                entity.Property(c => c.ValorMinimoSaldo)
                    .HasPrecision(18, 2);

                entity.Property(c => c.DiasAntesFatura)
                    .HasDefaultValue(3);

                entity.Property(c => c.DiasAntesPagamento)
                    .HasDefaultValue(3);

                entity.Property(c => c.DataCriacao)
                    .IsRequired();

                entity.HasOne(c => c.Usuario)
                    .WithOne(u => u.ConfiguracaoAlerta)
                    .HasForeignKey<ConfiguracaoAlerta>(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigurarConversaChat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversaChat>(entity =>
            {
                entity.ToTable("ConversaChat");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Titulo)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(c => c.Resumo)
                    .HasMaxLength(1000);

                entity.Property(c => c.DataCriacao)
                    .IsRequired();

                entity.Property(c => c.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(c => c.Usuario)
                    .WithMany(u => u.Conversas)
                    .HasForeignKey(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(c => new { c.UsuarioId, c.DataCriacao });
            });
        }

        private void ConfigurarMensagemChat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MensagemChat>(entity =>
            {
                entity.ToTable("MensagemChat");
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Role)
                    .IsRequired();

                entity.Property(m => m.Conteudo)
                    .IsRequired();

                entity.Property(m => m.Ordem)
                    .IsRequired();

                entity.Property(m => m.DataCriacao)
                    .IsRequired();

                entity.HasOne(m => m.ConversaChat)
                    .WithMany(c => c.Mensagens)
                    .HasForeignKey(m => m.ConversaChatId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(m => new { m.ConversaChatId, m.Ordem });
            });
        }

        private void ConfigurarPromptPersonalizado(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromptPersonalizado>(entity =>
            {
                entity.ToTable("PromptPersonalizado");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Descricao)
                    .HasMaxLength(300);

                entity.Property(p => p.Tipo)
                    .IsRequired();

                entity.Property(p => p.Conteudo)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(p => p.DataCriacao)
                    .IsRequired();

                entity.Property(p => p.Ativo)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasOne(p => p.Usuario)
                    .WithMany(u => u.PromptsPersonalizados)
                    .HasForeignKey(p => p.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigurarConfiguracaoChat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfiguracaoChat>(entity =>
            {
                entity.ToTable("ConfiguracaoChat");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.NomeModelo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValue("Padrao");

                entity.Property(c => c.PromptSistema)
                    .HasMaxLength(2000);

                entity.Property(c => c.MaxTokensResposta)
                    .HasDefaultValue(512);

                entity.Property(c => c.MaxMensagensContexto)
                    .HasDefaultValue(6);

                entity.Property(c => c.Temperatura)
                    .HasPrecision(3, 2)
                    .HasDefaultValue(0.7m);

                entity.Property(c => c.ResumirConversasAntigas)
                    .HasDefaultValue(true);

                entity.Property(c => c.IncluirDadosFinanceiros)
                    .HasDefaultValue(true);

                entity.Property(c => c.DataCriacao)
                    .IsRequired();

                entity.HasOne(c => c.Usuario)
                    .WithOne(u => u.ConfiguracaoChat)
                    .HasForeignKey<ConfiguracaoChat>(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigurarComandoChat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComandoChat>(entity =>
            {
                entity.ToTable("ComandoChat");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.TipoComando)
                    .IsRequired();

                entity.Property(c => c.DadosExtraidos)
                    .IsRequired();

                entity.Property(c => c.EntidadeCriada)
                    .HasMaxLength(100);

                entity.Property(c => c.Status)
                    .IsRequired();

                entity.Property(c => c.MensagemErro)
                    .HasMaxLength(500);

                entity.Property(c => c.DataCriacao)
                    .IsRequired();

                entity.HasOne(c => c.MensagemChat)
                    .WithMany()
                    .HasForeignKey(c => c.MensagemChatId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Usuario)
                    .WithMany()
                    .HasForeignKey(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(c => new { c.UsuarioId, c.Status });
            });
        }
    }
}
