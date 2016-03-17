using System.Collections.Generic;

namespace ProjetoPessoal.Domain.Entities.Cotacao
{
    public class Representante
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public Perfil.Contato Contato { get; set; }

        public int FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public string Observacao { get; set; }
    }
}
