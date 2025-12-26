using GestaoVendas.Models.Entidades;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoVendas.WinForms
{
    public partial class FrmProdutos : Form
    {
        private readonly IProdutoServico _produtoServico;
        private int _idSelecionado = 0;

        public FrmProdutos(IProdutoServico produtoServico)
        {
            InitializeComponent();
            _produtoServico = produtoServico;

            btnSalvar.Click += BtnSalvar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            btnNovo.Click += BtnNovo_Click;
            dgvProdutos.DoubleClick += DgvProdutos_DoubleClick;
            this.Load += FrmProdutos_Load;
        }

        private async void FrmProdutos_Load(object sender, EventArgs e)
        {
            await CarregarGrid();
        }

        private async Task CarregarGrid()
        {
            try
            {
                var produtos = await _produtoServico.ListarTodos();
                dgvProdutos.DataSource = produtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        private async void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var produto = new Produto
                {
                    Id = _idSelecionado,
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text,
                    Preco = numPreco.Value,
                    Estoque = (int)numEstoque.Value
                };

                await _produtoServico.Salvar(produto);

                MessageBox.Show("Produto salvo com sucesso!");
                LimparCampos();
                await CarregarGrid();
            }
            catch (DominioException ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0) return;

            if (MessageBox.Show("Deseja excluir este produto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _produtoServico.Remover(_idSelecionado);
                    MessageBox.Show("Produto excluído.");
                    LimparCampos();
                    await CarregarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void DgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                var produto = (Produto)dgvProdutos.CurrentRow.DataBoundItem;

                _idSelecionado = produto.Id;
                txtNome.Text = produto.Nome;
                txtDescricao.Text = produto.Descricao;
                numPreco.Value = produto.Preco;
                numEstoque.Value = produto.Estoque;

                btnSalvar.Text = "Atualizar";
            }
        }

        private void LimparCampos()
        {
            _idSelecionado = 0;
            txtNome.Clear();
            txtDescricao.Clear();
            numPreco.Value = 0;
            numEstoque.Value = 0;
            btnSalvar.Text = "Salvar";
            txtNome.Focus();
        }
    }
}