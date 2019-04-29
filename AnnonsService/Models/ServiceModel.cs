namespace AnnonsService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ServiceModel : DbContext
    {
        public ServiceModel()
            : base("name=ServiceModel")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceModifications> ServiceModifications { get; set; }
        public virtual DbSet<ServiceStatus> ServiceStatus { get; set; }
        public virtual DbSet<ServiceStatusType> ServiceStatusType { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategory)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Parent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ServiceModifications)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceStatus>()
                .HasMany(e => e.Service)
                .WithRequired(e => e.ServiceStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceStatusType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceStatusType>()
                .HasMany(e => e.ServiceStatus)
                .WithRequired(e => e.ServiceStatusType)
                .HasForeignKey(e => e.StatusTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Service)
                .WithRequired(e => e.SubCategory)
                .HasForeignKey(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}
