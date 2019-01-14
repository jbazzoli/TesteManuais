using ManuaisTeste.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace ManuaisTeste.Dal
{
    public class ManualContext : DbContext
    {
        public ManualContext() : base("ManualContext")
        {
        }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Produto_Cosif> Produto_Cosif { get; set; }
        public DbSet<Movimento_Manual> Movimento_Manual { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}