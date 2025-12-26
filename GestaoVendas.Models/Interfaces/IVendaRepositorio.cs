using GestaoVendas.Models.Dtos;
using GestaoVendas.Models.Entidades;
using System.Threading.Tasks;

namespace GestaoVendas.Models.Interfaces
{
    public interface IVendaRepositorio
    {
        Task Adicionar(Venda venda);

        Task<IEnumerable<VendaRelatorioDto>> ObterRelatorio(DateTime inicio, DateTime fim);
    }
}