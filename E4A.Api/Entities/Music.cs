namespace E4A.Api.Entities
{
    public class Music
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Nota { get; set; }
        public string Artista { get; set; }

        internal void Validate()
        {
            if (string.IsNullOrEmpty(Artista))
            {
                throw new ArgumentNullException("Descrição obrigatória");
            }

            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentNullException("Nome obrigatória");
            }
        }
    }
}
