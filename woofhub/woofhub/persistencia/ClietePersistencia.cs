using System;
using System.Collections.Generic;
using System.Linq;

namespace WoofHub.Persistencia
{
    public class ClientePersistencia
    {
        public static bool Incluir(Cliente cliente)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Clientes.Add(cliente);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Alterar(Cliente cliente)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var existingCliente = context.Clientes.Find(cliente.Id);
                    if (existingCliente != null)
                    {
                        context.Entry(existingCliente).CurrentValues.SetValues(cliente);
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

        public static bool Excluir(Cliente cliente)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var existingCliente = context.Clientes.Find(cliente.Id);
                    if (existingCliente != null)
                    {
                        context.Clientes.Remove(existingCliente);
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

        public static Cliente ProcurarPorCPF(Cliente cliente)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clientes.FirstOrDefault(c => c.Cpf == cliente.Cpf);
            }
        }

        public static Cliente ProcurarPorNome(Cliente cliente)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clientes.FirstOrDefault(c => c.Nome == cliente.Nome);
            }
        }

        public static Cliente ProcurarPorId(Cliente cliente)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clientes.Find(cliente.Id);
            }
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
