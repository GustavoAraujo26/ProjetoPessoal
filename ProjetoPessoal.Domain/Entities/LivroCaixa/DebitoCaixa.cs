using System;

namespace ProjetoPessoal.Domain.Entities.LivroCaixa
{
    public class DebitoCaixa
    {
        public int Id { get; set; }

        public int PerfilId { get; set; }

        public Perfil.Perfil Perfil { get; set; }

        public DateTime Data { get; set; }

        public string NumeroDocumento { get; set; }

        public string Tipo { get; set; }

        public string Titulo { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }
    }
}
