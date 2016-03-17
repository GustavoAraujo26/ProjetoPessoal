using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.LivroCaixa;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.LivroCaixa
{
    public interface ICreditoCaixaRepository : IRepositoryBase<CreditoCaixa>
    {
        IEnumerable<CreditoCaixa> ListaPorPerfil(int perfilId);
    }
}
