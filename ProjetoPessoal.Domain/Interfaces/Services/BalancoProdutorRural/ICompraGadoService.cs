using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural
{
    public interface ICompraGadoService : IServiceBase<CompraGado>
    {
        IEnumerable<CompraGado> ComprasPorProdutorEAno(int produtoId, int ano);
    }
}
