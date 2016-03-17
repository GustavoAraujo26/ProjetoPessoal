using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Application.Interfaces.Cotacao
{
    public interface IRepresentanteAppService : IAppServiceBase<Representante>
    {
        IEnumerable<Representante> ListaFornecedoresPorRepresentante(int representanteId);
    }
}
