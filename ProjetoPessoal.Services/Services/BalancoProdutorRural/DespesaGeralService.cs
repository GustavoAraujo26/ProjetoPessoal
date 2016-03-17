using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;

namespace ProjetoPessoal.Services.Services.BalancoProdutorRural
{
    public class DespesaGeralService : ServiceBase<DespesaGeral>, IDespesaGeralService
    {
        private readonly IDespesaGeralRepository _despesaGeralRepository;

        public DespesaGeralService(IDespesaGeralRepository despesaGeralRepository) : base(despesaGeralRepository)
        {
            this._despesaGeralRepository = despesaGeralRepository;
        }

        public IEnumerable<DespesaGeral> DespesasGeraisPorProdutorEAno(int produtoId, int ano)
        {
            return _despesaGeralRepository.DespesasGeraisPorProdutorEAno(produtoId, ano);
        }
    }
}
