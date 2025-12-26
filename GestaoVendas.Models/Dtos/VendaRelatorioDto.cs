using System;

namespace GestaoVendas.Models.Dtos
{
    public class VendaRelatorioDto
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
    }
}