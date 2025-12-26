using GestaoVendas.Infra.Contexto;
using GestaoVendas.Infra.Repositorios;
using GestaoVendas.Services.Servicos;
using System;
using System.Windows.Forms;

namespace GestaoVendas.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var contexto = new DbConexao();

            var clienteRepo = new ClienteRepositorio(contexto);
            var produtoRepo = new ProdutoRepositorio(contexto);
            var vendaRepo = new VendaRepositorio(contexto);

            var clienteServico = new ClienteServico(clienteRepo);
            var produtoServico = new ProdutoServico(produtoRepo);
            var vendaServico = new VendaServico(vendaRepo, produtoRepo);

            Application.Run(new FrmPrincipal(clienteServico, produtoServico, vendaServico));
        }
    }
}