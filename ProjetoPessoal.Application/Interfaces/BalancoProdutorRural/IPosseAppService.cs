using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Interfaces.BalancoProdutorRural
{
    public interface IPosseAppService : IAppServiceBase<Posse>
    {
        IEnumerable<Posse> PossesPorProdutorRuralEAno(int produtorId, int ano);
    }
}
