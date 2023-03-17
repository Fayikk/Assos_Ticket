﻿using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore;

namespace Assos_Ticket.Server.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
      
        public DbSet<BusExpedition> Busses { get; set; }
        public DbSet<PlaneExpedition> Planes { get; set; }
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }  
        public DbSet<User> Users { get; set; }  
        public DbSet<VipCar> VipCars { get; set; }  

    }
}
