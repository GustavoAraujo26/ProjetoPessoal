using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.ListaTelefonica;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;
using ProjetoPessoal.Domain.Interfaces.Services.ListaTelefonica;

namespace ProjetoPessoal.Application.Services.ListaTelefonica
{
    public class ContatoTelefonicoAppService : AppServiceBase<ContatoTelefonico>, IContatoTelefonicoAppService
    {
        private readonly IContatoTelefonicoService _contatoTelefonicoService;

        public ContatoTelefonicoAppService(IContatoTelefonicoService contatoTelefonicoService) 
            : base(contatoTelefonicoService)
        {
            this._contatoTelefonicoService = contatoTelefonicoService;
        }

        public IEnumerable<ContatoTelefonico> ContatosPorPerfil(int perfilId)
        {
            return _contatoTelefonicoService.ContatosPorPerfil(perfilId);
        }

        public IEnumerable<ContatoTelefonico> ContatosPorApelido(int pefilId, string apelido)
        {
            return _contatoTelefonicoService.ContatosPorApelido(pefilId, apelido);
        }
    }
}
