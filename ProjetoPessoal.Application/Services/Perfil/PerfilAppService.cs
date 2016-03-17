using System;
using System.Collections.Generic;
using ProjetoPessoal.Application.Interfaces.Perfil;
using ProjetoPessoal.Domain.Interfaces.Services.Perfil;

namespace ProjetoPessoal.Application.Services.Perfil
{
    public class PerfilAppService : AppServiceBase<Domain.Entities.Perfil.Perfil>, IPerfilAppService
    {
        private readonly IPerfilService _perfilService;

        public PerfilAppService(IPerfilService perfilService) : base(perfilService)
        {
            this._perfilService = perfilService;
        }

        public IEnumerable<Domain.Entities.Perfil.Perfil> ListaPorPerfil()
        {
            return _perfilService.ListaPorPerfil();
        }
    }
}
