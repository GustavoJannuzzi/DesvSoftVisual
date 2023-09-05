using System;
using System.Collections.Generic;
using System.Linq;

namespace WoofHub.Persistencia
{
    public class FelinoPersistencia
    {
        public static bool Incluir(Felino felino)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Felinos.Add(felino);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Felino felino)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var existingFelino = context.Felinos.Find(felino.Id);
                    if (existingFelino != null)
                    {
                        context.Entry(existingFelino).CurrentValues.SetValues(felino);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Excluir(Felino felino)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var existingFelino = context.Felinos.Find(felino.Id);
                    if (existingFelino != null)
                    {
                        context.Felinos.Remove(existingFelino);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                e.printStackTrace();
                return false;
            }
        }

        public static Felino ProcurarPorNome(Felino felino)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Felinos.FirstOrDefault(f => f.Nome == felino.Nome);
            }
        }

        public static List<Felino> ProcurarFelinoPorSituacao(string situacao)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Felinos.Where(f => f.Situacao == situacao).ToList();
            }
        }

        public static List<Felino> ProcurarFelinosSemLar()
        {
            return ProcurarFelinoPorSituacao("Sem lar");
        }

        public static List<Cliente> GetClientes(Cliente cliente)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clientes.Where(c => c.Nome.Contains(cliente.Nome)).ToList();
            }
        }
    }
}
