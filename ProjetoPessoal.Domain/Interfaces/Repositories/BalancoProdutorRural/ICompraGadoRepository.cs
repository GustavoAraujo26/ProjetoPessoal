using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural
{
    public interface ICompraGadoRepository : IRepositoryBase<CompraGado>
    {
        IEnumerable<CompraGado> ComprasPorProdutorEAno(int produtoId, int ano);
    }
}
