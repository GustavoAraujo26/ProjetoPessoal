using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Services.BalancoProdutorRural
{
    public class ReceitaGeralAppService : AppServiceBase<ReceitaGeral>, IReceitaGeralAppService
    {
        private readonly IReceitaGeralService _receitaGeralService;

        public ReceitaGeralAppService(IReceitaGeralService receitaGeralService) : base(receitaGeralService)
        {
            this._receitaGeralService = receitaGeralService;
        }

        public IEnumerable<ReceitaGeral> ReceitasGeraisPorProdutorEAno(int produtoId, int ano)
        {
            return _receitaGeralService.ReceitasGeraisPorProdutorEAno(produtoId, ano);
        }
    }
}
