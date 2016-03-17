using System.Collections.Generic;
using System.Linq;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories.Cotacao
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(Contexto db) : base(db)
        {
        }

        public IEnumerable<Fornecedor> ListaRepresentantesPorFornecedor(int fornecedorId)
        {
            var lista = from x in Db.Fornecedores.Include("Representante")
                        where x.Id == fornecedorId
                        orderby x.RazaoSocial
                        select x;
            return lista.ToList();
        }
    }
}
