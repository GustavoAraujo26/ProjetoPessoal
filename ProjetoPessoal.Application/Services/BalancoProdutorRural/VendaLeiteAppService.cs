using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Services.BalancoProdutorRural
{
    public class VendaLeiteAppService : AppServiceBase<VendaLeite>, IVendaLeiteAppService
    {
        public readonly IVendaLeiteService _vendaLeiteService;

        public VendaLeiteAppService(IVendaLeiteService vendaLeiteService) : base(vendaLeiteService)
        {
            this._vendaLeiteService = vendaLeiteService;
        }

        public IEnumerable<VendaLeite> VendasPorProdutorEAno(int produtoId, int ano)
        {
            return _vendaLeiteService.VendasPorProdutorEAno(produtoId, ano);
        }
    }
}
