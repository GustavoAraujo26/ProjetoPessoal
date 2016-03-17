using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural
{
    public interface IDespesaGeralService : IServiceBase<DespesaGeral>
    {
        IEnumerable<DespesaGeral> DespesasGeraisPorProdutorEAno(int produtoId, int ano);
    }
}
