using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural
{
    public interface IVendaLeiteService : IServiceBase<VendaLeite>
    {
        IEnumerable<VendaLeite> VendasPorProdutorEAno(int produtoId, int ano);
    }
}
