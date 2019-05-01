namespace AnnonsService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ServiceDBModel : DbContext
    {
        public ServiceDBModel()
            : base("name=ServiceDBModel1")
        {
        }

        public virtual DbSet<CategoryData> CategoryData { get; set; }
        public virtual DbSet<ContractData> ContractData { get; set; }
        public virtual DbSet<ContractStatusTypeData> ContractStatusTypeData { get; set; }
        public virtual DbSet<ServiceData> ServiceData { get; set; }
        public virtual DbSet<ServiceModificationsData> ServiceModificationsData { get; set; }
        public virtual DbSet<ServiceStatusData> ServiceStatusData { get; set; }
        public virtual DbSet<ServiceStatusTypeData> ServiceStatusTypeData { get; set; }
        public virtual DbSet<ServiceTypeData> ServiceTypeData { get; set; }
        public virtual DbSet<SubCategoryData> SubCategoryData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryData>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<CategoryData>()
                .HasMany(e => e.SubCategoryData)
                .WithRequired(e => e.CategoryData)
                .HasForeignKey(e => e.Parent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractStatusTypeData>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceData>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceData>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceData>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceModificationsData>()
                .HasMany(e => e.ServiceData)
                .WithOptional(e => e.ServiceModificationsData)
                .HasForeignKey(e => e.Modified);

            modelBuilder.Entity<ServiceStatusData>()
                .HasMany(e => e.ServiceData)
                .WithRequired(e => e.ServiceStatusData)
                .HasForeignKey(e => e.ServiceStatusID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceStatusTypeData>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceStatusTypeData>()
                .HasMany(e => e.ServiceStatusData)
                .WithRequired(e => e.ServiceStatusTypeData)
                .HasForeignKey(e => e.StatusTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceTypeData>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeData>()
                .HasMany(e => e.ServiceData)
                .WithRequired(e => e.ServiceTypeData)
                .HasForeignKey(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategoryData>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategoryData>()
                .HasMany(e => e.ServiceData)
                .WithRequired(e => e.SubCategoryData)
                .HasForeignKey(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}
