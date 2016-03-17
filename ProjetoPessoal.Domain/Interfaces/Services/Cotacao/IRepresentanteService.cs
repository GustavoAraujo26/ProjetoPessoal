using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Domain.Interfaces.Services.Cotacao
{
    public interface IRepresentanteService : IServiceBase<Representante>
    {
        IEnumerable<Representante> ListaFornecedoresPorRepresentante(int representanteId);
    }
}
