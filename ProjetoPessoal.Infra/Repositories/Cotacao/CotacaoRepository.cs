using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.Cotacao
{
    public class CotacaoRepository : RepositoryBase<Domain.Entities.Cotacao.Cotacao>, ICotacaoRepository
    {
        public CotacaoRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorRepresentante(int representanteId)
        {
            var lista = from x in Db.Cotacoes.Include("Representante")
                        where x.RepresentanteId == representanteId
                        orderby x.PrecoSugerido
                        select x;
            return lista.ToList();
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorMenorPreco()
        {
            var lista = from x in Db.Cotacoes
                        orderby x.PrecoSugerido
                        select x;
            return lista.ToList();
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorRepresentanteEMenorPreco(int representanteId)
        {
            var lista = from x in Db.Cotacoes.Include("Representante")
                        where x.RepresentanteId == representanteId
                        orderby x.PrecoSugerido
                        select x;
            return lista.ToList();
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorProdutoEMenorPreco(int produtoId)
        {
            var lista = from x in Db.Cotacoes.Include("Produto")
                        where x.ProdutoId == produtoId
                        orderby x.PrecoSugerido
                        select x;
            return lista.ToList();
        }
    }
}
