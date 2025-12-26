using GestaoVendas.Models.Entidades;
using GestaoVendas.Services.Excecoes;
using GestaoVendas.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GestaoVendas.WinForms
{
    public partial class FrmClientes : Form
    {
        private readonly IClienteServico _clienteServico;
        private int _idSelecionado = 0;
        public FrmClientes(IClienteServico clienteServico)
        {
            InitializeComponent();
            _clienteServico = clienteServico;

            btnSalvar.Click += BtnSalvar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            btnNovo.Click += BtnNovo_Click;
            dgvClientes.DoubleClick += DgvClientes_DoubleClick;

            this.Load += FrmClientes_Load;
        }

        private async void FrmClientes_Load(object sender, EventArgs e)
        {
            await CarregarGrid();
        }

        private async Task CarregarGrid()
        {
            try
            {
                var clientes = await _clienteServico.ListarTodos();
                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

        private async void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Cliente
                {
                    Id = _idSelecionado,
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text
                };

                await _clienteServico.Salvar(cliente);

                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um cliente na lista para excluir.");
                return;
            }

            if (MessageBox.Show("Tem certeza que deseja excluir este cliente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _clienteServico.Remover(_idSelecionado);
                    MessageBox.Show("Cliente excluído.");
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

        private void DgvClientes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

                _idSelecionado = cliente.Id;
                txtNome.Text = cliente.Nome;
                txtEmail.Text = cliente.Email;
                txtTelefone.Text = cliente.Telefone;

                btnSalvar.Text = "Atualizar";
            }
        }

        private void LimparCampos()
        {
            _idSelecionado = 0;
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            btnSalvar.Text = "Salvar";
            txtNome.Focus();
        }
    }
}