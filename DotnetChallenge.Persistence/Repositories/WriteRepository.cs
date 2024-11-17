using DotnetChallenge.Application.Repositories;
using DotnetChallenge.Domain.Entities.Common;
using DotnetChallenge.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		#region Fields
		private readonly DotnetChallengeDbContext _context;

		#endregion

		#region Ctor
		public WriteRepository(DotnetChallengeDbContext context)
		{
			_context = context;
		}
		public DbSet<T> Table => _context.Set<T>();

		#endregion

		#region Methods
		public async Task<bool> AddAsync(T model)
		{
			EntityEntry entityEntry = await Table.AddAsync(model);
			if (entityEntry.State != EntityState.Added)
			{
				throw new Exception($"Unexpected EntityState: {entityEntry.State}");
			}
			return entityEntry.State == EntityState.Added;

		}

		public async Task<bool> RemoveAsync(T model)
		{
			EntityEntry<T> entityEntry = Table.Remove(model);
			return entityEntry.State == EntityState.Deleted;
		}

		public bool Update(T model)
		{
			EntityEntry entityEntry = Table.Update(model);
			return entityEntry.State == EntityState.Modified;
		}

		public async Task SaveAsync()
		{
			try
			{
				int result = await _context.SaveChangesAsync();
				if (result <= 0)
				{
					throw new Exception("No changes were saved to the database.");
				}
			}
			catch (SwitchExpressionException ex)
			{
				// Hatanın kaynağını daha iyi anlamak için
				throw new Exception($"Switch expression failed: {ex.Message}", ex);
			}
		}
		#endregion
	}
}
