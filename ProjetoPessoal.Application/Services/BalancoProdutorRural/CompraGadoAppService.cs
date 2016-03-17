using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Services.BalancoProdutorRural
{
    public class CompraGadoAppService : AppServiceBase<CompraGado>, ICompraGadoAppService
    {
        private readonly ICompraGadoService _compraGadoService;

        public CompraGadoAppService(ICompraGadoService compraGadoService) : base(compraGadoService)
        {
            this._compraGadoService = compraGadoService;
        }

        public IEnumerable<CompraGado> ComprasPorProdutorEAno(int produtoId, int ano)
        {
            return _compraGadoService.ComprasPorProdutorEAno(produtoId, ano);
        }
    }
}
