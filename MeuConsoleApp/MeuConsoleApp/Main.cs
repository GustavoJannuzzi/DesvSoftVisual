using MeuConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuConsoleApp

{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> listaClientes = new List<Cliente>();

            while (true)
            {
                Console.WriteLine("Bem-vindo à Pizzaria!");
                Console.WriteLine("1. Cadastrar cliente");
                Console.WriteLine("2. Consultar Cliente");
                Console.WriteLine("3. Sair");
                Console.Write("Digite a opção desejada: ");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                           Cliente cliente = new();
                           Console.WriteLine("\nCPF do cliente: ");
                           cliente.CPF = (Console.ReadLine());
                           Console.WriteLine("Nome do cliente: ");
                           cliente.Nome = (Console.ReadLine());

                           listaClientes.Add(cliente);

                            break;
                        case 2:
                            // CÓDIGO PARA VER A LISTA DE CLIENTES
                            Console.WriteLine("\nLista de Clientes:");
                            {
                                Console.WriteLine(listaClientes);
                            }
                            // FIM DO CÓDIGO TESTE
                            break;
                        case 3:
                            Console.WriteLine("Saindo...");
                            return;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }

                Console.WriteLine();
            }
        }



        static void ConsultarPedido()
        {
            // Lógica para consultar um pedido
            Console.WriteLine("Consultando pedido...");
        }
    }
}

