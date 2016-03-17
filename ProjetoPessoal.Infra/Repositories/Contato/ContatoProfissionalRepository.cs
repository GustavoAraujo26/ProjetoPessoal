using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.Contato;
using ProjetoPessoal.Domain.Interfaces.Repositories.Contato;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.Contato
{
    public class ContatoProfissionalRepository : RepositoryBase<ContatoProfissional>, IContatoProfissionalRepository
    {
        public ContatoProfissionalRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<ContatoProfissional> ListaPorEmpresa(string empresa)
        {
            var lista = from x in Db.ContatosProfissionais
                where x.Empresa.Contains(empresa)
                orderby x.Data
                select x;
            return lista.ToList();
        }
    }
}
