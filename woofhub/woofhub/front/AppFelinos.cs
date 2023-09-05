using System;
using WoofHub.Entidades;
using WoofHub.Persistencia;

namespace WoofHub.Front
{
    public class AppFelinos
    {
        public AppFelinos()
        {
            int opc;
            do
            {
                Console.WriteLine("\n\n====== PETS FELINOS ======");
                Console.WriteLine("1 - Cadastrar Gatinho");
                Console.WriteLine("2 - Pesquisar Gatinho");
                Console.WriteLine("3 - Alterar Gatinho");
                Console.WriteLine("4 - Excluir Gatinho");
                Console.WriteLine("5 - Voltar");
                opc = ConsoleHelper.ReadInt("Opção: ");
                switch (opc)
                {
                    case 1:
                        CadastrarGatinho();
                        break;
                    case 2:
                        new AppFelinoConsultar();
                        break;
                    case 3:
                        AlterarGatinho();
                        break;
                    case 4:
                        ExcluirGatinho();
                        break;
                }
            } while (opc != 5);
        }

        public static void CadastrarGatinho()
        {
            Console.WriteLine("\n\n====== CADASTRO DE GATINHO ======");
            Felinos objFelino = new Felinos();
            objFelino.Nome = ConsoleHelper.ReadString("\n\nInforme o nome do gatinho: ");
            if (FelinoPersistencia.ProcurarPorNome(objFelino) == null)
            {
                objFelino.Idade = ConsoleHelper.ReadString("Informe a idade do gatinho: ");
                objFelino.Peso = ConsoleHelper.ReadString("Informe o peso do gatinho: ");
                FelinoPersistencia.Incluir(objFelino);
                Console.WriteLine("\n\nCadastro realizado!!");
            }
            else
            {
                Console.WriteLine("\n\nGatinho já cadastrado.");
            }
        }

        private static void AlterarGatinho()
        {
            int opc;
            Felinos objFelino = new Felinos();
            objFelino.Nome = ConsoleHelper.ReadString("\n\nInforme o Nome do Gatinho: ");
            objFelino = FelinoPersistencia.ProcurarPorNome(objFelino);
            if (objFelino != null)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Idade: " + objFelino.Idade);
                Console.WriteLine("Peso: " + objFelino.Peso);
                Console.WriteLine("============================");
                string resp = ConsoleHelper.ReadString("\n\nAlterar dados do Gatinho [S]/[N]: ");
                if (resp.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    do
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("====== ALTERAÇÃO ======");
                        Console.WriteLine("1 - Alterar Nome");
                        Console.WriteLine("2 - Alterar Idade");
                        Console.WriteLine("3 - Alterar Peso");
                        Console.WriteLine("4 - Alterar Situação");
                        Console.WriteLine("5 - Sair");
                        opc = ConsoleHelper.ReadInt("Opção: ");
                        switch (opc)
                        {
                            case 1:
                                objFelino.Nome = ConsoleHelper.ReadString("\n\nInforme um novo nome pro gatinho: ");
                                if (FelinoPersistencia.Alterar(objFelino))
                                {
                                    Console.WriteLine("\n\nAlteração realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do gatinho.");
                                }
                                break;
                            case 2:
                                objFelino.Idade = ConsoleHelper.ReadString("\n\nInforme nova idade: ");
                                if (FelinoPersistencia.Alterar(objFelino))
                                {
                                    Console.WriteLine("\n\nAlteração realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do cliente.");
                                }
                                break;
                            case 3:
                                objFelino.Peso = ConsoleHelper.ReadString("\n\nInforme um novo peso: ");
                                if (FelinoPersistencia.Alterar(objFelino))
                                {
                                    Console.WriteLine("\n\nAlteração realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do gatinho.");
                                }
                                break;
                            case 4:
                                objFelino.Situacao = ConsoleHelper.ReadString("\n\nInforme a atual situação de adoção: ");
                                if (FelinoPersistencia.Alterar(objFelino))
                                {
                                    Console.WriteLine("\n\nAlteração realizada!!");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nOcorreu um erro ao alterar dados do gatinho.");
                                }
                                break;
                        }
                    } while (opc != 5);
                }
            }
            else
            {
                Console.WriteLine("\n\nGatinho não cadastrado.");
            }
        }

        private static void ExcluirGatinho()
        {
            Felinos objFelino = new Felinos();
            objFelino.Nome = ConsoleHelper.ReadString("\n\nInforme o Nome do gatinho: ");
            objFelino = FelinoPersistencia.ProcurarPorNome(objFelino);
            if (objFelino != null)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Nome: " + objFelino.Idade);
                Console.WriteLine("CPF: " + objFelino.Peso);
                Console.WriteLine("============================");
                string resp = ConsoleHelper.ReadString("\n\nExcluir gatinho [S]/[N]: ");
                if (resp.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    if (FelinoPersistencia.Excluir(objFelino))
                    {
                        Console.WriteLine("\n\nGatinho excluído com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\n\nOcorreu um erro ao excluir o Gatinho.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\nGatinho não cadastrado.");
            }
        }
    }
}
