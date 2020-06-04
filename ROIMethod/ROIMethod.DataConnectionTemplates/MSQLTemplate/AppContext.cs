using Microsoft.EntityFrameworkCore;
using ROIMethod.DataInfrastructure.DataUtils.Entities;
using ROIMethod.DataInfrastructure.DataUtils.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.DataConnectionTemplates.MSQLTemplate
{
    public class AppContext : DbContext, IAppContext
    {
        private string connectionString;

        public AppContext(string connectionString)
        {
            this.connectionString = connectionString;
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Database.EnsureCreated();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Statistic>(etb =>
            {
                etb.HasKey(e => e.Id);
                etb.Property(e => e.Id);
                etb.ToTable("Statistics");
            }
            );
        }

    }
}
