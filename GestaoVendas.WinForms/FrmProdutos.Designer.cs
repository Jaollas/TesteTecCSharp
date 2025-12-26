namespace GestaoVendas.WinForms
{
    partial class FrmProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNome = new TextBox();
            txtDescricao = new TextBox();
            numPreco = new NumericUpDown();
            numEstoque = new NumericUpDown();
            btnSalvar = new Button();
            btnExcluir = new Button();
            btnNovo = new Button();
            dgvProdutos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEstoque).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 109);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "Descrição";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 185);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "Preço (R$)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 258);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 3;
            label4.Text = "Estoque";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 54);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(288, 27);
            txtNome.TabIndex = 4;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(12, 132);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(288, 27);
            txtDescricao.TabIndex = 5;
            // 
            // numPreco
            // 
            numPreco.DecimalPlaces = 2;
            numPreco.Location = new Point(12, 208);
            numPreco.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPreco.Name = "numPreco";
            numPreco.Size = new Size(150, 27);
            numPreco.TabIndex = 6;
            // 
            // numEstoque
            // 
            numEstoque.Location = new Point(12, 281);
            numEstoque.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numEstoque.Name = "numEstoque";
            numEstoque.Size = new Size(150, 27);
            numEstoque.TabIndex = 7;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(105, 357);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(331, 357);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(94, 29);
            btnExcluir.TabIndex = 9;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(566, 357);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(94, 29);
            btnNovo.TabIndex = 10;
            btnNovo.Text = "Limpar";
            btnNovo.UseVisualStyleBackColor = true;
            // 
            // dgvProdutos
            // 
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(399, 31);
            dgvProdutos.MultiSelect = false;
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowHeadersWidth = 51;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new Size(359, 277);
            dgvProdutos.TabIndex = 11;
            // 
            // FrmProdutos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvProdutos);
            Controls.Add(btnNovo);
            Controls.Add(btnExcluir);
            Controls.Add(btnSalvar);
            Controls.Add(numEstoque);
            Controls.Add(numPreco);
            Controls.Add(txtDescricao);
            Controls.Add(txtNome);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmProdutos";
            Text = "FrmProdutos";
            Load += FrmProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)numPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEstoque).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNome;
        private TextBox txtDescricao;
        private NumericUpDown numPreco;
        private NumericUpDown numEstoque;
        private Button btnSalvar;
        private Button btnExcluir;
        private Button btnNovo;
        private DataGridView dgvProdutos;
    }
}