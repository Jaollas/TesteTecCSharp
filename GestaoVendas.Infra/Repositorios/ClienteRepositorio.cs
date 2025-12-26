using Dapper;
using GestaoVendas.Infra.Contexto;
using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoVendas.Infra.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DbConexao _db;

        public ClienteRepositorio(DbConexao db)
        {
            _db = db;
        }

        public async Task<int> Adicionar(Cliente cliente)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "INSERT INTO Clientes (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone) RETURNING Id";
                return await con.ExecuteScalarAsync<int>(sql, cliente);
            }
        }

        public async Task Atualizar(Cliente cliente)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "UPDATE Clientes SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE Id = @Id";
                await con.ExecuteAsync(sql, cliente);
            }
        }

        public async Task Remover(int id)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "DELETE FROM Clientes WHERE Id = @Id";
                await con.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<Cliente> ObterPorId(int id)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "SELECT * FROM Clientes WHERE Id = @Id";
                return await con.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id });
            }
        }

        public async Task<Cliente> ObterPorEmail(string email)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "SELECT * FROM Clientes WHERE Email = @Email";
                return await con.QueryFirstOrDefaultAsync<Cliente>(sql, new { Email = email });
            }
        }

        public async Task<IEnumerable<Cliente>> ListarTodos()
        {
            using (var con = _db.CriarConexao())
            {
                var sql = "SELECT * FROM Clientes ORDER BY Nome";
                return await con.QueryAsync<Cliente>(sql);
            }
        }
    }
}