using System;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Contato;

namespace ProjetoPessoal.Domain.Interfaces.Services.Contato
{
    public interface IContatoProfissionalService : IServiceBase<ContatoProfissional>
    {
        IEnumerable<ContatoProfissional> ListaPorEmpresa(String empresa);
    }
}
