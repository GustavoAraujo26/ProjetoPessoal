using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.BalancoProdutorRural
{
    public class PosseRepository : RepositoryBase<Posse>, IPosseRepository
    {
        public PosseRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<Posse> PossesPorProdutorRuralEAno(int produtorId, int ano)
        {
            var lista = from x in Db.Posses.Include("ProdutorRural")
                where x.ProdutorRuralId == produtorId && x.DataAquisicao.Year == ano
                orderby x.DataAquisicao
                select x;
            return lista.ToList();
        }
    }
}
