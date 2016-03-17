using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;

namespace ProjetoPessoal.Services.Services.Cotacao
{
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public IEnumerable<Fornecedor> ListaRepresentantesPorFornecedor(int fornecedorId)
        {
            return _fornecedorRepository.ListaRepresentantesPorFornecedor(fornecedorId);
        }
    }
}
