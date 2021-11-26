using _07_11_2021_Entity_Framework_Core_CodeFirst.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_11_2021_Entity_Framework_Core_CodeFirst.Contexts
{
    class OlympContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Medals> Medals { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Sports> Sports { get; set; }
        public DbSet<ParticipantsSportsMedals> ParticipantsSportsMedals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Olymp;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Country>().HasKey(p => p.Id);
            //modelBuilder.Entity<Country>().Property(p => p.Name).IsRequired(true);
            //modelBuilder.Entity<Medals>().HasKey(p => p.Id);
            //modelBuilder.Entity<Medals>().Property(p => p.Type).IsRequired(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
