using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Agenda;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.Agenda;
using ProjetoPessoal.Domain.Interfaces.Services.Agenda;

namespace ProjetoPessoal.Services.Services.Agenda
{
    public class AtividadeService : ServiceBase<Atividade>, IAtividadeService
    {
        private readonly IAtividadeRepository _atividadeRepository;

        public AtividadeService(IAtividadeRepository atividadeRepository) : base(atividadeRepository)
        {
            this._atividadeRepository = atividadeRepository;
        }

        public IEnumerable<Atividade> AtividadesRealizadas(int perfilId)
        {
            return _atividadeRepository.AtividadesRealizadas(perfilId);
        }

        public IEnumerable<Atividade> AtividadesNaoRealizadas(int perfilId)
        {
            return _atividadeRepository.AtividadesNaoRealizadas(perfilId);
        }
    }
}
