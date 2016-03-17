using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Interfaces.BalancoProdutorRural
{
    public interface IFazendaAppService : IAppServiceBase<Fazenda>
    {
        IEnumerable<Fazenda> FazendasPorProdutor(int produtorId);
    }
}
