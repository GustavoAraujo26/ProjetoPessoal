using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural
{
    public interface IFazendaRepository : IRepositoryBase<Fazenda>
    {
        IEnumerable<Fazenda> FazendasPorProdutor(int produtorId);
    }
}
