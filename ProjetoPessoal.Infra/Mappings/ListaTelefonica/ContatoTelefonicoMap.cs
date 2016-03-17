using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;

namespace ProjetoPessoal.Infra.Mappings.ListaTelefonica
{
    public class ContatoTelefonicoMap: EntityTypeConfiguration<ContatoTelefonico>
    {
        public ContatoTelefonicoMap()
        {
            ToTable("ListaTelefonica_ContatoTelefonico");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Nome").IsRequired();

            Property(x => x.Apelido).HasColumnType("varchar").HasMaxLength(100).HasColumnName("Apelido");

            Property(x => x.Cargo).HasColumnType("varchar").HasMaxLength(700).HasColumnName("Cargo");

            Property(x => x.Empresa).HasColumnType("varchar").HasMaxLength(700).HasColumnName("Empresa");

            Property(x => x.Endereco.Logradouro).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Logradouro").IsRequired();

            Property(x => x.Endereco.Numero).HasColumnName("Numero").IsRequired();

            Property(x => x.Endereco.Complemento).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Complemento");

            Property(x => x.Endereco.Bairro).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Bairro").IsRequired();

            Property(x => x.Endereco.Cidade).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Cidade").IsRequired();

            Property(x => x.Endereco.Estado).HasColumnType("varchar").HasMaxLength(2).HasColumnName("Estado").IsRequired();

            Property(x => x.Endereco.Cep).HasColumnType("varchar").HasMaxLength(10).HasColumnName("Cep").IsRequired();

            Property(x => x.Contato.Email).HasColumnType("varchar").HasMaxLength(200).HasColumnName("Email").IsRequired();

            Property(x => x.Contato.Telefone1).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone1").IsRequired();

            Property(x => x.Contato.Telefone2).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone 2");

            Property(x => x.Contato.Facebook).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Facebook");

            Property(x => x.Contato.LinkedIn).HasColumnType("varchar").HasMaxLength(500).HasColumnName("LinkedIn");

            HasRequired(x => x.Perfil);

        }
    }
}
