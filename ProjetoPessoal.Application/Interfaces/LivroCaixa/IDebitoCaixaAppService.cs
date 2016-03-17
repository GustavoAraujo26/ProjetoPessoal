using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.LivroCaixa;

namespace ProjetoPessoal.Application.Interfaces.LivroCaixa
{
    public interface IDebitoCaixaAppService : IAppServiceBase<DebitoCaixa>
    {
        IEnumerable<DebitoCaixa> ListaPorPerfil(int perfilId);
    }
}
