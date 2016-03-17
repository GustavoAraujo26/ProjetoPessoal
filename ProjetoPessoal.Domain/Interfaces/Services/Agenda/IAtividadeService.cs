using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Agenda;

namespace ProjetoPessoal.Domain.Interfaces.Services.Agenda
{
    public interface IAtividadeService : IServiceBase<Atividade>
    {
        IEnumerable<Atividade> AtividadesRealizadas(int perfilId);

        IEnumerable<Atividade> AtividadesNaoRealizadas(int perfilId);
    }
}
