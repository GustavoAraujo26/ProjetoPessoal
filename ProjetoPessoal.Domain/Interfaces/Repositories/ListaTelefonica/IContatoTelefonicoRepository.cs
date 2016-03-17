using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.ListaTelefonica
{
    public interface IContatoTelefonicoRepository : IRepositoryBase<ContatoTelefonico>
    {
        IEnumerable<ContatoTelefonico> ContatosPorPerfil(int perfilId);

        IEnumerable<ContatoTelefonico> ContatosPorApelido(int pefilId, String apelido);
    }
}
