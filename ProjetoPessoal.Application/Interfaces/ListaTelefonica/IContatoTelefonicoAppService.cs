using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;

namespace ProjetoPessoal.Application.Interfaces.ListaTelefonica
{
    public interface IContatoTelefonicoAppService : IAppServiceBase<ContatoTelefonico>
    {
        IEnumerable<ContatoTelefonico> ContatosPorPerfil(int perfilId);

        IEnumerable<ContatoTelefonico> ContatosPorApelido(int pefilId, String apelido);
    }
}
