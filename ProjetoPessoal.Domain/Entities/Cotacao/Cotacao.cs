using System;

namespace ProjetoPessoal.Domain.Entities.Cotacao
{
    public class Cotacao
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public int RepresentanteId { get; set; }

        public virtual Representante Representante { get; set; }

        public int Qtd { get; set; }

        public decimal PrecoSugerido { get; set; }

        public string Observacao { get; set; }

        public Cotacao()
        {
            this.Data = DateTime.Now;
        }
    }
}
