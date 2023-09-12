using System;
using System.Collections.Generic;
using WoofHub.Entidades;
using WoofHub.Persistencia;

namespace WoofHub.Front
{
    public class AppFelinoConsultar
    {
        public AppFelinoConsultar()
        {
            int opc;
            do
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("====== O QUE VOC� DESEJA CONSULTAR ======");
                Console.WriteLine("1 - Pesquisar Gatinhos");
                Console.WriteLine("2 - Gatinhos em lar tempor�rio");
                Console.WriteLine("3 - Gatinhos sem lar");
                Console.WriteLine("4 - Voltar");
                opc = ConsoleHelper.ReadInt("Op��o: ");
                switch (opc)
                {
                    case 1:
                        ConsultarGatinho();
                        break;
                    case 2:
                        ConsultarFelinoEmLT();
                        break;
                    case 3:
                        ProcurarFelinosSemLar();
                        break;
                }
            } while (opc != 4);
        }

        private static void ConsultarGatinho()
        {
            Console.WriteLine("\n\n====== CONSULTA DE GATINHOS======");
            Felinos objFelino = new Felinos();
            objFelino.Nome = ConsoleHelper.ReadString("Informe o Nome do gatinho que deseja pesquisar: ");
            objFelino = FelinoPersistencia.ProcurarPorNome(objFelino);
            if (objFelino != null)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Nome: " + objFelino.Nome);
                Console.WriteLine("Idade: " + objFelino.Idade);
                Console.WriteLine("Peso: " + objFelino.Peso);
                Console.WriteLine("Situa��o: " + objFelino.Situacao);
                Console.WriteLine("============================");
            }
        }

        private static void ConsultarFelinoEmLT()
        {
            Console.WriteLine("\n\n====== CONSULTA DE GATINHOS EM LAR TEMPOR�RIO======");
            string situacao = ConsoleHelper.ReadString("Digite 'LT': ");
            List<Felinos> felinos = FelinoPersistencia.ProcurarFelinoPorLT(situacao);

            if (felinos.Count > 0)
            {
                Console.WriteLine("============================");
                foreach (Felinos objFelino in felinos)
                {
                    Console.WriteLine("Nome: " + objFelino.Nome);
                    Console.WriteLine("Idade: " + objFelino.Idade);
                    Console.WriteLine("Peso: " + objFelino.Peso);
                    Console.WriteLine("Situa��o: " + objFelino.Situacao);
                    Console.WriteLine("============================");
                }
            }
            else
            {
                Console.WriteLine("\n\n== N�o h� Lar tempor�rio dispon�vel. ==");
            }
        }

        private static void ProcurarFelinosSemLar()
        {
            Console.WriteLine("\n\n====== CONSULTA DE GATINHOS SEM LAR ======");
            List<Felinos> felinosSemLar = FelinoPersistencia.ProcurarFelinosSemLar();

            if (felinosSemLar.Count > 0)
            {
                Console.WriteLine("============================");
                foreach (Felinos objFelino in felinosSemLar)
                {
                    Console.WriteLine("Nome: " + objFelino.Nome);
                    Console.WriteLine("Idade: " + objFelino.Idade);
                    Console.WriteLine("Peso: " + objFelino.Peso);
                    Console.WriteLine("Situa��o: " + objFelino.Situacao);
                    Console.WriteLine("============================");
                }
            }
            else
            {
                Console.WriteLine("\n\n== N�o h� gatinhos sem lar registrados. ==");
            }
        }
    }
}
