using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Perfil;

namespace ProjetoPessoal.Domain.Entities.Cotacao
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string RazaoSocial { get; set; }

        public string Cnpj { get; set; }

        public string InscricaoEstadual { get; set; }

        public Endereco Endereco { get; set; }

        public Perfil.Contato Contato { get; set; }

        public string Observacao { get; set; }

        public virtual IList<Representante> Representantes { get; set; }
    }
}
