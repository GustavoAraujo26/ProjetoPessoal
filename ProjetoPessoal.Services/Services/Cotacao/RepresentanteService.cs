using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;

namespace ProjetoPessoal.Services.Services.Cotacao
{
    public class RepresentanteService : ServiceBase<Representante>, IRepresentanteService
    {
        private readonly IRepresentanteRepository _representanteRepository;

        public RepresentanteService(IRepresentanteRepository representanteRepository) : base(representanteRepository)
        {
            this._representanteRepository = representanteRepository;
        }

        public IEnumerable<Representante> ListaFornecedoresPorRepresentante(int representanteId)
        {
            return _representanteRepository.ListaFornecedoresPorRepresentante(representanteId);
        }
    }
}
