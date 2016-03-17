using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural
{
    public interface IPosseRepository : IRepositoryBase<Posse>
    {
        IEnumerable<Posse> PossesPorProdutorRuralEAno(int produtorId, int ano);
    }
}
