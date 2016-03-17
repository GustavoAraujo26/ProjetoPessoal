using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Application.Interfaces.Cotacao
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscaPorNome(String nome);
    }
}
