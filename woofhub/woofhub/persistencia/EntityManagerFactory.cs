using System;
using System.Data.Entity;

namespace WoofHub.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("bancowoof")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
