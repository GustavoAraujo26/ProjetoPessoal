using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural
{
    public interface IReceitaGeralService : IServiceBase<ReceitaGeral>
    {
        IEnumerable<ReceitaGeral> ReceitasGeraisPorProdutorEAno(int produtoId, int ano);
    }
}
