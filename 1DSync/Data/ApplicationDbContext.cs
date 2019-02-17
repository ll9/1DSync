using _1DSync.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DSync.Data
{
    class ApplicationDbContext: DbContext
    {
        public DbSet<PseudoDynamicEntity> PseudoDynamicEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SQLiteConnectionStringBuilder() { DataSource = "db.sqlite" };
            optionsBuilder.UseSqlite(builder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PseudoDynamicEntity>()
                .Property(p => p.Id)
                .HasDefaultValueSql("HEX(RANDOMBLOB(16))");
        }
    }
}
