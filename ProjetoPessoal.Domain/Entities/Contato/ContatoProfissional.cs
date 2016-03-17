using System;

namespace ProjetoPessoal.Domain.Entities.Contato
{
    public class ContatoProfissional
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string Nome { get; set; }

        public string Empresa { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }
    }
}
