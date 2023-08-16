using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuConsoleApp.Models
{
    public class ItemPedido
    {
        private int id;
        private int quantidade;

        public int Id { get => id; set => id = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
    }

}
