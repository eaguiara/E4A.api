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

            if (string.IsNullOrEmpty(Titulo))
            {
                throw new ArgumentNullException("Titulo é obrigatório");
            }

            if (string.IsNullOrEmpty(Diretora))
            {
                throw new ArgumentNullException("Diretora é obrigatória");
            }
            if (string.IsNullOrEmpty(Produtora))
            {
                throw new ArgumentNullException("Produtora é obrigatória");
            }
        }
    }
}
