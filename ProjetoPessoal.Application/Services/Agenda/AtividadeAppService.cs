using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.Agenda;
using ProjetoPessoal.Domain.Entities.Agenda;
using ProjetoPessoal.Domain.Interfaces.Services.Agenda;

namespace ProjetoPessoal.Application.Services.Agenda
{
    public class AtividadeAppService : AppServiceBase<Atividade>, IAtividadeAppService
    {
        private readonly IAtividadeService _atividadeService;

        public AtividadeAppService(IAtividadeService atividadeService) : base(atividadeService)
        {
            this._atividadeService = atividadeService;
        }

        public IEnumerable<Atividade> AtividadesRealizadas(int perfilId)
        {
            return _atividadeService.AtividadesRealizadas(perfilId);
        }

        public IEnumerable<Atividade> AtividadesNaoRealizadas(int perfilId)
        {
            return _atividadeService.AtividadesNaoRealizadas(perfilId);
        }
    }
}
