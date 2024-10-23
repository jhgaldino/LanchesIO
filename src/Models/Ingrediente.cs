namespace LanchesIO.src.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal Valor { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new ArgumentException("O nome do ingrediente é obrigatório.");
            }

            if (Valor <= 0)
            {
                throw new ArgumentException("O valor do ingrediente deve ser positivo.");
            }
        }
    }
}
