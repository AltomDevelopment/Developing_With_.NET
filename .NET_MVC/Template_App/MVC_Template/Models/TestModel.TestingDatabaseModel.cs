﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 9/19/2023 8:35:18 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_Template.Models
{

    public partial class TestingDatabaseModel : DbContext
    {

        public TestingDatabaseModel() :
            base()
        {
            OnCreated();
        }

        public TestingDatabaseModel(DbContextOptions<TestingDatabaseModel> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                !optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension)))
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP-5C578KU\\SQLEXPRESS; Database=TestingDatabase; Trusted_Connection=True; Trust Server Certificate =Yes; MultipleActiveResultSets=True;");
            }
            
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<CustomerOrderDetail> CustomerOrderDetails
        {
            get;
            set;
        }

        public virtual DbSet<CustomerOrder> CustomerOrders
        {
            get;
            set;
        }

        public virtual DbSet<Manufacturer> Manufacturers
        {
            get;
            set;
        }

        public virtual DbSet<ManufacturerContactInfo> ManufacturerContactInfos
        {
            get;
            set;
        }

        public virtual DbSet<ManufacturerOrderDetail> ManufacturerOrderDetails
        {
            get;
            set;
        }

        public virtual DbSet<ManufacturerOrder> ManufacturerOrders
        {
            get;
            set;
        }

        public virtual DbSet<ProductCategory> ProductCategories
        {
            get;
            set;
        }

        public virtual DbSet<Product> Products
        {
            get;
            set;
        }

        public virtual DbSet<ProductShipper> ProductShippers
        {
            get;
            set;
        }

        public virtual DbSet<User> Users
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CustomerOrderDetailMapping(modelBuilder);
            CustomizeCustomerOrderDetailMapping(modelBuilder);

            CustomerOrderMapping(modelBuilder);
            CustomizeCustomerOrderMapping(modelBuilder);

            ManufacturerMapping(modelBuilder);
            CustomizeManufacturerMapping(modelBuilder);

            ManufacturerContactInfoMapping(modelBuilder);
            CustomizeManufacturerContactInfoMapping(modelBuilder);

            ManufacturerOrderDetailMapping(modelBuilder);
            CustomizeManufacturerOrderDetailMapping(modelBuilder);

            ManufacturerOrderMapping(modelBuilder);
            CustomizeManufacturerOrderMapping(modelBuilder);

            ProductCategoryMapping(modelBuilder);
            CustomizeProductCategoryMapping(modelBuilder);

            ProductMapping(modelBuilder);
            CustomizeProductMapping(modelBuilder);

            ProductShipperMapping(modelBuilder);
            CustomizeProductShipperMapping(modelBuilder);

            UserMapping(modelBuilder);
            CustomizeUserMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region CustomerOrderDetail Mapping

        private void CustomerOrderDetailMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerOrderDetail>().ToTable(@"CustomerOrderDetails", @"dbo");
            modelBuilder.Entity<CustomerOrderDetail>().Property(x => x.OrderDetailsID).HasColumnName(@"OrderDetailsID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<CustomerOrderDetail>().Property(x => x.ProductID).HasColumnName(@"ProductID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<CustomerOrderDetail>().Property(x => x.ProductQTY).HasColumnName(@"ProductQTY").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<CustomerOrderDetail>().Property(x => x.Discount).HasColumnName(@"Discount").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<CustomerOrderDetail>().Property(x => x.Shipcost).HasColumnName(@"Shipcost").HasColumnType(@"money").IsRequired().ValueGeneratedNever().HasPrecision(19, 4);
            modelBuilder.Entity<CustomerOrderDetail>().Property(x => x.OrderTotal).HasColumnName(@"OrderTotal").HasColumnType(@"money").IsRequired().ValueGeneratedNever().HasPrecision(19, 4);
            modelBuilder.Entity<CustomerOrderDetail>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<CustomerOrderDetail>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<CustomerOrderDetail>().HasKey(@"OrderDetailsID");
        }

        partial void CustomizeCustomerOrderDetailMapping(ModelBuilder modelBuilder);

        #endregion

        #region CustomerOrder Mapping

        private void CustomerOrderMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerOrder>().ToTable(@"CustomerOrders", @"dbo");
            modelBuilder.Entity<CustomerOrder>().Property(x => x.OrderID).HasColumnName(@"OrderID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<CustomerOrder>().Property(x => x.UserID).HasColumnName(@"UserID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<CustomerOrder>().Property(x => x.OrderDetailsID).HasColumnName(@"OrderDetailsID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<CustomerOrder>().Property(x => x.ShipperID).HasColumnName(@"ShipperID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<CustomerOrder>().Property(x => x.TrackingInfo).HasColumnName(@"TrackingInfo").HasColumnType(@"nvarchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<CustomerOrder>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<CustomerOrder>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<CustomerOrder>().HasKey(@"OrderID");
        }

        partial void CustomizeCustomerOrderMapping(ModelBuilder modelBuilder);

        #endregion

        #region Manufacturer Mapping

        private void ManufacturerMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().ToTable(@"Manufacturer", @"dbo");
            modelBuilder.Entity<Manufacturer>().Property(x => x.ManufID).HasColumnName(@"ManufID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<Manufacturer>().Property(x => x.ManufContactID).HasColumnName(@"ManufContactID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Manufacturer>().Property(x => x.ShipperID).HasColumnName(@"ShipperID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Manufacturer>().Property(x => x.ManufName).HasColumnName(@"ManufName").HasColumnType(@"nvarchar(500)").IsRequired().ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<Manufacturer>().Property(x => x.ManufDescr).HasColumnName(@"ManufDescr").HasColumnType(@"nvarchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<Manufacturer>().Property(x => x.CurrentlyInUse).HasColumnName(@"CurrentlyInUse").HasColumnType(@"bit").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Manufacturer>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Manufacturer>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Manufacturer>().HasKey(@"ManufID");
        }

        partial void CustomizeManufacturerMapping(ModelBuilder modelBuilder);

        #endregion

        #region ManufacturerContactInfo Mapping

        private void ManufacturerContactInfoMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManufacturerContactInfo>().ToTable(@"ManufacturerContactInfo", @"dbo");
            modelBuilder.Entity<ManufacturerContactInfo>().Property(x => x.ManufContactID).HasColumnName(@"ManufContactID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<ManufacturerContactInfo>().Property(x => x.ManufAddress).HasColumnName(@"ManufAddress").HasColumnType(@"nvarchar(256)").ValueGeneratedNever().HasMaxLength(256);
            modelBuilder.Entity<ManufacturerContactInfo>().Property(x => x.ManufPhoneNumber).HasColumnName(@"ManufPhoneNumber").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<ManufacturerContactInfo>().Property(x => x.ManufEmail).HasColumnName(@"ManufEmail").HasColumnType(@"nvarchar(256)").ValueGeneratedNever().HasMaxLength(256);
            modelBuilder.Entity<ManufacturerContactInfo>().Property(x => x.ManufHourOfOperation).HasColumnName(@"ManufHourOfOperation").HasColumnType(@"nvarchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<ManufacturerContactInfo>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ManufacturerContactInfo>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ManufacturerContactInfo>().HasKey(@"ManufContactID");
        }

        partial void CustomizeManufacturerContactInfoMapping(ModelBuilder modelBuilder);

        #endregion

        #region ManufacturerOrderDetail Mapping

        private void ManufacturerOrderDetailMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManufacturerOrderDetail>().ToTable(@"ManufacturerOrderDetails", @"dbo");
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.OrderDetailsID).HasColumnName(@"OrderDetailsID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.ManufOrderID).HasColumnName(@"ManufOrderID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.ShipperID).HasColumnName(@"ShipperID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.TrackingInfo).HasColumnName(@"TrackingInfo").HasColumnType(@"nvarchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.ProductID).HasColumnName(@"ProductID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").HasColumnType(@"money").IsRequired().ValueGeneratedNever().HasPrecision(19, 4);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.ProductQTY).HasColumnName(@"ProductQTY").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.ShipperCost).HasColumnName(@"ShipperCost").HasColumnType(@"money").IsRequired().ValueGeneratedNever().HasPrecision(19, 4);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.OrderTotal).HasColumnName(@"OrderTotal").HasColumnType(@"money").IsRequired().ValueGeneratedNever().HasPrecision(19, 4);
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ManufacturerOrderDetail>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ManufacturerOrderDetail>().HasKey(@"OrderDetailsID");
        }

        partial void CustomizeManufacturerOrderDetailMapping(ModelBuilder modelBuilder);

        #endregion

        #region ManufacturerOrder Mapping

        private void ManufacturerOrderMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManufacturerOrder>().ToTable(@"ManufacturerOrders", @"dbo");
            modelBuilder.Entity<ManufacturerOrder>().Property(x => x.ManufOrderID).HasColumnName(@"ManufOrderID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<ManufacturerOrder>().Property(x => x.OrderDetailsID).HasColumnName(@"OrderDetailsID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<ManufacturerOrder>().Property(x => x.OrderName).HasColumnName(@"OrderName").HasColumnType(@"nvarchar(500)").IsRequired().ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<ManufacturerOrder>().Property(x => x.OrderDescr).HasColumnName(@"OrderDescr").HasColumnType(@"nvarchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<ManufacturerOrder>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ManufacturerOrder>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ManufacturerOrder>().HasKey(@"ManufOrderID");
        }

        partial void CustomizeManufacturerOrderMapping(ModelBuilder modelBuilder);

        #endregion

        #region ProductCategory Mapping

        private void ProductCategoryMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().ToTable(@"ProductCategory", @"dbo");
            modelBuilder.Entity<ProductCategory>().Property(x => x.CategoryID).HasColumnName(@"CategoryID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<ProductCategory>().Property(x => x.CategoryName).HasColumnName(@"CategoryName").HasColumnType(@"nvarchar(250)").IsRequired().ValueGeneratedNever().HasMaxLength(250);
            modelBuilder.Entity<ProductCategory>().Property(x => x.CategoryDescr).HasColumnName(@"CategoryDescr").HasColumnType(@"nvarchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<ProductCategory>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ProductCategory>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ProductCategory>().HasKey(@"CategoryID");
        }

        partial void CustomizeProductCategoryMapping(ModelBuilder modelBuilder);

        #endregion

        #region Product Mapping

        private void ProductMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(@"Products", @"dbo");
            modelBuilder.Entity<Product>().Property(x => x.ProductID).HasColumnName(@"ProductID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasColumnName(@"ProductName").HasColumnType(@"nvarchar(250)").IsRequired().ValueGeneratedNever().HasMaxLength(250);
            modelBuilder.Entity<Product>().Property(x => x.ProductDescr).HasColumnName(@"ProductDescr").HasColumnType(@"nvarchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<Product>().Property(x => x.CategoryID).HasColumnName(@"CategoryID").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.Unitprice).HasColumnName(@"Unitprice").HasColumnType(@"money").IsRequired().ValueGeneratedNever().HasPrecision(19, 4);
            modelBuilder.Entity<Product>().Property(x => x.Discontinued).HasColumnName(@"Discontinued").HasColumnType(@"bit").ValueGeneratedNever();
            modelBuilder.Entity<Product>().Property(x => x.DiscountAmount).HasColumnName(@"DiscountAmount").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.ManufacturerOrderID).HasColumnName(@"ManufacturerOrderID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.ProductWeight).HasColumnName(@"ProductWeight").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.ShipperID).HasColumnName(@"ShipperID").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Product>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Product>().HasKey(@"ProductID");
        }

        partial void CustomizeProductMapping(ModelBuilder modelBuilder);

        #endregion

        #region ProductShipper Mapping

        private void ProductShipperMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductShipper>().ToTable(@"ProductShippers", @"dbo");
            modelBuilder.Entity<ProductShipper>().Property(x => x.ShipperID).HasColumnName(@"ShipperID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<ProductShipper>().Property(x => x.ShipperName).HasColumnName(@"ShipperName").HasColumnType(@"nvarchar(256)").IsRequired().ValueGeneratedNever().HasMaxLength(256);
            modelBuilder.Entity<ProductShipper>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ProductShipper>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ProductShipper>().HasKey(@"ShipperID");
        }

        partial void CustomizeProductShipperMapping(ModelBuilder modelBuilder);

        #endregion

        #region User Mapping

        private void UserMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(@"Users", @"dbo");
            modelBuilder.Entity<User>().Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<User>().Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType(@"nvarchar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType(@"nvarchar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.UserName).HasColumnName(@"UserName").HasColumnType(@"nvarchar(256)").ValueGeneratedNever().HasMaxLength(256);
            modelBuilder.Entity<User>().Property(x => x.NormalizedUserName).HasColumnName(@"NormalizedUserName").HasColumnType(@"nvarchar(256)").ValueGeneratedNever().HasMaxLength(256);
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName(@"Email").HasColumnType(@"nvarchar(256)").ValueGeneratedNever().HasMaxLength(256);
            modelBuilder.Entity<User>().Property(x => x.NormalizedEmail).HasColumnName(@"NormalizedEmail").HasColumnType(@"nvarchar(256)").ValueGeneratedNever().HasMaxLength(256);
            modelBuilder.Entity<User>().Property(x => x.EmailConfirmed).HasColumnName(@"EmailConfirmed").HasColumnType(@"bit").ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.PasswordHash).HasColumnName(@"PasswordHash").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.PhoneNumber).HasColumnName(@"PhoneNumber").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.PhoneNumberConfirmed).HasColumnName(@"PhoneNumberConfirmed").HasColumnType(@"bit").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.TwoFactorEnabled).HasColumnName(@"TwoFactorEnabled").HasColumnType(@"bit").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.LockoutEnd).HasColumnName(@"LockoutEnd").HasColumnType(@"datetimeoffset").ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.LockoutEnabled).HasColumnName(@"LockoutEnabled").HasColumnType(@"bit").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.IsAdmin).HasColumnName(@"IsAdmin").HasColumnType(@"bit").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.AccessFailedCount).HasColumnName(@"AccessFailedCount").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<User>().Property(x => x.TimeCreated).HasColumnName(@"TimeCreated").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.LastModified).HasColumnName(@"LastModified").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<User>().HasKey(@"UserId");
        }

        partial void CustomizeUserMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
