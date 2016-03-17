using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.LivroCaixa;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.LivroCaixa
{
    public interface IDebitoCaixaRepository : IRepositoryBase<DebitoCaixa>
    {
        IEnumerable<DebitoCaixa> ListaPorPerfil(int perfilId);
    }
}
