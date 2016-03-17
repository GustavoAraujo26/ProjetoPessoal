using ProjetoPessoal.Domain.Entities.Perfil;

namespace ProjetoPessoal.Domain.Entities.BalancoProdutorRural
{
    public class Fazenda
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Area { get; set; }

        public int ProdutorRuralId { get; set; }

        public ProdutorRural ProdutorRural { get; set; }

        public Endereco Endereco { get; set; }
    }
}
