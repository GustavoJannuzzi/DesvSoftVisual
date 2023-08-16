using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuConsoleApp.Models
{
    public class Pizza
    {
        public string Categoria { get; set; }
        public string Sabor { get; set; }
        public string Tamanho { get; set; }
        public List<Complemento> Complementos { get; set; }
    }
}
