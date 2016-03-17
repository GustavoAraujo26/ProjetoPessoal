using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Services.Services.BalancoProdutorRural
{
    public class CompraGadoService : ServiceBase<CompraGado>, ICompraGadoService
    {
        private readonly ICompraGadoRepository _compraGadoRepository;

        public CompraGadoService(ICompraGadoRepository compraGadoRepository) : base(compraGadoRepository)
        {
            this._compraGadoRepository = compraGadoRepository;
        }

        public IEnumerable<CompraGado> ComprasPorProdutorEAno(int produtoId, int ano)
        {
            return _compraGadoRepository.ComprasPorProdutorEAno(produtoId, ano);
        }
    }
}
