using GestaoVendas.Models.Entidades;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoVendas.WinForms
{
    public partial class FrmVendas : Form
    {
        private readonly IClienteServico _clienteServico;
        private readonly IProdutoServico _produtoServico;
        private readonly IVendaServico _vendaServico;

        private List<ItemVenda> _carrinho = new List<ItemVenda>();

        public FrmVendas(IClienteServico clienteServico, IProdutoServico produtoServico, IVendaServico vendaServico)
        {
            InitializeComponent();
            _clienteServico = clienteServico;
            _produtoServico = produtoServico;
            _vendaServico = vendaServico;

            this.Load += FrmVendas_Load;
            cboProdutos.SelectedIndexChanged += CboProdutos_SelectedIndexChanged;
            btnAdicionar.Click += BtnAdicionar_Click;
            btnFinalizar.Click += BtnFinalizar_Click;
        }

        private async void FrmVendas_Load(object sender, EventArgs e)
        {
            await CarregarClientes();
            await CarregarProdutos();
            ConfigurarGrid();
        }

        private async Task CarregarClientes()
        {
            var clientes = await _clienteServico.ListarTodos();
            cboClientes.DataSource = clientes;
            cboClientes.DisplayMember = "Nome";
            cboClientes.ValueMember = "Id";
            cboClientes.SelectedIndex = -1;
        }

        private async Task CarregarProdutos()
        {
            var produtos = await _produtoServico.ListarTodos();
            cboProdutos.DataSource = produtos;
            cboProdutos.DisplayMember = "Nome";
            cboProdutos.ValueMember = "Id";
            cboProdutos.SelectedIndex = -1;
        }

        private void CboProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProdutos.SelectedItem is Produto produtoSelecionado)
            {
                txtPreco.Text = produtoSelecionado.Preco.ToString("C2");
            }
            else
            {
                txtPreco.Text = "";
            }
        }

        private void ConfigurarGrid()
        {
            dgvItens.AutoGenerateColumns = false;

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NomeProduto", HeaderText = "Produto" });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade", HeaderText = "Qtd" });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecoUnitario", HeaderText = "Preço Unit.", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });

        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (cboProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            var produtoSelecionado = (Produto)cboProdutos.SelectedItem;
            int quantidade = (int)numQtd.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("Quantidade deve ser maior que zero.");
                return;
            }

            if (produtoSelecionado.Estoque < quantidade)
            {
                MessageBox.Show($"Estoque insuficiente! Restam apenas {produtoSelecionado.Estoque}.");
                return;
            }

            var item = new ItemVenda
            {
                ProdutoId = produtoSelecionado.Id,
                NomeProduto = produtoSelecionado.Nome,
                Quantidade = quantidade,
                PrecoUnitario = produtoSelecionado.Preco
            };

            _carrinho.Add(item);

            AtualizarGridETotal();
        }

        private void AtualizarGridETotal()
        {
            dgvItens.DataSource = null;
            dgvItens.DataSource = _carrinho;

            decimal totalGeral = _carrinho.Sum(x => x.Quantidade * x.PrecoUnitario);
            lblTotal.Text = $"Total da Venda: {totalGeral:C2}";
        }

        private async void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para fechar a venda.");
                return;
            }

            if (_carrinho.Count == 0)
            {
                MessageBox.Show("Adicione produtos ao carrinho antes de finalizar.");
                return;
            }

            try
            {
                var venda = new Venda
                {
                    ClienteId = (int)cboClientes.SelectedValue,
                    DataVenda = DateTime.Now,
                    Itens = _carrinho
                };

                await _vendaServico.RegistrarVenda(venda);

                MessageBox.Show("Venda realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparTela();
            }
            catch (DominioException ex)
            {
                MessageBox.Show(ex.Message, "Erro de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro técnico: " + ex.Message);
            }
        }

        private void LimparTela()
        {
            cboClientes.SelectedIndex = -1;
            cboProdutos.SelectedIndex = -1;
            numQtd.Value = 1;
            txtPreco.Text = "";
            _carrinho.Clear();
            AtualizarGridETotal();
        }
    }
}