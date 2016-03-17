using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Interfaces.BalancoProdutorRural
{
    public interface IVendaLeiteAppService : IAppServiceBase<VendaLeite>
    {
        IEnumerable<VendaLeite> VendasPorProdutorEAno(int produtoId, int ano);
    }
}
