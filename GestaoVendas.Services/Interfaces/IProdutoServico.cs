using GestaoVendas.Models.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoVendas.Services.Interfaces
{
    public interface IProdutoServico
    {
        Task Salvar(Produto produto);
        Task Remover(int id);
        Task<IEnumerable<Produto>> ListarTodos();
        Task<Produto> ObterPorId(int id);
    }
}