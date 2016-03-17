using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Interfaces.BalancoProdutorRural
{
    public interface IVendaGadoAppService : IAppServiceBase<VendaGado>
    {
        IEnumerable<VendaGado> VendasPorProdutorEAno(int produtoId, int ano);
    }
}
