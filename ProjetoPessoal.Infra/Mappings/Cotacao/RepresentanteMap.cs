using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Infra.Mappings.Cotacao
{
    public class RepresentanteMap : EntityTypeConfiguration<Representante>
    {
        public RepresentanteMap()
        {
            ToTable("Cotacao_Representante");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Nome").IsRequired();

            Property(x => x.Apelido).HasColumnType("varchar").HasMaxLength(100).HasColumnName("Apelido");

            Property(x => x.Contato.Email).HasColumnType("varchar").HasMaxLength(200).HasColumnName("Email").IsRequired();

            Property(x => x.Contato.Telefone1).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone1").IsRequired();

            Property(x => x.Contato.Telefone2).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone 2");

            Property(x => x.Contato.Facebook).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Facebook");

            Property(x => x.Contato.LinkedIn).HasColumnType("varchar").HasMaxLength(500).HasColumnName("LinkedIn");

            Property(x => x.Observacao).HasColumnType("varchar").HasMaxLength(8000).HasColumnName("Observacao");

            //relacionamento obrigatório com o fornecedor
            HasRequired(x => x.Fornecedor);
        }
    }
}
