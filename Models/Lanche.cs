namespace LanchesIO.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required List<Ingrediente> Ingredientes { get; set; }
        public decimal Valor => Ingredientes?.Sum(i => i.Valor) ?? 0;
    }
}
