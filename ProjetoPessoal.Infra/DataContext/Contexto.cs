using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoPessoal.Domain.Entities.Agenda;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.Contato;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;
using ProjetoPessoal.Domain.Entities.LivroCaixa;
using ProjetoPessoal.Domain.Entities.Perfil;
using ProjetoPessoal.Infra.Mappings.Agenda;
using ProjetoPessoal.Infra.Mappings.BalancoProdutorRural;
using ProjetoPessoal.Infra.Mappings.Contato;
using ProjetoPessoal.Infra.Mappings.Cotacao;
using ProjetoPessoal.Infra.Mappings.ListaTelefonica;
using ProjetoPessoal.Infra.Mappings.LivroCaixa;
using ProjetoPessoal.Infra.Mappings.Perfil;

namespace ProjetoPessoal.Infra.DataContext
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Contexto") {}

        //Mapeando as classes relacionadas com o perfil
        //Namespace Perfil
        public DbSet<Perfil> Perfis { get; set; }
        //Namespace Agenda
        public DbSet<Atividade> Atividades { get; set; }
        //Namespace Contato
        public DbSet<ContatoProfissional> ContatosProfissionais { get; set; }
        //Namespace ListaTelefonica
        public DbSet<ContatoTelefonico> ContatosTelefonicos { get; set; }
        //Namespace LivroCaixa
        public DbSet<CreditoCaixa> CreditosCaixa { get; set; }
        public DbSet<DebitoCaixa> DebitosCaixa { get; set; }
        //Namespace BalancoProdutorRural
        public DbSet<CompraGado> ComprasGados { get; set; }
        public DbSet<DespesaGeral> DespesasGerais { get; set; }
        public DbSet<Fazenda> Fazendas { get; set; }
        public DbSet<Posse> Posses { get; set; }
        public DbSet<ProdutorRural> ProdutoresRurais { get; set; }
        public DbSet<ReceitaGeral> ReceitasGerais { get; set; }
        public DbSet<VendaGado> VendasGerais { get; set; }
        public DbSet<VendaLeite> VendasLeite { get; set; }
        //Namespace Cotacao
        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Representante> Representantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Removendo conveções de deletar em cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //Removendo a conveção de pluralização das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Adicionando as configurações das classes
            //Namespace Perfil
            modelBuilder.Configurations.Add(new PerfilMap());
            //Namespace Agenda
            modelBuilder.Configurations.Add(new AtividadeMap());
            //Namespace Contato
            modelBuilder.Configurations.Add(new ContatoProfissionalMap());
            //Namespace ListaTelefonica
            modelBuilder.Configurations.Add(new ContatoTelefonicoMap());
            //Namespace LivroCaixa
            modelBuilder.Configurations.Add(new CreditoCaixaMap());
            modelBuilder.Configurations.Add(new DebitoCaixaMap());
            //Namespace BalancoProdutorRural
            modelBuilder.Configurations.Add(new CompraGadoMap());
            modelBuilder.Configurations.Add(new DespesaGeralMap());
            modelBuilder.Configurations.Add(new FazendaMap());
            modelBuilder.Configurations.Add(new PosseMap());
            modelBuilder.Configurations.Add(new ProdutorRuralMap());
            modelBuilder.Configurations.Add(new ReceitaGeralMap());
            modelBuilder.Configurations.Add(new VendaGadoMap());
            modelBuilder.Configurations.Add(new VendaLeiteMap());
            //Namespace Cotacao
            modelBuilder.Configurations.Add(new CotacaoMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new RepresentanteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
