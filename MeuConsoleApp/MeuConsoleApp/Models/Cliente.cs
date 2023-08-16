using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuConsoleApp.Models
{
    public class Cliente
    {
        private string cpf;
        private string nome;

        public string CPF 
        { 
            get => cpf; set => cpf = value; 
        }
        public string Nome 
        { 
            get => nome; set => nome = value; 
        }

        public void Inserir() { /* Implementação aqui */ }
        public void Consultar() { /* Implementação aqui */ }
        public void Alterar() { /* Implementação aqui */ }
        public void Excluir() { /* Implementação aqui */ }
    }
}
