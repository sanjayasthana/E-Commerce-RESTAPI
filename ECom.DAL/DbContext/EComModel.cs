namespace ECom.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EComModel : DbContext
    {
        public EComModel()
            : base("name=EComModel")
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<ProductAttributeLookup> ProductAttributeLookups { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductAttributeLookup>()
                .Property(e => e.AttributeName)
                .IsUnicode(false);

            modelBuilder.Entity<ProductAttributeLookup>()
                .HasMany(e => e.ProductAttributes)
                .WithRequired(e => e.ProductAttributeLookup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.ProductAttributeLookups)
                .WithRequired(e => e.ProductCategory)
                .HasForeignKey(e => e.ProductCategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductAttributes)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductAttribute>()
                .Property(e => e.AttributeValue)
                .IsUnicode(false);
        }
    }
}
