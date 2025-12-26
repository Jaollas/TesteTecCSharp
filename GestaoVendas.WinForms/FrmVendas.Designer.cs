namespace GestaoVendas.WinForms
{
    partial class FrmVendas
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
            cboClientes = new ComboBox();
            cboProdutos = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            txtPreco = new Label();
            numQtd = new NumericUpDown();
            btnAdicionar = new Button();
            dgvItens = new DataGridView();
            lblTotal = new Label();
            btnFinalizar = new Button();
            ((System.ComponentModel.ISupportInitialize)numQtd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Produto";
            // 
            // cboClientes
            // 
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.FormattingEnabled = true;
            cboClientes.Location = new Point(12, 41);
            cboClientes.Name = "cboClientes";
            cboClientes.Size = new Size(299, 28);
            cboClientes.TabIndex = 2;
            // 
            // cboProdutos
            // 
            cboProdutos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdutos.FormattingEnabled = true;
            cboProdutos.Location = new Point(12, 109);
            cboProdutos.Name = "cboProdutos";
            cboProdutos.Size = new Size(299, 28);
            cboProdutos.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 86);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 4;
            label3.Text = "Preço Unitário";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(542, 86);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 5;
            label4.Text = "Quantidade";
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(330, 109);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(100, 23);
            txtPreco.TabIndex = 13;
            // 
            // numQtd
            // 
            numQtd.Location = new Point(542, 110);
            numQtd.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQtd.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQtd.Name = "numQtd";
            numQtd.Size = new Size(150, 27);
            numQtd.TabIndex = 7;
            numQtd.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(339, 156);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(94, 29);
            btnAdicionar.TabIndex = 8;
            btnAdicionar.Text = "Adicionar Item";
            btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // dgvItens
            // 
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Location = new Point(44, 191);
            dgvItens.Name = "dgvItens";
            dgvItens.RowHeadersWidth = 51;
            dgvItens.Size = new Size(711, 132);
            dgvItens.TabIndex = 9;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(44, 339);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(163, 20);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "Total da Venda: R$ 0,00";
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(339, 397);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(94, 29);
            btnFinalizar.TabIndex = 11;
            btnFinalizar.Text = "Finalizar Venda";
            btnFinalizar.UseVisualStyleBackColor = true;
            // 
            // FrmVendas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFinalizar);
            Controls.Add(lblTotal);
            Controls.Add(dgvItens);
            Controls.Add(btnAdicionar);
            Controls.Add(numQtd);
            Controls.Add(txtPreco);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cboProdutos);
            Controls.Add(cboClientes);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmVendas";
            Text = "FrmVendas";
            Load += FrmVendas_Load;
            ((System.ComponentModel.ISupportInitialize)numQtd).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cboClientes;
        private ComboBox cboProdutos;
        private Label label3;
        private Label label4;
        private Label txtPreco;
        private NumericUpDown numQtd;
        private Button btnAdicionar;
        private DataGridView dgvItens;
        private Label lblTotal;
        private Button btnFinalizar;
    }
}