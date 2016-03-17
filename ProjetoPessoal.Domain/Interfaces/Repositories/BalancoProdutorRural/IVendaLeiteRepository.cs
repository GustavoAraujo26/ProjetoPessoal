using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural
{
    public interface IVendaLeiteRepository : IRepositoryBase<VendaLeite>
    {
        IEnumerable<VendaLeite> VendasPorProdutorEAno(int produtoId, int ano);
    }
}
