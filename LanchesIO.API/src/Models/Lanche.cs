namespace LanchesIO.API.src.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

        public decimal Valor => Ingredientes.Sum(i => i.Valor);
    }
}
