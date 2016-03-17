using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Interfaces.BalancoProdutorRural
{
    public interface IProdutorRuralAppService : IAppServiceBase<ProdutorRural>
    {
        IEnumerable<ProdutorRural> ListaDeFazendas(int produtorId);
    }
}