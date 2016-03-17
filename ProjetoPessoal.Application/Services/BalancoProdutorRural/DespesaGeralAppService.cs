using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Services.BalancoProdutorRural
{
    public class DespesaGeralAppService : AppServiceBase<DespesaGeral>, IDespesaGeralAppService
    {
        private readonly IDespesaGeralService _despesaGeralService;

        public DespesaGeralAppService(IDespesaGeralService despesaGeralService) : base(despesaGeralService)
        {
            this._despesaGeralService = despesaGeralService;
        }

        public IEnumerable<DespesaGeral> DespesasGeraisPorProdutorEAno(int produtoId, int ano)
        {
            return _despesaGeralService.DespesasGeraisPorProdutorEAno(produtoId, ano);
        }
    }
}
