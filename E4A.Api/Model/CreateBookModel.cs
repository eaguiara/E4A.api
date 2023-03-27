namespace E4A.Api.Model
{
    public class CreateBookModel
    {
        public string Nome { get; set; }
        public int? Nota { get; set; }
        public string Descricao { get; set; }
        public string Autora { get; set; }
        public string Editora { get; set; }
        public string? ImageUrl { get; set; }
        public bool Visto { get; set; }
    }
}
