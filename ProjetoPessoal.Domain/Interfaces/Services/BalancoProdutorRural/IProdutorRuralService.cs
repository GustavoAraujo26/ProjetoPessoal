using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural
{
    public interface IProdutorRuralService : IServiceBase<ProdutorRural>
    {
        IEnumerable<ProdutorRural> ListaDeFazendas(int produtorId);
    }
}