using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.BalancoProdutorRural
{
    public class FazendaRepository : RepositoryBase<Fazenda>, IFazendaRepository
    {
        public FazendaRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<Fazenda> FazendasPorProdutor(int produtorId)
        {
            var lista = from x in Db.Fazendas.Include("ProdutorRural")
                where x.ProdutorRuralId == produtorId
                orderby x.Nome
                select x;
            return lista.ToList();
        }
    }
}
