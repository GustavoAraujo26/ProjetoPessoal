using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Services.LivroCaixa;

namespace ProjetoPessoal.Services.Services.LivroCaixa
{
    public class CreditoCaixaService : ServiceBase<CreditoCaixa>, ICreditoCaixaService
    {
        private readonly ICreditoCaixaRepository _creditoCaixaRepository;

        public CreditoCaixaService(ICreditoCaixaRepository creditoCaixaRepository) : base(creditoCaixaRepository)
        {
            this._creditoCaixaRepository = creditoCaixaRepository;
        }

        public IEnumerable<CreditoCaixa> ListaPorPerfil(int perfilId)
        {
            return _creditoCaixaRepository.ListaPorPerfil(perfilId);
        }
    }
}
