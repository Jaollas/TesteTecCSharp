using GestaoVendas.Models.Dtos;
using GestaoVendas.Models.Entidades;
using System.Threading.Tasks;

namespace GestaoVendas.Services.Interfaces
{
    public interface IVendaServico
    {
        Task RegistrarVenda(Venda venda);
        Task<IEnumerable<VendaRelatorioDto>> GerarRelatorio(DateTime inicio, DateTime fim);
    }
}