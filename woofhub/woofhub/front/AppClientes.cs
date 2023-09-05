using System;
using System.Linq;
using WoofHub.Entidades;
using WoofHub.Negocio;
using WoofHub.Persistencia;

namespace WoofHub.Front
{
    public class AppClientes
    {
        public AppClientes()
        {
            int opc;
            do
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("====== CLIENTES ======");
                Console.WriteLine("1 - Cadastrar pai adotivo");
                Console.WriteLine("2 - Consultar pai adotivo");
                Console.WriteLine("3 - Alterar pai adotivo");
                Console.WriteLine("4 - Excluir pai adotivo");
                Console.WriteLine("5 - Voltar");
                opc = ConsoleHelper.ReadInt("Op��o: ");
                switch (opc)
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        ConsultarCliente();
                        break;
                    case 3:
                        AlterarCliente();
                        break;
                    case 4:
                        ExcluirCliente();
                        break;
                }
            } while (opc != 5);
        }

        private static void CadastrarCliente()
        {
            Console.WriteLine("\n\n====== CADASTRO DE ADOTANTES ======");
            Cliente objCliente = new Cliente();
            objCliente.Cpf = ConsoleHelper.ReadString("\n\nInforme o CPF do adotante: ");
            if (ClienteNegocio.IsCPF(objCliente.Cpf))
            {
                if (ClientePersistencia.ProcurarPorCPF(objCliente) == null)
                {
                    objCliente.Nome = ConsoleHelper.ReadString("Informe o nome do adotante: ");
                    objCliente.Endereco = ConsoleHelper.ReadString("Informe o endere�o do adotante: ");
                    ClientePersistencia.Incluir(objCliente);
                    Console.WriteLine("\n\nCadastro realizado!!");
                }
                else
                {
                    Console.WriteLine("\n\nCliente j� cadastrado.");
                }
            }
            else
            {
                Console.WriteLine("\n\nCPF inv�lido.");
            }
        }

        private static void ConsultarCliente()
        {
            Console.WriteLine("\n\n====== CONSULTA DE CLIENTES ======");
            Cliente objCliente = new Cliente();
            objCliente.Cpf = ConsoleHelper.ReadString("Informe o CPF do cliente que deseja consultar: ");
            if (ClienteNegocio.IsCPF(objCliente.Cpf))
            {
                objCliente = ClientePersistencia.ProcurarPorCPF(objCliente);
                if (objCliente != null)
                {
                    Console.WriteLine("============================");
                    Console.WriteLine("ID: " + objCliente.Id);
                    Console.WriteLine("Nome: " + objCliente.Nome);
                    Console.WriteLine("CPF: " + objCliente.Cpf);
                    Console.WriteLine("Endere�o: " + objCliente.Endereco);
                    Console.WriteLine("============================");
                    if (!objCliente.Cachorros.Any() && !objCliente.Gatos.Any())
                    {
                        Console.WriteLine("\n\nCliente n�o possui ado��es ainda.");
                    }
                    else
                    {
                        Console.WriteLine("\n\n====== ADO��ES ======");
                        foreach (Caninos cachorro in objCliente.Cachorros)
                        {
                            Console.WriteLine("============================");
                            Console.WriteLine("Nome do PET: " + cachorro.Nome);
                            Console.WriteLine("Idade do PET: " + cachorro.Idade);
                            Console.WriteLine("Peso do PET: " + cachorro.Peso + "KG");
                            Console.WriteLine("Situa��o do PET: " + cachorro.Situacao);
                            Console.WriteLine("Endere�o do PET: " + cachorro.Endereco);
                        }
                        foreach (Felinos felino in objCliente.Gatos)
                        {
                            Console.WriteLine("============================");
                            Console.WriteLine("Nome do PET: " + felino.Nome);
                            Console.WriteLine("Idade do PET: " + felino.Idade);
                            Console.WriteLine("Peso do PET: " + felino.Peso + "KG");
                            Console.WriteLine("Situa��o do PET: " + felino.Situacao);
                            Console.WriteLine("Endere�o do PET: " + felino.Endereco);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n\nCliente n�o cadastrado.");
                }
            }
            else
            {
                Console.WriteLine("\n\nCPF inv�lido.");
            }
        }

        private static void AlterarCliente()
        {
            int opc;
            Cliente objCliente = new Cliente();
            objCliente.Cpf = ConsoleHelper.ReadString("\n\nInforme o CPF do cliente: ");
            objCliente = ClientePersistencia.ProcurarPorCPF(objCliente);
            if (objCliente != null)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Nome: " + objCliente.Nome);
                Console.WriteLine("CPF: " + objCliente.Cpf);
                Console.WriteLine("============================");
                string resp = ConsoleHelper.ReadString("\n\nAlterar dados do cliente [S]/[N]: ");
                if (resp.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    do
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("====== ALTERA��O ======");
                        Console.WriteLine("1 - Alterar nome");
                        Console.WriteLine("2 - Alterar endere�o");
                        Console.WriteLine("3 - Sair");
                        opc = ConsoleHelper.ReadInt("Op��o: ");
                        switch (opc)
                        {
                            case 1:
                                objCliente.Nome = ConsoleHelper.ReadString("\n\nInforme um novo nome: ");
                                if (ClientePersistencia.Alterar(objCliente))
                                {
                                    Console.WriteLine("\n\nAltera��o realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do cliente.");
                                }
                                break;
                            case 2:
                                objCliente.Endereco = ConsoleHelper.ReadString("\n\nInforme um novo endere�o: ");
                                if (ClientePersistencia.Alterar(objCliente))
                                {
                                    Console.WriteLine("\n\nAltera��o realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do cliente.");
                                }
                                break;
                        }
                    } while (opc != 3);
                }
            }
            else
            {
                Console.WriteLine("\n\nCliente n�o cadastrado.");
            }
        }

        private static void ExcluirCliente()
        {
            Cliente objCliente = new Cliente();
            objCliente.Cpf = ConsoleHelper.ReadString("\n\nInforme o CPF do cliente: ");
            objCliente = ClientePersistencia.ProcurarPorCPF(objCliente);
            if (objCliente != null)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Nome: " + objCliente.Nome);
                Console.WriteLine("CPF: " + objCliente.Cpf);
                Console.WriteLine("============================");
                string resp = ConsoleHelper.ReadString("\n\nExcluir cliente [S]/[N]: ");
                if (resp.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    if (ClientePersistencia.Excluir(objCliente))
                    {
                        Console.WriteLine("\n\nCliente exclu�do com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\n\nOcorreu um erro ao excluir o cliente.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\nCliente n�o cadastrado.");
            }
        }
    }
}
