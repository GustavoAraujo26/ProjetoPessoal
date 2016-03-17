using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Infra.Mappings.Cotacao
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Cotacao_Produto");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Nome").IsRequired();

            Property(x => x.Marca).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Marca").IsRequired();
            
            Property(x => x.Observacao).HasColumnType("varchar").HasMaxLength(8000).HasColumnName("Observacao");
        }
    }
}
