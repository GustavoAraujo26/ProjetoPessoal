using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.Contato;
using ProjetoPessoal.Domain.Entities.Contato;
using ProjetoPessoal.Domain.Interfaces.Services.Contato;

namespace ProjetoPessoal.Application.Services.Contato
{
    public class ContatoProfissionalAppService : AppServiceBase<ContatoProfissional>, IContatoProfissionalAppService
    {
        private readonly IContatoProfissionalService _contatoProfissionalService;

        public ContatoProfissionalAppService(IContatoProfissionalService contatoProfissionalService) 
            : base(contatoProfissionalService)
        {
            _contatoProfissionalService = contatoProfissionalService;
        }

        public IEnumerable<ContatoProfissional> ListaPorEmpresa(string empresa)
        {
            return _contatoProfissionalService.ListaPorEmpresa(empresa);
        }
    }
}
