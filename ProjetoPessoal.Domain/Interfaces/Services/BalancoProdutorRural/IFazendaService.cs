using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural
{
    public interface IFazendaService : IServiceBase<Fazenda>
    {
        IEnumerable<Fazenda> FazendasPorProdutor(int produtorId);
    }
}
