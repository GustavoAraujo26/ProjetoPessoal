using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Contato;

namespace ProjetoPessoal.Domain.Interfaces.Repositories.Contato
{
    public interface IContatoProfissionalRepository : IRepositoryBase<ContatoProfissional>
    {
        IEnumerable<ContatoProfissional> ListaPorEmpresa(String empresa);
    }
}
