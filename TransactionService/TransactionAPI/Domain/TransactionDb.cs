using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParserLib.Models;

namespace TransactionAPI.Domain
{
    public class TransactionDb : DbContext
    {
        public TransactionDb(DbContextOptions<TransactionDb> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasAlternateKey(t => t.Id);
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=efbasicsappdb;Trusted_Connection=True;");
        }
        */
    }
}
