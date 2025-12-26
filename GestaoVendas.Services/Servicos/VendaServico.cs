using GestaoVendas.Models.Dtos;
using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoVendas.Services.Servicos
{
    public class VendaServico : IVendaServico
    {
        private readonly IVendaRepositorio _vendaRepo;
        private readonly IProdutoRepositorio _produtoRepo;

        public VendaServico(IVendaRepositorio vendaRepo, IProdutoRepositorio produtoRepo)
        {
            _vendaRepo = vendaRepo;
            _produtoRepo = produtoRepo;
        }

        public async Task RegistrarVenda(Venda venda)
        {
            if (venda.ClienteId <= 0)
                throw new DominioException("Selecione um cliente para a venda.");

            if (venda.Itens == null || !venda.Itens.Any())
                throw new DominioException("A venda deve conter pelo menos um produto.");

            decimal totalCalculado = 0;

            foreach (var item in venda.Itens)
            {
                if (item.Quantidade <= 0)
                    throw new DominioException($"O produto {item.NomeProduto} tem quantidade inválida.");

                var produtoNoBanco = await _produtoRepo.ObterPorId(item.ProdutoId);
                if (produtoNoBanco == null)
                    throw new DominioException($"Produto {item.ProdutoId} não encontrado.");

                if (produtoNoBanco.Estoque < item.Quantidade)
                    throw new DominioException($"Estoque insuficiente para {produtoNoBanco.Nome}. Restam apenas {produtoNoBanco.Estoque}.");

                totalCalculado += item.Quantidade * item.PrecoUnitario;
            }

            venda.ValorTotal = totalCalculado;

            await _vendaRepo.Adicionar(venda);
        }

        public async Task<IEnumerable<VendaRelatorioDto>> GerarRelatorio(DateTime inicio, DateTime fim)
        {
            var fimDia = fim.Date.AddDays(1).AddTicks(-1);
            return await _vendaRepo.ObterRelatorio(inicio, fimDia);
        }
    }
}