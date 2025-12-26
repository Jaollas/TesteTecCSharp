namespace GestaoVendas.WinForms
{
    partial class FrmRelatorios
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
            dtInicio = new DateTimePicker();
            dtFim = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnGerar = new Button();
            SuspendLayout();
            // 
            // dtInicio
            // 
            dtInicio.Location = new Point(67, 63);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(250, 27);
            dtInicio.TabIndex = 0;
            // 
            // dtFim
            // 
            dtFim.Location = new Point(449, 63);
            dtFim.Name = "dtFim";
            dtFim.Size = new Size(250, 27);
            dtFim.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 40);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 2;
            label1.Text = "De";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(449, 40);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 3;
            label2.Text = "Até";
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(67, 136);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(94, 29);
            btnGerar.TabIndex = 4;
            btnGerar.Text = "Gerar";
            btnGerar.UseVisualStyleBackColor = true;
            // 
            // FrmRelatorios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGerar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtFim);
            Controls.Add(dtInicio);
            Name = "FrmRelatorios";
            Text = "FrmRelatorios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtInicio;
        private DateTimePicker dtFim;
        private Label label1;
        private Label label2;
        private Button btnGerar;
    }
}