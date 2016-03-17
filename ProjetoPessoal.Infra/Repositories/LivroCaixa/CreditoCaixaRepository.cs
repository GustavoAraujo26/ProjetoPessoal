using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Repositories.LivroCaixa;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.LivroCaixa
{
    public class CreditoCaixaRepository : RepositoryBase<CreditoCaixa>, ICreditoCaixaRepository
    {
        public CreditoCaixaRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<CreditoCaixa> ListaPorPerfil(int perfilId)
        {
            var lista = from x in Db.CreditosCaixa.Include("Perfil")
                where x.PerfilId == perfilId
                orderby x.Data
                select x;
            return lista.ToList();
        }
    }
}
