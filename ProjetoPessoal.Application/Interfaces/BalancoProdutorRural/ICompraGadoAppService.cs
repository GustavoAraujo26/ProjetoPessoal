using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Interfaces.BalancoProdutorRural
{
    public interface ICompraGadoAppService : IAppServiceBase<CompraGado>
    {
        IEnumerable<CompraGado> ComprasPorProdutorEAno(int produtoId, int ano);
    }
}
