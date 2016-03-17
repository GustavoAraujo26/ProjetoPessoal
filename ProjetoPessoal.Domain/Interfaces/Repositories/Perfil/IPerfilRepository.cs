using System;
using System.Collections.Generic;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.Perfil
{
    public interface IPerfilRepository : IRepositoryBase<Entities.Perfil.Perfil>
    {
        IEnumerable<Entities.Perfil.Perfil> ListaPorPerfil();
    }
}
