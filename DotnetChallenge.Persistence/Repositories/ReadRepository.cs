using DotnetChallenge.Application.Repositories;
using DotnetChallenge.Domain.Entities.Common;
using DotnetChallenge.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{
		#region Fields
		private readonly DotnetChallengeDbContext _context;
		#endregion
		
		#region Ctor
		public ReadRepository(DotnetChallengeDbContext context)
		{
			_context = context;
		}
		public DbSet<T> Table => _context.Set<T>();
		#endregion

		#region Methods		
		public IQueryable<T> GetAll() => Table;
		public async Task<T> GetByIdAsync(int id)
		{
			return await Table.FindAsync(id);
		}
		#endregion
	}
}
