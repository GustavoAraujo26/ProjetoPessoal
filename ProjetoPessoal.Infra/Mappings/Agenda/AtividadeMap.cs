using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjetoPessoal.Domain.Entities.Agenda;

namespace ProjetoPessoal.Infra.Mappings.Agenda
{
    public class AtividadeMap : EntityTypeConfiguration<Atividade>
    {
        public AtividadeMap()
        {
            ToTable("Agenda_Atividade");

            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Criando a chave estrangeira obrigatória com o perfil
            HasRequired(x => x.Perfil);

            Property(x => x.DataInicio).HasColumnName("DataInicio").HasColumnType("Date").IsRequired();

            Property(x => x.DataFinal).HasColumnName("DataFinal").HasColumnType("Date").IsRequired();

            Property(x => x.Assunto).HasColumnType("varchar").HasMaxLength(500).HasColumnName("Assunto").IsRequired();

            Property(x => x.Descricao).HasColumnType("varchar").HasMaxLength(8000).HasColumnName("Descricao");

            //Criando a chave estrangeira opicional com o contato telefonico
            HasOptional(x => x.ContatoTelefonico);

            Property(x => x.Realizado).HasColumnName("Realizado");
        }
    }
}
