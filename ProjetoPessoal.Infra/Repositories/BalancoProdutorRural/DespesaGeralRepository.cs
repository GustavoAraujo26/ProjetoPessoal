using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.BalancoProdutorRural
{
    public class DespesaGeralRepository : RepositoryBase<DespesaGeral>, IDespesaGeralRepository
    {
        public DespesaGeralRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<DespesaGeral> DespesasGeraisPorProdutorEAno(int produtoId, int ano)
        {
            var lista = from x in Db.DespesasGerais.Include("ProdutorRural")
                        where x.ProdutorRuralId == produtoId && x.Data.Year == ano
                        orderby x.Data
                        select x;
            return lista.ToList();
        }
    }
}
