using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E4A.Api.Entities
{
    public class Book
    {
        public int Id { get; set; } 
        public int? Nota { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Autora { get; set; }
        public string Editora { get; set; }
        public string? ImageUrl { get; set; }
        public bool Visto { get; set; }

        internal void Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
            {
                throw new ArgumentNullException("Descrição obrigatória");
            }

            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentNullException("Nome obrigatória");
            }

            if (string.IsNullOrEmpty(Autora))
            {
                throw new ArgumentNullException("Nome obrigatória");
            }

            if (string.IsNullOrEmpty(Editora))
            {
                throw new ArgumentNullException("Nome obrigatória");
            }

        }
    }
}
