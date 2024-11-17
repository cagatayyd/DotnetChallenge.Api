using DotnetChallenge.Domain.Entities;
using DotnetChallenge.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence.Contexts
{
	public class DotnetChallengeDbContext : DbContext
	{
        public DotnetChallengeDbContext(DbContextOptions options) : base(options)
        {
            
        }
		#region DbSets
		public DbSet<Carrier> Carriers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
		public DbSet<CarrierReport> CarrierReports { get; set; }
		#endregion

		#region ModelBuilder
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasOne<Carrier>()
				.WithMany(c => c.Orders)
				.HasForeignKey(o => o.CarrierId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Carrier>()
				.HasMany(c => c.CarrierConfigurations)
				.WithOne()
				.HasForeignKey(cc => cc.CarrierId)
				.OnDelete(DeleteBehavior.Cascade);

			// Column kısıtlamaları ve türleri
			modelBuilder.Entity<Carrier>()
				.Property(c => c.CarrierName)
				.IsRequired()
				.HasMaxLength(100);

			modelBuilder.Entity<Carrier>()
				.Property(c => c.CarrierPlusDesiCost)
				.IsRequired()
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<CarrierConfiguration>()
				.Property(cc => cc.CarrierMaxDesi)
				.IsRequired();

			modelBuilder.Entity<CarrierConfiguration>()
				.Property(cc => cc.CarrierMinDesi)
				.IsRequired();

			modelBuilder.Entity<CarrierConfiguration>()
				.Property(cc => cc.CarrierCost)
				.IsRequired()
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Order>()
				.Property(o => o.OrderDesi)
				.IsRequired()
				.HasColumnType("int");

			modelBuilder.Entity<Order>()
				.Property(o => o.OrderDate)
				.IsRequired()
				.HasColumnType("datetime2");

			modelBuilder.Entity<Order>()
				.Property(o => o.OrderCarrierCost)
				.IsRequired()
				.HasColumnType("decimal(18,2)");
		}
		#endregion

	}
}
