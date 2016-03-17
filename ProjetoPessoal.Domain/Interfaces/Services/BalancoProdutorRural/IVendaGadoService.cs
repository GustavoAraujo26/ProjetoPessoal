using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural
{
    public interface IVendaGadoService : IServiceBase<VendaGado>
    {
        IEnumerable<VendaGado> VendasPorProdutorEAno(int produtoId, int ano);
    }
}
