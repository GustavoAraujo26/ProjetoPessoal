using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Services.Services.BalancoProdutorRural
{
    public class PosseService : ServiceBase<Posse>, IPosseService
    {
        private readonly IPosseRepository _posseRepository;

        public PosseService(IPosseRepository posseRepository) : base(posseRepository)
        {
            this._posseRepository = posseRepository;
        }

        public IEnumerable<Posse> PossesPorProdutorRuralEAno(int produtorId, int ano)
        {
            return _posseRepository.PossesPorProdutorRuralEAno(produtorId, ano);
        }
    }
}
