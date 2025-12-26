using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Servicos;
using Moq;
using Xunit;

namespace GestaoVendas.Tests
{
    public class ProdutoServicoTeste
    {
        private readonly Mock<IProdutoRepositorio> _produtoRepoMock;
        private readonly ProdutoServico _produtoServico;

        public ProdutoServicoTeste()
        {
            _produtoRepoMock = new Mock<IProdutoRepositorio>();
            _produtoServico = new ProdutoServico(_produtoRepoMock.Object);
        }

        [Fact]
        public async void Salvar_DeveLancarErro_QuandoPrecoForZeroOuNegativo()
        {
            // Arrange
            var produtoRuim = new Produto { Nome = "Erro", Preco = 0, Estoque = 10 };

            // Act & Assert
            var erro = await Assert.ThrowsAsync<DominioException>(() => _produtoServico.Salvar(produtoRuim));

            Assert.Equal("O preço deve ser maior que zero.", erro.Message);
        }

        [Fact]
        public async void Salvar_DeveLancarErro_QuandoEstoqueForNegativo()
        {
            // Arrange
            var produtoRuim = new Produto { Nome = "Erro", Preco = 10, Estoque = -5 };

            // Act & Assert
            var erro = await Assert.ThrowsAsync<DominioException>(() => _produtoServico.Salvar(produtoRuim));

            Assert.Equal("O estoque não pode ser negativo.", erro.Message);
        }
    }
}