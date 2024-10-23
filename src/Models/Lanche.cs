namespace LanchesIO.src.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required List<Ingrediente> Ingredientes { get; set; }
        public decimal Valor => Ingredientes.Sum(i => i.Valor);

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new ArgumentException("O nome do lanche é obrigatório.");
            }

            if (Ingredientes == null || !Ingredientes.Any())
            {
                throw new ArgumentException("O lanche deve ter pelo menos um ingrediente.");
            }

            foreach (var ingrediente in Ingredientes)
            {
                ingrediente.Validate();
            }
        }
    }
}
