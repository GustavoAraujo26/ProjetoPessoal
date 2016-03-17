using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Infra.Mappings.BalancoProdutorRural
{
    public class PosseMap : EntityTypeConfiguration<Posse>
    {
        public PosseMap()
        {
            ToTable("BalancoProdutorRural_Posse");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.DataAquisicao).HasColumnName("DataAquisicao").HasColumnType("Date").IsRequired();

            //relacionamento one-to-many com a tabela produtor rural
            HasRequired(x => x.ProdutorRural);

            Property(x => x.Valor).HasColumnName("Valor").IsRequired();

            Property(x => x.Descricao).HasColumnType("varchar").HasMaxLength(8000).HasColumnName("Descricao");
        }
    }
}
