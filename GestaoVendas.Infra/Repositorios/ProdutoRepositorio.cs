using Dapper;
using GestaoVendas.Infra.Contexto;
using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoVendas.Infra.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DbConexao _db;

        public ProdutoRepositorio(DbConexao db)
        {
            _db = db;
        }

        public async Task<int> Adicionar(Produto produto)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = @"INSERT INTO Produtos (Nome, Descricao, Preco, Estoque) 
                            VALUES (@Nome, @Descricao, @Preco, @Estoque) RETURNING Id";
                return await con.ExecuteScalarAsync<int>(sql, produto);
            }
        }

        public async Task Atualizar(Produto produto)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = @"UPDATE Produtos 
                            SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, Estoque = @Estoque 
                            WHERE Id = @Id";
                await con.ExecuteAsync(sql, produto);
            }
        }

        public async Task Remover(int id)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "DELETE FROM Produtos WHERE Id = @Id";
                await con.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<Produto> ObterPorId(int id)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "SELECT * FROM Produtos WHERE Id = @Id";
                return await con.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Produto>> ListarTodos()
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "SELECT * FROM Produtos ORDER BY Nome";
                return await con.QueryAsync<Produto>(sql);
            }
        }
    }
}