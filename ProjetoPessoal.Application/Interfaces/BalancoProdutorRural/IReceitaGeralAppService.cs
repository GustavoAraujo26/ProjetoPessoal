using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Interfaces.BalancoProdutorRural
{
    public interface IReceitaGeralAppService : IAppServiceBase<ReceitaGeral>
    {
        IEnumerable<ReceitaGeral> ReceitasGeraisPorProdutorEAno(int produtoId, int ano);
    }
}
