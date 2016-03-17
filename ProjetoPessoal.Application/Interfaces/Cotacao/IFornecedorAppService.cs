using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Application.Interfaces.Cotacao
{
    public interface IFornecedorAppService : IAppServiceBase<Fornecedor>
    {
        IEnumerable<Fornecedor> ListaRepresentantesPorFornecedor(int fornecedorId);
    }
}
