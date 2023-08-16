using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuConsoleApp.Models
{
    public class Complemento
    {
        private int id;
        private string descricao;
        private float valor;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public float Valor { get => valor; set => valor = value; }
    }
}
