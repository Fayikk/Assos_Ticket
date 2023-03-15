using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore;

namespace Assos_Ticket.Server.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           


            modelBuilder.Entity<Expedition>()
                .Property(e => e.CreatedDate)
                .HasColumnType("datetime");

        }

        public DbSet<Bus> Busses { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }  

    }
}
