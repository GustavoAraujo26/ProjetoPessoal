using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoPessoal.Infra.Mappings.Cotacao
{
    public class CotacaoMap : EntityTypeConfiguration<Domain.Entities.Cotacao.Cotacao>
    {
        public CotacaoMap()
        {
            ToTable("Cotacao_Cotacao");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Data).HasColumnName("Data").HasColumnType("Date").IsRequired();

            //relacionamento obrigatório com o produto
            HasRequired(x => x.Produto);

            //relacionamento obrigatório com o representante
            HasRequired(x => x.Representante);

            Property(x => x.Qtd).HasColumnName("Qtd").IsRequired();

            Property(x => x.PrecoSugerido).HasColumnName("PrecoSugerido").IsRequired();

            Property(x => x.Observacao).HasColumnType("varchar").HasMaxLength(8000).HasColumnName("Observacao");
        }
    }
}
