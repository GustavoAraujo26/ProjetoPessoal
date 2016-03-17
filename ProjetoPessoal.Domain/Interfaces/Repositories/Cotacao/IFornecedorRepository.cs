using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao
{
    public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
    {
        IEnumerable<Fornecedor> ListaRepresentantesPorFornecedor(int fornecedorId);
    }
}
