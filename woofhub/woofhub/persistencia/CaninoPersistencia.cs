using System;
using System.Collections.Generic;
using System.Linq;

namespace WoofHub.Persistencia
{
    public class CaninoPersistencia
    {
        public static bool Incluir(Canino canino)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Caninos.Add(canino);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Canino canino)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var existingCanino = context.Caninos.Find(canino.Id);
                    if (existingCanino != null)
                    {
                        context.Entry(existingCanino).CurrentValues.SetValues(canino);
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

        public static bool Excluir(Canino canino)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var existingCanino = context.Caninos.Find(canino.Id);
                    if (existingCanino != null)
                    {
                        context.Caninos.Remove(existingCanino);
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

        public static Canino ProcurarPorNome(Canino canino)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Caninos.FirstOrDefault(c => c.Nome == canino.Nome);
            }
        }

        public static List<Canino> ProcurarCaninosPorSituacao(string situacao)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Caninos.Where(c => c.Situacao == situacao).ToList();
            }
        }

        public static List<Canino> ProcurarCaninosSemLar()
        {
            return ProcurarCaninosPorSituacao("Sem lar");
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
