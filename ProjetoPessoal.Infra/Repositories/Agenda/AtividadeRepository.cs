using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.Agenda;
using ProjetoPessoal.Domain.Interfaces.Repositories.Agenda;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.Agenda
{
    public class AtividadeRepository : RepositoryBase<Atividade>, IAtividadeRepository
    {
        public AtividadeRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<Atividade> AtividadesRealizadas(int perfilId)
        {
            var lista = from x in Db.Atividades
                        where x.PerfilId == perfilId && x.Realizado == true
                        orderby x.DataInicio
                        select x;
            return lista.ToList();
        }

        public IEnumerable<Atividade> AtividadesNaoRealizadas(int perfilId)
        {
            var lista = from x in Db.Atividades
                        where x.PerfilId == perfilId && x.Realizado == false
                        orderby x.DataInicio
                        select x;
            return lista.ToList();
        }
    }
}
