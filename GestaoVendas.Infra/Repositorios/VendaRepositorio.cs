using Dapper;
using GestaoVendas.Infra.Contexto;
using GestaoVendas.Models.Dtos;
using GestaoVendas.Models.Entidades;
using GestaoVendas.Models.Interfaces;
using System.Threading.Tasks;

namespace GestaoVendas.Infra.Repositorios
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private readonly DbConexao _db;

        public VendaRepositorio(DbConexao db)
        {
            _db = db;
        }

        public async Task Adicionar(Venda venda)
        {
            using (var con = _db.CriarConexao())
            {
                con.Open();
                using (var transacao = con.BeginTransaction())
                {
                    try
                    {
                        var sqlVenda = @"INSERT INTO Vendas (ClienteId, DataVenda, ValorTotal) 
                                         VALUES (@ClienteId, @DataVenda, @ValorTotal) RETURNING Id";

                        var idVendaGerado = await con.ExecuteScalarAsync<int>(sqlVenda, venda, transaction: transacao);

                        foreach (var item in venda.Itens)
                        {
                            item.VendaId = idVendaGerado;

                            var sqlItem = @"INSERT INTO ItensVenda (VendaId, ProdutoId, Quantidade, PrecoUnitario) 
                                            VALUES (@VendaId, @ProdutoId, @Quantidade, @PrecoUnitario)";
                            await con.ExecuteAsync(sqlItem, item, transaction: transacao);

                            var sqlEstoque = "UPDATE Produtos SET Estoque = Estoque - @Quantidade WHERE Id = @ProdutoId";
                            await con.ExecuteAsync(sqlEstoque, new { item.Quantidade, item.ProdutoId }, transaction: transacao);
                        }

                        transacao.Commit();
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<IEnumerable<VendaRelatorioDto>> ObterRelatorio(DateTime inicio, DateTime fim)
        {
            using (var con = _db.CriarConexao())
            {
                var sql = @"
            SELECT v.Id, c.Nome AS NomeCliente, v.DataVenda, v.ValorTotal 
            FROM Vendas v
            INNER JOIN Clientes c ON v.ClienteId = c.Id
            WHERE v.DataVenda >= @Inicio AND v.DataVenda <= @Fim
            ORDER BY c.Nome ASC, v.DataVenda DESC";

                return await con.QueryAsync<VendaRelatorioDto>(sql, new { Inicio = inicio, Fim = fim });
            }
        }
    }
}