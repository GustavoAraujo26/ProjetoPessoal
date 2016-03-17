using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.BalancoProdutorRural
{
    public class ProdutorRuralRepository : RepositoryBase<ProdutorRural>, IProdutorRuralRepository
    {
        public ProdutorRuralRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<ProdutorRural> ListaDeFazendas(int produtorId)
        {
            var lista = from x in Db.ProdutoresRurais
                where x.Fazendas.Any(z => z.ProdutorRuralId == produtorId)
                orderby x.Nome
                select x;
            return lista.ToList();
        }
    }
}
