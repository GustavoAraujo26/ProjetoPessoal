using System;

namespace ProjetoPessoal.Domain.Entities.BalancoProdutorRural
{
    public class Posse
    {
        public int Id { get; set; }

        public DateTime DataAquisicao { get; set; }

        public int ProdutorRuralId { get; set; }

        public ProdutorRural ProdutorRural { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }
    }
}
