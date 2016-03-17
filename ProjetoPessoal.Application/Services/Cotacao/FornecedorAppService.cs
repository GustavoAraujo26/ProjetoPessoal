using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.Cotacao;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;

namespace ProjetoPessoal.Application.Services.Cotacao
{
    public class FornecedorAppService : AppServiceBase<Fornecedor>, IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorAppService(IFornecedorService fornecedorService) : base(fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        public IEnumerable<Fornecedor> ListaRepresentantesPorFornecedor(int fornecedorId)
        {
            return _fornecedorService.ListaRepresentantesPorFornecedor(fornecedorId);
        }
    }
}
