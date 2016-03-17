using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Perfil;

namespace ProjetoPessoal.Domain.Entities.BalancoProdutorRural
{
    public class ProdutorRural
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string InscricaoEstadual { get; set; }

        public Endereco Endereco { get; set; }

        public string Email { get; set; }

        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        public string Observacao { get; set; }

        public virtual IList<Fazenda> Fazendas { get; set; }
    }
}
