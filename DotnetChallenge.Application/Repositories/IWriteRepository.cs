using DotnetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<bool> AddAsync(T model);
		bool Update(T model);
		Task<bool> RemoveAsync(T model);
		Task SaveAsync();
	}
}
