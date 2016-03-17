using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.Cotacao;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;

namespace ProjetoPessoal.Application.Services.Cotacao
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService) : base(produtoService)
        {
            this._produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return _produtoService.BuscaPorNome(nome);
        }
    }
}
