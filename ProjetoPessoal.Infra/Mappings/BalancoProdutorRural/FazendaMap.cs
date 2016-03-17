using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Infra.Mappings.BalancoProdutorRural
{
    public class FazendaMap : EntityTypeConfiguration<Fazenda>
    {
        public FazendaMap()
        {
            ToTable("BalancoProdutorRural_Fazenda");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Nome").IsRequired();

            Property(x => x.Area).HasColumnName("Area").IsRequired();

            Property(x => x.Endereco.Logradouro).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Logradouro").IsRequired();

            Property(x => x.Endereco.Numero).HasColumnName("Numero").IsRequired();

            Property(x => x.Endereco.Complemento).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Complemento");

            Property(x => x.Endereco.Bairro).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Bairro").IsRequired();

            Property(x => x.Endereco.Cidade).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Cidade").IsRequired();

            Property(x => x.Endereco.Estado).HasColumnType("varchar").HasMaxLength(2).HasColumnName("Estado").IsRequired();

            Property(x => x.Endereco.Cep).HasColumnType("varchar").HasMaxLength(10).HasColumnName("Cep").IsRequired();

            //relacionamento one-to-many com a tabela produtor rural
            HasRequired(x => x.ProdutorRural);
        }
    }
}
