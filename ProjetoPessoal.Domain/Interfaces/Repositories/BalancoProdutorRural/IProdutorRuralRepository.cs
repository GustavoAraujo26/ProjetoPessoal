using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural
{
    public interface IProdutorRuralRepository : IRepositoryBase<ProdutorRural>
    {
        IEnumerable<ProdutorRural> ListaDeFazendas(int produtorId);
    }
}