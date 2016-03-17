using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Application.Services.BalancoProdutorRural
{
    public class PosseAppService : AppServiceBase<Posse>, IPosseAppService
    {
        private readonly IPosseService _posseService;

        public PosseAppService(IPosseService posseService) : base(posseService)
        {
            this._posseService = posseService;
        }

        public IEnumerable<Posse> PossesPorProdutorRuralEAno(int produtorId, int ano)
        {
            return _posseService.PossesPorProdutorRuralEAno(produtorId, ano);
        }
    }
}
