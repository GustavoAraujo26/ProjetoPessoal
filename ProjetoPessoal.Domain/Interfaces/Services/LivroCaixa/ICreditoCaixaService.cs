using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.LivroCaixa;

namespace ProjetoPessoal.Domain.Interfaces.Services.LivroCaixa
{
    public interface ICreditoCaixaService : IServiceBase<CreditoCaixa>
    {
        IEnumerable<CreditoCaixa> ListaPorPerfil(int perfilId);
    }
}
