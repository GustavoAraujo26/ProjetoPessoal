using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural
{
    public interface IDespesaGeralRepository : IRepositoryBase<DespesaGeral>
    {
        IEnumerable<DespesaGeral> DespesasGeraisPorProdutorEAno(int produtoId, int ano);
    }
}
