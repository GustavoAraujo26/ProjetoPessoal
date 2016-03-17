using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Services.Services.BalancoProdutorRural
{
    public class FazendaService : ServiceBase<Fazenda>, IFazendaService
    {
        private readonly IFazendaRepository _fazendaRepository;

        public FazendaService(IFazendaRepository fazendaRepository) : base(fazendaRepository)
        {
            _fazendaRepository = fazendaRepository;
        }

        public IEnumerable<Fazenda> FazendasPorProdutor(int produtorId)
        {
            return _fazendaRepository.FazendasPorProdutor(produtorId);
        }
    }
}
