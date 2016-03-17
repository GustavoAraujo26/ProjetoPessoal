using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.LivroCaixa;
using ProjetoPessoal.Domain.Entities.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Services.LivroCaixa;

namespace ProjetoPessoal.Application.Services.LivroCaixa
{
    public class DebitoCaixaAppService : AppServiceBase<DebitoCaixa>, IDebitoCaixaAppService
    {
        private readonly IDebitoCaixaService _debitoCaixaService;

        public DebitoCaixaAppService(IDebitoCaixaService debitoCaixaService) : base(debitoCaixaService)
        {
            this._debitoCaixaService = debitoCaixaService;
        }

        public IEnumerable<DebitoCaixa> ListaPorPerfil(int perfilId)
        {
            return _debitoCaixaService.ListaPorPerfil(perfilId);
        }
    }
}
