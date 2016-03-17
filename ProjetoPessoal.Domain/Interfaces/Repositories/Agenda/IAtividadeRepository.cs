using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Agenda;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.Agenda
{
    public interface IAtividadeRepository : IRepositoryBase<Atividade>
    {
        IEnumerable<Atividade> AtividadesRealizadas(int perfilId);

        IEnumerable<Atividade> AtividadesNaoRealizadas(int perfilId);
    }
}
