using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao
{
    public interface IRepresentanteRepository : IRepositoryBase<Representante>
    {
        IEnumerable<Representante> ListaFornecedoresPorRepresentante(int representanteId);
    }
}
