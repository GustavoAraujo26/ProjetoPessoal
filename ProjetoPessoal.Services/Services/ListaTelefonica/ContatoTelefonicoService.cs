using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.ListaTelefonica;
using ProjetoPessoal.Domain.Interfaces.Services.ListaTelefonica;

namespace ProjetoPessoal.Services.Services.ListaTelefonica
{
    public class ContatoTelefonicoService : ServiceBase<ContatoTelefonico>, IContatoTelefonicoService
    {
        private readonly IContatoTelefonicoRepository _contatoTelefonicoRepository;

        public ContatoTelefonicoService(IContatoTelefonicoRepository contatoTelefonicoRepository) 
            : base(contatoTelefonicoRepository)
        {
            this._contatoTelefonicoRepository = contatoTelefonicoRepository;
        }

        public IEnumerable<ContatoTelefonico> ContatosPorPerfil(int perfilId)
        {
            return _contatoTelefonicoRepository.ContatosPorPerfil(perfilId);
        }

        public IEnumerable<ContatoTelefonico> ContatosPorApelido(int pefilId, string apelido)
        {
            return _contatoTelefonicoRepository.ContatosPorApelido(pefilId, apelido);
        }
    }
}
