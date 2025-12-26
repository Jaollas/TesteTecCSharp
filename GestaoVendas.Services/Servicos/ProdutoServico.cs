using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoVendas.Services.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepo;

        public ProdutoServico(IProdutoRepositorio produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }

        public async Task Salvar(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new DominioException("O nome do produto é obrigatório.");

            if (produto.Preco <= 0)
                throw new DominioException("O preço deve ser maior que zero.");

            if (produto.Estoque < 0)
                throw new DominioException("O estoque não pode ser negativo.");

            if (produto.Id == 0)
                await _produtoRepo.Adicionar(produto);
            else
                await _produtoRepo.Atualizar(produto);
        }

        public async Task Remover(int id)
        {
            await _produtoRepo.Remover(id);
        }

        public async Task<IEnumerable<Produto>> ListarTodos()
        {
            return await _produtoRepo.ListarTodos();
        }

        public async Task<Produto> ObterPorId(int id)
        {
            return await _produtoRepo.ObterPorId(id);
        }
    }
}