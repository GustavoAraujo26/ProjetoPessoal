using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;

namespace ProjetoPessoal.Services.Services.Cotacao
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return _produtoRepository.BuscaPorNome(nome);
        }
    }
}
