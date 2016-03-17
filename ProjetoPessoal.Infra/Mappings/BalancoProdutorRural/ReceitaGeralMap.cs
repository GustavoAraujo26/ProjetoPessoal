using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Infra.Mappings.BalancoProdutorRural
{
    public class ReceitaGeralMap : EntityTypeConfiguration<ReceitaGeral>
    {
        public ReceitaGeralMap()
        {
            ToTable("BalancoProdutorRural_ReceitaGeral");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //relacionamento one-to-many com a tabela produtor rural
            HasRequired(x => x.ProdutorRural);

            Property(x => x.Data).HasColumnName("Data").HasColumnType("Date").IsRequired();

            Property(x => x.NumeroDocumento).HasColumnType("varchar").HasMaxLength(20).HasColumnName("NumeroDocumento");

            Property(x => x.NomeComprador).HasColumnType("varchar").HasMaxLength(300).HasColumnName("NomeComprador").IsRequired();

            Property(x => x.Valor).HasColumnName("Valor").IsRequired();

            Property(x => x.Descricao).HasColumnType("varchar").HasMaxLength(8000).HasColumnName("Descricao");
        }
    }
}
