using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;
using ProjetoPessoal.Domain.Interfaces.Repositories.ListaTelefonica;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.ListaTelefonica
{
    public class ContatoTelefonicoRepository : RepositoryBase<ContatoTelefonico>, IContatoTelefonicoRepository
    {
        public ContatoTelefonicoRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<ContatoTelefonico> ContatosPorPerfil(int perfilId)
        {
            var lista = from x in Db.ContatosTelefonicos.Include("Perfil")
                where x.PerfilId == perfilId
                orderby x.Nome
                select x;
            return lista.ToList();
        }

        public IEnumerable<ContatoTelefonico> ContatosPorApelido(int pefilId, string apelido)
        {
            var lista = from x in Db.ContatosTelefonicos.Include("Perfil")
                        where x.PerfilId == pefilId && x.Apelido.Contains(apelido)
                        orderby x.Nome
                        select x;
            return lista.ToList();
        }
    }
}
