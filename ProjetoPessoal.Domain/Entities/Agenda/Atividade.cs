using System;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;

namespace ProjetoPessoal.Domain.Entities.Agenda
{
    public class Atividade
    {
        public int Id { get; set; }

        public int PerfilId { get; set; }

        public Perfil.Perfil Perfil { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFinal { get; set; }

        public string Assunto { get; set; }

        public string Descricao { get; set; }

        public int? ContatoTelefonicoId { get; set; }

        public ContatoTelefonico ContatoTelefonico { get; set; }

        public bool Realizado { get; set; }
    }
}
