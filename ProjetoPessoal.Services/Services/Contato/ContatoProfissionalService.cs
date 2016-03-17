using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Contato;
using ProjetoPessoal.Domain.Interfaces.Repositories.Contato;
using ProjetoPessoal.Domain.Interfaces.Services.Contato;

namespace ProjetoPessoal.Services.Services.Contato
{
    public class ContatoProfissionalService : ServiceBase<ContatoProfissional>, IContatoProfissionalService
    {
        private readonly IContatoProfissionalRepository _contatoProfissionalRepository;

        public ContatoProfissionalService(IContatoProfissionalRepository contatoProfissionalRepository) 
            : base(contatoProfissionalRepository)
        {
            _contatoProfissionalRepository = contatoProfissionalRepository;
        }

        public IEnumerable<ContatoProfissional> ListaPorEmpresa(string empresa)
        {
            return _contatoProfissionalRepository.ListaPorEmpresa(empresa);
        }
    }
}
