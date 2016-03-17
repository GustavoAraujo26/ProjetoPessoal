using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural
{
    public interface IVendaGadoRepository : IRepositoryBase<VendaGado>
    {
        IEnumerable<VendaGado> VendasPorProdutorEAno(int produtoId, int ano);
    }
}
