using System;
using System.Collections.Generic;
using WoofHub.Entidades;
using WoofHub.Persistencia;

namespace WoofHub.Front
{
    public class AppCaninoConsultar
    {
        public AppCaninoConsultar()
        {
            int opc;
            do
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("====== O QUE VOC� DESEJA CONSULTAR ======");
                Console.WriteLine("1 - Pesquisar Doguinhos");
                Console.WriteLine("2 - Dogs em lar tempor�rio");
                Console.WriteLine("3 - Dogs sem lar");
                Console.WriteLine("4 - Voltar");
                opc = ConsoleHelper.ReadInt("Op��o: ");
                switch (opc)
                {
                    case 1:
                        ConsultarCanino();
                        break;
                    case 2:
                        ConsultarCaninoEmLT();
                        break;
                    case 3:
                        ProcurarCaninosSemLar();
                        break;
                }
            } while (opc != 4);
        }

        private static void ConsultarCanino()
        {
            Console.WriteLine("\n\n====== CONSULTA DE C�ES======");
            Caninos objCanino = new Caninos();
            objCanino.Nome = ConsoleHelper.ReadString("Informe o Nome do c�ozinho que deseja pesquisar: ");
            objCanino = CaninoPersistencia.ProcurarPorNome(objCanino);
            if (objCanino != null)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Nome: " + objCanino.Nome);
                Console.WriteLine("Idade: " + objCanino.Idade);
                Console.WriteLine("Peso: " + objCanino.Peso);
                Console.WriteLine("Situa��o: " + objCanino.Situacao);
                Console.WriteLine("============================");
            }
        }

        private static void ConsultarCaninoEmLT()
        {
            Console.WriteLine("\n\n====== CONSULTA DE C�ES EM LAR TEMPOR�RIO======");
            string situacao = ConsoleHelper.ReadString("Digite 'LT': ");
            List<Caninos> caninos = CaninoPersistencia.ProcurarCaninosPorLT(situacao);

            if (caninos.Count > 0)
            {
                Console.WriteLine("============================");
                foreach (Caninos objCanino in caninos)
                {
                    Console.WriteLine("Nome: " + objCanino.Nome);
                    Console.WriteLine("Idade: " + objCanino.Idade);
                    Console.WriteLine("Peso: " + objCanino.Peso);
                    Console.WriteLine("Situa��o: " + objCanino.Situacao);
                    Console.WriteLine("============================");
                }
            }
            else
            {
                Console.WriteLine("\n\n== N�o h� Lar tempor�rio dispon�vel. ==");
            }
        }

        private static void ProcurarCaninosSemLar()
        {
            Console.WriteLine("\n\n====== CONSULTA DE C�ES SEM LAR ======");
            List<Caninos> caninosSemLar = CaninoPersistencia.ProcurarCaninosSemLar();

            if (caninosSemLar.Count > 0)
            {
                Console.WriteLine("============================");
                foreach (Caninos objCanino in caninosSemLar)
                {
                    Console.WriteLine("Nome: " + objCanino.Nome);
                    Console.WriteLine("Idade: " + objCanino.Idade);
                    Console.WriteLine("Peso: " + objCanino.Peso);
                    Console.WriteLine("Situa��o: " + objCanino.Situacao);
                    Console.WriteLine("============================");
                }
            }
            else
            {
                Console.WriteLine("\n\n== N�o h� c�es sem lar registrados. ==");
            }
        }
    }
}
