using GestaoVendas.Models.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoVendas.Services.Interfaces
{
    public interface IClienteServico
    {
        Task Salvar(Cliente cliente);
        Task Remover(int id);
        Task<IEnumerable<Cliente>> ListarTodos();
    }
}