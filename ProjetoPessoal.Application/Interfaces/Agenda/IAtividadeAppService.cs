using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Agenda;
using ProjetoPessoal.Domain.Interfaces.Services;

namespace ProjetoPessoal.Application.Interfaces.Agenda
{
    public interface IAtividadeAppService : IServiceBase<Atividade>
    {
        IEnumerable<Atividade> AtividadesRealizadas(int perfilId);

        IEnumerable<Atividade> AtividadesNaoRealizadas(int perfilId);
    }
}
