using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.LivroCaixa;

namespace ProjetoPessoal.Infra.Mappings.LivroCaixa
{
    public class DebitoCaixaMap : EntityTypeConfiguration<DebitoCaixa>
    {
        public DebitoCaixaMap()
        {
            ToTable("LivroCaixa_DebitoCaixa");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //relacionamento one-to-many com a tabela perfil
            HasRequired(x => x.Perfil);

            Property(x => x.Data).HasColumnName("Data").HasColumnType("Date").IsRequired();

            Property(x => x.NumeroDocumento).HasColumnType("varchar").HasMaxLength(20).HasColumnName("NumeroDocumento");

            Property(x => x.Tipo).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Tipo").IsRequired();

            Property(x => x.Titulo).HasColumnType("varchar").HasMaxLength(800).HasColumnName("Titulo").IsRequired();

            Property(x => x.Valor).HasColumnName("Valor").IsRequired();

            Property(x => x.Descricao).HasColumnType("varchar").HasMaxLength(8000).HasColumnName("Descricao");
        }
    }
}
