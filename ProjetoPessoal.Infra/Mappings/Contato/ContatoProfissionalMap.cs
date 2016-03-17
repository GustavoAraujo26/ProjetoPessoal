using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.Contato;

namespace ProjetoPessoal.Infra.Mappings.Contato
{
    public class ContatoProfissionalMap : EntityTypeConfiguration<ContatoProfissional>
    {
        public ContatoProfissionalMap()
        {
            ToTable("Contato_ContatoProfissional");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Nome").IsRequired();

            Property(x => x.Empresa).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Empresa").IsRequired();
            
            Property(x => x.Email).HasColumnType("varchar").HasMaxLength(200).HasColumnName("Email").IsRequired();

            Property(x => x.Telefone).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone").IsRequired();

            Property(x => x.Assunto).HasColumnType("varchar").HasMaxLength(1000).HasColumnName("Assunto");

            Property(x => x.Mensagem).HasColumnType("varchar").HasMaxLength(8000).HasColumnName("Mensagem");
        }
    }
}
