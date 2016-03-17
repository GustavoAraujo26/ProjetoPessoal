using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Services.Services.BalancoProdutorRural
{
    public class ReceitaGeralService : ServiceBase<ReceitaGeral>, IReceitaGeralService
    {
        private readonly IReceitaGeralRepository _receitaGeralRepository;

        public ReceitaGeralService(IReceitaGeralRepository receitaGeralRepository) : base(receitaGeralRepository)
        {
            this._receitaGeralRepository = receitaGeralRepository;
        }

        public IEnumerable<ReceitaGeral> ReceitasGeraisPorProdutorEAno(int produtoId, int ano)
        {
            return _receitaGeralRepository.ReceitasGeraisPorProdutorEAno(produtoId, ano);
        }
    }
}
