using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.Cotacao
{
    public class RepresentanteRepository : RepositoryBase<Representante>, IRepresentanteRepository
    {
        public RepresentanteRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<Representante> ListaFornecedoresPorRepresentante(int representanteId)
        {
            var lista = from x in Db.Representantes.Include("Fornecedor")
                where x.Id == representanteId
                orderby x.Nome
                select x;
            return lista.ToList();
        }
    }
}
