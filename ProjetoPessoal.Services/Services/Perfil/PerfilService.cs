using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.Perfil;
using ProjetoPessoal.Domain.Interfaces.Services.Perfil;

namespace ProjetoPessoal.Services.Services.Perfil
{
    public class PerfilService : ServiceBase<Domain.Entities.Perfil.Perfil>, IPerfilService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository) : base(perfilRepository)
        {
            this._perfilRepository = perfilRepository;
        }

        public IEnumerable<Domain.Entities.Perfil.Perfil> ListaPorPerfil()
        {
            return _perfilRepository.ListaPorPerfil();
        }
    }
}
