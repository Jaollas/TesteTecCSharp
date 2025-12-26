using GestaoVendas.Models.Dtos;
using GestaoVendas.Services.Interfaces;
using Microsoft.Reporting.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GestaoVendas.WinForms
{
    public partial class FrmRelatorios : Form
    {
        private readonly IVendaServico _vendaServico;
        private ReportViewer reportViewer1;

        public FrmRelatorios(IVendaServico vendaServico)
        {
            InitializeComponent();
            _vendaServico = vendaServico;

            ConfigurarReportViewer();
            btnGerar.Click += BtnGerar_Click;
        }

        private void ConfigurarReportViewer()
        {
            if (this.reportViewer1 != null)
            {
                this.Controls.Remove(this.reportViewer1);
            }

            this.reportViewer1 = new ReportViewer();

            int alturaCabecalho = 200;

            this.reportViewer1.Location = new Point(0, alturaCabecalho);

            this.reportViewer1.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - alturaCabecalho);

            this.reportViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            this.Controls.Add(this.reportViewer1);
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private async void BtnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                var dados = await _vendaServico.GerarRelatorio(dtInicio.Value, dtFim.Value);

                string caminhoRelatorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Relatorios", "RptVendas.rdlc");

                if (!File.Exists(caminhoRelatorio))
                {
                    MessageBox.Show($"Arquivo não encontrado em: {caminhoRelatorio}\nVerifique se marcou 'Copiar Sempre' nas propriedades.");
                    return;
                }

                reportViewer1.LocalReport.ReportPath = caminhoRelatorio;
                reportViewer1.LocalReport.DataSources.Clear();

                var rds = new ReportDataSource("DataSetVendas", dados);

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar: " + ex.Message);
            }
        }
    }
}