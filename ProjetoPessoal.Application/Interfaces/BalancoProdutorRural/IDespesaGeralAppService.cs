using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Interfaces.BalancoProdutorRural
{
    public interface IDespesaGeralAppService : IAppServiceBase<DespesaGeral>
    {
        IEnumerable<DespesaGeral> DespesasGeraisPorProdutorEAno(int produtoId, int ano);
    }
}
