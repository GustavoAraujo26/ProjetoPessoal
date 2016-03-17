using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Domain.Interfaces.Services.Cotacao
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscaPorNome(String nome);
    }
}
