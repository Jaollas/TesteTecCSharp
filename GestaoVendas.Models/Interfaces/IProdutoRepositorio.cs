using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoVendas.Models.Entidades;

namespace GestaoVendas.Models.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<int> Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(int id);
        Task<Produto> ObterPorId(int id);
        Task<IEnumerable<Produto>> ListarTodos();
    }
}