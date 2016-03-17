using System;
using System.Collections.Generic;

namespace ProjetoPessoal.Application.Interfaces.Cotacao
{
    public interface ICotacaoAppService : IAppServiceBase<Domain.Entities.Cotacao.Cotacao>
    {
        IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorRepresentante(int representanteId);

        IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorMenorPreco();

        IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorRepresentanteEMenorPreco(int representanteId);

        IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorProdutoEMenorPreco(int produtoId);
    }
}
