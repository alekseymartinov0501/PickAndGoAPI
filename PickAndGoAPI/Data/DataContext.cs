using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Aisle> Aisles { get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Distribution> Distributions    { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PurchasesDetail> PurchasesDetails { get; set; }
        public DbSet<PurchasesOrder> PurchasesOrders { get; set; }
        public DbSet<QualityRegistry> QualityRegistries { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<SequenceAisle> SequenceAisles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=ALEKSEYLAPTOP; DataBase=PickAndGoDB; Trusted_Connection=True;");
        }
    }
}
