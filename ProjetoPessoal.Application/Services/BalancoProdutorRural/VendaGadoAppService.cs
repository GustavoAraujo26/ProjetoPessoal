using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Services.BalancoProdutorRural
{
    public class VendaGadoAppService : AppServiceBase<VendaGado>, IVendaGadoAppService
    {
        private readonly IVendaGadoService _vendaGadoService;

        public VendaGadoAppService(IVendaGadoService vendaGadoService) : base(vendaGadoService)
        {
            this._vendaGadoService = vendaGadoService;
        }

        public IEnumerable<VendaGado> VendasPorProdutorEAno(int produtoId, int ano)
        {
            return _vendaGadoService.VendasPorProdutorEAno(produtoId, ano);
        }
    }
}
