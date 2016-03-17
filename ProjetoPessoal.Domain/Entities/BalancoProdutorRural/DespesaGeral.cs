using System;

namespace ProjetoPessoal.Domain.Entities.BalancoProdutorRural
{
    public class DespesaGeral
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int ProdutorRuralId { get; set; }

        public ProdutorRural ProdutorRural { get; set; }

        public string NumeroDocumento { get; set; }

        public string NomeVendedor { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }
    }
}
