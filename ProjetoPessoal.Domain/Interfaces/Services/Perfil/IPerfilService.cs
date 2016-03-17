using System;
using System.Collections.Generic;

namespace ProjetoPessoal.Domain.Interfaces.Services.Perfil
{
    public interface IPerfilService : IServiceBase<Entities.Perfil.Perfil>
    {
        IEnumerable<Entities.Perfil.Perfil> ListaPorPerfil();
    }
}
