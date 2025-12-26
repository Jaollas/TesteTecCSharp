using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoVendas.Models.Entidades;

namespace GestaoVendas.Models.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<int> Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(int id);
        Task<Cliente> ObterPorId(int id);
        Task<Cliente> ObterPorEmail(string email);
        Task<IEnumerable<Cliente>> ListarTodos();
    }
}