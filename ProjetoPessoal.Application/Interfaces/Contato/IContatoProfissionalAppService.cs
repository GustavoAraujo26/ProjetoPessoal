using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Contato;

namespace ProjetoPessoal.Application.Interfaces.Contato
{
    public interface IContatoProfissionalAppService : IAppServiceBase<ContatoProfissional>
    {
        IEnumerable<ContatoProfissional> ListaPorEmpresa(String empresa);
    }
}
