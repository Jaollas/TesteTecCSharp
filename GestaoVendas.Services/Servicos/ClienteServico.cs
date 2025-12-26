using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoVendas.Services.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepo;

        public ClienteServico(IClienteRepositorio clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public async Task Salvar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nome))
                throw new DominioException("O nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new DominioException("O e-mail é obrigatório.");

            var clienteExistente = await _clienteRepo.ObterPorEmail(cliente.Email);
            if (clienteExistente != null && clienteExistente.Id != cliente.Id)
            {
                throw new DominioException("Este e-mail já está cadastrado para outro cliente.");
            }

            if (cliente.Id == 0)
                await _clienteRepo.Adicionar(cliente);
            else
                await _clienteRepo.Atualizar(cliente);
        }

        public async Task Remover(int id)
        {
            await _clienteRepo.Remover(id);
        }

        public async Task<IEnumerable<Cliente>> ListarTodos()
        {
            return await _clienteRepo.ListarTodos();
        }
    }
}