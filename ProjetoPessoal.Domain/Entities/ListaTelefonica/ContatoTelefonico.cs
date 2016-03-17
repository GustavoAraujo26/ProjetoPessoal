using ProjetoPessoal.Domain.Entities.Perfil;

namespace ProjetoPessoal.Domain.Entities.ListaTelefonica
{
    public class ContatoTelefonico
    {
        public int Id { get; set; }

        public int PerfilId { get; set; }

        public Perfil.Perfil Perfil { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string Empresa { get; set; }

        public string Cargo { get; set; }

        public Endereco Endereco { get; set; }

        public Perfil.Contato Contato { get; set; }
    }
}
