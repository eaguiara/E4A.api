namespace E4A.Api.Entities
{
    public class Movies
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }
        public string Titulo { get; set; }
        public bool JaAssistiu { get; set; }
        public string ImageUrl { get; set; }
        public string Produtora { get; set; }
        public string Diretora { get; set; }

        internal void Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
            {
                throw new ArgumentNullException("Descrição obrigatória");
            }

            if (string.IsNullOrEmpty(Titulo))
            {
                throw new ArgumentNullException("Titulo obrigatória");
            }

            if (string.IsNullOrEmpty(Diretora))
            {
                throw new ArgumentNullException("Titulo obrigatória");
            }

            if (string.IsNullOrEmpty(Produtora))
            {
                throw new ArgumentNullException("Titulo obrigatória");
            }
        }
    }
}
