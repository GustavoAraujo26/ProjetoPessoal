using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.Cotacao;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;

namespace ProjetoPessoal.Application.Services.Cotacao
{
    public class RepresentanteAppService : AppServiceBase<Representante>, IRepresentanteAppService
    {
        private readonly IRepresentanteService _representanteService;

        public RepresentanteAppService(IRepresentanteService representanteService) : base(representanteService)
        {
            this._representanteService = representanteService;
        }

        public IEnumerable<Representante> ListaFornecedoresPorRepresentante(int representanteId)
        {
            return _representanteService.ListaFornecedoresPorRepresentante(representanteId);
        }
    }
}
