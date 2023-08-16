using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuConsoleApp.Models
{
    public class Pedido
    {
        private int id;
        private List<ItemPedido> itens;

        public int Id { get => id; set => id = value; }
        public List<ItemPedido> Itens { get => itens; set => itens = value; }
    }
}
