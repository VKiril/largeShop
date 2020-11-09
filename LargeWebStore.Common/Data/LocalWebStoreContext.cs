using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Domain.Data;
using LargeWebStore.Common.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LargeWebStore.Common.Data
{
    public class LocalWebStoreContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProductImageModel> ProductImages { get; set; }
        public DbSet<ProductReviewModel> ProductReviews { get; set; }
        public DbSet<ProductTranslationModel> ProductTranslations { get; set; }
        public DbSet<ProductVariantModel> ProductVariants { get; set; }
        public DbSet<ProductVariantTranslationModel> ProductVariantTranslations { get; set; }
        public DbSet<TaxonModel> Taxons { get; set; }
        public DbSet<TaxonTranslationModel> TaxonTranslations { get; set; }
		

		public LocalWebStoreContext(DbContextOptions<LocalWebStoreContext> options) : base(options)
        {
        }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
			{

				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedAt = DateTime.Now;
						entry.Entity.UpdatedAt = DateTime.MinValue;
						entry.Entity.Id = Guid.NewGuid();
						break;
					case EntityState.Modified:
						entry.Entity.UpdatedAt = DateTime.Now;
						break;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
			{

				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedAt = DateTime.Now;
						entry.Entity.UpdatedAt = DateTime.MinValue;
						entry.Entity.Id = Guid.NewGuid();
						break;
					case EntityState.Modified:
						entry.Entity.UpdatedAt = DateTime.Now;
						break;
				}
			}

			return base.SaveChanges();
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
			{

				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedAt = DateTime.Now;
						entry.Entity.UpdatedAt = DateTime.MinValue;
						entry.Entity.Id = Guid.NewGuid();
						break;
					case EntityState.Modified:
						entry.Entity.UpdatedAt = DateTime.Now;
						break;
				}
			}

			return base.SaveChanges(acceptAllChangesOnSuccess);
		}
	}
}
