using System;

namespace WoofHub.Front
{
    public class Principal
    {
        public static void Main(string[] args)
        {
            int opc;
            do
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("====== WOOF HUB ====== ");
                Console.WriteLine("1 - Pais adotivos");
                Console.WriteLine("2 - Pets caninos");
                Console.WriteLine("3 - Pets felinos");
                Console.WriteLine("4 - Registrar adoção");
                Console.WriteLine("5 - Sair");
                opc = ConsoleHelper.ReadInt("Opção: ");
                switch (opc)
                {
                    case 1:
                        new AppClientes();
                        break;
                    case 2:
                        new AppCanino();
                        break;
                    case 3:
                        new AppFelinos();
                        break;
                    case 4:
                        new AppAdocao();
                        break;
                }
            } while (opc != 5);
        }
    }
}
