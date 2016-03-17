using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Interfaces.Repositories.Perfil;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.Perfil
{
    public class PerfilRepository : RepositoryBase<Domain.Entities.Perfil.Perfil>, IPerfilRepository
    {
        public PerfilRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<Domain.Entities.Perfil.Perfil> ListaPorPerfil()
        {
            var lista = from x in Db.Perfis
                orderby x.NomeCompleto
                select x;
            return lista.ToList();
        }
    }
}
