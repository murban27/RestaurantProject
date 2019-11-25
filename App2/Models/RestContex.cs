using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace App2.Models
{
    public class RestContext : DbContext
    {

        public DbSet<Stoly> Stolies { get; set; }

        public DbSet<Hyarch> Hyarches { get; set; }
        public DbSet<Polozka> Polozkas { get; set; }
        public DbSet<Order> Orders { get; set; }

        private const string DatabaseFilename = "Contacts.db";
        public RestContext(string dbPath) : base()
        {
            DbPath = dbPath;
            Database.EnsureDeleted();
           
        }
        private string DbPath { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var databaseFilePath = Path.Combine(FileSystem.AppDataDirectory, DbPath);
          
            dbContextOptionsBuilder.UseSqlite($"Filename={databaseFilePath}");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stoly>().HasKey(x => x.Id);
            modelBuilder.Entity<Stoly>().Property(x => x.Id).ValueGeneratedOnAdd();
            

        }
    }
}
