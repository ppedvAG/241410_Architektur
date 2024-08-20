using Microsoft.EntityFrameworkCore;
using ppedv.PuecklerPalace.Model;
using System.Diagnostics;

namespace ppedv.PuecklerPalace.Data.Db
{
    public class PuecklerContext : DbContext
    {
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<BestellPosition> BestellPositionen { get; set; }
        public DbSet<Eissorte> Eissorten { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Zutat> Zutaten { get; set; }

        private string _conString;

        public PuecklerContext(string conString)
        {
            _conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conString)
                          .UseLazyLoadingProxies()
                          .LogTo(x => Debug.WriteLine(x));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bestellung>().Property(x => x.Kunde).HasColumnName("Kundenname").HasMaxLength(276);

            modelBuilder.Entity<EisElement>().UseTptMappingStrategy();
        }
    }
}
