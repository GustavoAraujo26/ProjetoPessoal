using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;

namespace ProjetoPessoal.Application.Services.Cotacao
{
    public class CotacaoAppService : AppServiceBase<Domain.Entities.Cotacao.Cotacao>, ICotacaoAppService
    {
        private readonly ICotacaoService _cotacaoService;

        public CotacaoAppService(ICotacaoService cotacaoService) : base(cotacaoService)
        {
            _cotacaoService = cotacaoService;
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorRepresentante(int representanteId)
        {
            return _cotacaoService.OfertasPorRepresentante(representanteId);
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorMenorPreco()
        {
            return _cotacaoService.OfertasPorMenorPreco();
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorRepresentanteEMenorPreco(int representanteId)
        {
            return _cotacaoService.OfertasPorRepresentanteEMenorPreco(representanteId);
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorProdutoEMenorPreco(int produtoId)
        {
            return _cotacaoService.OfertasPorProdutoEMenorPreco(produtoId);
        }
    }
}
