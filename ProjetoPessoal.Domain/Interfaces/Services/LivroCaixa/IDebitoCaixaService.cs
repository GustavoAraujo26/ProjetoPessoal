using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.LivroCaixa;

namespace ProjetoPessoal.Domain.Interfaces.Services.LivroCaixa
{
    public interface IDebitoCaixaService : IServiceBase<DebitoCaixa>
    {
        IEnumerable<DebitoCaixa> ListaPorPerfil(int perfilId);
    }
}
