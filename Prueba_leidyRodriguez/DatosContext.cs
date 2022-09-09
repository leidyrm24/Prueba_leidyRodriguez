using Microsoft.EntityFrameworkCore;
using Prueba_leidyRodriguez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_leidyRodriguez
{
    public class DatosContext : DbContext
    {
        public DatosContext(DbContextOptions<DatosContext> options) : base(options)
        {
        }

        public DbSet<CITY> CITYS { get; set; }
        public DbSet<SELLER> SELLERS { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CITY>().ToTable("CITY");
            modelBuilder.Entity<SELLER>().ToTable("SELLER");


        }
    }
}
