using System;
using System.Collections.Generic;

namespace ProjetoPessoal.Domain.Interfaces.Services.Cotacao
{
    public interface ICotacaoService : IServiceBase<Entities.Cotacao.Cotacao>
    {
        IEnumerable<Entities.Cotacao.Cotacao> OfertasPorRepresentante(int representanteId);

        IEnumerable<Entities.Cotacao.Cotacao> OfertasPorMenorPreco();

        IEnumerable<Entities.Cotacao.Cotacao> OfertasPorRepresentanteEMenorPreco(int representanteId);

        IEnumerable<Entities.Cotacao.Cotacao> OfertasPorProdutoEMenorPreco(int produtoId);
    }
}
