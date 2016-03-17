using System;
using System.Collections.Generic;

namespace ProjetoPessoal.Application.Interfaces.Perfil
{
    public interface IPerfilAppService : IAppServiceBase<Domain.Entities.Perfil.Perfil>
    {
        IEnumerable<Domain.Entities.Perfil.Perfil> ListaPorPerfil();
    }
}
