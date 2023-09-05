using System;
using WoofHub.Entidades;
using WoofHub.Persistencia;

namespace WoofHub.Front
{
    public class AppCanino
    {
        public AppCanino()
        {
            int opc;
            do
            {
                Console.WriteLine("\n\n====== PETS CANINOS ======");
                Console.WriteLine("1 - Cadastrar Doguinho");
                Console.WriteLine("2 - Pesquisar Doguinho");
                Console.WriteLine("3 - Alterar doguinho");
                Console.WriteLine("4 - Excluir doguinho");
                Console.WriteLine("5 - Voltar");
                opc = ConsoleHelper.ReadInt("Op��o: ");
                switch (opc)
                {
                    case 1:
                        CadastrarDoguinho();
                        break;
                    case 2:
                        new AppCaninoConsultar();
                        break;
                    case 3:
                        AlterarDoguinho();
                        break;
                    case 4:
                        ExcluirDoguinho();
                        break;
                }
            } while (opc != 5);
        }

        public static void CadastrarDoguinho()
        {
            Console.WriteLine("\n\n====== CADASTRO DE DOGUINHOS ======");
            Caninos objCanino = new Caninos();
            objCanino.Nome = ConsoleHelper.ReadString("\n\nInforme o nome do doguinho: ");
            if (CaninoPersistencia.ProcurarPorNome(objCanino) == null)
            {
                objCanino.Idade = ConsoleHelper.ReadString("Informe a idade do doguinho: ");
                objCanino.Peso = ConsoleHelper.ReadString("Informe o peso do doguinho: ");
                objCanino.Endereco = "Canil";
                CaninoPersistencia.Incluir(objCanino);
                Console.WriteLine("\n\nCadastro realizado!!");
            }
            else
            {
                Console.WriteLine("\n\nC�ozinho j� cadastrado.");
            }
        }

        private static void AlterarDoguinho()
        {
            int opc;
            Caninos objCanino = new Caninos();
            objCanino.Nome = ConsoleHelper.ReadString("\n\nInforme o Nome do doguinho: ");
            objCanino = CaninoPersistencia.ProcurarPorNome(objCanino);
            if (objCanino != null)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Idade: " + objCanino.Idade);
                Console.WriteLine("Peso: " + objCanino.Peso);
                Console.WriteLine("Situa��o: " + objCanino.Situacao);
                Console.WriteLine("============================");
                string resp = ConsoleHelper.ReadString("\n\nAlterar dados do doguinho [S]/[N]: ");
                if (resp.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    do
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("====== ALTERA��O ======");
                        Console.WriteLine("1 - Alterar Nome");
                        Console.WriteLine("2 - Alterar Idade");
                        Console.WriteLine("3 - Alterar Peso");
                        Console.WriteLine("4 - Alterar Situa��o");
                        Console.WriteLine("5 - Sair");
                        opc = ConsoleHelper.ReadInt("Op��o: ");
                        switch (opc)
                        {
                            case 1:
                                objCanino.Nome = ConsoleHelper.ReadString("\n\nInforme um novo nome: ");
                                if (CaninoPersistencia.Alterar(objCanino))
                                {
                                    Console.WriteLine("\n\nAltera��o realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do c�ozinho.");
                                }
                                break;
                            case 2:
                                objCanino.Idade = ConsoleHelper.ReadString("\n\nInforme nova idade: ");
                                if (CaninoPersistencia.Alterar(objCanino))
                                {
                                    Console.WriteLine("\n\nAltera��o realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do c�ozinho.");
                                }
                                break;
                            case 3:
                                objCanino.Peso = ConsoleHelper.ReadString("\n\nInforme um novo peso: ");
                                if (CaninoPersistencia.Alterar(objCanino))
                                {
                                    Console.WriteLine("\n\nAltera��o realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do c�ozinho.");
                                }
                                break;
                            case 4:
                                objCanino.Situacao = ConsoleHelper.ReadString("\n\nInforme a atual situa��o de ado��o: ");
                                if (CaninoPersistencia.Alterar(objCanino))
                                {
                                    Console.WriteLine("\n\nAltera��o realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do c�ozinho.");
                                }
                                break;
                        }
                    } while (opc != 5);
                }
            }
            else
            {
                Console.WriteLine("\n\nC�ozinho n�o cadastrado.");
            }
        }

        private static void ExcluirDoguinho()
        {
            Caninos objCanino = new Caninos();
            objCanino.Nome = ConsoleHelper.ReadString("\n\nInforme o Nome do c�ozinho: ");
            objCanino = CaninoPersistencia.ProcurarPorNome(objCanino);
            if (objCanino != null)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Nome: " + objCanino.Idade);
                Console.WriteLine("CPF: " + objCanino.Peso);
                Console.WriteLine("============================");
                string resp = ConsoleHelper.ReadString("\n\nExcluir c�ozinho [S]/[N]: ");
                if (resp.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    if (CaninoPersistencia.Excluir(objCanino))
                    {
                        Console.WriteLine("\n\nC�ozinho exclu�do com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\n\nOcorreu um erro ao excluir o c�ozinho.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\nC�ozinho n�o cadastrado.");
            }
        }
    }
}
