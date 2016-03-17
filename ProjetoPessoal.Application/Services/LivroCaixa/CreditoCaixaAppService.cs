using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.LivroCaixa;
using ProjetoPessoal.Domain.Entities.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Services.LivroCaixa;

namespace ProjetoPessoal.Application.Services.LivroCaixa
{
    public class CreditoCaixaAppService : AppServiceBase<CreditoCaixa>, ICreditoCaixaAppService
    {
        private readonly ICreditoCaixaService _creditoCaixaService;

        public CreditoCaixaAppService(ICreditoCaixaService creditoCaixaService) : base(creditoCaixaService)
        {
            this._creditoCaixaService = creditoCaixaService;
        }

        public IEnumerable<CreditoCaixa> ListaPorPerfil(int perfilId)
        {
            return _creditoCaixaService.ListaPorPerfil(perfilId);
        }
    }
}
