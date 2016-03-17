using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;

namespace ProjetoPessoal.Domain.Interfaces.Services.ListaTelefonica
{
    public interface IContatoTelefonicoService : IServiceBase<ContatoTelefonico>
    {
        IEnumerable<ContatoTelefonico> ContatosPorPerfil(int perfilId);

        IEnumerable<ContatoTelefonico> ContatosPorApelido(int pefilId, String apelido);
    }
}
