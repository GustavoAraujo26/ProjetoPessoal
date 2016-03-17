using System;
using System.Collections.Generic;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao
{
    public interface ICotacaoRepository : IRepositoryBase<Entities.Cotacao.Cotacao>
    {
        IEnumerable<Entities.Cotacao.Cotacao> OfertasPorRepresentante(int representanteId);

        IEnumerable<Entities.Cotacao.Cotacao> OfertasPorMenorPreco();

        IEnumerable<Entities.Cotacao.Cotacao> OfertasPorRepresentanteEMenorPreco(int representanteId);

        IEnumerable<Entities.Cotacao.Cotacao> OfertasPorProdutoEMenorPreco(int produtoId);
    }
}
