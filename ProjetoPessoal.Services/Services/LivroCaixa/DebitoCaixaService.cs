using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Services.LivroCaixa;

namespace ProjetoPessoal.Services.Services.LivroCaixa
{
    public class DebitoCaixaService : ServiceBase<DebitoCaixa>, IDebitoCaixaService
    {
        private readonly IDebitoCaixaRepository _debitoCaixaRepository;

        public DebitoCaixaService(IDebitoCaixaRepository debitoCaixaRepository) : base(debitoCaixaRepository)
        {
            this._debitoCaixaRepository = debitoCaixaRepository;
        }

        public IEnumerable<DebitoCaixa> ListaPorPerfil(int perfilId)
        {
            return _debitoCaixaRepository.ListaPorPerfil(perfilId);
        }
    }
}
