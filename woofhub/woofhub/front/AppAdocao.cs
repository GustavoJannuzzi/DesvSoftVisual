using System;
using WoofHub.Entidades;
using WoofHub.Negocio;
using WoofHub.Persistencia;

namespace WoofHub.Front
{
	public class AppAdocao
	{
		public AppAdocao()
		{
			int opc;

			do
			{
				Console.WriteLine("\n\n");
				Console.WriteLine("======  ADOTAR :)  ======");
				Console.WriteLine("1 - Pets Caninos");
				Console.WriteLine("2 - Pets Felinos");
				Console.WriteLine("3 - Voltar");
				opc = ConsoleHelper.ReadInt("Op��o: ");
				switch (opc)
				{
					case 1:
						AdotarCanino();
						break;
					case 2:
						AdotarFelino();
						break;
				}
			} while (opc != 3);
		}

		public static void AdotarCanino()
		{
			Console.WriteLine("\n\n====== ADO��O DE DOGUINHO ======");
			Caninos objCanino = new Caninos();
			Cliente objCliente = new Cliente();
			objCliente.Cpf = ConsoleHelper.ReadString("Informe o CPF do Adotante: ");
			if (ClienteNegocio.IsCPF(objCliente.Cpf))
			{
				objCliente = ClientePersistencia.ProcurarPorCPF(objCliente);
				if (objCliente != null)
				{
					objCanino.Nome = ConsoleHelper.ReadString("\n\nInforme o nome do doguinho: ");
					objCanino = CaninoPersistencia.ProcurarPorNome(objCanino);
					if (objCanino != null)
					{
						objCanino.Endereco = objCliente.Endereco;
						objCanino.Situacao = "Adotado";
						objCliente.Cachorros.Add(objCanino);
						objCanino.Dono = objCliente;
						if (ClientePersistencia.Alterar(objCliente) && CaninoPersistencia.Alterar(objCanino))
						{
							Console.WriteLine("\n\nRegistro de ado��o realizado!!");
						}
						else
						{
							Console.WriteLine("\n\nN�o foi poss�vel adotar o Doguinho.");
						}
					}
					else
					{
						Console.WriteLine("\n\nDoguinho n�o cadastrado.");
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

		public static void AdotarFelino()
		{
			Console.WriteLine("\n\n====== ADO��O DE GATINHO ======");
			Felinos objFelino = new Felinos();
			Cliente objCliente = new Cliente();
			objCliente.Cpf = ConsoleHelper.ReadString("Informe o CPF do Adotante: ");
			if (ClienteNegocio.IsCPF(objCliente.Cpf))
			{
				objCliente = ClientePersistencia.ProcurarPorCPF(objCliente);
				if (objCliente != null)
				{
					objFelino.Nome = ConsoleHelper.ReadString("\n\nInforme o nome do gatinho: ");
					objFelino = FelinoPersistencia.ProcurarPorNome(objFelino);
					if (objFelino != null)
					{
						objFelino.Endereco = objCliente.Endereco;
						objFelino.Situacao = "Adotado";
						objCliente.Gatos.Add(objFelino);
						objFelino.Dono = objCliente;
						if (ClientePersistencia.Alterar(objCliente) && FelinoPersistencia.Alterar(objFelino))
						{
							Console.WriteLine("\n\nRegistro de ado��o realizado!!");
						}
						else
						{
							Console.WriteLine("\n\nN�o foi poss�vel adotar o Gatinho.");
						}
					}
					else
					{
						Console.WriteLine("\n\nGatinho n�o cadastrado.");
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
	}
}
