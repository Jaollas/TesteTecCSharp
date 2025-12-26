using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Servicos;
using Moq;
using Xunit;

namespace GestaoVendas.Tests
{
    public class ClienteServicoTeste
    {
        private readonly Mock<IClienteRepositorio> _clienteRepoMock;
        private readonly ClienteServico _clienteServico;

        public ClienteServicoTeste()
        {
            _clienteRepoMock = new Mock<IClienteRepositorio>();
            _clienteServico = new ClienteServico(_clienteRepoMock.Object);
        }

        [Fact]
        public async void Salvar_DeveLancarErro_QuandoEmailJaExiste()
        {
            // Arrange
            var clienteNovo = new Cliente { Nome = "Teste", Email = "jaexiste@email.com" };

            _clienteRepoMock.Setup(r => r.ObterPorEmail("jaexiste@email.com"))
                            .ReturnsAsync(new Cliente { Id = 5, Nome = "Outro Cliente", Email = "jaexiste@email.com" });

            // Act & Assert
            var erro = await Assert.ThrowsAsync<DominioException>(() => _clienteServico.Salvar(clienteNovo));

            Assert.Equal("Este e-mail já está cadastrado para outro cliente.", erro.Message);
        }

        [Fact]
        public async void Salvar_DeveSucesso_QuandoEmailForUnico()
        {
            // Arrange
            var clienteNovo = new Cliente { Nome = "Teste", Email = "unico@email.com" };

            _clienteRepoMock.Setup(r => r.ObterPorEmail("unico@email.com"))
                            .ReturnsAsync((Cliente)null);

            // Act
            await _clienteServico.Salvar(clienteNovo);

            // Assert
            _clienteRepoMock.Verify(r => r.Adicionar(It.IsAny<Cliente>()), Times.Once);
        }
    }
}