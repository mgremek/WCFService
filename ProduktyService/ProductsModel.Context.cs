﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProduktyService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WarKonfiguratorEntities : DbContext
    {
        public WarKonfiguratorEntities()
            : base("name=WarKonfiguratorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<Products_TEST> Products_TEST { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<clients> clients { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<BasketStatusCode> BasketStatusCode { get; set; }
        public virtual DbSet<BasketItems> BasketItems { get; set; }
    }
}
