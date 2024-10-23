using LanchesIO.src.Models;
using LanchesIO.src.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LanchesIO.Tests
{
    public class PedidoServiceTests
    {
        private readonly PedidoService _pedidoService;

        public PedidoServiceTests()
        {
            _pedidoService = new PedidoService();
        }

        [Fact]
        public async Task AddPedido_ShouldAddPedido()
        {
            // Limpa a lista de pedidos antes de adicionar um novo pedido
            var field = typeof(PedidoService)
                .GetField("pedidos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (field != null)
            {
                field.SetValue(null, new List<Pedido>());
            }

            var pedido = new Pedido
            {
                Lanches = new List<Lanche>
                    {
                        new Lanche
                        {
                            Nome = "Lanche 1",
                            Ingredientes = new List<Ingrediente>
                            {
                                new Ingrediente { Nome = "Ingrediente 1", Valor = 2.5m },
                                new Ingrediente { Nome = "Ingrediente 2", Valor = 3.0m }
                            }
                        }
                    }
            };

            var result = await _pedidoService.AddPedidoAsync(pedido);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Single(result.Lanches);
        }

        [Fact]
        public async Task GetPedidoByIdShouldReturnPedido()
        {
            var pedido = new Pedido
            {
                Lanches = new List<Lanche>
                    {
                        new Lanche
                        {
                            Nome = "Lanche 1",
                            Ingredientes = new List<Ingrediente>
                            {
                                new Ingrediente { Nome = "Ingrediente 1", Valor = 2.5m },
                                new Ingrediente { Nome = "Ingrediente 2", Valor = 3.0m }
                            }
                        }
                    }
            };

            await _pedidoService.AddPedidoAsync(pedido);
            var result = await _pedidoService.GetPedidoByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task DeletePedido_ShouldRemovePedido()
        {
            var pedido = new Pedido
            {
                Lanches = new List<Lanche>
                    {
                        new Lanche
                        {
                            Nome = "Lanche 1",
                            Ingredientes = new List<Ingrediente>
                            {
                                new Ingrediente { Nome = "Ingrediente 1", Valor = 2.5m },
                                new Ingrediente { Nome = "Ingrediente 2", Valor = 3.0m }
                            }
                        }
                    }
            };

            await _pedidoService.AddPedidoAsync(pedido);
            var result = await _pedidoService.DeletePedidoAsync(1);

            Assert.True(result);
        }
    }
}
