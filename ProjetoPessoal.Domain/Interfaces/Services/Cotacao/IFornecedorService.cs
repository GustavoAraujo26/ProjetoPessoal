using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Domain.Interfaces.Services.Cotacao
{
    public interface IFornecedorService : IServiceBase<Fornecedor>
    {
        IEnumerable<Fornecedor> ListaRepresentantesPorFornecedor(int fornecedorId);
    }
}
