using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.Cotacao
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            var produto = from x in Db.Produtos
                where x.Nome.Contains(nome)
                orderby x.Nome
                select x;
            return produto.ToList();
        }
    }
}
