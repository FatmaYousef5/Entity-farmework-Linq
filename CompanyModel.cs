using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FProject
{
    public partial class CompanyModel : DbContext
    {
        public CompanyModel()
            : base("name=ComanyModel")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Export_Permission> Export_Permission { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Import_Permission> Import_Permission { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Client_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Client_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.E_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Emp_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Emp_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Emp_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Emp_Department)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Export_Permission)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.SuppE_Id);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Warehouses)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.Resp_Id);

            modelBuilder.Entity<Good>()
                .Property(e => e.G_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.G_Unit)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Export_Permission)
                .WithOptional(e => e.Good)
                .HasForeignKey(e => e.Goods_Id);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Import_Permission)
                .WithOptional(e => e.Good)
                .HasForeignKey(e => e.Goods_Id);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Supp_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Supp_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.E_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.W_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.W_Address)
                .IsUnicode(false);
        }
    }
}
