using Npgsql;
using System.Data;

namespace GestaoVendas.Infra.Contexto
{
    public class DbConexao
    {
        private readonly string _stringConexao = "Server=localhost;Port=5432;Database=GestaoVendasDB;User Id=postgres;Password=admin;";

        public IDbConnection CriarConexao()
        {
            return new NpgsqlConnection(_stringConexao);
        }
    }
}