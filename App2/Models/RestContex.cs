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

        public DbSet<StolyBackup> Stolies { get; set; }

        public DbSet<Hyarch> Hyarches { get; set; }
        public DbSet<Polozka> Polozkas { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<VAT> Dane { get; set; }

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
            modelBuilder.Entity<StolyBackup>().HasKey(x => x.Id);
            modelBuilder.Entity<StolyBackup>().Property(x => x.Id).ValueGeneratedOnAdd();
            

        }
    }
}
