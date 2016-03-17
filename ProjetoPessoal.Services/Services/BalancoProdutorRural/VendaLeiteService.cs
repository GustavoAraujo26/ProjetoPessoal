using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Services.Services.BalancoProdutorRural
{
    public class VendaLeiteService : ServiceBase<VendaLeite>, IVendaLeiteService
    {
        public readonly IVendaLeiteRepository _vendaLeiteRepository;

        public VendaLeiteService(IVendaLeiteRepository vendaLeiteRepository) : base(vendaLeiteRepository)
        {
            this._vendaLeiteRepository = vendaLeiteRepository;
        }

        public IEnumerable<VendaLeite> VendasPorProdutorEAno(int produtoId, int ano)
        {
            return _vendaLeiteRepository.VendasPorProdutorEAno(produtoId, ano);
        }
    }
}
