using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Services.Services.BalancoProdutorRural
{
    public class VendaGadoService : ServiceBase<VendaGado>, IVendaGadoService
    {
        private readonly IVendaGadoRepository _vendaGadoRepository;

        public VendaGadoService(IVendaGadoRepository vendaGadoRepository) : base(vendaGadoRepository)
        {
            this._vendaGadoRepository = vendaGadoRepository;
        }

        public IEnumerable<VendaGado> VendasPorProdutorEAno(int produtoId, int ano)
        {
            return _vendaGadoRepository.VendasPorProdutorEAno(produtoId, ano);
        }
    }
}
