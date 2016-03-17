using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.LivroCaixa;

namespace ProjetoPessoal.Application.Interfaces.LivroCaixa
{
    public interface ICreditoCaixaAppService : IAppServiceBase<CreditoCaixa>
    {
        IEnumerable<CreditoCaixa> ListaPorPerfil(int perfilId);
    }
}
