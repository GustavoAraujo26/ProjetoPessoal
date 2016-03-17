using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Repositories.LivroCaixa;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.LivroCaixa
{
    public class DebitoCaixaRepository : RepositoryBase<DebitoCaixa>, IDebitoCaixaRepository
    {
        public DebitoCaixaRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<DebitoCaixa> ListaPorPerfil(int perfilId)
        {
            var lista = from x in Db.DebitosCaixa.Include("Perfil")
                where x.PerfilId == perfilId
                orderby x.Data
                select x;
            return lista.ToList();
        }
    }
}
