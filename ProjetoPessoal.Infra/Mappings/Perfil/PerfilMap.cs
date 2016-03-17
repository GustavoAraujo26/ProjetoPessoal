using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoPessoal.Infra.Mappings.Perfil
{
    public class PerfilMap : EntityTypeConfiguration<Domain.Entities.Perfil.Perfil>
    {
        public PerfilMap()
        {
            ToTable("Perfil_Perfil");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NomeCompleto).HasColumnType("varchar").HasMaxLength(300).HasColumnName("NomeCompleto").IsRequired();

            Property(x => x.DataNascimento).HasColumnName("DataNascimento").HasColumnType("Date").IsRequired();

            Property(x => x.GrauInstrucao).HasColumnType("varchar").HasMaxLength(100).HasColumnName("GrauInstrucao");

            Property(x => x.EstadoCivil).HasColumnType("varchar").HasMaxLength(50).HasColumnName("EstadoCivil");

            Property(x => x.Sexo).HasColumnType("varchar").HasMaxLength(1).HasColumnName("Sexo").IsRequired();

            Property(x => x.Endereco.Logradouro).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Logradouro").IsRequired();

            Property(x => x.Endereco.Numero).HasColumnName("Numero").IsRequired();

            Property(x => x.Endereco.Complemento).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Complemento");

            Property(x => x.Endereco.Bairro).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Bairro").IsRequired();

            Property(x => x.Endereco.Cidade).HasColumnType("varchar").HasMaxLength(300).HasColumnName("Cidade").IsRequired();

            Property(x => x.Endereco.Estado).HasColumnType("varchar").HasMaxLength(2).HasColumnName("Estado").IsRequired();

            Property(x => x.Endereco.Cep).HasColumnType("varchar").HasMaxLength(10).HasColumnName("Cep").IsRequired();

            Property(x => x.Contato.Email).HasColumnType("varchar").HasMaxLength(200).HasColumnName("Email").IsRequired();

            Property(x => x.Contato.Telefone1).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone1").IsRequired();

            Property(x => x.Contato.Telefone2).HasColumnType("varchar").HasMaxLength(14).HasColumnName("Telefone2");

            Property(x => x.Contato.Facebook).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Facebook");

            Property(x => x.Contato.LinkedIn).HasColumnType("varchar").HasMaxLength(500).HasColumnName("LinkedIn");
        }
    }
}