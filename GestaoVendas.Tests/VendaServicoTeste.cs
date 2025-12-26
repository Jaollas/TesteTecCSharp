using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Servicos;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GestaoVendas.Tests
{
    public class VendaServicoTeste
    {
        private readonly Mock<IVendaRepositorio> _vendaRepoMock;
        private readonly Mock<IProdutoRepositorio> _produtoRepoMock;
        private readonly VendaServico _vendaServico;

        public VendaServicoTeste()
        {
            _vendaRepoMock = new Mock<IVendaRepositorio>();
            _produtoRepoMock = new Mock<IProdutoRepositorio>();

            _vendaServico = new VendaServico(_vendaRepoMock.Object, _produtoRepoMock.Object);
        }

        [Fact]
        public async void RegistrarVenda_DeveLancarErro_QuandoListaDeItensEstiverVazia()
        {
            // Arrange
            var vendaVazia = new Venda
            {
                ClienteId = 1,
                Itens = new List<ItemVenda>()
            };

            // Act & Assert
            var erro = await Assert.ThrowsAsync<DominioException>(() => _vendaServico.RegistrarVenda(vendaVazia));

            Assert.Equal("A venda deve conter pelo menos um produto.", erro.Message);
        }

        [Fact]
        public async void RegistrarVenda_DeveCalcularValorTotal_Corretamente()
        {
            // Arrange
            var item1 = new ItemVenda { ProdutoId = 1, Quantidade = 2, PrecoUnitario = 50 };
            var item2 = new ItemVenda { ProdutoId = 2, Quantidade = 1, PrecoUnitario = 30 };

            var venda = new Venda
            {
                ClienteId = 1,
                Itens = new List<ItemVenda> { item1, item2 }
            };

            _produtoRepoMock.Setup(r => r.ObterPorId(1)).ReturnsAsync(new Produto { Id = 1, Estoque = 100, Preco = 50 });
            _produtoRepoMock.Setup(r => r.ObterPorId(2)).ReturnsAsync(new Produto { Id = 2, Estoque = 100, Preco = 30 });

            // Act
            await _vendaServico.RegistrarVenda(venda);

            // Assert
            Assert.Equal(130, venda.ValorTotal);

            _vendaRepoMock.Verify(r => r.Adicionar(It.IsAny<Venda>()), Times.Once);
        }
    }
}