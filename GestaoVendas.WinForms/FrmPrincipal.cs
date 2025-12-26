using GestaoVendas.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GestaoVendas.WinForms
{
    public partial class FrmPrincipal : Form
    {
        private readonly IClienteServico _clienteServico;
        private readonly IProdutoServico _produtoServico;
        private readonly IVendaServico _vendaServico;

        public FrmPrincipal(IClienteServico clienteServico, IProdutoServico produtoServico, IVendaServico vendaServico)
        {
            InitializeComponent();

            _clienteServico = clienteServico;
            _produtoServico = produtoServico;
            _vendaServico = vendaServico;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmClientes)
                {
                    form.Focus();
                    return;
                }
            }

            FrmClientes frm = new FrmClientes(_clienteServico);
            frm.MdiParent = this;
            frm.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmProdutos)
                {
                    form.Focus();
                    return;
                }
            }

            FrmProdutos frm = new FrmProdutos(_produtoServico);
            frm.MdiParent = this;
            frm.Show();
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVendas frm = new FrmVendas(_clienteServico, _produtoServico, _vendaServico);
            frm.MdiParent = this;
            frm.Show();
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRelatorios frm = new FrmRelatorios(_vendaServico);
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}