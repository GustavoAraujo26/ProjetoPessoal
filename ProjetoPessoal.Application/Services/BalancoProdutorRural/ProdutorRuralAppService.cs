using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Services.BalancoProdutorRural
{
    public class ProdutorRuralAppService : AppServiceBase<ProdutorRural>, IProdutorRuralAppService
    {
        private readonly IProdutorRuralService _produtorRuralService;

        public ProdutorRuralAppService(IProdutorRuralService produtorRuralService) : base(produtorRuralService)
        {
            this._produtorRuralService = produtorRuralService;
        }

        public IEnumerable<ProdutorRural> ListaDeFazendas(int produtorId)
        {
            return _produtorRuralService.ListaDeFazendas(produtorId);
        }
    }
}
