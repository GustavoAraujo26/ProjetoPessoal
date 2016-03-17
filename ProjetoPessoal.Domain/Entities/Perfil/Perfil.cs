using System;

namespace ProjetoPessoal.Domain.Entities.Perfil
{
    public class Perfil
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public DateTime DataNascimento { get; set; }

        public string GrauInstrucao { get; set; }

        public string EstadoCivil { get; set; }

        public string Sexo { get; set; }

        public Endereco Endereco { get; set; }

        public Contato Contato { get; set; }
    }
}
