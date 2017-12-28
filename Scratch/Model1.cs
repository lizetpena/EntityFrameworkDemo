namespace Scratch
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CanadaCustomer> CanadaCustomers { get; set; }
        public virtual DbSet<CarrierContact> CarrierContacts { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<EmployeeFinancial> EmployeeFinancials { get; set; }
        public virtual DbSet<EmployeePersonal> EmployeePersonals { get; set; }
        public virtual DbSet<EmployeePromotion> EmployeePromotions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FederalTaxAudit> FederalTaxAudits { get; set; }
        public virtual DbSet<InternationalOrder> InternationalOrders { get; set; }
        public virtual DbSet<NOVCustomer> NOVCustomers { get; set; }
        public virtual DbSet<OHCustomer> OHCustomers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PreviousEmployee> PreviousEmployees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<StateTaxAudit> StateTaxAudits { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TargetCustomer> TargetCustomers { get; set; }
        public virtual DbSet<TaxAudit> TaxAudits { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanadaCustomer>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<CanadaCustomer>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<CanadaCustomer>()
                .Property(e => e.City)
                .IsFixedLength();

            modelBuilder.Entity<CarrierContact>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<CarrierContact>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Carrier>()
                .Property(e => e.Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<Carrier>()
                .Property(e => e.Rating)
                .IsFixedLength();

            modelBuilder.Entity<Carrier>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Carrier>()
                .HasMany(e => e.CarrierContacts)
                .WithRequired(e => e.Carrier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerID)
                .IsFixedLength();

            modelBuilder.Entity<EmployeePersonal>()
                .Property(e => e.SSN)
                .IsFixedLength();

            modelBuilder.Entity<EmployeePromotion>()
                .Property(e => e.AnnualSalary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.EmployeeFinancial)
                .WithRequired(e => e.Employee);

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.EmployeePersonal)
                .WithRequired(e => e.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeePromotions)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Territories)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeesTerritories").MapLeftKey("EmployeeID").MapRightKey("TerritoryID"));

            modelBuilder.Entity<FederalTaxAudit>()
                .Property(e => e.TaxYear)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<InternationalOrder>()
                .Property(e => e.ExciseTax)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NOVCustomer>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<NOVCustomer>()
                .Property(e => e.Zip1)
                .IsFixedLength();

            modelBuilder.Entity<NOVCustomer>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<OHCustomer>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<OHCustomer>()
                .Property(e => e.Zip)
                .IsFixedLength();

            modelBuilder.Entity<OHCustomer>()
                .Property(e => e.City)
                .IsFixedLength();

            modelBuilder.Entity<OHCustomer>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.CustomerID)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasOptional(e => e.InternationalOrder)
                .WithRequired(e => e.Order);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.RowVersionStamp)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Territories)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StateTaxAudit>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.VolumeDiscountPercent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.ShippingDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.PartnerDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TargetCustomer>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TargetCustomer>()
                .Property(e => e.Zip)
                .IsFixedLength();

            modelBuilder.Entity<TargetCustomer>()
                .Property(e => e.City)
                .IsFixedLength();

            modelBuilder.Entity<TargetCustomer>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<TaxAudit>()
                .Property(e => e.Adjustment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TaxAudit>()
                .HasOptional(e => e.FederalTaxAudit)
                .WithRequired(e => e.TaxAudit);

            modelBuilder.Entity<TaxAudit>()
                .HasOptional(e => e.StateTaxAudit)
                .WithRequired(e => e.TaxAudit);
        }
    }
}
