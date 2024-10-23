namespace LanchesIO.src.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public required List<Lanche> Lanches { get; set; }
        public decimal ValorTotal => CalcularValorTotal();

        private decimal CalcularValorTotal()
        {
            decimal total = Lanches?.Sum(lanche => lanche.Valor) ?? 0;
            int quantidadeLanches = Lanches?.Count ?? 0;

            if (quantidadeLanches >= 5)
            {
                total *= 0.90m; // 10% de desconto
            }
            else if (quantidadeLanches == 3)
            {
                total *= 0.95m; // 5% de desconto
            }
            else if (quantidadeLanches == 2)
            {
                total *= 0.97m; // 3% de desconto
            }

            return total;
        }

        public void Validate()
        {
            if (Lanches == null || !Lanches.Any())
            {
                throw new ArgumentException("O pedido deve ter pelo menos um lanche.");
            }

            foreach (var lanche in Lanches)
            {
                lanche.Validate();
            }
        }
    }
}
