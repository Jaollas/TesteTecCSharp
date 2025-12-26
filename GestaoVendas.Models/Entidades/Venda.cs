using System;
using System.Collections.Generic;

namespace GestaoVendas.Models.Entidades
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }

        public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();

        public Venda()
        {
            DataVenda = DateTime.Now;
        }
    }
}