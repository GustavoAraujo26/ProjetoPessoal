using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Services.Services.BalancoProdutorRural
{
    public class ProdutorRuralService : ServiceBase<ProdutorRural>, IProdutorRuralService
    {
        private readonly IProdutorRuralRepository _produtorRuralRepository;

        public ProdutorRuralService(IProdutorRuralRepository produtorRuralRepository) : base(produtorRuralRepository)
        {
            this._produtorRuralRepository = produtorRuralRepository;
        }

        public IEnumerable<ProdutorRural> ListaDeFazendas(int produtorId)
        {
            return _produtorRuralRepository.ListaDeFazendas(produtorId);
        }
    }
}
