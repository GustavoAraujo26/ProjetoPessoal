using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Services.BalancoProdutorRural
{
    public class FazendaAppService : AppServiceBase<Fazenda>, IFazendaAppService
    {
        private readonly IFazendaService _fazendaService;

        public FazendaAppService(IFazendaService fazendaService) : base(fazendaService)
        {
            _fazendaService = fazendaService;
        }

        public IEnumerable<Fazenda> FazendasPorProdutor(int produtorId)
        {
            return _fazendaService.FazendasPorProdutor(produtorId);
        }
    }
}
