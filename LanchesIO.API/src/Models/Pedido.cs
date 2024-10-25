namespace LanchesIO.API.src.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<Lanche> Lanches { get; set; } = new List<Lanche>();
        public decimal ValorTotal { get; set; }
    }
}
