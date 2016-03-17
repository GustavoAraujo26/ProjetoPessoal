using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Infra.Mappings.BalancoProdutorRural
{
    public class ProdutorRuralMap : EntityTypeConfiguration<ProdutorRural>
    {
        public ProdutorRuralMap()
        {
            ToTable("BalancoProdutorRural_ProdutorRural");

            HasKey(x => x.Id);
            
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Nome").IsRequired();

            Property(x => x.Cpf).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Cpf").IsRequired();

            Property(x => x.InscricaoEstadual).HasColumnType("varchar").HasMaxLength(20).HasColumnName("InscricaoEstadual").IsRequired();

            Property(x => x.Endereco.Logradouro).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Logradouro").IsRequired();

            Property(x => x.Endereco.Numero).HasColumnName("Numero").IsRequired();

            Property(x => x.Endereco.Complemento).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Complemento");

            Property(x => x.Endereco.Bairro).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Bairro").IsRequired();

            Property(x => x.Endereco.Cidade).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Cidade").IsRequired();

            Property(x => x.Endereco.Estado).HasColumnType("varchar").HasMaxLength(2).HasColumnName("Estado").IsRequired();

            Property(x => x.Endereco.Cep).HasColumnType("varchar").HasMaxLength(10).HasColumnName("Cep").IsRequired();

            Property(x => x.Email).HasColumnType("varchar").HasMaxLength(200).HasColumnName("Email").IsRequired();

            Property(x => x.Telefone1).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone1").IsRequired();

            Property(x => x.Telefone2).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone 2");
        }
    }
}
