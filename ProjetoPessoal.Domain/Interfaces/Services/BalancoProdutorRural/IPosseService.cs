using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural
{
    public interface IPosseService : IServiceBase<Posse>
    {
        IEnumerable<Posse> PossesPorProdutorRuralEAno(int produtorId, int ano);
    }
}
