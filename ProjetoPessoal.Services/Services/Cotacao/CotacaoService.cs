using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;

namespace ProjetoPessoal.Services.Services.Cotacao
{
    public class CotacaoService : ServiceBase<Domain.Entities.Cotacao.Cotacao>, ICotacaoService
    {
        private readonly ICotacaoRepository _cotacaoRepository;

        public CotacaoService(ICotacaoRepository cotacaoRepository) : base(cotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorRepresentante(int representanteId)
        {
            return _cotacaoRepository.OfertasPorRepresentante(representanteId);
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorMenorPreco()
        {
            return _cotacaoRepository.OfertasPorMenorPreco();
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorRepresentanteEMenorPreco(int representanteId)
        {
            return _cotacaoRepository.OfertasPorRepresentanteEMenorPreco(representanteId);
        }

        public IEnumerable<Domain.Entities.Cotacao.Cotacao> OfertasPorProdutoEMenorPreco(int produtoId)
        {
            return _cotacaoRepository.OfertasPorProdutoEMenorPreco(produtoId);
        }
    }
}
