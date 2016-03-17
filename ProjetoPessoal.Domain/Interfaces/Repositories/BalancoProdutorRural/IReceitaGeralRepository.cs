using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural
{
    public interface IReceitaGeralRepository : IRepositoryBase<ReceitaGeral>
    {
        IEnumerable<ReceitaGeral> ReceitasGeraisPorProdutorEAno(int produtoId, int ano);
    }
}
